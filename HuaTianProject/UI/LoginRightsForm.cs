using HuaTianProject.Core;
using HuaTianProject.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HuaTianProject.UserControls;

namespace HuaTianProject.UI
{
    public partial class LoginRightsForm : Form
    {
        private FormMain m_mainForm;

        private User m_user;

        private string m_name;

        private string m_password;

        private DBTool m_dbTool;

        private List<string> m_listName;

        public static string CurrencyManager = String.Empty;

        public delegate void LoginResultHandle(object sender, MyEvent e);

        public event LoginResultHandle LoginResult;

        //触发登录结果函数
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

        public LoginRightsForm(FormMain main)
        {
            InitializeComponent();
            m_mainForm = main;
        }

        private void LogonRightsForm_Load(object sender, EventArgs e)
        {
            m_listName = new List<string>();
            this.cmbUserType.Items.Clear();

            List<User> list = DBTool.GetInstance().SelectDataList("users");
            for (int i = 0; i < list.Count - 1; i++)
            {
                this.cmbUserType.Items.Add(list[i].Name);
                m_listName.Add(list[i].Name);
            }
            this.cmbUserType.SelectedIndex = 0;
            m_user = new User();
            m_dbTool = DBTool.GetInstance();//FormMain.DbTool;
            GetUserInfo();
        }

        private void GetUserInfo()
        {
            m_name = this.cmbUserType.SelectedItem.ToString();
            m_password = this.txtPassword.Text.Trim();
            m_user = m_dbTool.SelectOneData(m_name);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int index = this.cmbUserType.SelectedIndex;
            GetUserInfo();
            if (m_user == null) return;
            //正确密码
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
                        return;
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
                        return;
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
                        return;
                    }
                    break;
            }
            CurrencyManager = m_name;
        }

        private void LoginSucceed()
        {
            OnLoginResult(this, new MyEvent { Result = true });
            //MontionControlForm.Result = true;
            ShowMsg("登录成功！");
            m_mainForm.AddLog("当前用户：" + m_name, false, false);
        }

        private void ShowMsg(string msg)
        {
            m_mainForm.AddLog(msg, false, false);
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }private void ShowError(string ero)
        {
            MessageBox.Show(ero, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GetUserInfo();
            if (this.btnCancel.Text == "取消")
            {
                OnLoginResult(this, new MyEvent { Result = false });
                this.Close();
            }
            else if (this.btnCancel.Text == "管理中心" && m_password != null && m_password == m_user.Password)
            {
                EnterManageForm();
            }
            else
            {
                ShowError("密码错误！");
            }

        }

        private void EnterManageForm()
        {
            CurrencyManager = m_name;
            ManageUserForm manage = new ManageUserForm();
            manage.ShowDialog();
            this.Close();
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetUserInfo();
            if (e.KeyChar == (int)Keys.Enter && btnCancel.Text == "管理中心"
                  && m_password != null && m_password == m_user.Password)
            {
                EnterManageForm();
            }
            else if (e.KeyChar == (int)Keys.Enter && m_password != m_user.Password)
            {
                MessageBox.Show("密码错误！");
            }
        }
    }
}
