using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CoderMachine.Core
{
    public static class StructHelper
    {

        /// <summary>
        /// byte数组转目标结构体
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="type">目标结构体类型</param>
        /// <returns>目标结构体</returns>
        public static T ByteToStuct<T>(byte[] DataBuff_) where T : struct
        {
            Type t = typeof(T);
            //得到结构体大小
            int size = Marshal.SizeOf(t);
            //数组长度小于结构体大小
            if (size > DataBuff_.Length)
            {
                return default(T);
            }

            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组cpoy到分配好的内存空间内
            Marshal.Copy(DataBuff_, 0, structPtr, size);
            //将内存空间转换为目标结构体
            T obj = (T)Marshal.PtrToStructure(structPtr, t);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        /// <summary>
        /// 结构体转byte数组
        /// </summary>
        /// <param name="objstuct">结构体</param>
        /// <returns>byte数组</returns>
        public static byte[] StuctToByte(object objstuct)
        {
            //得到结构体大小
            int size = Marshal.SizeOf(objstuct);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体copy到分配好的内存空间内
            Marshal.StructureToPtr(objstuct, structPtr, false);
            //从内存空间copy到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }

        /// <summary>
        /// 将字符串转为固定长度char数组
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static char[] GetFixLengthChar(this string s, int length)
        {
            char[] chaVal = new char[length];
            Array.Copy(s.PadRight(length, '\0').ToCharArray(), chaVal, length);
            return chaVal;
        }

        public static string GetString(this char[] cc)
        {
            return GetString(cc, true);
        }

        /// <summary>
        /// 从char数组转为字符串，因为有'\0'可以用TrimEnd函数去掉，这样字符串后面就不会有一排空的
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="isTrimEnd"></param>
        /// <returns></returns>
        public static string GetString(this char[] cc, bool isTrimEnd)
        {
            if (isTrimEnd)
            {
                return new string(cc).TrimEnd('\0');
            }
            else
            {
                return new string(cc);
            }
        }

        public static string ByteToHexString(byte[] InBytes)
        {
            return ByteToHexString(InBytes, (char)0);
        }

        /// <summary>
        /// 字节数据转化成16进制表示的字符串
        /// </summary>
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

        /// 从字符串转换到16进制表示的字符串
        /// 编码,如"utf-8","gb2312"
        /// 是否每字符用逗号分隔
        public static string ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//空格
                         //throw new ArgumentException("s is not valid chinese string!");
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X}", bytes[i]);
                if (fenge && (i != bytes.Length - 1))
                {
                    str += string.Format("{0}", ",");
                }
            }
            return str.ToLower();
        }

        /// 从16进制转换成utf编码的字符串
        /// 编码,如"utf-8","gb2312"
        public static string UnHex(string hex, string charset)
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("\n", "");
            hex = hex.Replace("\\", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格
                throw new ArgumentException("hex is not a valid number!", "hex");
            }
            // 需要将 hex 转换成 byte 数组。
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message.
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }

    }
}
