using System;
using System.Windows.Forms;
using MES.Core;
using System.Threading;

namespace MES.UserControls
{
    public partial class LoadProgressBar : UserControl
    {
        public string Tips { set; get; }

        public int DataCount { set; get; }

        public delegate void AsyncUpdateUI(int step);

        public UpdateProgress update;

        public LoadProgressBar()
        {
            InitializeComponent();
        }

        private void LoadProgressBar_Load(object sender, EventArgs e)
        {
            if (DataCount == 0) return;

            this.progressBar1.Maximum = DataCount;
            this.progressBar1.Value = 0;

            update = new UpdateProgress();
            update.UpdateUIHandle += Update;
            update.TaskHandle += Accomplish;

            Thread thread = new Thread(new ParameterizedThreadStart(update.Update));
            thread.IsBackground = true;
            thread.Start(DataCount);

        }

        public void Update(int step)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsyncUpdateUI(delegate (int s)
                {
                    this.progressBar1.Value += s;
                }
                ), step);
            }
            else
            {
                this.progressBar1.Value += step;
            }
        }

        public void Accomplish()
        {
            //MessageBox.Show("更新完成！");
        }

        private void labTips_VisibleChanged(object sender, EventArgs e)
        {
            this.labTips.Text = Tips;//"数据加载中，请稍等.....";
        }
    }
}
