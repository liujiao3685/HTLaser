using QRCode.DAL;
using QRCode.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QRCode
{
    public partial class CsvDemoForm : Form
    {
        private Db db = Db.GetInstance();

        private string id;

        private string name;

        public string password;

        private User CurFouseUser = new User();

        private DataTable m_dataTabel = null;

        private DataSet m_dataSet = null;

        public CsvDemoForm()
        {
            InitializeComponent();
        }

        #region 保存CSV文件

        private void btnOutCSV_Click(object sender, EventArgs e)
        {
            if (m_dataTabel == null || m_dataTabel.Columns.Count == 0)
            {
                return;
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "保存导出文件";
            saveFile.Filter = "导出数据文件(.csv) | *.csv";
            saveFile.FilterIndex = 1;
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                SetCsvFile(saveFile.FileName);
            }
        }

        private void SetCsvFile(string fileName)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fileStream, Encoding.Default);//Encoding.GetEncoding("UTF-8")
                for (int col = 0; col < m_dataTabel.Columns.Count; col++)
                {
                    if (col < 1)
                    {
                        sw.Write(m_dataTabel.Columns[col].ColumnName + ",");//ID
                    }
                    else
                    {
                        switch (m_dataTabel.Columns[col].ColumnName)
                        {
                            case "name":
                                sw.Write(m_dataTabel.Columns[col].ColumnName + "(用户名)" + ",");
                                break;

                            case "password":
                                sw.Write(m_dataTabel.Columns[col].ColumnName + "(密码)" + ",");
                                break;

                            case "pid":
                                sw.Write(m_dataTabel.Columns[col].ColumnName + ",");
                                break;
                        }
                    }
                }
                sw.WriteLine(String.Empty);

                for (int row = 0; row < m_dataTabel.Rows.Count; row++)
                {
                    //sw.Write((row + 1).ToString() + ",");
                    for (int col = 0; col < m_dataTabel.Columns.Count; col++)
                    {
                        string str = String.Format("\t{0}", m_dataTabel.Rows[row][col].ToString());
                        sw.Write(String.Format("\t{0}", m_dataTabel.Rows[row][col].ToString()) + ",");
                    }
                    sw.Write("\n");
                }
                sw.Close();
                fileStream.Close();
                MessageBox.Show("导出成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败，失败原因：" + ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        #endregion 导入CSV文件

        private void btnInPutCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "打开文件";
            dialog.Filter = "CSV文件|*.csv|所有文件|*.*";
            dialog.ReadOnlyChecked = true;
            dialog.InitialDirectory = Application.StartupPath;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                string fileName = dialog.FileName;
                DataTable dt = LoadCSV(fileName);

                ListViewItem item = null;
                foreach (DataRow dataRow in dt.Rows)
                {
                    item = new ListViewItem(dataRow[0].ToString());

                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        string str = dataRow[i].ToString();
                        item.SubItems.Add(dataRow[i].ToString());
                    }
                    myCache.Add(item);
                    //正常加载
                    //this.listViewUsers.Items.Add(item);
                }
                listViewUsers.VirtualListSize = myCache.Count;
                listViewUsers.Invalidate();
            }
        }

        public DataTable LoadCSV(string filePath)
        {
            DataTable dt = new DataTable();

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string line = string.Empty;//记录每行的数据
            string[] aryLine;
            string[] tableHeader;
            int columnCount = 0;
            bool isFirst = true;

            while ((line = sr.ReadLine()) != null)
            {
                if (isFirst)
                {
                    isFirst = false;
                    tableHeader = line.Split(',');
                    columnCount = tableHeader.Length;

                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn column = new DataColumn(tableHeader[i]);
                        dt.Columns.Add(column);
                    }
                }
                else
                {
                    aryLine = line.Split(',');
                    //创建行
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < columnCount; i++)
                    {
                        dr[i] = aryLine[i];
                    }
                    dt.Rows.Add(dr);
                }
            }

            sr.Close();
            fs.Close();

            return dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            string sql = "select * from users";
            //string sql = "select * from product";

            DataSet ds = db.Select(sql);
            m_dataTabel = ds.Tables[0];

            this.listViewUsers.Items.Clear();
            this.myCache.Clear();
            int rowNo = 0;
            ListViewItem item;

            #region 耗时操作

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            this.BeginInvoke((MethodInvoker)DoUpdate);

            this.labSum.Text = m_dataTabel.Rows.Count.ToString();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed; //  获取总时间
            double seconds = timeSpan.TotalMilliseconds;  //  秒数
            labUseTime.Text = seconds.ToString() + "s";

            #endregion 耗时操作
        }

        private List<ListViewItem> myCache = new List<ListViewItem>();

        private delegate void UpdateHandle();

        private void DoUpdate()
        {
            ListViewItem item = null;
            if (this.listViewUsers.InvokeRequired)
            {
                UpdateHandle handle = new UpdateHandle(DoUpdate);
                this.Invoke(handle);
            }
            else
            {
                foreach (DataRow dataRow in m_dataTabel.Rows)
                {
                    item = new ListViewItem(dataRow[0].ToString());

                    for (int i = 1; i < m_dataTabel.Columns.Count; i++)
                    {
                        string str = dataRow[i].ToString();
                        item.SubItems.Add(dataRow[i].ToString());
                    }
                    //虚拟加载
                    myCache.Add(item);
                    //正常加载
                    //this.listViewUsers.Items.Add(item);
                }
                listViewUsers.VirtualListSize = myCache.Count;
                listViewUsers.Invalidate();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            CurFouseUser.Id = Convert.ToInt32(txtID.Text.Trim());
            CurFouseUser.Name = txtName.Text.Trim();
            CurFouseUser.Password = txtPasssword.Text.Trim();

            int i = db.Update(CurFouseUser);

            if (i > 0)
            {
                Update();
                MessageBox.Show("修改成功！");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            CurFouseUser.Name = txtName.Text.Trim();
            CurFouseUser.Password = txtPasssword.Text.Trim();

            int i = db.Insert(CurFouseUser);

            if (i > 0)
            {
                Update();
                MessageBox.Show("增加成功！");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from users where id=" + txtID.Text;
            int i = db.Delete(sql);

            if (i > 0)
            {
                Update();
                MessageBox.Show("删除成功！");
            }
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = txtID.Text = this.listViewUsers.FocusedItem.SubItems[0].Text;
            name = txtName.Text = this.listViewUsers.FocusedItem.SubItems[1].Text;
            password = txtPasssword.Text = this.listViewUsers.FocusedItem.SubItems[2].Text;

            CurFouseUser.Id = Convert.ToInt32(id);
            CurFouseUser.Name = name;
            CurFouseUser.Password = password;
        }

        private void CsvDemoForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        //listview虚拟模式加载大数据，或分页操作
        private void listViewUsers_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (myCache != null)
            {
                e.Item = myCache[e.ItemIndex];
            }

            #region 总结

            /*
            (1)必须设置VirtualMode为true并设置VirtualListSize大小

　　        (2)绑定该事件RetrieveVirtualItem

　　        (3)如果中间更新了数据需要重新设置VirtualListSize，并调用Invalidate()方法

　　        (4)禁用selectedItem，在该模式下使用selectedItem将产生异常，可以用下面方法代替
             private List<ListViewItem> FindSelectedAll()
            {
                List<ListViewItem> r = new List<ListViewItem>();
                foreach (int item in listView1.SelectedIndices)
                {
                     r.Add(bufferItems[item]);
                 }
                 return r;
             }
             */

            #endregion 总结
        }



        /// <summary>
        /// 导出数据到Excel中
        /// </summary>
        /// <param name="dt">DataTable数据源</param>
        /// <returns></returns>
        public void ExportToExcel(System.Data.DataTable dt)
        {
            if (dt == null) return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的电脑未安装Excel", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            System.Windows.Forms.SaveFileDialog saveDia = new SaveFileDialog();
            saveDia.Filter = "Excel|*.xls";
            saveDia.Title = "导出为Excel文件";
            if (saveDia.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.Empty.Equals(saveDia.FileName))
            {
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                Microsoft.Office.Interop.Excel.Range range = null;
                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                string fileName = saveDia.FileName;

                //写入标题 
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                    //range.Interior.ColorIndex = 15;//背景颜色 
                    range.Font.Bold = true;//粗体 
                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中 
                    //加边框 
                    range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous);

                    //range.ColumnWidth = 4.63;//设置列宽 
                    //range.EntireColumn.AutoFit();//自动调整列宽 
                    //r1.EntireRow.AutoFit();//自动调整行高 
                }

                //写入内容 
                for (int r = 0; r < dt.DefaultView.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dt.DefaultView[r][i];
                        range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[r + 2, i + 1];
                        range.Font.Size = 9;//字体大小 
                        //加边框 
                        range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous);
                        range.EntireColumn.AutoFit();//自动调整列宽 
                    }
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                    System.Windows.Forms.Application.DoEvents();
                }

                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                if (dt.Columns.Count > 1)
                {
                    range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                }

                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                workbooks.Close();
                if (xlApp != null)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    int generation = System.GC.GetGeneration(xlApp);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                    xlApp = null;
                    System.GC.Collect(generation);
                }
                GC.Collect();//强行销毁 

                #region 强行杀死最近打开的Excel进程
                Process[] excelProc = Process.GetProcessesByName("EXCEL");
                System.DateTime startTime = new DateTime();
                int m, killId = 0;
                for (m = 0; m < excelProc.Length; m++)
                {
                    if (startTime < excelProc[m].StartTime)
                    {
                        startTime = excelProc[m].StartTime;
                        killId = m;
                    }
                }
                if (excelProc[killId].HasExited == false)
                {
                    excelProc[killId].Kill();
                }
                #endregion
                MessageBox.Show("导出成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}