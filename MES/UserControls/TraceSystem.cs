using System;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MES.Core;
using System.IO;
using ProductManage.Language.MyLanguageTool;
using MES.DAL;
using System.Threading.Tasks;
using ProductManage.Log;
using BLL;
using Model;

namespace MES.UserControls
{
    public partial class TraceSystem : UserControl
    {
        private FormMain m_main;

        private int Inum = 1;//行号，索引初始值为1

        private int PageCount;//总页数

        private int AllCount;//总条数

        private int PageSize = 10;//每页的数量

        private int Remain;//总条数%总页数是否为0

        private DataTable CurrentProductTable;

        private string sqlPage;

        private string[] surfaceStringS = new string[] { "OK", "同心度NG", "瑕疵NG" };
        private string[] surfaceStringSEN = new string[] { "OK", "CoaxialityNG", "SurfaceNG" };

        private string[] surfaceStringL = new string[] { "OK", "同心度NG", "焊缝NG" };
        private string[] surfaceStringLEN = new string[] { "OK", "CoaxialityNG", "WeldDepthNG" };

        private string[] lwmStrings = new string[] { "OK", "NG" };

        private string[] coaxialStrings = new string[] { "A:0.8~0.9", "B:0.7~1.0", "C:0.6~0.7", "D:1.0~1.3" };

        public DataTable ExcelProductTable;

        private string m_manualInfo;

        private string m_qcResult;

        private bool m_ifUpdateResult;

        private int m_culture = 1;

        private object[] conditions = { "状态", "过程条码", "焊缝质量", "LWM检测" };

        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// 执最终行查询的sql语句
        /// </summary>
        private string SQLFinalSelect = string.Empty;
        private StringBuilder m_sqlByConditionSB = new StringBuilder();

        private string m_conditionExtra = string.Empty;
        private StringBuilder m_conditionExtraSB = new StringBuilder();

        private StringBuilder SqlWhere;

        private string m_dbColunmsNames = string.Empty;

        private bool m_weldSuccess = false;

        public TraceSystem()
        {
            InitializeComponent();
        }

        public TraceSystem(FormMain main)
        {
            InitializeComponent();

            m_main = main;
            m_culture = m_main.Culture;
            CultureChange();
            if (main.UseLanguage == 1) m_main.CultureChangeEvent += M_main_CultureChangeEvent;
            m_main.WeldSuccessEvent += M_main_WeldSuccessEvent;

        }

        private void TraceSystem_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            initSqlStrings();

            initDGVStyle();

            initDefaultData();
        }

        #region Init
        //界面默认值
        private void initDefaultData()
        {
            SqlWhere = new StringBuilder(" 1=1 ");

            cmbPageSize.SelectedIndex = 0;

            cmbProductState.SelectedIndex = 0;
            cmbCoaxState.SelectedIndex = 0;
            cmbWeldState.SelectedIndex = 0;
            cmbLwmState.SelectedIndex = 0;
            cmbNewResult.SelectedIndex = 0;

            if (m_main.IsStation_S)
            {
                dgvLookBoard.Columns["colWeldDepth"].Visible = false;
            }

            txtCurPage.Text = "1";
            txtPageCount.Text = "1";
            txtAllCount.Text = "1";

            timeCheckStart.Value = DateTime.Now.AddDays(-1);
            timeCheckEnd.Value = DateTime.Now;
        }
        //样式设置
        private void initDGVStyle()
        {
            //设定按字体来缩放控件  
            this.AutoScaleMode = AutoScaleMode.Font;
            //设定字体大小为12px       
            this.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(134)));

            //锁定列头不可排序
            foreach (DataGridViewColumn column in dgvLookBoard.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvLookBoard.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, 134);
            dgvLookBoard.RowsDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, 134);
        }
        //数据库查询字段
        private void initSqlStrings()
        {
            m_dbColunmsNames = " ID,WorkNo,PNo,QCResult,Coaxiality,WeldDepth,Surface,LwmCheck,WeldPower,WeldSpeed," +
                "Pressure,Flow,XPos,YPos,ZPos,RPos,WeldTime,ManualCheck,StorageTime ";

            SQLFinalSelect = "select TOP 20 " + m_dbColunmsNames + "  from Product where QCResult is not null order by StorageTime desc";

            m_conditionExtra = " QCResult is not null";
        }
        private void M_main_WeldSuccessEvent(object obj, MyEvent e)
        {
            m_weldSuccess = e.WeldSuccess;
            if (m_weldSuccess)
            {
                string sqlLast = "SELECT TOP 20 * FROM Product WHERE QCResult IS NOT NULL ORDER BY StorageTime DESC";
                Invoke(new Action(() =>
                {
                    CurrentProductTable = m_main.DbTool.SelectTable(sqlLast);

                    if (CurrentProductTable != null)
                    {
                        dgvLookBoard.DataSource = CurrentProductTable;
                    }
                    else
                    {
                        LogHelper.WriteLog("追溯系统", "m_productTable is null!");
                    }

                    Thread.Sleep(50);

                    UpdateProduction();
                }));
            }
        }

        #endregion

        #region 系统语言
        private void M_main_CultureChangeEvent(object obj, MyEvent e)
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
            cmbSelectCondition.Items.Clear();
            cmbQCResult.Items.Clear();

            conditions = new object[] { ResourceCulture.GetValue("FinalCheckResult"), ResourceCulture.GetValue("BarCode"),
               /* ResourceCulture.GetValue("WorkNo"),*/ ResourceCulture.GetValue("Surface"),ResourceCulture.GetValue("LwmCheck") };
            cmbSelectCondition.Items.AddRange(conditions);

            if (m_main.IsStation_S)
            {
                cmbQCResult.Items.AddRange(surfaceStringS);
            }
            else
            {
                dgvLookBoard.Columns["colWeldDepth"].HeaderText = ResourceCulture.GetValue("WeldDepth") + "(mm)";

                cmbQCResult.Items.AddRange(surfaceStringL);
            }
            cmbQCResult.SelectedIndex = cmbSelectCondition.SelectedIndex = 0;

            dgvLookBoard.Columns["colWorkNo"].HeaderText = ResourceCulture.GetValue("WorkNo");
            dgvLookBoard.Columns["colPNo"].HeaderText = ResourceCulture.GetValue("BarCode");
            dgvLookBoard.Columns["colCheckResult"].HeaderText = ResourceCulture.GetValue("FinalResult");
            dgvLookBoard.Columns["colCoaxiality"].HeaderText = ResourceCulture.GetValue("Coaxiality") + "(mm)";
            //dgvLookBoard.Columns["colCoaxUp"].HeaderText = ResourceCulture.GetValue("CoaxUp") + "(mm)";
            //dgvLookBoard.Columns["colCoaxDown"].HeaderText = ResourceCulture.GetValue("CoaxDown") + "(mm)";
            dgvLookBoard.Columns["colSurface"].HeaderText = ResourceCulture.GetValue("Surface");
            dgvLookBoard.Columns["colLwmCheck"].HeaderText = ResourceCulture.GetValue("LwmResult");
            dgvLookBoard.Columns["colWeldPower"].HeaderText = ResourceCulture.GetValue("WeldPower") + "(W)";
            dgvLookBoard.Columns["colWeldSpeed"].HeaderText = ResourceCulture.GetValue("WeldSpeed") + "(°/s)";

            if (m_main.IsStation_S) dgvLookBoard.Columns["colPressure"].HeaderText = ResourceCulture.GetValue("ChuckClamp") + "(MPa)";
            else dgvLookBoard.Columns["colPressure"].HeaderText = ResourceCulture.GetValue("WorkpiecePressure") + "(MPa)";

            dgvLookBoard.Columns["colFlow"].HeaderText = ResourceCulture.GetValue("ProtectFlow") + "(L/min)";
            //dgvLookBoard.Columns["colFlowUp"].HeaderText = ResourceCulture.GetValue("ProtectFlowUp") + "(L/min)";
            //dgvLookBoard.Columns["colFlowDown"].HeaderText = ResourceCulture.GetValue("ProtectFlowDown") + "(L/min)";
            dgvLookBoard.Columns["colXPos"].HeaderText = ResourceCulture.GetValue("WeldXPos") + "(mm)";
            dgvLookBoard.Columns["colYPos"].HeaderText = ResourceCulture.GetValue("WeldYPos") + "(mm)";
            dgvLookBoard.Columns["colZPos"].HeaderText = ResourceCulture.GetValue("WeldZPos") + "(mm)";
            dgvLookBoard.Columns["colRPos"].HeaderText = ResourceCulture.GetValue("WeldRPos") + "(°)";
            dgvLookBoard.Columns["colWeldTime"].HeaderText = ResourceCulture.GetValue("WeldTime") + "(S)";
            dgvLookBoard.Columns["colMnaualCheck"].HeaderText = ResourceCulture.GetValue("ManualCheck");
            dgvLookBoard.Columns["colTime"].HeaderText = ResourceCulture.GetValue("StoreTime");

            labTotal.Text = ResourceCulture.GetValue("Production");
            labEach.Text = ResourceCulture.GetValue("PageSize");
            labWhich.Text = ResourceCulture.GetValue("Which");
            labHomePage.Text = ResourceCulture.GetValue("HomePage");
            labLastPage.Text = ResourceCulture.GetValue("LastPage");
            labNextPage.Text = ResourceCulture.GetValue("NextPage");
            labAfterPage.Text = ResourceCulture.GetValue("AfterPage");
            labPage.Text = ResourceCulture.GetValue("Page");
            labPage2.Text = ResourceCulture.GetValue("Page");
            labItem.Text = ResourceCulture.GetValue("Item");
            labSum.Text = ResourceCulture.GetValue("Sum");
            labSum2.Text = ResourceCulture.GetValue("Sum");

            labSelectMethod.Text = ResourceCulture.GetValue("SelectMethod");
            labSelectValue.Text = ResourceCulture.GetValue("QueryValue");
            btnSelectByTerm.Text = ResourceCulture.GetValue("Query");
            btnOutExcel.Text = ResourceCulture.GetValue("OutExcel");
            //btnManualCheck.Text = ResourceCulture.GetValue("ManualCheck");

            grbSelectCondition.Text = ResourceCulture.GetValue("SelectCondition");
            labBarCode.Text = ResourceCulture.GetValue("BarCode");
            labOnTIme.Text = ResourceCulture.GetValue("StoreTime");
            tabState.Text = ResourceCulture.GetValue("State");
            tabCoax.Text = ResourceCulture.GetValue("Coaxiality");
            tabSuface.Text = ResourceCulture.GetValue("Surface");
            chkProductState.Text = ResourceCulture.GetValue("State");
            chkCoaxState.Text = ResourceCulture.GetValue("CoaxState");
            chkCoaxRange.Text = ResourceCulture.GetValue("CoaxRange");
            chkWeldState.Text = ResourceCulture.GetValue("Surface");
            chkWeldDepth.Text = ResourceCulture.GetValue("WeldDepthRange");
            chkLwmState.Text = ResourceCulture.GetValue("LwmState");

            grbManual.Text = ResourceCulture.GetValue("ManualCheck");
            labCurResult.Text = ResourceCulture.GetValue("CurrentResult");
            labUpResult.Text  = ResourceCulture.GetValue("NewResult");
            labUpdateUser.Text = ResourceCulture.GetValue("Operator");
            labManualReason.Text = ResourceCulture.GetValue("ModifyReason");
            btnManualCheck.Text = ResourceCulture.GetValue("ManualCheck");

        }
        #endregion

        /// <summary>
        /// 更新产量UI
        /// </summary>
        private void UpdateProduction()
        {
            string count, pass, ng;
            m_main.DbTool.GetTableCountByProcedure(out count, out pass, out ng);

            txtSumPro.Text = count;
            txtPassPro.Text = pass;
            txtNGPro.Text = ng;
        }

        /// <summary>
        /// 更新追溯界面页数数据
        /// </summary>
        private void UpdatePageCount()
        {
            PageSize = Convert.ToInt32(cmbPageSize.SelectedItem);
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

            if (Inum > PageCount && PageCount > 0)
            {
                Inum = PageCount;
            }
            else
            {
                Inum = 1;
            }

            txtCurPage.Text = Inum.ToString();
            txtPageCount.Text = PageCount.ToString();
        }

        private void btnSelectByTerm_Click(object sender, EventArgs e)
        {
            if (!SQLServerDAL.SqlHelper.IsConnection(SQLServerDAL.SqlHelper.SQLServerConnectionString)) return;

            DateTime starTime = timeCheckStart.Value;
            DateTime endTime = timeCheckEnd.Value;
            if (starTime > endTime)
            {
                MessageBox.Show("起始时间不能大于终止时间！");
                return;
            }

            bool productChecked = chkProductState.Checked;
            bool coaxStateChecked = chkCoaxState.Checked;
            bool coaxRangeChecked = chkCoaxRange.Checked;
            bool weldChecked = chkWeldState.Checked;
            bool weldDepthChecked = chkWeldDepth.Checked;
            bool lwmStateChecked = chkLwmState.Checked;

            string strSQL = string.Empty;
            SqlWhere = new StringBuilder(" 1=1 ");

            strSQL = "SELECT " + m_dbColunmsNames + "FROM Product WHERE ";

            if (!string.IsNullOrEmpty(txtBarCode.Text.Trim()))
            {
                SqlWhere.Append(" AND PNo='" + txtBarCode.Text.Trim() + "'");
                m_conditionExtra = "PNo = '" + txtBarCode.Text.Trim() + "'";
            }
            if (productChecked)//产品状态
            {
                SqlWhere.Append(" AND QCResult='" + cmbProductState.SelectedItem.ToString() + "'");
                m_conditionExtra = "QCResult='" + cmbProductState.SelectedItem.ToString() + "'";
            }
            if (coaxStateChecked)//同心度状态
            {
                if (cmbCoaxState.SelectedItem.ToString() == "OK")
                {
                    SqlWhere.Append(" AND Surface='OK'");
                    m_conditionExtra = "Surface='OK'";
                }
                else if (cmbCoaxState.SelectedItem.ToString() == "NG")
                {
                    SqlWhere.Append(" AND Surface='同心度NG'");
                    m_conditionExtra = " Surface='同心度NG'";
                }
            }
            if (coaxRangeChecked)//同心度范围
            {
                string coaxDown = numCoaxRangeDowm.Value.ToString();
                string coaxUp = numCoaxRangeUp.Value.ToString();
                SqlWhere.Append(" AND Coaxiality BETWEEN " + coaxDown + " AND " + coaxUp);
                m_conditionExtra = " Coaxiality BETWEEN " + coaxDown + " AND " + coaxUp;
            }
            if (weldChecked)//表面质量
            {
                if (cmbWeldState.SelectedItem.ToString() == "OK")
                {
                    SqlWhere.Append(" AND Surface='OK'");
                    m_conditionExtra = " Surface='OK'";
                }
                else if (cmbWeldState.SelectedItem.ToString() == "焊缝NG")
                {
                    SqlWhere.Append(" AND Surface='焊缝NG'");
                    m_conditionExtra = " Surface='焊缝NG'";
                }
                else if (cmbWeldState.SelectedItem.ToString() == "瑕疵NG")
                {
                    SqlWhere.Append(" AND Surface='瑕疵NG'");
                    m_conditionExtra = " Surface='瑕疵NG'";
                }
            }
            if (weldDepthChecked)//焊缝高度差
            {
                string depthDown = numWeldDepthDown.Value.ToString();
                string depthUp = numWeldDepthUp.Value.ToString();
                SqlWhere.Append(" AND WeldDepth BETWEEN " + depthDown + " AND " + depthUp);
                m_conditionExtra = " WeldDepth BETWEEN " + depthDown + " AND " + depthUp;
            }
            if (lwmStateChecked)
            {
                SqlWhere.Append("AND LwmCheck='" + cmbLwmState.SelectedItem.ToString() + "'");
                m_conditionExtra = " LwmCheck='" + cmbLwmState.SelectedItem.ToString() + "'";
            }

            SqlWhere.Append(" AND StorageTime BETWEEN '" + timeCheckStart.Value + "' AND '" + timeCheckEnd.Value.AddDays(1) + "' ");
            SqlWhere.Append("ORDER BY StorageTime DESC");
            SQLFinalSelect = strSQL + SqlWhere.ToString();

            stopwatch.Restart();
            m_main.AddTips("正在查询数据，请稍等...", false);

            //更新总条数
            AllCount = m_main.DbTool.GetTableCount(string.Format("SELECT COUNT(1) FROM ({0}) T", SQLFinalSelect.Replace("ORDER BY StorageTime DESC", "")));
            txtAllCount.Text = AllCount.ToString();
            Remain = AllCount % PageSize;
            UpdatePageCount();

            ShowPage(Inum, PageSize);

            UpdateProduction();
            stopwatch.Stop();
            LogHelper.WriteLog("查询数据", "耗时 - " + Math.Round(stopwatch.Elapsed.TotalSeconds, 2) + " s");
            m_main.AddTips("查询成功!", false);

            //Query();
        }

        private void cmbSelectCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trem = cmbSelectCondition.SelectedItem.ToString();

            switch (trem)
            {
                //case "上线时间":
                //case "StoreTime":
                //    timeCheckStart.Visible = true;
                //    label6.Visible = true;
                //    timeCheckEnd.Visible = true;

                //    txtQCResult.Visible = false;
                //    cmbQCResult.Visible = false;
                //    break;
                case "状态":
                case "FinalResult":
                case "LWM检测":
                case "LwmCheck":
                    cmbQCResult.Items.Clear();
                    cmbQCResult.Items.AddRange(lwmStrings);
                    cmbQCResult.SelectedIndex = 0;

                    txtQCResult.Visible = false;
                    cmbQCResult.Visible = true;
                    break;
                case "焊缝质量":
                case "Surface":
                    cmbQCResult.Items.Clear();

                    if (m_culture == 1)
                    {
                        if (m_main.IsStation_S)
                        {
                            cmbQCResult.Items.AddRange(surfaceStringS);
                        }
                        else
                        {
                            cmbQCResult.Items.AddRange(surfaceStringL);
                        }
                    }
                    else
                    {
                        if (m_main.IsStation_S)
                        {
                            cmbQCResult.Items.AddRange(surfaceStringSEN);
                        }
                        else
                        {
                            cmbQCResult.Items.AddRange(surfaceStringLEN);
                        }
                    }

                    cmbQCResult.SelectedIndex = 0;

                    txtQCResult.Visible = false;
                    cmbQCResult.Visible = true;
                    break;
                default:
                    txtQCResult.Visible = true;
                    cmbQCResult.Visible = false;
                    break;
            }
        }

        private void UpdateFaceUIByCondition(string sql)
        {
            string sqlCount = String.Format("select count(1) from ({0}) t", sql);

            //更新总条数
            AllCount = m_main.DbTool.GetTableCount(sqlCount);
            txtAllCount.Text = AllCount.ToString();

            Inum = 1;
            Remain = AllCount % PageSize;
            txtCurPage.Text = Inum.ToString();

            UpdatePageCount();

            //分页显示数据
            ShowPage(Inum, PageSize);

        }
        /// <summary>
        /// 执行查询
        /// </summary>
        private void Query()
        {

            if (!DBHelper.Instance.Open()) return;
            if (!ConditionJudge()) return;

            stopwatch.Restart();
            m_main.AddTips("正在查询数据，请稍等...", false);
            //UpdateFaceUIByCondition(SQLFinalSelectl);

            //更新总条数
            AllCount = m_main.DbTool.GetTableCount(String.Format("SELECT COUNT(1) FROM ({0}) T", SQLFinalSelect));
            txtAllCount.Text = AllCount.ToString();

            Inum = 1;
            Remain = AllCount % PageSize;
            txtCurPage.Text = Inum.ToString();

            UpdatePageCount();

            //分页显示数据
            ShowPage(Inum, PageSize);

            UpdateProduction();
            stopwatch.Stop();
            LogHelper.WriteLog("查询数据", "耗时 - " + Math.Round(stopwatch.Elapsed.TotalSeconds, 2) + " s");
            m_main.AddTips("查询成功!", false);
        }
        /// <summary>
        /// 返回 finalSQL
        /// </summary>
        /// <returns></returns>
        private bool ConditionJudge()
        {
            if (cmbSelectCondition.SelectedIndex < 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("PleaseChoseMethod"));
                return false;
            }

            DateTime starTime = timeCheckStart.Value;
            DateTime endTime = timeCheckEnd.Value;

            if (starTime > endTime)
            {
                MessageBox.Show("起始时间不能大于终止时间！");
                return false;
            }

            string storeTime = "' and StorageTime between '" + starTime + "' and '" + endTime.AddDays(1) + "' ";
            string condition = cmbSelectCondition.SelectedItem.ToString();
            string value = string.Empty;

            if (condition.Equals("状态") || condition.Equals("FinalResult")
                || condition.Equals("焊缝质量") || condition.Equals("Surface")
                || condition.Equals("同心度") || condition.Equals("Coaxiality")
                || condition.Equals("LWM检测") || condition.Equals("LwmCheck"))
            {
                value = cmbQCResult.SelectedItem.ToString();
                if (String.IsNullOrEmpty(value)) return false;
                if (value == "CoaxialityNG")
                {
                    value = "同心度NG";
                }
                else if (value == "WeldDepthNG")
                {
                    value = "焊缝NG";
                }
                else if (value == "SurfaceNG")
                {
                    value = "瑕疵NG";
                }
            }
            else
            {
                value = txtQCResult.Text;
            }

            SQLFinalSelect = string.Empty;
            m_sqlByConditionSB = new StringBuilder();
            m_conditionExtraSB = new StringBuilder();

            switch (condition)
            {
                case "过程条码":
                case "BarCode":
                    SQLFinalSelect = "select " + m_dbColunmsNames + " from product where PNo='" + value + "'" + storeTime;
                    m_conditionExtra = "PNo='" + value + "'" + storeTime;

                    //m_sqlByConditionSB.Append("select").Append(m_dbColunmsNames).Append(" from product where PNo='").Append(value).Append(storeTime);
                    //m_conditionExtraSB.Append("PNo = '").Append(value).Append(storeTime);
                    break;
                case "焊缝质量":
                case "Surface":
                    SQLFinalSelect = "select " + m_dbColunmsNames + "  from product where Surface='" + value + "'" + storeTime;
                    m_conditionExtra = "Surface='" + value + "'" + storeTime;

                    //m_sqlByConditionSB.Append("select").Append(m_dbColunmsNames).Append(" from product where Surface='").Append(value).Append(storeTime);
                    //m_conditionExtraSB.Append("Surface='").Append(value).Append(storeTime);
                    break;
                case "状态":
                case "FinalResult":
                    SQLFinalSelect = "select " + m_dbColunmsNames + "  from product where QCResult='" + value + "'" + storeTime;
                    m_conditionExtra = "QCResult='" + value + "'" + storeTime;

                    //m_sqlByConditionSB.Append("select").Append(m_dbColunmsNames).Append(" from product where QCResult='").Append(value).Append(storeTime);
                    //m_conditionExtraSB.Append("QCResult='").Append(value).Append(storeTime);
                    break;
                case "LWM检测":
                case "LwmCheck":
                    SQLFinalSelect = "select " + m_dbColunmsNames + "  from product where LwmCheck='" + value + "'" + storeTime;
                    m_conditionExtra = "LwmCheck='" + value + "'" + storeTime;

                    //m_sqlByConditionSB.Append("select").Append(m_dbColunmsNames).Append(" from product where LwmCheck='").Append(value).Append(storeTime);
                    //m_conditionExtraSB.Append("LwmCheck='").Append(value).Append(storeTime);
                    break;
                //case "上线时间":
                //case "StoreTime":
                //    sqlByCondition = "select " + m_dbColunmsNames + "  from product where StorageTime between '" + starTime + "' and '" + endTime + "' ";
                //    m_conditionExtra = "StorageTime between '" + starTime + "' and '" + endTime + "' ";
                //    break;
                default:
                    break;
            }

            //m_sqlByCondition = m_sqlByConditionSB.ToString();
            //m_conditionExtra = m_conditionExtraSB.ToString();

            return true;
        }

        #region 导出Excel

        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            ButtonOutExcel(SQLFinalSelect);
        }

        private void ButtonOutExcel(string sqlSelectFinal)
        {
            if (CurrentProductTable == null || CurrentProductTable.Rows.Count == 0)
            {
                dgvLookBoard.DataSource = CurrentProductTable;
                MessageBox.Show(ResourceCulture.GetValue("NotData"));
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "保存导出文件";
            saveFile.Filter = "导出数据文件(.csv) | *.csv";
            saveFile.FilterIndex = 1;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                m_main.AddTips("正在导出数据，请稍等...", false);

                //ThreadPool.QueueUserWorkItem((t =>
                //{
                Task.Factory.StartNew(() =>
                {
                    ExcelProductTable = m_main.DbTool.SelectTable(sqlSelectFinal);
                    ExportExcel(saveFile.FileName);
                });
                //}));
            }
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="fileName"></param>
        private void ExportExcel(string fileName)
        {
            try
            {
                stopwatch.Restart();
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);//Encoding.GetEncoding("UTF-8")
                for (int col = 1; col < ExcelProductTable.Columns.Count; col++)
                {
                    string colName = ExcelProductTable.Columns[col].ColumnName;
                    string headName = dgvLookBoard.Columns[col].HeaderText;

                    if (headName.Contains("ManualCheck") || headName.Contains("人工干预") ||
                        headName.Contains("WorkNo") || headName.Contains("工单号") ||
                        headName.Contains("ID"))
                        continue;
                    if (m_main.IsStation_S)
                        if (headName.Contains("WeldDepth") || headName.Contains("焊缝高度差")) continue;

                    sw.Write(headName + ",");
                }

                sw.WriteLine(string.Empty);

                for (int row = 0; row < ExcelProductTable.Rows.Count; row++)
                {
                    //sw.Write((row + 1).ToString() + ",");
                    for (int col = 1; col < ExcelProductTable.Columns.Count; col++)
                    {
                        string headName = ExcelProductTable.Columns[col].ColumnName;

                        //不导出产品类型列
                        if (headName.Contains(("ManualCheck")) || headName.Contains(("WorkNo")) ||
                            headName.Contains("ID"))
                            continue;
                        if (m_main.IsStation_S)
                            if (headName.Contains("WeldDepth")) continue;

                        string value = string.Format("\t{0}", ExcelProductTable.Rows[row][col]);
                        sw.Write(string.Format("\t{0}", value) + ",");
                    }
                    sw.Write("\n");
                }

                sw.Close();
                fs.Close();

                stopwatch.Stop();
                LogHelper.WriteLog("导出EXCEL", "耗时 - " + stopwatch.Elapsed.TotalSeconds.ToString("0.000") + " s");

                MessageBox.Show(ResourceCulture.GetValue("OutExcelOK"));
                m_main.AddTips("导出成功!", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败，失败原因：" + ex.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                LogHelper.WriteWarmLog("导出Excel失败---->" + ex.Message);
            }
        }

        #endregion

        #region 人工干预

        private void btnManualCheck_Click(object sender, EventArgs e)
        {
            if (!m_main.CheckUserAuth())
            {
                return;
            }

            txtModifyUser.Text = m_main.CurrentUser.Name;
            string newResult = cmbNewResult.SelectedItem.ToString();
            string modifyUser = txtModifyUser.Text.Trim();
            string modifyReason = txtModifyReason.Text;

            if (String.IsNullOrEmpty(modifyUser))
            {
                MessageBox.Show("人工干预修改人不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(modifyReason))
            {
                MessageBox.Show("人工干预理由不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewCell curCell = dgvLookBoard.CurrentCell;
            if (curCell != null)
            {
                string barcode = dgvLookBoard.Rows[curCell.RowIndex].Cells["colPNo"].Value.ToString();
                string state = dgvLookBoard.Rows[curCell.RowIndex].Cells["colCheckResult"].Value.ToString();
                string oldResult = dgvLookBoard.Rows[curCell.RowIndex].Cells["colMnaualCheck"].Value.ToString();

                AirBag bag = new AirBag();
                ServiceResult result = bag.UpdateManaulCheck(barcode, newResult, modifyReason, modifyUser);
                if (result.IsSuccess)
                {
                    UpdateCurrentPage();
                }
                else
                {
                    MessageBox.Show("人工干预失败！Msg:" + result.Msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                /**
                int colIndex = curCell.ColumnIndex;
                string colName = dgvLookBoard.Columns[colIndex].HeaderText;
                if (colName.Equals("人工干预") || colName.Equals("ManualCheck"))
                {
                    bool boo = dgvLookBoard.SelectedCells.IsReadOnly;
                }

                ManualCheckForm form = new ManualCheckForm(m_culture, manual, result);
                form.ModifyManual += GetManualInfo;
                form.ShowDialog();
                if (!m_ifUpdateResult) return;
                string sql = "update product set QCResult='" + m_qcResult + "' ,ManualCheck='" + m_manualInfo + "' where PNo='" + pno + "'";
                int c = m_main.DbTool.TransactionTable(sql);
                if (c < 0)
                {
                    MessageBox.Show(ResourceCulture.GetValue("UpdateFail"));
                    return;
                }
                else
                {
                    MessageBox.Show(ResourceCulture.GetValue("UpdateSuccess"));
                }
                UpdateCurrentPage();
                */

            }
            else
            {
                MessageBox.Show("请选择需要修改的数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GetManualInfo(object sender, MyEvent e)
        {
            m_ifUpdateResult = e.IfUpdateResult;
            m_manualInfo = e.ManualInfo;
            m_qcResult = e.QCResult.ToString();
        }

        /// <summary>
        /// 更新人工干预后的数据
        /// </summary>
        private void UpdateCurrentPage()
        {
            ShowPage(Inum, PageSize);
            UpdateProduction();
        }

        #endregion

        #region 查询条件改变

        private void chkProductState_CheckedChanged(object sender, EventArgs e)
        {
            cmbProductState.Enabled = chkProductState.Checked;
        }

        private void chkCoaxState_CheckedChanged(object sender, EventArgs e)
        {
            cmbCoaxState.Enabled = chkCoaxState.Checked;
        }

        private void chkCoaxRange_CheckedChanged(object sender, EventArgs e)
        {
            numCoaxRangeDowm.Enabled = chkCoaxRange.Checked;
            numCoaxRangeUp.Enabled = chkCoaxRange.Checked;
        }

        private void chkWeldState_CheckedChanged(object sender, EventArgs e)
        {
            cmbWeldState.Enabled = chkWeldState.Checked;
        }

        private void chkWeldDepth_CheckedChanged(object sender, EventArgs e)
        {
            numWeldDepthDown.Enabled = chkWeldDepth.Checked;
            numWeldDepthUp.Enabled = chkWeldDepth.Checked;
        }

        private void chkLwmState_CheckedChanged(object sender, EventArgs e)
        {
            cmbLwmState.Enabled = chkLwmState.Checked;
        }

        #endregion

        #region 分页显示

        private void ShowPage(int Inum, int pageSize)
        {
            sqlPage = String.Empty;

            if (Remain != 0 && Inum == PageCount)
            {
                //sqlPage = "SELECT TOP " + Remain + m_dbColunmsNames + " FROM Product WHERE Id NOT IN (SELECT TOP " + Convert.ToInt32(cmbPageSize.SelectedItem) * (Inum - 1)
                //          + " Id FROM Product WHERE " + m_conditionExtra + " ORDER BY StorageTime DESC )" + " AND " + m_conditionExtra + " ORDER BY StorageTime DESC";

                sqlPage = String.Format("SELECT TOP {0} {1} FROM Product WHERE Id NOT IN (SELECT TOP {2} Id FROM Product WHERE {3})" +
                    " AND {4}  ",
                    Remain, m_dbColunmsNames, Convert.ToInt32(cmbPageSize.SelectedItem) * (Inum - 1), SqlWhere, SqlWhere);
            }
            else
            {
                //sqlPage = "SELECT TOP " + pageSize + m_dbColunmsNames + "  FROM Product WHERE Id NOT IN (SELECT TOP " + pageSize * (Inum - 1)
                //          + " Id FROM Product WHERE " + m_conditionExtra + " ORDER BY StorageTime DESC )" + " AND " + m_conditionExtra + " ORDER BY StorageTime DESC";

                sqlPage = String.Format("SELECT TOP {0} {1} FROM Product WHERE Id NOT IN (SELECT TOP {2} Id FROM Product WHERE {3} )" +
                    " AND {4}  ",
                    pageSize, m_dbColunmsNames, pageSize * (Inum - 1), SqlWhere, SqlWhere);
            }

            CurrentProductTable = m_main.DbTool.SelectTable(sqlPage);

            if (CurrentProductTable != null)
            {
                dgvLookBoard.DataSource = CurrentProductTable;
            }
        }

        //首页
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentProductTable == null || CurrentProductTable.Rows.Count < 1) return;

            Inum = 1;

            ShowPage(Inum, PageSize);

            txtCurPage.Text = Inum.ToString();
        }

        //上一页
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentProductTable == null || CurrentProductTable.Rows.Count < 1) return;

            Inum--;
            if (Inum > 0)                     //如果当前不是首页
            {
                ShowPage(Inum, PageSize);    //显示上一页记录
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("IsFirstPage"));
                Inum = 1;
                return;
            }
            txtCurPage.Text = Inum.ToString();
        }

        //下一页
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentProductTable == null || CurrentProductTable.Rows.Count < 1) return;

            Inum++;

            if (Inum <= PageCount)              //如果没有超出总页数
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
                MessageBox.Show(ResourceCulture.GetValue("IsLastPage"));
                Inum = PageCount;
                return;
            }
            txtCurPage.Text = Inum.ToString();
        }

        //末页
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentProductTable == null || CurrentProductTable.Rows.Count < 1) return;

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

        //数据发送变化
        private void dgvLookBoard_DataSourceChanged(object sender, EventArgs e)
        {
            if (CurrentProductTable == null)
            {
                return;
            }
            try
            {
                SetDGVStyle(dgvLookBoard);

                for (int i = 0; i < dgvLookBoard.RowCount - 1; i++)
                {
                    DataGridViewRow dgvRow = dgvLookBoard.Rows[i];

                    string no = dgvRow.Cells["colPNo"].Value.ToString();
                    string value = dgvRow.Cells["colCheckResult"].Value.ToString();
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (value.Equals("OK"))
                        {
                            //dgvLookBoard.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                            dgvRow.Cells["colCheckResult"].Style.BackColor = Color.LawnGreen;
                        }
                        else if (value.Equals("NG"))
                        {
                            //dgvLookBoard.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                            dgvRow.Cells["colCheckResult"].Style.BackColor = Color.OrangeRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_main.LogNetProgramer.WriteError("异常", "追溯系统更新时异常-->" + ex.Message);
            }
        }

        private void SetDGVStyle(DataGridView dgv)
        {
            if (dgv.Rows.Count != 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(224, 254, 254);
                    }
                }
            }
        }
        #endregion

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePageCount();
        }

        private void cmbPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvLookBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCell = dgvLookBoard.CurrentCell;
            if (dgvLookBoard.Rows.Count > 1 && curCell != null)
            {
                txtOldResult.Text = dgvLookBoard.Rows[curCell.RowIndex].Cells["colCheckResult"].Value.ToString();
            }
        }
    }
}
