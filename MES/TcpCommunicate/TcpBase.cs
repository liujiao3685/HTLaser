using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.TcpCommunicate
{
    public class TcpBase
    {
        public string IP { set; get; }

        public int Port { set; get; }

        public Socket Socket { set; get; }

        public IPEndPoint IPEndPoint { set; get; }

        public bool IsAsyncTcp = false;

        public bool IsClienTcp = false;

        public TcpBase()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
        }

        public bool SafeClose(Socket socket)
        {
            try
            {
                if (socket == null) return false;
                if (!socket.Connected) return false;

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket.Dispose();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


    }
}
