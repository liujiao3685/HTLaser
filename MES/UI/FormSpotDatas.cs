using MES;
using MES.Core;
using MES.DAL;
using ProductManage.Language.MyLanguageTool;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProductManage.UI
{
    public partial class FormSpotDatas : Form
    {
        private FormMain m_main;

        private int Inum = 1;//行号，索引初始值为1

        private int PageCount = 1;//总页数

        private int AllCount;//总条数

        private int PageSize = 10;//每页的数量

        private int Remain;//总条数%总页数是否为0

        private DataTable m_currentTable = null;

        private string sqlPage = string.Empty;

        private string m_conditionExtra = "EmpNo is not null";

        private string m_dbColumnNames = string.Empty;

        /// <summary>
        /// 执最终行查询的sql语句
        /// </summary>
        private string sqlByCondition = string.Empty;

        private int m_culture = 1;

        private string[] conditions = { "点检人", "点检结果", "点检时间" };

        private string[] results = { "成功", "失败" };

        public FormSpotDatas()
        {
            InitializeComponent();
        }

        public FormSpotDatas(FormMain main)
        {
            InitializeComponent();
            m_main = main;

            m_culture = m_main.Culture;
            if (m_main.UseLanguage == 1) CultureChange();

            dgvSpotData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, 134);
            dgvSpotData.RowsDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, 134);

        }

        private void FormSpotDatas_Load(object sender, System.EventArgs e)
        {
            Init();

            LoadData();
        }

        private void LoadData()
        {
            LoadLastData();
        }

        private void Init()
        {
            m_dbColumnNames = "SID,EmpNo,PWeldPower,PWeldSpeed,PWeldPressure,PWeldFlow,PWeldXPos,PWeldYPos,PWeldZPos,PWeldRPos,SpotTime,SpotResult,FailReason";
            cmbPageSize.SelectedIndex = 0;

            timeCheckStart.Value = DateTime.Now.AddDays(-1);
            timeCheckEnd.Value = DateTime.Now;

            //锁定列头
            foreach (DataGridViewColumn column in dgvSpotData.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CultureChange()
        {
            if (m_culture == 1)
            {
                ResourceCulture.SetCurrentCulture("zh-CN");
                SetCulture();
            }
            else
            {
                ResourceCulture.SetCurrentCulture("en-US");
                SetCulture();
            }
        }

        private void SetCulture()
        {
            cmbSelectCondition.Items.Clear();
            cmbResult.Items.Clear();

            conditions = new string[] { ResourceCulture.GetValue("SpotUser"), ResourceCulture.GetValue("SpotResult"),ResourceCulture.GetValue("SpotTime") };
            cmbSelectCondition.Items.AddRange(conditions);

            results = new string[] { ResourceCulture.GetValue("Success"), ResourceCulture.GetValue("Fail") };
            cmbResult.Items.AddRange(results);

            cmbResult.SelectedIndex = cmbSelectCondition.SelectedIndex = 0;

            Text = ResourceCulture.GetValue("SpotDataCenter");

            dgvSpotData.Columns["colEmpNo"].HeaderText = ResourceCulture.GetValue("SpotUser");
            dgvSpotData.Columns["colPWeldPower"].HeaderText = ResourceCulture.GetValue("WeldPower") + "(W)";
            dgvSpotData.Columns["colPWeldSpeed"].HeaderText = ResourceCulture.GetValue("WeldSpeed") + "(°/s)";

            if (m_main.IsStation_S) dgvSpotData.Columns["colPWeldPressure"].HeaderText = ResourceCulture.GetValue("ChuckClamp") + "(MPa)";
            else dgvSpotData.Columns["colPWeldPressure"].HeaderText = ResourceCulture.GetValue("WorkpiecePressure") + "(MPa)";

            dgvSpotData.Columns["colPWeldFlow"].HeaderText = ResourceCulture.GetValue("ProtectFlow") + "(L/min)";
            dgvSpotData.Columns["colPWeldXPos"].HeaderText = ResourceCulture.GetValue("WeldXPos") + "(mm)";
            dgvSpotData.Columns["colPWeldYPos"].HeaderText = ResourceCulture.GetValue("WeldYPos") + "(mm)";
            dgvSpotData.Columns["colPWeldZPos"].HeaderText = ResourceCulture.GetValue("WeldZPos") + "(mm)";
            dgvSpotData.Columns["colPWeldRPos"].HeaderText = ResourceCulture.GetValue("WeldRPos") + "(°)";
            dgvSpotData.Columns["colSpotResult"].HeaderText = ResourceCulture.GetValue("SpotResult");
            dgvSpotData.Columns["colFailReason"].HeaderText = ResourceCulture.GetValue("SpotFailReason");
            dgvSpotData.Columns["colSpotTime"].HeaderText = ResourceCulture.GetValue("SpotTime");

            labEach.Text = ResourceCulture.GetValue("PageSize");
            labWhich.Text = ResourceCulture.GetValue("Which");
            labHomePage.Text = ResourceCulture.GetValue("HomePage");
            labLastPage.Text = ResourceCulture.GetValue("LastPage");
            labNextPage.Text = ResourceCulture.GetValue("NextPage");
            labAfterPage.Text = ResourceCulture.GetValue("AfterPage");
            labPage.Text = ResourceCulture.GetValue("Page");
            labPage2.Text = ResourceCulture.GetValue("Page");
            labSum.Text = ResourceCulture.GetValue("Sum");

            labSelectMethod.Text = ResourceCulture.GetValue("SelectMethod");
            labSelectValue.Text = ResourceCulture.GetValue("QueryValue");
            btnSelect.UIText = ResourceCulture.GetValue("Query");
            btnSelectLast.UIText = ResourceCulture.GetValue("SelectLatestData");


        }

        //分页显示数据
        private void ShowPage(int Inum, int pageSize)
        {
            sqlPage = string.Empty;

            if (Remain != 0 && Inum == PageCount)
            {
                sqlPage = "select top " + Remain + " " + m_dbColumnNames + " from SpotCheck where SId not in (select top " + Convert.ToInt32(cmbPageSize.SelectedItem) * (Inum - 1)
                          + " SId from SpotCheck order by SpotTime desc )" + " and " + m_conditionExtra + " order by SpotTime desc";
            }
            else
            {
                sqlPage = "select top " + pageSize + " " + m_dbColumnNames + " from SpotCheck where SId not in (select top " + pageSize * (Inum - 1)
                          + " SId from SpotCheck order by SpotTime desc )" + " and " + m_conditionExtra + " order by SpotTime desc";
            }

            m_currentTable = m_main.DbTool.SelectTable(sqlPage);

            if (m_currentTable != null)
            {
                dgvSpotData.DataSource = m_currentTable;
            }
        }

        //首页
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_currentTable == null || m_currentTable.Rows.Count < 1) return;

            Inum = 1;

            ShowPage(Inum, PageSize);

            txtCurPage.Text = Inum.ToString();
        }

        //上一页
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_currentTable == null || m_currentTable.Rows.Count < 1) return;

            Inum--;
            if (Inum > 0)                     //如果当前不是首页
            {
                ShowPage(Inum, PageSize);    //显示上一页记录
            }
            else
            {
                Inum = 1;
                MessageBox.Show(ResourceCulture.GetValue("IsFirstPage"));
                return;
            }
            txtCurPage.Text = Inum.ToString();
        }

        //下一页
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_currentTable == null || m_currentTable.Rows.Count < 1) return;

            Inum++;

            if (Inum <= PageCount)//如果没有超出总页数
            {
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
            if (m_currentTable == null || m_currentTable.Rows.Count < 1) return;

            if (PageCount == 0) Inum = 1;
            else Inum = PageCount;
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

        private void dgvSpotData_DataSourceChanged(object sender, EventArgs e)
        {
            if (m_currentTable == null)
            {
                return;
            }
            try
            {
                SetDGVStyle(dgvSpotData);

                for (int i = 0; i < dgvSpotData.RowCount - 1; i++)
                {
                    DataGridViewRow dgvRow = dgvSpotData.Rows[i];

                    string value = dgvRow.Cells["colSpotResult"].Value.ToString();
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (value.Equals("成功"))
                        {
                            dgvRow.Cells["colSpotResult"].Style.BackColor = Color.LawnGreen;
                        }
                        else if (value.Equals("失败"))
                        {
                            dgvRow.Cells["colSpotResult"].Style.BackColor = Color.OrangeRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                m_main.LogNetProgramer.WriteError("异常", "点检数据更新异常-->" + ex.Message);
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

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        //查询
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!ConditionJudge()) return;

            UpdateLookBoard(sqlByCondition);
        }

        private bool ConditionJudge()
        {
            if (!m_main.CheckDbState()) return false;

            if (cmbSelectCondition.SelectedIndex < 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("PleaseChoseMethod"));
                return false;
            }

            string condition = cmbSelectCondition.SelectedItem.ToString();
            string value = string.Empty;

            if (condition.Equals("点检人") || condition.Equals("SpotUser"))
            {
                value = txtSelectValue.Text;
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("请输入查询条件！");
                    return false;
                }
            }
            else if (condition.Equals("点检结果") || condition.Equals("SpotResult"))
            {
                value = cmbResult.SelectedItem.ToString();
            }

            sqlByCondition = string.Empty;

            switch (condition)
            {
                case "点检人":
                case "SpotUser":
                    sqlByCondition = "select " + m_dbColumnNames + " from SpotCheck where EmpNo = '" + value + "'";
                    m_conditionExtra = "EmpNo = '" + value + "'";

                    break;
                case "SpotResult":
                case "点检结果":
                    sqlByCondition = "select " + m_dbColumnNames + " from SpotCheck where SpotResult ='" + value + "'";
                    m_conditionExtra = "SpotResult ='" + value + "'";

                    break;
                case "点检时间":
                case "SpotTime":
                    DateTime starTime = timeCheckStart.Value;
                    DateTime endTime = timeCheckEnd.Value;

                    if (starTime > endTime)
                    {
                        MessageBox.Show("起始时间不能大于终止时间！");
                        break;
                    }

                    sqlByCondition = "select  " + m_dbColumnNames + " from SpotCheck where SpotTime between '" + starTime + "' and '" + endTime + "' ";
                    m_conditionExtra = "SpotTime between '" + starTime + "' and '" + endTime + "' ";
                    break;
                default:
                    break;
            }
            return true;
        }

        //更新查询后界面
        private void UpdateLookBoard(string sql)
        {
            string sqlCount = String.Format("select count(*) from ({0}) t", sql);

            AllCount = m_main.DbTool.GetTableCount(sqlCount);

            //更新总条数
            //txtAllCount.Text = AllCount.ToString();

            Inum = 1;
            Remain = AllCount % PageSize;
            txtCurPage.Text = Inum.ToString();

            UpdatePageCount();

            //分页显示数据
            ShowPage(Inum, PageSize);

        }

        /// <summary>
        /// 更新追溯界面页数信息
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

        private void cmbPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSelectLast_Click(object sender, EventArgs e)
        {
            LoadLastData();
        }

        private void LoadLastData()
        {
            string sql = "select top 20 " + m_dbColumnNames + " from SpotCheck order by SpotTime desc";

            m_currentTable = m_main.DbTool.SelectTable(sql);

            if (m_currentTable != null)
            {
                dgvSpotData.DataSource = m_currentTable;
            }

            txtPageCount.Text = "1";
        }

        private void cmbSelectCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trem = cmbSelectCondition.SelectedItem.ToString();

            switch (trem)
            {
                case "点检人":
                case "SpotUser":
                    txtSelectValue.Visible = true;
                    cmbResult.Visible = false;

                    timeCheckStart.Visible = false;
                    timeCheckEnd.Visible = false;
                    label6.Visible = false;
                    break;
                case "点检结果":
                case "SpotResult":
                    cmbResult.Items.Clear();
                    cmbResult.Items.AddRange(results);
                    cmbResult.SelectedIndex = 0;

                    txtSelectValue.Visible = false;
                    cmbResult.Visible = true;

                    timeCheckStart.Visible = false;
                    timeCheckEnd.Visible = false;
                    label6.Visible = false;
                    break;
                case "点检时间":
                case "SpotTime":
                    txtSelectValue.Visible = false;
                    cmbResult.Visible = false;

                    timeCheckStart.Visible = true;
                    timeCheckEnd.Visible = true;
                    label6.Visible = true;
                    break;
            }
        }
    }
}
