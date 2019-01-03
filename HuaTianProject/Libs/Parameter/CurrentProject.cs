using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaTianProject.Libs.Parameter
{
    public class CurrentProject
    {
        public string CurrentProjectName = "HuaTianLaser";

        private static CurrentProject m_currentProject;

        public static CurrentProject Instance
        {
            get
            {
                if (m_currentProject == null)
                {
                    m_currentProject = new CurrentProject();
                    AppLog.Instance().ApendLog("new CurrentProject");
                }
                return m_currentProject;
            }
        }

    }
}
