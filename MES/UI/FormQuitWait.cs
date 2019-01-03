using System;
using System.Threading;
using System.Windows.Forms;

namespace MES.UI
{
    public partial class FormQuitWait : Form
    {
        private Action ActionWait { set; get; }//无返回用action，无返回用func

        private Func<string> FuncWaitString { set; get; }

        private Func<string, string> FuncWaitString2 { set; get; }

        public FormQuitWait(Func<string> func)
        {
            InitializeComponent();
            FuncWaitString = func;
        }

        public FormQuitWait(Func<string, string> func)
        {
            InitializeComponent();
            FuncWaitString2 = func;
        }


        public FormQuitWait(Action action)
        {
            InitializeComponent();
            ActionWait = action;
        }

        private void FormQuitWait_Shown(object sender, EventArgs e)
        {
            //1、
            //label1.Text = FuncWaitString();

            //2、
            //label1.Text = FuncWaitString2("Name:");

            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolAction), null);
        }

        private void ThreadPoolAction(object state)
        {
            //2、
            //Thread.Sleep(500);
            //Invoke(new Action(() =>
            //{
            //    DialogResult = DialogResult.OK;
            //}));


            //1、
            ActionWait?.Invoke();
            Thread.Sleep(1000);

            Invoke(new Action(() =>
            {
                DialogResult = DialogResult.OK;
            }));

        }
    }
}
