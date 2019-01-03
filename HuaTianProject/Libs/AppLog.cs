using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HuaTianProject.Libs
{
    public class AppLog
    {
        private static object myobj = new object();

        private static AppLog appLog;

        private StreamFile m_logFile;

        private string LogFilePath = String.Empty;

        private bool IsInit = false;//日志文件是否初始化成功

        public static AppLog Instance()
        {
            lock (myobj)
            {
                if (appLog == null)
                {
                    appLog = new AppLog();
                }
                return appLog;
            }
        }

        public void InitLogPath()
        {
            string appPath = Application.StartupPath;
            DateTime time = DateTime.Now;

            LogFilePath = appPath + "\\Log";
            if (!Directory.Exists(LogFilePath)) Directory.CreateDirectory(LogFilePath);
            LogFilePath = LogFilePath + "\\Log_" + time.Month + "-" + time.Day + ".txt";

            m_logFile = new StreamFile(LogFilePath, false);

            if (m_logFile != null)
            {
                IsInit = true;
            }
        }

        public bool ApendLog(string log)
        {
            if (!IsInit)
            {
                return false;
            }

            string stime = DateTime.Now.ToString();
            log = stime + " ," + log;
            bool result = m_logFile.AppendText(log);

            return result;
        }

        public List<string> ReadLog()
        {
            List<string> list = m_logFile.ReadText();

            return list;
        }

    }
}
