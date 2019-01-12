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
        public TcpBase()
        {
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
                socket = null;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


    }
}
