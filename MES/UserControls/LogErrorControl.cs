using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MES;
using MES.DAL;
using OpcUaHelper;
using ProductManage.Core;
using ProductManage.Entity;
using ProductManage.Language.MyLanguageTool;

namespace ProductManage.UserControls
{
    public partial class LogErrorControl : UserControl
    {
        private FormMain m_main;

        private DBTool m_dbTool = null;
        
        private DateTime m_startTime, m_endTime;

        private string[] methodsCH = new string[] { "日志结果", "发生时间", "处理时间", "内容关键字" };

        private string[] methodsEN = new string[] { "LogResult", "HappenTime", "DealTime", "KeyWords" };

        private string[] m_resultCH = new string[] { "已处理", "未处理" };

        private string[] m_resultEN = new string[] { "Handled", "Untreated" };

        private Logs m_currentLog;

        private string m_sqlByCondition = string.Empty;

        private string m_condition;

        private string m_value;

        private DataTable m_currentTable = new DataTable();

        private int m_culture = 1;//默认中文

        private bool b_saveAlarmLog = false;

        private OpcUaClient m_opcUaClient = null;

        private int AlarmNo = 0;

        private int AlarmNoLast = 0;

        private string AlarmContent = string.Empty;

        private bool b_isWindowShow = true;

        private string m_dbColunmNames = string.Empty;

        public LogErrorControl()
        {
            InitializeComponent();
        }

        public LogErrorControl(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            m_culture = m_main.Culture;
            CultureChange();
            m_dbTool = m_main.DbTool;
            if (m_main.UseLanguage == 1) m_main.CultureChangeEvent += M_main_CultureChangeEvent;
            m_main.WindowStateEvent += M_main_WindowStateEvent;
            m_opcUaClient = m_main.OpcUaClient;
        }

        private void LogErrorControl_Load(object sender, EventArgs e)
        {
            InitStyle();

            InitData();

            InitThreads();
        }

        private void InitData()
        {
            m_dbColunmNames = "Id,LogNo,LogContent,LogResult,HappenTime,DealTime";

            timeCheckStart.Value = timeCheckEnd.Value = DateTime.Now;

            timeRecord.Value = timeDealTime.Value = DateTime.Now;
        }

        private void M_main_WindowStateEvent(object obj, MES.Core.MyEvent e)
        {
            b_isWindowShow = e.IsWindowShow;
        }

        private void InitThreads()
        {
            //报警内容存入数据库
            Thread t_saveAlarmLog = new Thread(SaveAlarmLog);
            t_saveAlarmLog.IsBackground = true;
            t_saveAlarmLog.Start();

            //报警日志实时监控
            Thread t_alarmThread = new Thread(AlarmMonitor);
            t_alarmThread.IsBackground = true;
            t_alarmThread.Start();

        }

        private void AlarmMonitor()
        {
            while (b_isWindowShow)
            {
                try
                {
                    if (m_opcUaClient != null && m_opcUaClient.Connected)
                    {
                        AlarmNo = m_opcUaClient.ReadNode<int>("ns=3;s=\"WeldPara\".\"Alarmlog\"");
                        if (AlarmNo != 0)
                        {
                            if (AlarmNo != AlarmNoLast)
                            {
                                if (m_main.IsStation_S) AlarmContent = Alarm.SortAlarmS(AlarmNo);
                                else AlarmContent = Alarm.SortAlarmL(AlarmNo);

                                AlarmNoLast = AlarmNo;

                                b_saveAlarmLog = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_main.AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                    m_main.LogNetProgramer.WriteError("异常", "读取报警内容异常--->" + ex.Message);
                }

                Thread.Sleep(3000);
            }
        }

        private void SaveAlarmLog()
        {
            while (b_isWindowShow)
            {
                if (b_saveAlarmLog)
                {
                    DateTime now = DateTime.Now;
                    string sql = "insert into Logs(LogNo,LogContent,LogResult,HappenTime) values(@no,@content,@res,@htime)";

                    try
                    {
                        SqlParameter[] sqlParameters =
                        {
                            new SqlParameter {ParameterName = "@no", SqlDbType = SqlDbType.Int, SqlValue = AlarmNo},
                            new SqlParameter {ParameterName = "@content", SqlDbType = SqlDbType.NVarChar, SqlValue = AlarmContent},
                            new SqlParameter {ParameterName = "@res", SqlDbType = SqlDbType.NVarChar, SqlValue = m_culture==1? "未处理":"Untreated"},
                            new SqlParameter {ParameterName = "@htime", SqlDbType = SqlDbType.DateTime, SqlValue = now}
                        };

                        int c = m_main.DbTool.ModifyTable(sql, sqlParameters);
                        if (c > 0)
                        {
                            //刷新数据
                            Invoke(new Action(() =>
                            {
                                SelectLastLogs();
                            }));
                            b_saveAlarmLog = !b_saveAlarmLog;
                        }
                    }
                    catch (Exception ex)
                    {
                        m_main.LogNetProgramer.WriteError("异常", "保存报警内容异常--->" + ex.Message);
                    }
                }
                Thread.Sleep(500);
            }
        }

        private void M_main_CultureChangeEvent(object obj, MES.Core.MyEvent e)
        {
            m_culture = e.Culture;
            CultureChange();
        }

        private void CultureChange()
        {
            if (m_culture == 1)
            {
                ResourceCulture.SetCurrentCulture("zh-CN");
                SetResourceCulture();
            }
            else
            {
                ResourceCulture.SetCurrentCulture("en-US");
                SetResourceCulture();
            }
        }

        private void SetResourceCulture()
        {
            dgvLogError.Columns["colContent"].HeaderText = ResourceCulture.GetValue("LogContent");
            dgvLogError.Columns["colResult"].HeaderText = ResourceCulture.GetValue("LogResult");
            dgvLogError.Columns["colHappenTime"].HeaderText = ResourceCulture.GetValue("HappenTime");
            dgvLogError.Columns["colDealTime"].HeaderText = ResourceCulture.GetValue("DealTime");

            grbSelectLog.Text = ResourceCulture.GetValue("SelectLog");
            grbEditLog.Text = ResourceCulture.GetValue("EditLog");
            labSelectMethod.Text = ResourceCulture.GetValue("SelectMethod");
            labSelectValue.Text = ResourceCulture.GetValue("QueryValue");
            labDealTime.Text = ResourceCulture.GetValue("DealTime");
            labHappenTime.Text = ResourceCulture.GetValue("HappenTime");
            labLogContent.Text = ResourceCulture.GetValue("LogContent");
            labLogResult.Text = ResourceCulture.GetValue("LogResult");
            btnSelect.UIText = ResourceCulture.GetValue("Query");
            btnSelectLastTen.UIText = ResourceCulture.GetValue("SelectLatestLog");
            btnUpdate.UIText = ResourceCulture.GetValue("Modify");
            btnDelete.UIText = ResourceCulture.GetValue("Delete");
            btnRecord.UIText = ResourceCulture.GetValue("Record");

            cmbSelectCondition.Items.Clear();
            cmbSelectCondition.Items.AddRange(new string[]{ResourceCulture.GetValue("LogResult"), ResourceCulture.GetValue("HappenTime"),
                ResourceCulture.GetValue("DealTime"), ResourceCulture.GetValue("KeyWords") });
            cmbSelectCondition.SelectedIndex = 0;

            cmbLogResult.Items.Clear();
            cmbSelectResult.Items.Clear();
            cmbLogResult.Items.AddRange(new string[] { ResourceCulture.GetValue("Handled"), ResourceCulture.GetValue("Untreated") });
            cmbSelectResult.Items.AddRange(new string[] { ResourceCulture.GetValue("Handled"), ResourceCulture.GetValue("Untreated") });
            cmbLogResult.SelectedIndex = cmbSelectResult.SelectedIndex = 0;

        }

        private void InitStyle()
        {
            //设定按字体来缩放控件  
            this.AutoScaleMode = AutoScaleMode.Font;
            //设定字体大小为12px       
            this.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(134)));
            dgvLogError.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, 134);
            dgvLogError.RowsDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, 134);

            //锁定列头
            foreach (DataGridViewColumn column in dgvLogError.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void cmbSelectCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trem = cmbSelectCondition.SelectedItem.ToString();

            switch (trem)
            {
                case "内容关键字":
                case "KeyWords":
                    txtSelectValue.Visible = true;
                    cmbSelectResult.Visible = false;
                    timeCheckEnd.Visible = false;
                    labFuhao.Visible = false;
                    timeCheckStart.Visible = false;
                    break;
                case "日志结果":
                case "LogResult":
                    txtSelectValue.Visible = false;
                    cmbSelectResult.Visible = true;
                    timeCheckEnd.Visible = false;
                    labFuhao.Visible = false;
                    timeCheckStart.Visible = false;
                    break;
                case "发生时间":
                case "HappenTime":
                case "处理时间":
                case "DealTime":
                    txtSelectValue.Visible = false;
                    cmbSelectResult.Visible = false;
                    timeCheckEnd.Visible = true;
                    labFuhao.Visible = true;
                    timeCheckStart.Visible = true;
                    break;
                default:
                    txtSelectValue.Visible = true;
                    cmbSelectResult.Visible = false;
                    timeCheckEnd.Visible = false;
                    labFuhao.Visible = false;
                    timeCheckStart.Visible = false;
                    break;
            }

        }

        private bool b_clickSelect = false;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbLogResult.SelectedItem == null)
            {
                MessageBox.Show("不支持剪切功能!");
                return;
            }
            b_clickSelect = true;
            b_clickSelectNum = false;

            if (!ConditionJudge()) return;

            SelectLog();
        }

        private void SelectLog()
        {
            StartSelect();
        }

        private bool ConditionJudge()
        {
            if (m_dbTool == null) return false;

            if (cmbSelectCondition.SelectedIndex < 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("PleaseChoseMethod"));
                return false;
            }

            m_condition = cmbSelectCondition.SelectedItem.ToString();
            m_value = string.Empty;

            if (m_condition == ResourceCulture.GetValue("HappenTime") || m_condition == ResourceCulture.GetValue("DealTime"))
            {
                m_startTime = timeCheckStart.Value;
                m_endTime = timeCheckEnd.Value;

                if (m_startTime > m_endTime)
                {
                    MessageBox.Show(ResourceCulture.GetValue("StartTimeMoreThanEndTime"));
                    return false;
                }
            }
            else
            {
                if (m_condition == "日志结果" || m_condition == "LogResult")
                {
                    if (m_culture == 1)
                    {
                        m_value = cmbSelectResult.SelectedItem.ToString();
                    }
                    else
                    {
                        m_value = cmbSelectResult.SelectedItem.ToString();
                    }

                }
                else if (m_condition == "内容关键字" || m_condition == "KeyWords")
                {
                    m_value = txtSelectValue.Text;
                }

                if (String.IsNullOrEmpty(m_value))
                {
                    MessageBox.Show(ResourceCulture.GetValue("PleaseInputValue"));
                    return false;
                }
            }

            return true;
        }

        private void StartSelect()
        {
            switch (m_condition)
            {
                case "内容关键字":
                case "KeyWords":
                    m_sqlByCondition = "select top 300  " + m_dbColunmNames + " from Logs where LogContent LIKE '%" + m_value + "%'";

                    break;
                case "日志结果":
                case "LogResult":
                    m_sqlByCondition = "select top 300 " + m_dbColunmNames + " from Logs where LogResult = '" + m_value + "'";

                    break;
                case "发生时间":
                case "HappenTime":
                    m_sqlByCondition = "select top 300  " + m_dbColunmNames + " from Logs where HappenTime between '" + m_startTime + "' and '" + m_endTime + "' ";

                    break;
                case "处理时间":
                case "DealTime":
                    m_sqlByCondition = "select top 300  " + m_dbColunmNames + " from Logs where DealTime between '" + m_startTime + "' and '" + m_endTime + "' ";

                    break;
            }

            m_sqlByCondition += "order by HappenTime desc;";

            m_currentTable = m_main.DbTool.SelectTable(m_sqlByCondition);

            if (m_currentTable != null && m_currentTable.Rows.Count < 1)
            {
                dgvLogError.DataSource = m_currentTable;
                MessageBox.Show(ResourceCulture.GetValue("NotData"));
            }
            else if (m_currentTable != null)
            {
                dgvLogError.DataSource = m_currentTable;
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("SelectFail"));
            }
        }

        //清空所有日志
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            string sql = "Delete from Logs";

            //int r = m_dbTool.ModifyTable(sql, null);
            //if (r > 0)
            //{
            //    MessageBox.Show("删除成功！");
            //}
            //else
            //{
            //    MessageBox.Show("删除失败！");
            //}
        }

        private bool b_clickSelectNum = false;

        private void btnSelectLsetTen_Click(object sender, EventArgs e)
        {
            b_clickSelectNum = true;
            b_clickSelect = false;
            SelectLastLogByNum(20);
        }

        /// <summary>
        /// 查询最近的日志
        /// </summary>
        /// <param name="num">日志条数</param>
        private void SelectLastLogByNum(int num)
        {
            string sql = "  select top " + num + " " + m_dbColunmNames + " from logs order by HappenTime desc";

            m_currentTable = m_main.DbTool.SelectTable(sql);

            if (m_currentTable != null && m_currentTable.Rows.Count < 1)
            {
                MessageBox.Show(ResourceCulture.GetValue("NotData"));
            }
            else if (m_currentTable != null)
            {
                dgvLogError.DataSource = m_currentTable;
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("SelectFail"));
            }
        }

        private void SelectLastLogs()
        {
            string sql = " select top  20  " + m_dbColunmNames + " from logs order by HappenTime desc;";

            m_currentTable = m_main.DbTool.SelectTable(sql);

            if (m_currentTable != null)
            {
                dgvLogError.DataSource = m_currentTable;
            }
        }

        private void dgvLogError_DataSourceChanged(object sender, EventArgs e)
        {
            if (m_currentTable == null)
            {
                return;
            }

            try
            {
                SetDGVStyle();

                for (int i = 0; i < dgvLogError.RowCount - 1; i++)
                {
                    DataGridViewRow dgvRow = dgvLogError.Rows[i];

                    string value = dgvRow.Cells["colResult"].Value.ToString();
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (value.Equals("已处理") || value.Equals("Handled"))
                        {
                            dgvRow.Cells["colResult"].Style.BackColor = Color.LawnGreen;
                        }
                        else if (value.Equals("未处理") || value.Equals("Untreated"))
                        {
                            dgvRow.Cells["colResult"].Style.BackColor = Color.OrangeRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_main.LogNetProgramer.WriteError("异常", "追溯系统更新异常-->" + ex.Message);
            }
        }

        private void SetDGVStyle()
        {
            if (dgvLogError.Rows.Count != 0)
            {
                for (int i = 0; i < dgvLogError.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        dgvLogError.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        dgvLogError.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(224, 254, 254);
                    }
                }
            }
        }

        private void cmbSelectCondition_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvLogError_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetFocusCell();
        }

        private void GetFocusCell()
        {
            if (dgvLogError.CurrentRow.Index < dgvLogError.Rows.Count - 1)
            {
                int indexID = dgvLogError.Columns["colID"].Index;
                int indexName = dgvLogError.Columns["colContent"].Index;
                int indexResult = dgvLogError.Columns["colResult"].Index;
                int indexLogTime = dgvLogError.Columns["colHappenTime"].Index;
                int indexDealTime = dgvLogError.Columns["colDealTime"].Index;

                string id = dgvLogError.Rows[dgvLogError.CurrentRow.Index].Cells[indexID].Value.ToString();
                string name = dgvLogError.Rows[dgvLogError.CurrentRow.Index].Cells[indexName].Value.ToString();
                string result = dgvLogError.Rows[dgvLogError.CurrentRow.Index].Cells[indexResult].Value.ToString();
                string time = dgvLogError.Rows[dgvLogError.CurrentRow.Index].Cells[indexLogTime].Value.ToString();
                string dealtime = dgvLogError.Rows[dgvLogError.CurrentRow.Index].Cells[indexDealTime].Value.ToString();

                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(result))
                {
                    MessageBox.Show(ResourceCulture.GetValue("LogContentNotEmpty"), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                m_currentLog = new Logs();
                m_currentLog.ID = Convert.ToInt32(id);
                m_currentLog.LogContent = name;
                m_currentLog.LogResult = result;
                m_currentLog.HappenTime = Convert.ToDateTime(time);
                if (!String.IsNullOrEmpty(dealtime)) m_currentLog.DealTime = Convert.ToDateTime(dealtime);

                txtLogName.Text = name;
                if (result == "已处理" || result == "Handled") cmbLogResult.SelectedIndex = 0;
                else if (result == "未处理" || result == "Untreated") cmbLogResult.SelectedIndex = 1;
                else cmbLogResult.SelectedIndex = 0;
                timeRecord.Value = m_currentLog.HappenTime;
                if (!String.IsNullOrEmpty(dealtime)) timeDealTime.Value = m_currentLog.DealTime;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbLogResult.SelectedItem == null)
            {
                MessageBox.Show("不支持剪切功能!");
                return;
            }

            if (!m_main.CheckUserAuth()) return;
            if (m_currentTable == null || m_currentTable.Rows.Count < 1) return;

            UpdateLog();
        }

        private void UpdateLog()
        {
            string name = txtLogName.Text;
            string result = cmbLogResult.SelectedItem.ToString();
            DateTime time = timeRecord.Value;
            DateTime dealtime = timeDealTime.Value;
            string id = dgvLogError.Rows[dgvLogError.CurrentRow.Index].Cells[0].Value.ToString();

            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show(ResourceCulture.GetValue("LogContentNotEmpty"));
                return;
            }
            if (String.IsNullOrEmpty(result))
            {
                MessageBox.Show("请选择日志处理结果!");
                return;
            }
            if (m_currentLog == null)
            {
                MessageBox.Show(ResourceCulture.GetValue("NotData"));
                return;
            }

            string update = "update Logs set LogContent=@name,LogResult=@result,HappenTime=@time,DealTime=@dealtime where ID=@id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.NVarChar){Value = name},
                new SqlParameter("@result",SqlDbType.NVarChar){Value = result},
                new SqlParameter("@time",SqlDbType.DateTime){Value = time},
                new SqlParameter("@dealtime",SqlDbType.DateTime){Value = dealtime},
                new SqlParameter("@id",SqlDbType.Int){Value = id},
            };

            int rs = m_dbTool.ModifyTable(update, parameters);

            if (rs > 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveSuccess"));
                if (b_clickSelect) SelectLog();
                else SelectLastLogs();
                GetFocusCell();
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveFail"));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbLogResult.SelectedItem == null)
            {
                MessageBox.Show("不支持剪切功能!");
                return;
            }
            if (!m_main.CheckUserAuth()) return;
            if (m_currentTable == null || m_currentTable.Rows.Count < 1) return;

            DeleteLog();
        }

        private void DeleteLog()
        {
            DialogResult result = MessageBox.Show(ResourceCulture.GetValue("IfSureDelete"), "提示", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (m_currentLog == null)
                {
                    MessageBox.Show(ResourceCulture.GetValue("NotData"));
                    return;
                }

                string delete = "delete from Logs where ID=" + m_currentLog.ID;

                int rs = m_dbTool.ModifyTable(delete);

                if (rs > 0)
                {
                    MessageBox.Show(ResourceCulture.GetValue("DeleteOK"));
                    if (b_clickSelect) SelectLog();
                    else SelectLastLogs();
                    GetFocusCell();
                }
                else
                {
                    MessageBox.Show(ResourceCulture.GetValue("DeleteFail"));
                }
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            RecordLog();

        }

        private void RecordLog()
        {
            string log = txtLogName.Text;
            string result = cmbLogResult.SelectedItem.ToString();
            DateTime logtime = timeRecord.Value;
            DateTime dealTime = timeDealTime.Value;

            if (string.IsNullOrEmpty(log))
            {
                MessageBox.Show(ResourceCulture.GetValue("LogContentNotEmpty"));
                return;
            }
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("请选择日志处理结果！");
                return;
            }

            string sql = "insert into Logs(LogContent,LogResult,HappenTime,DealTime) values(@name,@result,@time,@dealTime);";

            SqlParameter[] ps = new SqlParameter[]
            {
                 new SqlParameter(){ParameterName="@name",SqlDbType = SqlDbType.NVarChar,SqlValue = log },
                 new SqlParameter(){ParameterName="@result",SqlDbType = SqlDbType.NVarChar,SqlValue = result },
                 new SqlParameter(){ParameterName="time",SqlDbType = SqlDbType.DateTime,SqlValue = logtime  },
                 new SqlParameter(){ParameterName="dealTime",SqlDbType = SqlDbType.DateTime,SqlValue = dealTime  }
             };

            int rs = m_dbTool.ModifyTable(sql, ps);

            if (rs > 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveSuccess"));
                SelectLastLogs();
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveFail"));
            }
        }

    }
}
