using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.BasicFramework;
using HslCommunication.Profinet.Siemens;

namespace MES.UserControls
{
    public partial class SiemensPLC : UserControl
    {
        private SiemensS7Net m_siemensTcpNet;

        public SiemensPLC()
        {
            InitializeComponent();

            //实例化一个西门子对象
            m_siemensTcpNet = new SiemensS7Net(SiemensPLCS.S1500);
        }
        private void SiemensPlc_Load(object sender, EventArgs e)
        {
            EventHandleInitialize();
        }

        //事件初始化
        private void EventHandleInitialize()
        {
            btnStart.Click += btnStart_Click;

            button_read_bool.Click += button_read_bool_Click;
            button_read_byte.Click += button_read_byte_Click;
            button_read_double.Click += button_read_double_Click;
            button_read_float.Click += button_read_float_Click;
            button_read_int.Click += button_read_int_Click;
            button_read_string.Click += button_read_string_Click;
            button_read_short.Click += button_read_short_Click;

            button_write_bool.Click += button_write_bool_Click;
            button_write_byte.Click += button_write_byte_Click;
            button_write_double.Click += button_write_double_Click;
            button_write_float.Click += button_write_folat_Click;
            button_write_int.Click += button_write_int_Click;
            button_write_string.Click += button_write_string_Click;
            button_write_short.Click += button_write_short_Click;
        }

        #region PLC模块

        //连接PLC
        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress address;
            if (!IPAddress.TryParse(txtIP.Text, out address))
            {
                MessageBox.Show("IP地址输入错误！");
                return;
            }

            m_siemensTcpNet.IpAddress = txtIP.Text;

            try
            {
                //长连接
                OperateResult connect = m_siemensTcpNet.ConnectServer();
                if (connect.IsSuccess)
                {
                    MessageBox.Show("连接成功！");
                    btnConnect.Enabled = false;
                    btnDisConnect.Enabled = true;
                    panel3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("连接失败！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            m_siemensTcpNet.ConnectClose();
            btnConnect.Enabled = true;
            btnDisConnect.Enabled = false;
            panel3.Enabled = false;
        }

        #region Read
        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void ReadResultRender<T>(OperateResult<T> result, string address, TextBox textBox)
        {
            if (result.IsSuccess)
            {
                textBox.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] {result.Content}{Environment.NewLine}");
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
            }

        }

        private void button_read_bool_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadBool(txtAddress.Text), txtAddress.Text, txtResult);
        }

        private void button_read_string_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadString(txtAddress.Text, ushort.Parse(txtStrLength.Text)),
                txtAddress.Text, txtResult);
        }

        private void button_read_byte_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadByte(txtAddress.Text), txtAddress.Text, txtResult);
        }

        private void button_read_short_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadInt16(txtAddress.Text), txtAddress.Text, txtResult);
        }

        private void button_read_int_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadInt32(txtAddress.Text), txtAddress.Text, txtResult);
        }

        private void button_read_float_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadFloat(txtAddress.Text), txtAddress.Text, txtResult);
        }

        private void button_read_double_Click(object sender, EventArgs e)
        {
            ReadResultRender(m_siemensTcpNet.ReadDouble(txtAddress.Text), txtAddress.Text, txtResult);
        }

        #endregion

        #region Write
        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void WriteResultRender(OperateResult result, string address)
        {
            if (result.IsSuccess)
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入成功");
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
            }
        }

        private void button_write_bool_Click(object sender, EventArgs e)
        {
            //bool写入
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, bool.Parse(txtWValue.Text)), txtWAddress.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button_write_string_Click(object sender, EventArgs e)
        {
            //String写入
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, txtWValue.Text), txtWAddress.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_write_byte_Click(object sender, EventArgs e)
        {
            //byte 写入
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, byte.Parse(txtWValue.Text)), txtWAddress.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_write_short_Click(object sender, EventArgs e)
        {
            //Short 写入
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, short.Parse(txtWValue.Text)), txtWAddress.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_write_int_Click(object sender, EventArgs e)
        {
            //int 写入
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, int.Parse(txtWValue.Text)), txtWAddress.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_write_folat_Click(object sender, EventArgs e)
        {
            //float 
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, float.Parse(txtWValue.Text)), txtWAddress.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_write_double_Click(object sender, EventArgs e)
        {
            //double
            try
            {
                WriteResultRender(m_siemensTcpNet.Write(txtWAddress.Text, double.Parse(txtWValue.Text)), txtWAddress.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 定时读取PLC

        private Thread m_thread = null; //后台读取线程

        private int m_timeSleep = 300;  //读取间隔

        private bool m_isThreadRun = false; //线程是否运行

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!m_isThreadRun)
            {
                if (!int.TryParse(txtInterval.Text, out m_timeSleep))
                {
                    MessageBox.Show("时间格式输入错误！");
                    return;
                }
                btnStart.Text = "停止";
                m_isThreadRun = true;
                m_thread = new Thread(ThreadRead);
                m_thread.IsBackground = true;
                m_thread.Start();
            }
        }

        private void ThreadRead()
        {
            while (m_isThreadRun)
            {
                Thread.Sleep(m_timeSleep);

                try
                {
                    OperateResult<short> read = m_siemensTcpNet.ReadInt16(txtTimingAddress.Text);
                    if (read.IsSuccess)
                    {
                        //显示曲线
                        if (m_isThreadRun)
                        {
                            Invoke(new Action<short>(AddDataCurve), read.Content);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取失败：" + ex.Message);
                }
            }
        }

        private void AddDataCurve(short obj)
        {
            userCurve1.AddCurveData("A", obj);
        }

        #endregion


        #endregion

        #region 批量读取

        private void btnManyRead_Click(object sender, EventArgs e)
        {
            try
            {
                OperateResult<byte[]> read = m_siemensTcpNet.Read(txtManyReadAddr.Text, ushort.Parse(txtManyReadLen.Text));
                if (read.IsSuccess)
                {
                    txtManyReadResult.Text = "结果：" + SoftBasic.ByteToHexString(read.Content);
                }
                else
                {
                    txtManyReadResult.Text = "读取失败：" + read.ToMessageShowString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取失败：" + ex.StackTrace);
            }

        }

        #endregion
    }
}
