using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CheckProject
{
    public partial class FormMain : Form
    {
        private Process p;

        private string exeName = "CoderMachine.exe";
        //private string exeName = Application.StartupPath + @"/CoderMachine.exe";

        public FormMain()
        {
            InitializeComponent();
        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            StartProcess();
        }

        private void StartProcess()
        {
            try
            {
                if (p == null)
                {
                    p = new Process();
                    p.StartInfo.FileName = exeName;
                    p.Start();
                    p.WaitForExit();//关键，等待外部程序退出后才能往下执行
                }
                else
                {
                    if (p.HasExited) //是否正在运行
                    {
                        p.Start();
                    }
                }

                this.Close();

                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
