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
    public partial class FormQuitWithPwd : Form
    {
        /** USE DEMO
         * 
         *      FormQuitWithPwd inputBox = new FormQuitWithPwd("请输入退出系统的确认密码:", "退出确认");
                DialogResult dr = inputBox.ShowDialog();
                if (dr == DialogResult.OK && inputBox.Value.Length > 0)
                {
                    if (inputBox.Value == "123")
                    {
                        Dispose();
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("密码不正确!", "退出确认");
                        e.Cancel = true;
                    }
                }
         * 
         * */

        public string Value { set; get; }

        public FormQuitWithPwd()
        {
            InitializeComponent();
        }

        public FormQuitWithPwd(string labTip, string title)
        {
            InitializeComponent();
            Text = title;
            label1.Text = labTip;
        }

        private void FormWithPwd_Load(object sender, EventArgs e)
        {
            txtValue.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Value = txtValue.Text.Trim();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
