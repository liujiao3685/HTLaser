using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApplication1.Core;

namespace WindowsFormsApplication1.UI
{
    public partial class FormIniFile : Form
    {
        DateTime[] dates = new DateTime[10];

        public FormIniFile()
        {
            InitializeComponent();
        }

        private void FormIniFile_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath + "\\Configs";
            dialog.Title = "选择文件";
            dialog.Filter = "配置文件|*.ini";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.FileName;

                OperateIniFile operateIniFile = new OperateIniFile();
                operateIniFile.LoadIniFile(dialog.FileName);

                foreach (var sections in operateIniFile.Items)
                {
                    string section = sections.Key;
                    Dictionary<string, string> values = sections.Value;

                    foreach (var item in values)
                    {
                        lstKeys.Items.Add(item.Key);
                        string[] vals = item.Value.Split(',');
                        lstValues.Items.Add(vals[1]);
                    }
                }

            }

        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtPath.Text.Substring(3, 3));

            //for (int i = 0; i < dates.Length; i++)
            //{
            //    DateTime d = dates[i];
            //    if (d == DateTime.MinValue)
            //    {
            //        DateTime d2 = d.AddSeconds(1.05 + i);
            //        bool boo = true;
            //    }
            //}
        }

    }
}
