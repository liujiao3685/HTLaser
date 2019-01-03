using HuaTianProject.Core;
using HuaTianProject.Entity;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HuaTianProject.UI
{
    public partial class ManageUserForm : Form
    {
        private DBTool m_dbTool;

        private SQLiteConnection m_sqlConnection;

        private SQLiteDataAdapter m_sqlAdapter;

        private SQLiteCommand m_command;

        private DataSet m_dataSet = new DataSet();

        private DataTable m_dataTable = new DataTable();

        private User m_user = null;

        public ManageUserForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        private void ManageUserForm_Load(object sender, EventArgs e)
        {
            //m_dbTool = FormMain.DbTool;
            m_dbTool = DBTool.GetInstance();

            UpdatData();

            this.dgvUsers.Columns[0].HeaderCell.Value = "用户名";
            this.dgvUsers.Columns[1].HeaderCell.Value = "密码";
            this.dgvUsers.Columns[2].HeaderCell.Value = "操作权限";
        }

        /// <summary>
        /// 实时更新数据
        /// </summary>
        private void UpdatData()
        {
            m_dataSet.Clear();
            m_sqlConnection = m_dbTool.GetSQLConnection();
            m_command = m_dbTool.GetCommand();
            m_sqlAdapter = new SQLiteDataAdapter(m_command);
            m_sqlAdapter.Fill(m_dataSet, "users");
            m_dataTable = m_dataSet.Tables[0];
            this.dgvUsers.DataSource = m_dataTable;
        }

        private void GetFocusUser()
        {
            string name = this.dgvUsers.Rows[this.dgvUsers.CurrentRow.Index].Cells[0].Value.ToString(); ;
            string password = this.dgvUsers.Rows[this.dgvUsers.CurrentRow.Index].Cells[1].Value.ToString();
            string auth = this.dgvUsers.Rows[this.dgvUsers.CurrentRow.Index].Cells[2].Value.ToString();
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户名或密码不能为空！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(auth))
            {
                MessageBox.Show("请输入用户权限(操作员/管理员)！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            m_user = new User();
            m_user.Name = name;
            m_user.Password = password;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetFocusUser();
            if (m_user != null)
            {
                int n = m_dbTool.InsertData(m_user.Name, m_user.Password, m_user.Auth);
                if (n <= 0)
                {
                    MessageBox.Show("增加失败，此用户名已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("增加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdatData();
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetFocusUser();
            if (m_user != null)
            {
                int n = m_dbTool.UpdateData(m_user.Name, m_user.Password);
                if (n <= 0)
                {
                    MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdatData();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                GetFocusUser();
                if (m_user == null) return;

                if (m_user.Name.Equals("程序员"))
                {
                    MessageBox.Show("此用户无法被删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int n = m_dbTool.DeleteData(m_user.Name);
                if (n <= 0)
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdatData();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            UpdatData();
        }

    }
}
