using HslCommunication.BasicFramework;
using MES.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MES.BasicFramework
{
    /// <summary>
    /// 一个软件基础类，提供常用的一些静态方法
    /// </summary>
    public class SoftBasic
    {

        #region 软件权限检测

        public static DateTime SelectSysTime(int useDays = 0)
        {
            string sql = String.Format(" Select StorageTime+{0} from Product order by StorageTime ", useDays);
            object obj = DBTool.Instance.SelectObject(sql);
            if (obj != null)
                return Convert.ToDateTime(obj);
            return Convert.ToDateTime("1000-01-01 13:16:41.650");
        }

        /// <summary>
        /// 检测软件是否授权
        /// </summary>
        public static void CheckSoftAuthorize()
        {
            SoftAuthorize m_softAuthorize = new SoftAuthorize();

            //方式一
            m_softAuthorize.FileSavePath = Application.StartupPath + @"\Authorize.sys"; //存储激活码文件，存储加密
            m_softAuthorize.LoadByFile();

            // 检测激活码是否正确，没有文件，或激活码错误都算作激活失败
            if (!m_softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
            {
                //显示注册窗口
                using (FormAuthorize form = new FormAuthorize(m_softAuthorize, "请填写注册码！", AuthorizeEncrypted))
                {
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        //授权失败，退出应用程序
                        Application.Exit();
                    }
                }
            }

            //方式二 :直接进行判断授权码
            //if (!m_softAuthorize.CheckAuthorize("4408B6C4F17EF79B0210F997771C1E5FBA75748F5DD9DD3C59B9E69FCE05DAF5", AuthorizeEncrypted))
            //{
            //    //授权失败！
            //    Application.Exit();
            //}
        }

        /// <summary>
        /// 自定义加密算法，传入原始数据，返回加密结果
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>加密结果</returns>
        public static string AuthorizeEncrypted(string origin)
        {
            //DES对称加密
            string license = SoftSecurity.MD5Encrypt(origin, "CSTLASER");
            return license;
        }

        #endregion

        public static int BytesToInt(byte[] bytes)
        {
            int i = BitConverter.ToInt32(bytes, 0);
            return i;
        }

        /// <summary>
        /// Int 转成 byte[]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static byte[] IntToBytes(int i)
        {
            byte[] buf = BitConverter.GetBytes(i);
            return buf;
        }


        /// <summary>
        /// 获取一个枚举类型的所有枚举值，可直接应用于组合框数据
        /// </summary>
        /// <typeparam name="TEnum">枚举的类型值</typeparam>
        /// <returns></returns>
        public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        #region Hex string and Byte[] transform

        /// <summary>
        /// 字节数据转化成16进制表示的字符串 ->
        /// Byte data into a string of 16 binary representations
        /// </summary>
        /// <param name="InBytes">字节数组</param>
        /// <returns>返回的字符串</returns>
        public static string ByteToHexString(byte[] InBytes)
        {
            return ByteToHexString(InBytes, (char)0);
        }

        /// <summary>
        /// 字节数据转化成16进制表示的字符串 ->
        /// Byte data into a string of 16 binary representations
        /// </summary>
        /// <param name="InBytes">字节数组</param>
        /// <param name="segment">分割符</param>
        /// <returns>返回的字符串</returns>
        public static string ByteToHexString(byte[] InBytes, char segment)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte InByte in InBytes)
            {
                if (segment == 0) sb.Append(string.Format("{0:X2}", InByte));
                else sb.Append(string.Format("{0:X2}{1}", InByte, segment));
            }

            if (segment != 0 && sb.Length > 1 && sb[sb.Length - 1] == segment)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 字符串数据转化成16进制表示的字符串 ->
        /// String data into a string of 16 binary representations
        /// </summary>
        /// <param name="InString">输入的字符串数据</param>
        /// <returns>返回的字符串</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static string ByteToHexString(string InString)
        {
            return ByteToHexString(Encoding.Unicode.GetBytes(InString));
        }

        private static List<char> hexCharList = new List<char>()
        {
            '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'
        };

        /// <summary>
        /// 将16进制的字符串转化成Byte数据，将检测每2个字符转化，也就是说，中间可以是任意字符 ->
        /// Converts a 16-character string into byte data, which will detect every 2 characters converted, that is, the middle can be any character
        /// </summary>
        /// <param name="hex">十六进制的字符串，中间可以是任意的分隔符</param>
        /// <returns>转换后的字节数组</returns>
        /// <remarks>参数举例：AA 01 34 A8</remarks>
        /// <example>
        /// <code lang="cs" source="HslCommunication_Net45.Test\Documentation\Samples\BasicFramework\SoftBasicExample.cs" region="HexStringToBytesExample" title="HexStringToBytes示例" />
        /// </example>
        public static byte[] HexStringToBytes(string hex)
        {
            hex = hex.ToUpper();

            MemoryStream ms = new MemoryStream();

            for (int i = 0; i < hex.Length; i++)
            {
                if ((i + 1) < hex.Length)
                {
                    if (hexCharList.Contains(hex[i]) && hexCharList.Contains(hex[i + 1]))
                    {
                        // 这是一个合格的字节数据
                        ms.WriteByte((byte)(hexCharList.IndexOf(hex[i]) * 16 + hexCharList.IndexOf(hex[i + 1])));
                        i++;
                    }
                }
            }

            byte[] result = ms.ToArray();
            ms.Dispose();
            return result;
        }

        #endregion Hex string and Byte[] transform

        /// <summary>
        /// 强行结束应用程序
        /// </summary>
        public static void KillExe()
        {
            try
            {
                string name = Process.GetCurrentProcess().ProcessName;
                Process[] excelProc = Process.GetProcessesByName(name);
                DateTime startTime = new DateTime();
                int m, killId = 0;
                for (m = 0; m < excelProc.Length; m++)
                {
                    if (startTime < excelProc[m].StartTime)
                    {
                        startTime = excelProc[m].StartTime;
                        killId = m;
                    }
                }
                if (excelProc[killId].HasExited == false)
                {
                    excelProc[killId].Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}