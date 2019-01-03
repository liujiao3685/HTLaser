using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Language
{
    /// <summary>
    /// 系统的字符串资源及多语言管理中心 ->
    /// System string resource and multi-language management Center
    /// </summary>
    public static class StringResources
    {
        /// <summary>
        /// 获取或设置系统的语言选项 ->
        /// </summary>
        public static DefaultLanguage Language = new SimpleChinese();

        static StringResources()
        {
            if (System.Globalization.CultureInfo.CurrentCulture.ToString().StartsWith("zh"))
            {
                SetSimpleChinese();
            }
            else
            {
                SetEnglish();
            }

        }

        /// <summary>
        /// 设置系统语言为英文
        /// </summary>
        public static void SetEnglish()
        {
            Language = new English();
        }

        /// <summary>
        /// 设置系统语言为简体中文
        /// </summary>
        public static void SetSimpleChinese()
        {
            Language = new SimpleChinese();
        }
    }
}
