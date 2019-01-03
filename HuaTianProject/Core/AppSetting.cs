using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HuaTianProject.Core
{
    public class AppSetting
    {
        /// <summary>
        /// 获取测试数字
        /// </summary>
        /// <returns></returns>
        public static double GetIntValue()
        {
            string value = ConfigurationManager.AppSettings["TestNum"];
            if (String.IsNullOrEmpty(value))
            {
                return Double.NaN;
            }
            else
            {
                return Double.Parse(value);
            }
        }

        /// <summary>
        /// 获取测试数据
        /// </summary>
        /// <returns></returns>
        public static string GetTestValue()
        {
            string value = ConfigurationManager.AppSettings["Test"];
            return value;

        }

    }
}
