using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using HslCommunication.LogNet;
using MES.UI;
using ProductManage.UI;

namespace MES
{
    static class Program
    {
        /// <summary>
        /// 语言选择：1、简体中文，2、英文
        /// </summary>
        public static int Language = 1;

        public static ILogNet LogNet = new LogNetDateTime(Application.StartupPath + @"/Logs", GenerateMode.ByEveryDay);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
            //1.1.0
            //HslControls.Authorization.SetAuthorizationCode("1557360d-6de4-445c-b669-dee903f02d4a");

            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");

            //bool isCreateNew;
            //Mutex mutex = new Mutex(true, Application.ProductName, out isCreateNew);
            //if (isCreateNew)
            //{

            Process process = Process.GetCurrentProcess();
            // 遍历应用程序的同名进程组
            foreach (Process p in Process.GetProcessesByName(process.ProcessName))
            {
                // 不是同一进程则关闭刚刚创建的进程
                if (p.Id != process.Id)
                {
                    // 此处显示原先的窗口需要一定的时间，不然无法显示
                    ShowWindowAsync(p.MainWindowHandle, 9);
                    SetForegroundWindow(p.MainWindowHandle);
                    Application.Exit(); // 关闭当前的应用程序
                    return;
                }
            }

            ThreadPool.SetMaxThreads(2000, 256);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogNet.WriteInfo("正常", "应用程序正常启动！！！");
            Application.Run(new SpotCheckForm());
            //Application.Run(new FormMain());

            //}
            //else
            //{
            //    MessageBox.Show("应用程序已运行，请勿运行多个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    LogNet.WriteInfo("应用程序已运行，请勿运行多个！");
            //    Application.Exit();
            //}
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
