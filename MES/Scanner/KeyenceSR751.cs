using ProductManage.TcpCommunicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Scanner
{
    public class KeyenceSR751 : TcpBase
    {
        public static string Ip = "192.168.0.78";

        public static int Port = 9004;

        public Socket ScanSocket;

        private static KeyenceSR751 sR751;
        public static KeyenceSR751 GetInstance()
        {
            if (sR751 == null)
            {
                sR751 = new KeyenceSR751(Ip, Port);
            }
            return sR751;
        }

        public KeyenceSR751(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }

        public bool Open()
        {
            try
            {
                ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Ip), Port);
                ScanSocket.Connect(endPoint);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Close()
        {
            return base.SafeClose(ScanSocket);
        }


    }
}
