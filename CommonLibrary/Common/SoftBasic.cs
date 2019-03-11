using System;
using System.Net.NetworkInformation;
using System.Text;

namespace CommonLibrary.Common
{
    public class SoftBasic
    {
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
    }
}
