using System;
using System.Configuration;
using System.Windows.Forms;

namespace MES
{
    public class AppSetting
    {
        private static string m_systemFile = Application.ExecutablePath;

        private static Configuration m_config;

        static AppSetting()
        {
            m_config = ConfigurationManager.OpenExeConfiguration(m_systemFile);
        }

        /// <summary>
        /// 获取系统语言
        /// </summary>
        /// <returns></returns>
        public static int GetTest()
        {
            int val = 0;
            try
            {
                val = Convert.ToInt32(ConfigurationManager.AppSettings["Test"]);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return val;
        }

        /// <summary>
        /// 设置系统语言
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static bool SetLanguage(int lang)
        {
            try
            {
                SetAppSettingValue("Language", lang.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更改配置文件的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetAppSettingValue(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(m_systemFile);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取系统语言
        /// </summary>
        /// <returns></returns>
        public static int GetLanguage()
        {
            int val = 0;
            try
            {
                val = Convert.ToInt32(ConfigurationManager.AppSettings["Language"]);
            }
            catch (Exception ex)
            {
                return 1;
            }
            return val;
        }

        /// <summary>
        /// 获取LWMIP
        /// </summary>
        /// <returns></returns>
        public static string GetLwmIP()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["LwmIP"];
            }
            catch (Exception ex)
            {
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取扫描枪IP
        /// </summary>
        /// <returns></returns>
        public static string GetScanIP()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["ScanIP"];
            }
            catch (Exception ex)
            {
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取扫描枪端口号
        /// </summary>
        /// <returns></returns>
        public static string GetScanPort()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["ScanPort"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取视觉服务器地址
        /// </summary>
        /// <returns></returns>
        public static string GetVisionPath()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["VisionPath"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取焊接工作站名称
        /// </summary>
        /// <returns></returns>
        public static string GetStationName()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["StationName"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取设备自检时间间隔
        /// </summary>
        /// <returns></returns>
        public static int GetCheckInterval()
        {
            int val = 0;
            try
            {
                val = Convert.ToInt32(ConfigurationManager.AppSettings["CheckInterval"]);
            }
            catch (Exception)
            {
                return 0;
            }
            return val;
        }

        /// <summary>
        /// 获取PLC服务器IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetPLCIP()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["PLCIP"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取日志路径
        /// </summary>
        /// <returns></returns>
        public static string GetLogPath()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["LogPath"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取连接PLC的用户名密码
        /// </summary>
        /// <returns></returns>
        public static string GetOPCUserPwd()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["PLC_OPC_UserPwd"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取连接PLC的用户名
        /// </summary>
        /// <returns></returns>
        public static string GetOPCUser()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["PLC_OPC_User"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取连接PLC的IP地址及端口号
        /// </summary>
        /// <returns></returns>
        public static string GetOPCAddress()
        {
            string value = string.Empty;

            try
            {
                value = ConfigurationManager.AppSettings["PLC_OPC_Address"];
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return string.Empty;
            }
            return value;
        }

        /// <summary>
        /// 获取数据库连接字符
        /// </summary>
        /// <returns></returns>
        public static string GetDbConnectString()
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.ConnectionStrings["MyDatabase"].ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            return value;
        }
    }
}