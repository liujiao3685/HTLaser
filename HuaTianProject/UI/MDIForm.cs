using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaTianProject.UI
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            string point = txtPoint.Text.Trim();
            if (String.IsNullOrEmpty(point))
            {
                MessageBox.Show("点位名称不能为空！");
                return;
            }

            cmbLocation.Items.Add(point);

        }
    }
}
