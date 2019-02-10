using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MES.Entity;
using ProductManage.Language.MyLanguageTool;

namespace MES.UI
{
    public partial class OMCSForm : Form
    {
        private FormMain m_main;

        private DataTable m_usersTable = null;

        private User m_currentUser = null;

        private string m_sqlSelectAll = string.Empty;

        private string m_dbColunmNames = string.Empty;

        private int m_culture = 1;

        private object[] auths = new object[] { "操作员", "管理员" };

        public OMCSForm()
        {
            InitializeComponent();
        }

        public OMCSForm(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            m_usersTable = main.UsersTable;
        }

        private void AptitudeForm_Load(object sender, System.EventArgs e)
        {
            Init();

            cmbAuth.SelectedIndex = 0;

            m_culture = m_main.Culture;
            if (m_main.UseLanguage == 1) CultureChange();

            LoadUsersInfo();
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
            dgvUsersInfo.Columns["colEmpNo"].HeaderText = ResourceCulture.GetValue("EmpNo");
            dgvUsersInfo.Columns["colName"].HeaderText = ResourceCulture.GetValue("UserName");
            dgvUsersInfo.Columns["colPassword"].HeaderText = ResourceCulture.GetValue("Password");
            dgvUsersInfo.Columns["colAuth"].HeaderText = ResourceCulture.GetValue("Auth");

            Text = ResourceCulture.GetValue("OMCS");
            grbAddUser.Text = ResourceCulture.GetValue("AddUser");
            labEmpNo.Text = ResourceCulture.GetValue("EmpNo");
            labUserName.Text = ResourceCulture.GetValue("UserName");
            labPassword.Text = ResourceCulture.GetValue("Password");
            labAuth.Text = ResourceCulture.GetValue("Auth");
            btnAdd.UIText = ResourceCulture.GetValue("Add");
            btnReset.UIText = ResourceCulture.GetValue("Reset");
            grbCurrentUser.Text = ResourceCulture.GetValue("SelectedUser");
            labUserCur.Text = ResourceCulture.GetValue("UserName");
            labPasswordCur.Text = ResourceCulture.GetValue("Password");
            labAuthCur.Text = ResourceCulture.GetValue("Auth");
            btnUpdate.UIText = ResourceCulture.GetValue("Update");
            btnModify.UIText = ResourceCulture.GetValue("Modify");
            btnDelete.UIText = ResourceCulture.GetValue("Delete");
            chkShowPassword.Text = ResourceCulture.GetValue("Show");

            cmbAuth.Items.Clear();
            cmbCurAuth.Items.Clear();

            auths = new object[] { ResourceCulture.GetValue("Operator"), ResourceCulture.GetValue("Admin") };
            cmbAuth.Items.AddRange(auths);
            cmbCurAuth.Items.AddRange(auths);

            cmbAuth.SelectedIndex = 0;
            cmbCurAuth.SelectedIndex = 0;
        }

        private void Init()
        {
            //设定按字体来缩放控件  
            //this.AutoScaleMode = AutoScaleMode.Font;
            ////设定字体大小为12px       
            //this.Font = new Font("Tahoma", 15F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(134)));

            //锁定列头
            foreach (DataGridViewColumn column in dgvUsersInfo.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            m_sqlSelectAll = "select ID,EmpNo,Name,Password,Auth from users";
            m_dbColunmNames = "ID,EmpNo,Name,Password,Auth";

        }

        private void SetDGVStyle()
        {
            if (dgvUsersInfo.Rows.Count != 0)
            {
                for (int i = 0; i < dgvUsersInfo.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        dgvUsersInfo.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        dgvUsersInfo.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(224, 254, 254);
                    }
                }
            }
        }

        private void LoadUsersInfo()
        {
            dgvUsersInfo.Rows.Clear();

            //m_usersTable = new DataTable();

            m_usersTable = m_main.DbTool.SelectTable(m_sqlSelectAll);

            try
            {
                if (m_usersTable != null)
                {
                    foreach (DataRow rows in m_usersTable.Rows)
                    {
                        dgvUsersInfo.Rows.Add(rows.ItemArray);
                    }
                    SetDGVStyle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                m_main.LogNetProgramer.WriteDebug("用户信息加载异常", ex.Message);
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (cmbAuth.SelectedItem == null)
            {
                MessageBox.Show("不支持剪切功能！");
                return;
            }

            string empNo = txtEmpNo.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string auth = cmbAuth.SelectedItem.ToString();

            if (!m_main.CheckUserAuth())
            {
                return;
            }

            if (String.IsNullOrEmpty(empNo))
            {
                MessageBox.Show(ResourceCulture.GetValue("EmpNoEmpty"));
                return;
            }
            else if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show(ResourceCulture.GetValue("UserNameNoEmpty"));
                return;
            }
            else if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show(ResourceCulture.GetValue("PasswordNoEmpty"));
                return;
            }

            if (auth == "Operator" || auth == "操作员")
            {

            }

            //检查员工编号是否已存在
            string ifexist = "select * from Users where EmpNo = '" + empNo + "'";
            int type = m_main.DbTool.IsExist(ifexist);
            if (type == 1)
            {
                MessageBox.Show(ResourceCulture.GetValue("TheEmpNoExist"));
                return;
            }

            //检查此用户名是否已存在
            User user = m_main.DbTool.SelectUserByName(name);
            if (user != null)
            {
                MessageBox.Show(ResourceCulture.GetValue("TheUserNameExist"));
                return;
            }

            string sql = "insert into users(EmpNo,Name,Password,Auth) values(@empNo,@name,@pass,@auth)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@empNo",SqlDbType.NVarChar){Value = empNo},
                new SqlParameter("@name",SqlDbType.NVarChar){Value = name},
                new SqlParameter("@pass",SqlDbType.NVarChar){Value = password},
                new SqlParameter("@auth",SqlDbType.NVarChar){Value = auth},
            };

            int res = m_main.DbTool.TransactionTable(sql, parameters);

            if (res > 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveSuccess"));
                LoadUsersInfo();
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveFail"));
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmpNo.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbAuth.SelectedIndex = 0;
        }

        private void GetFocusUser()
        {
            if (dgvUsersInfo.CurrentRow.Index < dgvUsersInfo.Rows.Count - 1)
            {
                int indexName = dgvUsersInfo.Columns["colName"].Index;
                int indexPassword = dgvUsersInfo.Columns["colPassword"].Index;
                int indexAuth = dgvUsersInfo.Columns["colAuth"].Index;

                string name = dgvUsersInfo.Rows[dgvUsersInfo.CurrentRow.Index].Cells[indexName].Value.ToString(); ;
                string password = dgvUsersInfo.Rows[dgvUsersInfo.CurrentRow.Index].Cells[indexPassword].Value.ToString();
                string auth = dgvUsersInfo.Rows[dgvUsersInfo.CurrentRow.Index].Cells[indexAuth].Value.ToString();

                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password))
                {
                    MessageBox.Show(ResourceCulture.GetValue("UserNameNoEmpty"), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                if (String.IsNullOrEmpty(auth))
                {
                    MessageBox.Show("请输入用户权限(操作员/管理员)！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                m_currentUser = new User();
                m_currentUser.Name = name;
                m_currentUser.Password = password;
                m_currentUser.Auth = auth;

                txtNameInfo.Text = name;
                txtPasswordInfo.Text = password;
                cmbCurAuth.Text = auth;
            }
        }

        private void dgvUsersInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetFocusUser();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!m_main.CheckUserAuth() || m_currentUser == null)
            {
                return;
            }

            if (m_currentUser.Name.EndsWith("Admin"))
            {
                MessageBox.Show(ResourceCulture.GetValue("AdminCanNotDelete"));
                return;
            }

            string name = txtNameInfo.Text;

            DialogResult result = MessageBox.Show(ResourceCulture.GetValue("IfSureDelete"), "提示", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {

                User user = m_main.DbTool.SelectUserByName(name);
                if (user != null)
                {
                    string sql = "delete from users where name='" + name + "'";

                    int res = m_main.DbTool.TransactionTable(sql);

                    if (res > 0)
                    {
                        MessageBox.Show(ResourceCulture.GetValue("DeleteOK"));
                        LoadUsersInfo();
                        GetFocusUser();
                    }
                    else
                    {
                        MessageBox.Show(ResourceCulture.GetValue("DeleteFail"));
                    }
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (cmbCurAuth.SelectedItem == null)
            {
                MessageBox.Show("不支持剪切功能！");
                return;
            }

            string name = txtNameInfo.Text;
            string password = txtPasswordInfo.Text;
            string auth = cmbCurAuth.SelectedItem.ToString();
            string id = dgvUsersInfo.Rows[dgvUsersInfo.CurrentRow.Index].Cells[0].Value.ToString();

            if (!m_main.CheckUserAuth() || m_currentUser == null)
            {
                return;
            }

            if (m_currentUser.Name.EndsWith("Admin"))
            {
                MessageBox.Show(ResourceCulture.GetValue("AdminNotModify"));
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(ResourceCulture.GetValue("UserNameNoEmpty"));
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(ResourceCulture.GetValue("PasswordNoEmpty"));
                return;
            }

            string sql = "update users set Name=@name,Password=@pass,Auth=@auth where ID=@id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.NVarChar){Value = name},
                new SqlParameter("@pass",SqlDbType.NVarChar){Value = password},
                new SqlParameter("@auth",SqlDbType.NVarChar){Value = auth},
                new SqlParameter("@id",SqlDbType.Int){Value = id},
            };

            int res = m_main.DbTool.TransactionTable(sql, parameters);

            if (res > 0)
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveSuccess"));
                LoadUsersInfo();
                GetFocusUser();
            }
            else
            {
                MessageBox.Show(ResourceCulture.GetValue("SaveFail"));
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            m_usersTable = m_main.DbTool.SelectTable(m_sqlSelectAll);
            LoadUsersInfo();
            GetFocusUser();
        }

        private void cmbAuthInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            if (chkShowPassword.Checked)//显示
            {
                txtPassword.PasswordChar = new char();
                chkShowPassword.Text = ResourceCulture.GetValue("Hide");
            }
            else//隐藏
            {
                txtPassword.PasswordChar = '*';
                chkShowPassword.Text = ResourceCulture.GetValue("Show");
            }

        }
    }
}
