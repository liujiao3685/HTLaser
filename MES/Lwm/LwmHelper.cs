using ProductManage.TcpCommunicate;
using System;
using System.Net;
using System.Net.Sockets;

namespace ProductManage.Lwm
{
    public class LwmHelper : TcpBase
    {
        public string LwmIp = "192.168.0.60";

        public int Port = 8000;//8000;//700：控制端口

        private static readonly object locker = new object();

        public Socket LwmSocket = null;

        private static LwmHelper lwm = null;
        public static LwmHelper GetInstance()
        {
            if (lwm == null)
            {
                lock (locker)
                {
                    lwm = new LwmHelper();
                }
            }

            return lwm;
        }

        public LwmHelper()
        {

        }

        public bool Open()
        {
            try
            {
                LwmSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(LwmIp), Port);
                LwmSocket.Connect(endPoint);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Close()
        {
            return base.SafeClose(LwmSocket);
        }

    }
}
