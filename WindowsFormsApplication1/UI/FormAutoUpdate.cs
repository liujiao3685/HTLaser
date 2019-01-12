using MES.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Core;

namespace WindowsFormsApplication1.UI
{
    public partial class FormAutoUpdate : Form
    {
        public FormAutoUpdate()
        {
            InitializeComponent();
        }

        private void FormAutoUpdate_Load(object sender, EventArgs e)
        {

        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            ExeHelper.AutoUpdateName = Assembly.GetExecutingAssembly().GetName().Version + @"\123.exe";
            ExeHelper.AutoUpdate();
        }
    }
}
