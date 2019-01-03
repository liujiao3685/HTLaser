using System;
using System.Configuration;

namespace CheckProject
{
    public class AppSetting
    {
        public static string Get()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["Cipher"];
                bool b = Convert.ToBoolean(value);

            }
            catch (Exception ex)
            {
                value = null;
            }

            return value;
        }

        public static void UpdateAppSetting(string nodeName, string value)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //添加节点
            //cfg.AppSettings.Settings.Add("key", "value");

            //修改节点
            cfg.AppSettings.Settings[nodeName].Value = value;

            cfg.Save();

            //刷新命名节，在下次检索它时将从磁盘重新读取它。记住应用程序要刷新节点
            ConfigurationManager.RefreshSection("appSettings");

        }

    }
}
