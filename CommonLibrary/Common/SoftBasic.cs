using CommonLibrary.Log;
using HslCommunication.BasicFramework;
using SQLServerDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CommonLibrary.Common
{
    public class SoftBasic
    {
        public static void ShowMoniorExe()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "MonitorDevice.exe");
            Process splashProcess = null;
            try
            {
                splashProcess = Process.Start(fileName);
            }
            catch (Win32Exception ex)
            {
                Log.LogHelper.WriteLog("启动设备监控程序失败：", ex);
            }
        }

        #region 邮件功能
        private static string IsOpenSendMail = ConfigurationManager.AppSettings["IsOpenSendMail"]; //是否启用异常消息发送邮箱功能
        private static string SendUser = ConfigurationManager.AppSettings["MailUserName"];
        private static string SendPass = ConfigurationManager.AppSettings["MailPassword"];
        private static string ReceiveMail = ConfigurationManager.AppSettings["ReceiveMail"];
        private static string MailHost = ConfigurationManager.AppSettings["MailHost"]; //smtp.gmail.com
        private static string MailPort = ConfigurationManager.AppSettings["MailPort"]; //Gmail的smtp端口587
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailName">标题</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码</param>
        /// <param name="isBodyHtml">是否Html</param>
        /// <param name="enableSsl">是否SSL加密连接</param>
        /// <returns>是否成功</returns>
        /// <returns></returns>
        public static void SendMail(string mailName, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = true)
        {
            try
            {
                if (!string.IsNullOrEmpty(IsOpenSendMail) && IsOpenSendMail == "开启")
                {
                    MailMessage message = new MailMessage();
                    message.To.Add(new MailAddress(ReceiveMail)); // 接收人邮箱地址
                    message.From = new MailAddress(SendUser, mailName);
                    message.BodyEncoding = Encoding.GetEncoding(encoding);
                    message.Body = body;
                    //GB2312
                    message.SubjectEncoding = Encoding.GetEncoding(encoding);
                    message.Subject = mailName;
                    message.IsBodyHtml = isBodyHtml;

                    SmtpClient smtpclient = new SmtpClient(MailHost, Convert.ToInt32(MailPort)); //Gmail的smtp端口587
                    smtpclient.Credentials = new System.Net.NetworkCredential(SendUser, SendPass);
                    smtpclient.EnableSsl = enableSsl; //Gmail要求SSL连接
                    smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network; //Gmail的发送方式是通过网络的方式，需要指定
                    smtpclient.Send(message);
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion


        public static bool IsPingOk(string ip = "192.168.20.101", string data = "123")
        {
            bool result = true;
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                options.DontFragment = true;

                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 10;
                //如果网络连接成功，PING就应该有返回；否则，网络连接有问题
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);
                //PingReply reply = pingSender.Send(ip);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }


        #region 软件权限检测

        public static DateTime SelectSysTime(int useDays = 0)
        {
            string sql = String.Format(" Select StorageTime+{0} from Product order by StorageTime ", useDays);
            object obj = SqlHelper.ExecuteScalar(SqlHelper.SQLServerConnectionString, System.Data.CommandType.Text, sql, null);
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
                LogHelper.WriteLog("KillExe异常", ex);
            }
        }

    }
}
