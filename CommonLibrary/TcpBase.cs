using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class TcpBase
    {
        private Socket Client;

        private string Ip;

        private int Port;

        //通知一个或多个正在等待的线程已发生事件
        public ManualResetEvent TimeOutEvent;

        public bool IsConn;

        public TcpBase()
        {

        }

        public Socket CreateSocket(string ip, int port)
        {
            Ip = ip;
            Port = port;
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsConn = false;
            TimeOutEvent = new ManualResetEvent(false);
            return Client;
        }

        public bool Connect(int timeOut)
        {
            if (Client == null) return false;

            Client.BeginConnect(Ip, Port, new AsyncCallback(CallBackMethod), Client);

            //阻止当前线程，直到ManualResetEvent对象被set或者超过timeout时间
            //waitone收到信号返回true，否则返回false
            if (!TimeOutEvent.WaitOne(timeOut, false))
            {
                Client.Close();
            }

            return IsConn;
        }

        public void CallBackMethod(IAsyncResult ar)
        {
            try
            {
                Client = ar.AsyncState as Socket;
                if (Client != null)
                {
                    Client.EndConnect(ar);
                    IsConn = true;
                }

            }
            catch (Exception)
            {
                IsConn = false;
            }
            finally
            {
                TimeOutEvent.Set();//解除被阻塞的连接线程
            }

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
