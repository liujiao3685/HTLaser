using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class TxtRWForm : Form
    {
        public TxtRWForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("G00 X: 150.000, Y: 150.415, Z: 0.000");
            this.listBox1.Items.Add("G01 X: 220.000, Y: 330.415, Z: 43.000");

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存文件";
            dialog.Filter = "文本 |*.txt|所有文件 |*.*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Application.StartupPath;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                string fileName = dialog.FileName;
                string[] rlines = new string[8];
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    rlines[i] = Convert.ToString(listBox1.Items[i]);
                }

                File.WriteAllLines(fileName, rlines);

            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            string[] lines = new[] { "Set V:20", "G00 X:150.000,Y:150.415,Z:0.000", "G11 0" };

            System.IO.File.WriteAllLines(@Application.StartupPath + "\\文本.txt", lines);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "选择文件";
            dialog.Filter = "文本 |*.txt|所有文件 |*.*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Application.StartupPath;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                string fileName = dialog.FileName;
                string[] rlines = File.ReadAllLines(fileName);
                for (int i = 0; i < rlines.Length; i++)
                {
                    if (i == rlines.Length - 1)
                    {
                        this.listBox1.Items.Add(rlines[i]);
                    }
                    else
                    {
                        this.listBox1.Items.Add(rlines[i] + "\r");
                    }
                }
            }


        }
    }
}
