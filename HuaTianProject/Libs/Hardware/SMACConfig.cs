using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HuaTianProject.Libs.Hardware
{
    public class SMACConfig
    {
        //存储执行步骤的字典
        public Dictionary<string, string> StepDictionary = new Dictionary<string, string>();

        private static object obj = new object();

        private static SMACConfig m_smacConfig;

        private SMACConfig()
        {
        }

        public static SMACConfig Instance()
        {
            lock (obj)
            {
                if (m_smacConfig == null)
                {
                    m_smacConfig = new SMACConfig();
                }
                return m_smacConfig;
            }
        }

        public string ConfigPath { get; set; }  //配置的全路径  ;;注意：一定要在调用 ReadConfig() 前设置值；
        public void ReadConfig()
        {
            if (StepDictionary.Count != 0) StepDictionary.Clear();

        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        /// <param name="path"></param>
        public void InitFilePath(string path)
        {
            //ConfigPath = path + "SmacConfig.xml";
            //AppLog.Instance().ApendLog("Init SettingData FilePath：" + ConfigPath);
        }
    }
}
