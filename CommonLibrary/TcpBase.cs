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
        private string IpAddress;
        private int Port;
        public bool Connected = false;
        public string Last_Error;

        public TcpBase()
        {
            Init();
        }

        public TcpBase(string ipAddress)
        {
            Init(ipAddress);
        }

        public TcpBase(string ipAddress, int port)
        {
            Init(ipAddress, port);
        }

        private void Init(string ipAddress = "", int port = 0)
        {
            try
            {
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    IpAddress = ipAddress;
                }
                if (port != 0)
                {
                    Port = port;
                }

                if (Client == null || !Client.Connected)
                {
                    IPAddress ip = IPAddress.Parse(IpAddress);
                    IPEndPoint ipe = new IPEndPoint(ip, Port);

                    Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Client.Connect(ipe);
                    Connected = true;
                }
            }
            catch (System.Exception)
            {
                Connected = false;
            }
        }

        public virtual void Send(byte[] data)
        {
            try
            {
                Client.Send(data, SocketFlags.None);
            }
            catch (Exception ex)
            {
                Last_Error = ex.Message;
                Init();
            }
        }

        public virtual byte[] Read()
        {
            byte[] data = new byte[1024];
            try
            {
                Client.Receive(data);
            }
            catch (Exception ex)
            {
                Last_Error = ex.Message;
                data = new byte[1024];
                Init();
            }
            return data;
        }

        #region 异步
        //通知一个或多个正在等待的线程已发生事件
        public ManualResetEvent TimeOutEvent;
        public bool Connect(int timeOut)
        {
            if (Client == null) return false;

            Client.BeginConnect(IpAddress, Port, new AsyncCallback(CallBackMethod), Client);

            //阻止当前线程，直到ManualResetEvent对象被set或者超过timeout时间
            //waitone收到信号返回true，否则返回false
            if (!TimeOutEvent.WaitOne(timeOut, false))
            {
                Client.Close();
            }

            return Connected;
        }
        public void CallBackMethod(IAsyncResult ar)
        {
            try
            {
                Client = ar.AsyncState as Socket;
                if (Client != null)
                {
                    Client.EndConnect(ar);
                    Connected = true;
                }

            }
            catch (Exception)
            {
                Connected = false;
            }
            finally
            {
                TimeOutEvent.Set();//解除被阻塞的连接线程
            }

        }

        #endregion

        public void Close()
        {
            if (Client != null)
            {
                Client.Shutdown(SocketShutdown.Both);
                Client.Close();
                Client.Dispose();
                Client = null;
            }
        }

        public bool SafeClose(Socket socket)
        {
            try
            {
                if (socket == null) return false;

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
