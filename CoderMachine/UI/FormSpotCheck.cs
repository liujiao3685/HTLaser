using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoderMachine.UI
{
    public partial class FormSpotCheck : Form
    {
        public FormSpotCheck()
        {
            InitializeComponent();
        }

        private void userButton1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("点检成功！");

            Hide();

            FormMain main = new FormMain(this);
            main.Show();



        }
    }
}
