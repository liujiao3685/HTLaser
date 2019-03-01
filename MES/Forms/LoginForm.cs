using System;
using System.Windows.Forms;
using MES.Core;
using MES.DAL;
using MES.Entity;
using ProductManage.Language.MyLanguageTool;

namespace MES.UI
{
    public partial class LoginForm : Form
    {
        private string m_name;
        private string m_password;
        public string Password { set { m_password = value; } }

        public delegate void LoginResultHandle(object sender, MyEvent e);

        public event LoginResultHandle LoginResultEvent;

        public User CurrentUser;

        private FormMain m_main;

        public int m_culture = 1;

        public void OnLoginResult(object sender, MyEvent e)
        {
            LoginResultEvent?.Invoke(sender, e);
        }

        private DBTool m_dbtool;

        public LoginForm()
        {
            InitializeComponent();
            m_culture = AppSetting.GetLanguage();
            CultureChange();
        }

        public LoginForm(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            m_culture = main.Culture;
            if (main.UseLanguage == 1) CultureChange();
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
            Text = ResourceCulture.GetValue("LoginTips");
            labName.Text = ResourceCulture.GetValue("UserName");
            labPassword.Text = ResourceCulture.GetValue("Password");
            btnOK.UIText = ResourceCulture.GetValue("OK");

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
            Init();
        }

        private void Init()
        {
            m_dbtool = new DBTool();
            if (AppSetting.GetTest() != 1) txtUserName.Text = String.Empty;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            string name = txtUserName.Text;
            string password = txtPassword.Text;

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(ResourceCulture.GetValue("UserNameIsEmpty"));
                txtUserName.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(ResourceCulture.GetValue("PasswordIsEmpty"));
                txtPassword.Focus();
                return;
            }

            m_name = name;
            m_password = password;

            CurrentUser = m_dbtool.SelectUserByName(m_name);//验证用户名及密码是否正确！

            if (CurrentUser != null && CurrentUser.Password == m_password)
            {
                LoginSuccess();
                isClose = false;
                Close();
            }
            else if (CurrentUser == null || CurrentUser.Password != m_password)
            {
                LoginFailed();
                MessageBox.Show(ResourceCulture.GetValue("UserNameOrPasswordError"));
                txtPassword.Focus();
            }
        }

        public void LoginSuccess()
        {
            OnLoginResult(this, new MyEvent() { LoginResult = true, LoginUser = CurrentUser });
        }

        public void LoginFailed()
        {
            OnLoginResult(this, new MyEvent() { LoginResult = false });
        }

        private bool isClose = true;

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isClose)
            {
                LoginFailed();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClose = true;
            LoginFailed();
            Close();
        }
    }
}
