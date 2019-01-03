using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ResourceCulture.SetCurrentCulture("zh-CN");

            SetResourceCulture();

        }

        private void SetResourceCulture()
        {
            Text = ResourceCulture.GetString("FormMain");

            labName.Text = ResourceCulture.GetString("Name");
            labPass.Text = ResourceCulture.GetString("Password");

            btnChinese.Text = ResourceCulture.GetString("Chinese");
            btnEnglish.Text = ResourceCulture.GetString("English");

            btnLogin.Text = ResourceCulture.GetString("Login");
            btnReset.Text = ResourceCulture.GetString("Reset");

        }

        private void btnChinese_Click(object sender, EventArgs e)
        {
            ResourceCulture.SetCurrentCulture("zh-CN");
            SetResourceCulture();
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            ResourceCulture.SetCurrentCulture("en-US");
            SetResourceCulture();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            float f;
            //str  = Convert.ToDecimal(str).ToString("0.00");

            double d = Math.Round(Convert.ToDouble(str), 2);

            f = (float)(d);

            textBox3.Text = f.ToString();

        }
    }
}
