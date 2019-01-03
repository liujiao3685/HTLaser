using MES;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace ProductManage.Language.MyLanguageTool
{
    public class ResourceCulture
    {
        /// <summary>
        /// 设置系统语言
        /// </summary>
        /// <param name="lang"></param>
        public static void SetCurrentCulture(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                lang = "zh-CN";
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
        }

        /// <summary>
        /// 根据名称获取资源文件的值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetValue(string name)
        {
            string curLanguage = string.Empty;

            try
            {
                ResourceManager rm = new ResourceManager("ProductManage.Properties.Resource",
                    Assembly.GetExecutingAssembly());
                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                curLanguage = rm.GetString(name, ci);

            }
            catch (System.Exception ex)
            {
                curLanguage = "No Name:" + name + ",Please Add";
                Program.LogNet.WriteError("异常", "GetValue():" + ex.Message);
            }
            return curLanguage;
        }

    }
}
