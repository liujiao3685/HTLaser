using MES.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Core
{
    public class ExeHelper
    {
        private string m_autoExeName;
        public static string AutoUpdateName { get; set; }

        private static ExeHelper m_exeHelper;

        public static ExeHelper Instance
        {
            get
            {
                if (m_exeHelper == null)
                {
                    m_exeHelper = new ExeHelper();
                }
                return m_exeHelper;
            }
        }

        public ExeHelper()
        {
            
        }

        public static void AutoUpdate()
        {
            if (String.IsNullOrEmpty(AutoUpdateName)) return;

            string currentVerion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            DataTable dt = DBTool.SelectTable("select Version,AutoExeName from T_Version");
            string version = dt.Rows[0]["Version"].ToString();
            string autoExeName = dt.Rows[0]["AutoExeName"].ToString();

            if (currentVerion != version)
            {
                string exeName = Directory.GetCurrentDirectory() + @"\" + AutoUpdateName;
                if (File.Exists(exeName))
                {
                    StartExe(exeName);
                    Application.Exit();
                }
            }
        }

        public static void StartExe(string exeName)
        {
            if (String.IsNullOrEmpty(exeName)) return;

            string path = exeName;
            Process ps = new Process();
            ps.StartInfo.FileName = path;
            ps.StartInfo.Arguments = "T";
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
            ps.Start();
        }

    }
}
