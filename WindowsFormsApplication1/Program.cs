using System;
using System.Windows.Forms;
using HslControls;
using WindowsFormsApplication1.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //激活码：16e0ce1e-ce2a-4317-bf96-757f76262d0e
            Authorization.SetAuthorizationCode("16e0ce1e-ce2a-4317-bf96-757f76262d0e");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormTimerDelete());

        }
    }
}
