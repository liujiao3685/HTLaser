using MES.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.UI
{
    public partial class ProgressForm : Form
    {
        public int Count { set; get; }

        public int Step { set; get; }

        public string Tips { set; get; }

        public string Accomplish { set; get; }

        public ProgressForm()
        {
            InitializeComponent();
        }
        public ProgressForm(int count)
        {
            InitializeComponent();
            Count = count;
            this.progress.Max = count;
        }
        private void ProgressForm_Load(object sender, EventArgs e)
        {
            this.labTips.Text = Tips;//"数据加载中，请稍等.....";
        }

        internal void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progress.Value = Step;
            //if (progress.Value >= Count) progress.Value = Count;
            Debug.Write("Value: " + progress.Value + "\r\n");
        }

        internal void OnProcessCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Accomplish))
                this.labTips.Text = Accomplish;
        }

    }
}
