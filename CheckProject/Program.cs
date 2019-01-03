using HslCommunication.LogNet;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheckProject
{
    static class Program
    {
        private static string exeName = "HT 生产管理系统.exe";

        public static ILogNet LogNet = new LogNetDateTime(Application.StartupPath + @"/Logs", GenerateMode.ByEveryDay);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

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
                    System.Threading.Thread.Sleep(5);
                    Application.Exit(); // 关闭当前的应用程序
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //bool boo = Convert.ToBoolean(AppSetting.Get());
            //if (boo)
            //{
            //    Process.Start(exeName);
            //}
            //else
            //{
            Application.Run(new FormMesSpotCheck());
            //}

        }


        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

    }
}
