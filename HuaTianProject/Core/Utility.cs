using System;
using System.ComponentModel;
using System.Reflection;

namespace HuaTianProject.Core
{
    public class Utility
    {
        /// <summary>
        /// 获取一个枚举值的中文描述
        /// </summary>
        /// <param name="obj">枚举值</param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum obj)
        {
            FieldInfo fi = obj.GetType().GetField(obj.ToString());
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return arrDesc[0].Description;
        }

    }
}
