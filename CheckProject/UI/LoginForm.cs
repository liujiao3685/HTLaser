using System;
using System.Windows.Forms;
using MES.Core;
using MES.DAL;
using MES.Entity;

namespace MES.UI
{
    public partial class LoginForm : Form
    {
        private string m_name;
        public string Name { set { m_name = value; } }

        private string m_password;
        public string Password { set { m_password = value; } }

        public delegate void LoginResultHandle(object sender, MyEvent e);

        public event LoginResultHandle LoginResultEvent;

        public User CurrentUser;

        public void OnLoginResult(object sender, MyEvent e)
        {
            LoginResultEvent?.Invoke(sender, e);
        }

        private DBTool m_dbtool;

        public LoginForm()
        {
            InitializeComponent();
            m_dbtool = new DBTool();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            string name = txtUserName.Text;
            string password = txtPassword.Text;

            if (String.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("用户名不能为空！");
                txtUserName.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("密码不能为空！");
                txtPassword.Focus();
                return;
            }

            m_name = name;
            m_password = password;

            CurrentUser = m_dbtool.SelectUserByName(m_name);//验证用户名及密码是否正确！

            if (CurrentUser != null && CurrentUser.Password == m_password)
            {
                LoginSuccess();
                //MessageBox.Show("登录成功！");
                this.Close();
            }
            else if (CurrentUser == null || CurrentUser.Password != m_password)
            {
                LoginFailed();
                MessageBox.Show("用户名或密码错误！");
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

    }
}
