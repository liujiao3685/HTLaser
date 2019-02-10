using MES.Core;
using MES.DAL;
using MES.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HuaTianProject.UI
{
    public partial class LoginRightsForm : Form
    {
        private User m_user;

        private string m_name;

        private string m_password;

        private DbUserHelper m_dbTool;

        private List<string> m_listName;

        public static string CurrencyManager = String.Empty;

        public delegate void LoginResultHandle(object sender, MyEvent e);

        public event LoginResultHandle LoginResult;

        public void OnLoginResult(object sender, MyEvent e)
        {
            if (LoginResult != null)
            {
                LoginResult(this, e);
            }
        }

        public LoginRightsForm()
        {
            InitializeComponent();
        }

        private void LogonRightsForm_Load(object sender, EventArgs e)
        {
            m_listName = new List<string>();
            this.cmbUserType.Items.Clear();

            List<User> list = DbUserHelper.GetInstance().SelectDataList("users");
            for (int i = 0; i < list.Count - 1; i++)
            {
                this.cmbUserType.Items.Add(list[i].Name);
                m_listName.Add(list[i].Name);
            }
            this.cmbUserType.SelectedIndex = 0;
            m_user = new User();
            m_dbTool = DbUserHelper.GetInstance();//FormMain.DbTool;
            GetUserInfo();
        }

        private void GetUserInfo()
        {
            if (cmbUserType.SelectedIndex < 0 || String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return;
            }

            m_name = this.cmbUserType.SelectedItem.ToString();
            m_password = this.txtPassword.Text.Trim();
            m_user = m_dbTool.SelectOneData(m_name);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int index = this.cmbUserType.SelectedIndex;
            GetUserInfo();
            if (m_user == null) return;
            string db_pass = m_user.Password;

            if (m_user.Name == null)
            {
                ShowMsg("此用户不存在！");
                return;
            }

            if (String.IsNullOrEmpty(m_password))
            {
                ShowMsg("请输入密码！");
                return;
            }
            switch (index)
            {
                case 0:
                    if (db_pass.Equals(m_password))
                    {
                        LoginSucceed();
                        this.Close();
                    }
                    else
                    {
                        ShowError("密码错误！");
                    }
                    break;
                case 1:
                    if (db_pass.Equals(m_password))
                    {
                        LoginSucceed();
                        this.Close();
                    }
                    else
                    {
                        ShowError("密码错误！");
                    }
                    break;
                case 2:
                    if (db_pass.Equals(m_password))
                    {
                        LoginSucceed();
                        this.Close();
                    }
                    else
                    {
                        ShowError("密码错误！");
                    }
                    break;
            }
            CurrencyManager = m_name;
        }

        private void LoginSucceed()
        {
            OnLoginResult(this, new MyEvent { LoginResult = true });
            ShowMsg("登录成功！");
        }

        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowError(string ero)
        {
            MessageBox.Show(ero, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GetUserInfo();
            if (this.btnCancel.Text == "取消")
            {
                OnLoginResult(this, new MyEvent { LoginResult = false });
                this.Close();
            }
            else if (this.btnCancel.Text == "管理中心" && m_password != null && m_password == m_user.Password)
            {
                CurrencyManager = m_name;
                //进入维护界面
                //ManageUserForm manage = new ManageUserForm();
                //manage.ShowDialog();
                this.Close();
            }
            else
            {
                ShowError("密码错误！");
            }
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string user = this.cmbUserType.SelectedItem.ToString();
            if ("程序员".Equals(user) || "管理员".Equals(user))
            {
                this.btnCancel.Text = "管理中心";
            }
            else
            {
                this.btnCancel.Text = "取消";
            }
        }

        private void cmbUserType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //设置文本不可编辑
            e.Handled = true;
        }
    }
}
