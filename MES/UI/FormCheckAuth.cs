using MES.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManage.UI
{
    public partial class FormCheckAuth : Form
    {
        private readonly string Password = "123";

        public FormCheckAuth()
        {
            InitializeComponent();
        }
        private void FormCheckAuth_Load(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text.Trim();

            if (pass.Equals(Password))
            {
                Hide();

                SpotCheckForm form = new SpotCheckForm();
                form.ShowDialog();

            }
            else
            {
                MessageBox.Show("密码错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
        }

    }
}
