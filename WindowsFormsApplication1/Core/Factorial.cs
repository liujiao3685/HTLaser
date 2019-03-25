using System.Collections.Generic;
using System.Text;

// 算法：阶乘类   
//   
// 版权所有(C) Snowdust   
// 个人博客    http://blog.csdn.net/snwodust & http://snowdust.cnblogs.com   
// MSN & Email snwodust77@sina.com   
//   
// 此源代码可免费用于各类软件（含商业软件）   
// 允许对此代码的进一步修改与开发   
// 但必须完整保留此版权信息   
//   
// 调用方法如下：   
// int num = 10000;   
// Arithmetic.Factorial f = new Arithmetic.Factorial(num);   
// List<int> result = f.Calculate();   
// String ret = f.ToString();   
// 返回结果：result为100000进制表示的范型，ret为转换成十制制的字符串   
//   
// 版本历史：   
// V0.1 2010-03-17 摘要：首次创建    
//   
//-----------------------------------------------------------------------------   

namespace Arithmetic
{
    public class Factorial
    {
        #region 定义属性   
        /// <summary>   
        /// 进制   
        /// </summary>   
        private int m_BaseNumber = 100000;
        public int BaseNumber
        {
            get
            {
                return m_BaseNumber;
            }
        }

        /// <summary>   
        /// 待求阶乘的数   
        /// </summary>   
        private int m_Number;

        /// <summary>   
        /// 结果   
        /// </summary>   
        private List<int> m_Result = new List<int>();
        #endregion

        #region 构造函数   
        /// <summary>   
        /// 构造函数   
        /// </summary>   
        /// <param name="n">待求阶乘的数</param>   
        public Factorial(int n)
        {
            m_Number = n;
            m_Result = new List<int>();
        }
        #endregion

        #region 方法   

        /// <summary>   
        /// 计算阶乘   
        /// </summary>   
        /// <returns>结果范型</returns>   
        public List<int> Calculate()
        {
            int digit = (int)System.Math.Log10(m_BaseNumber);
            int len = (int)(m_Number * System.Math.Log10((m_Number + 1) / 2)) / digit;//计算n!有数数字的个数    
            len += 2; //保险起见，加长2位   

            int[] a = new int[len];
            int i, j;
            long c;
            int m = 0;

            a[0] = 1;
            for (i = 2; i <= m_Number; i++)
            {
                c = 0;
                for (j = 0; j <= m; j++)
                {
                    long t = a[j] * i + c;
                    c = t / m_BaseNumber;
                    a[j] = (int)(t % m_BaseNumber);
                }
                while (c > 0)
                {
                    m++;
                    a[m] = (int)(c % m_BaseNumber);
                    c = c / m_BaseNumber;
                }
            }
            for (i = 0; i <= m; i++)
            {
                m_Result.Add(a[i]);
            }
            return m_Result;
        }

        /// <summary>   
        /// 重写ToString方法   
        /// </summary>   
        /// <returns>结果字符串</returns>   
        public override string ToString()
        {
            if (m_Result.Count == 0)
            {
                Calculate();
            }
            StringBuilder sb = new StringBuilder();
            int digit = (int)System.Math.Log10(m_BaseNumber);
            sb.Append(m_Result[m_Result.Count - 1]);
            for (int i = m_Result.Count - 2; i >= 0; i--)
            {
                sb.Append(m_Result[i].ToString().PadLeft(digit, '0'));
            }
            return sb.ToString();
        }
        #endregion
    }
}