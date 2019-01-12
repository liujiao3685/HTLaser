using CoderMachine.Core;
using CoderMachine.Core.Structs;
using CoderMachine.DAL;
using CoderMachine.Serial;
using CoderMachine.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CoderMachine
{
    public partial class FormMain : Form
    {
        private DbHelper m_dbHelper;

        private int Inum = 1;//行号，规定其索引初始值为1

        private int PageCount;//总页数

        private int AllCount;//总条数

        private int PageSize = 10;//每页的数量

        private int Remain;//总条数%总页数是否为0

        private DataTable m_productTable;

        private string sqlPage;

        private string m_selectCondition;

        public DataTable ExcelProductTable;

        public FormSpotCheck spotCheckForm;

        private object[] conditions = { "ID", "雷管编号", "员工编号", "生产日期" };

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(FormSpotCheck form)
        {
            InitializeComponent();
            spotCheckForm = form;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            cmbPageSize.SelectedIndex = 0;

            //追溯条件设置
            cmbSelectCondition.Items.AddRange(conditions);
            cmbSelectCondition.SelectedIndex = 0;

            //锁定列头
            foreach (DataGridViewColumn column in dgvProduct.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            m_dbHelper = new DbHelper();

            timeCheckEnd.Value = timeCheckStart.Value = DateTime.Now;

        }

        #region 串口通讯

        private SerialPort m_serivalPort = null;// 串口初始化

        private string m_servialName = "COM1";//串口名称

        private int m_rate = 9600;//串口波特率

        private int m_bits = 8;//串口数据位长度

        private const int StartLength = 2;

        private const int DataLength = 1 + 14 + 4 + 1;

        private const int EndLength = 2;//校验位、结束位

        private int TotalLength = 0;

        private bool if_receive;

        private byte[] buffer;

        private byte[] data;

        private byte[] CallBack = new byte[] { 0x01 };

        public List<Product> Products = new List<Product>();

        public DataTable m_dataTable = new DataTable();

        //测试
        private byte[] test = new byte[24]
        {
                0xAA,
                0x44,
                0x01,
                0x19,
                0x02,
                0xF0,
                0x80,
                0x32,
                0x01,
                0x00,
                0x00,
                0x04,
                0x00,
                0x08,
                0x00,
                0x00,
                0xF0,
                0x00,
                0x00,
                0x01,
                0x00,
                0x01,
                0x01,
                0xEA
        };

        /// <summary>
        /// 初始化串口
        /// </summary>
        private void OpenSerial()
        {
            m_serivalPort = new SerialPort();
            m_serivalPort.PortName = m_servialName;
            m_serivalPort.BaudRate = m_rate;
            m_serivalPort.DataBits = m_bits;
            m_serivalPort.StopBits = StopBits.One; //StopBits.None StopBits.Two;
            m_serivalPort.Parity = Parity.None;//Parity.None Parity.Even);

            if_receive = true;
            try
            {
                m_serivalPort.DataReceived += ReadData_DataReceived;
                m_serivalPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TotalLength = StartLength + DataLength * 10 + EndLength;
        }

        private ComQueue<byte> ComDatas = new ComQueue<byte>(200);

        private void Analysis_Received(ref ComQueue<byte> rec)
        {
            byte[] lastBytes = rec.Reverse().ToArray();
            List<byte> checkBytes = new List<byte>();
            for (int i = 0; i < lastBytes.Count(); i++)
            {
                if (lastBytes[i] != 0x0a && lastBytes[i] != 0x0d)
                {
                    checkBytes.Add(lastBytes[i]);
                }
            }
            Result result = new Result(true, "ScannReceived OK!", checkBytes.Reverse<byte>().ToArray());
            DoCallBack(result);
        }

        public Action<Result> DataCallBack;

        private void DoCallBack(Result rs)
        {
            DataCallBack?.Invoke(rs);
        }

        //采集数据
        private void ReadData_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] datas = new byte[m_serivalPort.BytesToRead];
            m_serivalPort.Read(datas, 0, datas.Length);
            Array.ForEach(datas, data =>
            {
                ComDatas.Enqueue(data);
                if (data == 0x0a || data == 0x0d)
                {
                    Analysis_Received(ref ComDatas);
                    ComDatas.Clear();
                }
                else
                {
                    ComDatas.Clear();
                }
            });


            // 接收数据
            data = new byte[TotalLength];
            int receiveCount = 0;
            while (true)
            {
                if (!if_receive) break;

                Thread.Sleep(20);

                if (m_serivalPort.BytesToRead < 1)
                {
                    buffer = new byte[receiveCount];
                    Array.Copy(data, 0, buffer, 0, receiveCount);
                    break;
                }

                int count = m_serivalPort.Read(data, receiveCount, m_serivalPort.BytesToRead);
                receiveCount += count;
            }

            if (receiveCount == 0)
            {
                return;
            }
            else//解析数据
            {
                //1
                Analysis(buffer, data);

                //2
                buf.AddRange(data);
                Analysis2(buf);
            }

            ShowData();
        }



        private void ShowData()
        {
            Invoke(new Action(() =>
            {
                string msg = string.Empty;

                //二进制显示
                //msg = HslCommunication.BasicFramework.SoftBasic.ByteToHexString(buffer, ' ');

                msg = Encoding.ASCII.GetString(buffer);

                txtData.Text = msg;

            }));
        }

        private bool startAnasy = false;
        private List<byte> buf = new List<byte>(1024) { 0xAA, 0x44, 0x05, 0x01, 0x02, 0x03, 0x04, 0x05, 0xEA };
        private byte[] bytesReal = new byte[9];
        private void Analysis2(List<byte> buffer)
        {
            while (buffer.Count >= 4)//至少要包含头（2字节）+长度（1字节）+校验（1字节）
            {
                if (buffer[0] == 0xAA && buffer[1] == 0x44)
                {
                    int len = buffer[2];//数据长度

                    //len是数据段长度,4个字节是while行注释的3部分长度  
                    if (buffer.Count < len + 4) break;//数据不够的时候什么都不做

                    // 2.3 校验数据，确认数据正确
                    //异或校验，逐个字节异或得到校验码  
                    byte checksum = 0;
                    for (int i = 0; i < len + 3; i++)//len+3表示校验之前的位置                          
                    {
                        checksum ^= buffer[i];
                    }
                    if (checksum != buffer[len + 3])
                    {
                        buffer.RemoveRange(0, len + 4);//从缓存中删除错误数据  
                        continue;//继续下一次循环
                    }

                    buffer.CopyTo(0, bytesReal, 0, len + 4);//复制一条完整数据到具体的数据缓存  
                    startAnasy = true;
                    buffer.RemoveRange(0, len + 4);

                }
                else
                {
                    buffer.RemoveAt(0);
                }
            }

            //分析数据
            if (startAnasy)
            {
                Product pro;

                for (int i = 0; i < DataLength * 10; i++)
                {
                    pro = new Product();

                    //pro.ID = Convert.ToInt32(bytesReal[0].ToString("X2"));

                    string data = String.Format(" {0} {1} {2} {3}", bytesReal[3].ToString("X2"), bytesReal[4].ToString("X2"),
                        bytesReal[5].ToString("X2"), bytesReal[6].ToString("X2"), bytesReal[7].ToString("X2"));

                    string data2 = ByteToHexString(bytesReal, ' ');

                    Console.WriteLine("Data------------>" + data);
                    Console.WriteLine("Data2------------>" + data2);

                }
            }
        }

        /// <summary>
        /// 解析串口数据
        /// </summary>
        /// <param name="buffer"><缓存区数组/param>
        /// <param name="data">原始数组</param>
        private void Analysis(byte[] buffer, byte[] data)
        {
            int offset = 0;
            if (buffer[0] == 0xAA && buffer[1] == 0x44) //两个字节的开始标志
            {
                offset += 2;

                Product pro;

                //for (int i = offset; i < TotalLength - 4; i += DataLength)//循环十次
                for (int i = offset; i < 20; i += 20)
                {
                    pro = new Product();

                    byte[] temp = new byte[DataLength];

                    Array.Copy(data, offset, temp, 0, 1);
                    int index = Convert.ToInt32(temp[offset]);//序号 1
                    offset++;

                    Array.Copy(data, offset, temp, 0, 14);//ID 14
                    pro.PID = ByteToHexString(temp);

                    offset += 14;
                    Array.Copy(data, offset, temp, 0, 4);
                    pro.CurrentVal = Convert.ToDouble(temp);//电流值 4

                    offset += 4;
                    Array.Copy(data, offset, temp, 0, 1);
                    pro.Pass = Convert.ToInt32(ByteToHexString(temp));//是否合格 1

                    //Products.Add(pro);
                }

                offset += 2;
                if (buffer[offset] == 0xEA)//校验位
                {
                    m_serivalPort.Write(CallBack, 0, CallBack.Length);
                }
            }

            SaveToDb();

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Analysis2(buf);

            //Test();

        }

        private static void Test()
        {
            try
            {
                ProductStruct product = new ProductStruct();
                product.No = 1;
                product.UID = "PNo123456".GetFixLengthChar(14);
                product.Current = 0.567;
                product.Pass = 0;

                var b = StructHelper.StuctToByte(product);
                Console.WriteLine("Struct length:" + b.Length);
                Console.WriteLine("Hex: " + ByteToHexString(b, ' '));

                var s = StructHelper.ByteToStuct<ProductStruct>(b);
                Console.WriteLine("No: " + s.No.ToString());
                Console.WriteLine("UID: " + s.UID.GetString());
                Console.WriteLine("Current: " + s.Current.ToString());
                Console.WriteLine("Pass: " + s.Pass.ToString());

                //Test1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //byte[] buffer = new byte[1024];
            //Array.Copy(test, 0, buffer, 0, test.Length);
            //Analysis(buffer, test);
        }

        private static void Test1()
        {
            InfoStruct Info = new InfoStruct();
            Info.HardwareNum = "1.0.0".GetFixLengthChar(16);
            Info.HardwareVersion = "ABC1234567".GetFixLengthChar(16);
            Info.DeviceName = "Device Name1".GetFixLengthChar(32);
            Info.ModuleID = 0x10000001;
            Info.SlotNum = 1;
            Info.SoftwareDate = "2018/1/22".GetFixLengthChar(16);
            Info.SoftwareVersion = "V1.0.0".GetFixLengthChar(16);

            var b = StructHelper.StuctToByte(Info);
            Console.WriteLine("Struct length:" + b.Length);
            Console.WriteLine("Hex:" + ByteToHexString(b, ' '));
            var s = StructHelper.ByteToStuct<InfoStruct>(b);
            Console.WriteLine("Name:" + s.DeviceName.GetString());
            Console.WriteLine("HardwareVersion:" + s.HardwareVersion.GetString());
        }

        private void SerialSend(float vaildData)
        {
            OpenSerial();

            byte[] sendData = null;

            //二进制发送
            //sendData = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes(vaildData);
            //普通发送
            //sendData = new[] { Convert.ToByte(vaildData) };

            //m_serivalPort?.Write(sendData, 0, sendData.Length);
        }

        /// <summary>
        /// 保存数据到数据库
        /// </summary>
        private void SaveToDb()
        {
            if (Products.Count < 0) return;

            Product p;

            string sql = "insert into Product(Pid,TubeNo,CurrentVal,Pass,ProductTime) VALUES(@id,@tno,@cur,@pass,@date)";

            try
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    p = Products[i];

                    SqlParameter[] parms =
                    {
                        new SqlParameter{ParameterName="@id",SqlDbType = SqlDbType.Int,SqlValue = p.PID },
                        new SqlParameter{ParameterName="@tno",SqlDbType = SqlDbType.NVarChar,SqlValue = p.TubeNo },
                        new SqlParameter{ParameterName="@cur",SqlDbType = SqlDbType.Float,SqlValue = p.CurrentVal },
                        new SqlParameter{ParameterName="@pass",SqlDbType = SqlDbType.Bit,SqlValue = p.Pass },
                        new SqlParameter{ParameterName="@date",SqlDbType = SqlDbType.DateTime,SqlValue = DateTime.Now }
                    };

                    int res = m_dbHelper.ModifyTable(sql, parms);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            OpenSerial();
        }

        private void btnCloseSerial_Click(object sender, EventArgs e)
        {
            m_serivalPort?.Close();
        }

        #endregion

        private void cmbPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePageCount();
        }

        /// <summary>
        /// 更新界面页数信息
        /// </summary>
        private void UpdatePageCount()
        {
            PageSize = Convert.ToInt32(this.cmbPageSize.SelectedItem);
            PageCount = AllCount % PageSize;

            //只能显示一页,判断是否是整除
            if (PageCount == 0)
            {
                PageCount = AllCount / PageSize;
            }
            else
            {
                PageCount = AllCount / PageSize + 1;
            }

            if (Inum > PageCount)
            {
                Inum = PageCount;
            }
            else
            {
                Inum = 1;
            }

            txtCurPage.Text = PageCount.ToString();
            txtPageCount.Text = PageCount.ToString();
        }

        private void cmbSelectCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trem = cmbSelectCondition.SelectedItem.ToString();

            switch (trem)
            {
                case "ID":
                case "雷管编号":
                case "员工编号":
                    txtID.Visible = true;
                    break;
                case "生产日期":
                    break;
                default:
                    break;
            }
        }

        private void btnSelectByTerm_Click(object sender, EventArgs e)
        {
            Query();
        }

        private string sql;

        private string m_ID;

        private string m_empNo;

        private DateTime m_startTime, m_endTime;

        private bool m_idCheck, m_empNoCheck, m_timeCheck;

        private string m_extraCondition;

        /// <summary>
        /// 执行查询
        /// </summary>
        private void Query()
        {

            if (!chkID.Checked && !chkEmpNo.Checked && !chkProductDate.Checked)
            {
                MessageBox.Show("请选择查询方式！");
                return;
            }
            if (chkID.Checked && txtID.Text == "")
            {
                MessageBox.Show("请输入ID！");
                return;
            }
            if (chkEmpNo.Checked && txtEmpNo.Text == "")
            {
                MessageBox.Show("请输入员工编号！");
                return;
            }
            if (chkProductDate.Checked)
            {
                m_startTime = timeCheckStart.Value;
                m_endTime = timeCheckEnd.Value;

                if (m_startTime > m_endTime)
                {
                    MessageBox.Show("起始时间不能大于终止时间！");
                    return;
                }
            }

            m_extraCondition = string.Empty;

            sql = "select * from product";

            string where = " where 1=1";

            if (m_idCheck)
            {
                m_ID = txtID.Text.Trim();

                where += " and PID = '" + m_ID + "'";
                m_selectCondition = "PID = '" + m_ID + "'";
                m_extraCondition += " and PID = '" + m_ID + "'";

            }
            if (m_empNoCheck)
            {
                m_empNo = txtEmpNo.Text.Trim();

                where += " and EmpNo = '" + m_empNo + "'";
                m_selectCondition = "EmpNo = '" + m_empNo + "'";
                m_extraCondition += " and EmpNo = '" + m_empNo + "'";
            }
            if (m_timeCheck)
            {
                m_startTime = timeCheckStart.Value;
                m_endTime = timeCheckEnd.Value;

                where += " and ProductTime between '" + m_startTime + "' and '" + m_endTime + "' ";
                m_selectCondition = "ProductTime between '" + m_startTime + "' and '" + m_endTime + "' ";
                m_extraCondition += " and ProductTime between '" + m_startTime + "' and '" + m_endTime + "' ";
            }

            sql += where;
            m_selectCondition += m_extraCondition;

            UpdateDb(sql);

        }

        private void SelectOne()
        {
            if (cmbSelectCondition.SelectedIndex < 0)
            {
                MessageBox.Show("请选择查询方式！");
                return;
            }

            string condition = cmbSelectCondition.SelectedItem.ToString();
            string value = this.txtID.Text;

            string pattern = @"^[0-9]+$";  //@意思忽略转义，+匹配前面一次或多次，$匹配结尾
            Match match = Regex.Match(value, pattern);

            if (!condition.Equals("生产日期") && String.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show("请输入查询条件！");
                return;
            }
            else if (condition == "ID" && !match.Success)
            {
                MessageBox.Show("请输入正确的值！");
                return;
            }

            sql = string.Empty;

            switch (condition)
            {
                case "ID":
                    sql = "select  * from product where ID = '" + value + "'";
                    m_selectCondition = "ID = '" + value + "'";
                    break;
                case "员工编号":
                    sql = "select  * from product where EmpNo = '" + value + "'";
                    m_selectCondition = "EmpNo = '" + value + "'";
                    break;
                /*
            case "雷管编号":
                sql = "select  * from product where TubeNo = '" + value + "'";
                m_selectCondition = "TubeNo = '" + value + "'";
                break;*/
                case "生产日期":

                    DateTime starTime = timeCheckStart.Value;
                    DateTime endTime = timeCheckEnd.Value;

                    if (starTime > endTime)
                    {
                        MessageBox.Show("起始时间不能大于终止时间！");
                        return;
                    }

                    sql = "select  * from product where ProductTime between '" + starTime + "' and '" + endTime + "' ;";
                    m_selectCondition = "ProductTime between '" + starTime + "' and '" + endTime + "' ;";
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 根据查询条件更新数据
        /// </summary>
        /// <param name="sql"></param>
        private void UpdateDb(string sql)
        {
            ExcelProductTable = m_productTable = m_dbHelper.SelectTable(sql);

            if (m_productTable == null || m_productTable.Rows.Count < 1)
            {
                txtAllCount.Text = "0";
                txtPageCount.Text = "0";
                txtCurPage.Text = "0";
                MessageBox.Show("未查询到数据！");
                return;
            }

            AllCount = m_productTable.Rows.Count;//更新pagecount

            UpdatePageCount();

            //更新总条数
            txtAllCount.Text = AllCount.ToString();

            Invoke(new MethodInvoker(delegate ()
            {
                Inum = 1;
                ShowPage(Inum, PageSize);
                txtCurPage.Text = Inum.ToString();

                //dgvProduct.DataSource = m_productTable;
            }
            ));

        }

        #region 分页模块

        //分页显示数据
        private void ShowPage(int Inum, int pageSize)
        {
            sqlPage = string.Empty;

            if (Remain != 0 && Inum == PageCount)
            {
                sqlPage = "select top " + Remain + " * from Product where Id not in (select top " + Convert.ToInt32(cmbPageSize.SelectedItem) * (Inum - 1)
                          + " Id from Product where " + m_selectCondition + ")" + " and " + m_selectCondition;
            }
            else
            {
                sqlPage = "select top " + pageSize + " * from Product where Id not in (select top " + pageSize * (Inum - 1)
                          + " Id from Product where " + m_selectCondition + ")" + " and " + m_selectCondition;
            }

            m_productTable = m_dbHelper.SelectTable(sqlPage);

            if (m_productTable != null)
            {
                this.dgvProduct.DataSource = m_productTable;
            }
        }

        //首页
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inum = 1;
            ShowPage(Inum, PageSize);

            txtCurPage.Text = Inum.ToString();
        }

        //上一页
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inum--;
            if (Inum > 0)                     //如果当前不是首记录
            {
                ShowPage(Inum, PageSize);    //显示上一页记录
            }
            else
            {
                MessageBox.Show("现已是第一页!");
                Inum = 1;
                return;
            }
            txtCurPage.Text = Inum.ToString();
        }

        //下一页
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inum++;

            if (Inum <= PageCount)              //如果没有超出记录行数
            {
                //ShowPage(Inum, PageSize);

                Remain = AllCount % PageSize;
                if (Inum == PageCount && Remain != 0)
                {
                    ShowPage(Inum, Remain);
                }
                else
                {
                    ShowPage(Inum, PageSize);
                }
            }
            else
            {
                MessageBox.Show("现已是最后一页!");
                Inum = PageCount;
                return;
            }
            txtCurPage.Text = Inum.ToString();
        }

        //末页
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inum = PageCount;
            Remain = AllCount % PageSize;
            if (Remain != 0)
            {
                ShowPage(Inum, Remain);
            }
            else
            {
                ShowPage(Inum, PageSize);
            }

            txtCurPage.Text = Inum.ToString();
        }

        private void dgvProduct_DataSourceChanged(object sender, EventArgs e)
        {
            if (m_productTable == null)
            {
                return;
            }

            try
            {
                for (int i = 0; i < dgvProduct.RowCount - 1; i++)
                {
                    DataGridViewRow dgvRow = dgvProduct.Rows[i];

                    int value = Convert.ToInt32(dgvRow.Cells["colPass"].Value);
                    if (value == 0)
                    {
                        dgvRow.Cells["colPass"].Style.BackColor = Color.OrangeRed;
                    }
                    else if (value == 1)
                    {
                        dgvRow.Cells["colPass"].Style.BackColor = Color.LawnGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            Products = new List<Product>
            {
                new Product{PID="NO001",CurrentVal=0.123,Pass=1,EmpNo="ENO001",ProductTime = DateTime.Now},
                new Product{PID="NO002",CurrentVal=0.123,Pass=0,EmpNo="ENO001",ProductTime = DateTime.Now},
                new Product{PID="NO009",CurrentVal=0.568,Pass=1,EmpNo="ENO001",ProductTime = DateTime.Now},
            };

            //SaveProduct();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Products.Count; i++)
            {
                Product p = Products[i];

                sb.Append(p.ToString());
            }

            string str = sb.ToString();//txtData.Text;
            txtData.Text = str;

            SaveAsText(str);
            //SaveAsExcel(str);
        }

        /// <summary>
        /// 保存CSV文件
        /// </summary>
        /// <param name="str"></param>
        private void SaveAsExcel(string str)
        {
            m_dataTable = (DataTable)dgvProduct.DataSource;

            if (String.IsNullOrEmpty(str)) return;
            // if (m_dataTable.Columns.Count < 0) return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存文件";
            dialog.Filter = ".csv | *.csv";
            dialog.FilterIndex = 1;
            if (DialogResult.OK == dialog.ShowDialog())
            {
                string fileName = dialog.FileName;

                ThreadPool.QueueUserWorkItem(t =>
                {
                    SaveCsv(fileName);
                });
            }

        }

        private void SaveCsv(string fileName)
        {
            string headName = string.Empty;
            string value = string.Empty;
            Product p;

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                for (int i = 1; i <= 5; i++)
                {
                    switch (i)
                    {
                        case 1:
                            headName = "UID,";
                            break;
                        case 2:
                            headName = "是否合格,";
                            break;
                        case 3:
                            headName = "电流值,";
                            break;
                        case 4:
                            headName = "生产日期,";
                            break;
                        case 5:
                            headName = "员工编号,";
                            break;
                    }

                    sw.Write(headName);

                }

                sw.WriteLine(string.Empty);//换行

                for (int row = 0; row < Products.Count; row++)
                {
                    p = Products[row];
                    for (int col = 1; col <= 5; col++)
                    {
                        switch (col)
                        {
                            case 1:
                                value = p.PID;
                                break;
                            case 2:
                                value = p.Pass.ToString();
                                break;
                            case 3:
                                value = p.CurrentVal.ToString();
                                break;
                            case 4:
                                value = p.ProductTime.ToString();
                                break;
                            case 5:
                                value = p.EmpNo;
                                break;
                        }
                        sw.Write(value + ",");
                    }
                    sw.Write("\n");

                }
                MessageBox.Show("保存成功！");

                sw.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 保存文本文件
        /// </summary>
        /// <param name="str"></param>
        private void SaveAsText(string str)
        {

            if (String.IsNullOrEmpty(str)) return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存文件";
            dialog.Filter = ".txt | *.txt";
            dialog.FilterIndex = 1;
            if (DialogResult.OK == dialog.ShowDialog())
            {
                string path = dialog.FileName;

                try
                {
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.Write(str);

                    MessageBox.Show("写入成功！");

                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static string ByteToHexString(byte[] InBytes)
        {
            return ByteToHexString(InBytes, (char)0);
        }

        /// <summary>
        /// 字节数据转化成16进制表示的字符串
        /// </summary>
        public static string ByteToHexString(byte[] InBytes, char segment)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte InByte in InBytes)
            {
                if (segment == 0) sb.Append(string.Format("{0:X2}", InByte));
                else sb.Append(string.Format("{0:X2}{1}", InByte, segment));
            }

            if (segment != 0 && sb.Length > 1 && sb[sb.Length - 1] == segment)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        private Process p;

        //private string exeName = Application.StartupPath + @"/CheckProject.exe";
        private string exeName = "CheckProject.exe";

        private void userButton1_Click(object sender, EventArgs e)
        {
            StartCmd();

            //StartProcess();

        }

        private void StartCmd()
        {
            if (System.IO.File.Exists(exeName))
            {
                System.Diagnostics.Process.Start(exeName);
            }
            else
            {
                MessageBox.Show("文件不存在！");
            }

        }

        private void StartProcess()
        {
            try
            {
                MessageBox.Show("点检成功！");

                if (p == null)
                {
                    p = new Process();
                    p.StartInfo.FileName = exeName;
                    p.Start();
                }
                else
                {
                    if (p.HasExited) //是否正在运行
                    {
                        p.Start();
                    }
                }

                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //using (FormQuitWait form = new FormQuitWait(FuncString2))
            //{
            //    form.ShowDialog();
            //}

            using (FormQuitWait form = new FormQuitWait(FuncString))
            {
                form.ShowDialog();
            }

            //1、
            //using (FormQuitWait form = new FormQuitWait(() =>
            //{
            //    m_serivalPort?.Dispose();
            //    m_serivalPort?.Close();
            //}))
            //{
            //    form.ShowDialog();
            //}
            //}
        }
        public string FuncString2(string Name)
        {
            return Name + " I AM STRING";
        }

        public string FuncString()
        {
            return "正准备退出应用程序，请稍等...";
        }

        private void chkID_CheckedChanged(object sender, EventArgs e)
        {
            txtID.Enabled = m_idCheck = chkID.Checked;
        }

        private void chkEmpNo_CheckedChanged(object sender, EventArgs e)
        {
            txtEmpNo.Enabled = m_empNoCheck = chkEmpNo.Checked;
        }

        private void chkProductDate_CheckedChanged(object sender, EventArgs e)
        {
            m_timeCheck = chkProductDate.Checked;

            labFuhao.Enabled = m_timeCheck;
            timeCheckStart.Enabled = m_timeCheck;
            timeCheckEnd.Enabled = m_timeCheck;

        }
    }
}
