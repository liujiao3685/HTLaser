using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderMachine
{
    public class AppSetting
    {
        /// <summary>
        /// 获取数据库连接字符
        /// </summary>
        /// <returns></returns>
        public static string GetConnectString()
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
