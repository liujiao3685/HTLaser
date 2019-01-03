using ProductManage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManage.TcpCommunicate
{
    /// <summary>
    /// TCP服务端-异步
    /// </summary>
    public class MyTcpServer
    {
        private Socket m_socket;

        private IPEndPoint m_ipEndPoint;

        public string IpAddress { set; get; }
        private string m_ipAddress;

        public int Port { set; get; }
        private int m_port;

        public int MaxListen { get; set; } = 100;
        private int m_maxListen;

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public MyTcpServer(string ip, int port)
        {
            m_ipAddress = ip;
            m_port = port;
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public string StartListen()
        {
            string error = string.Empty;

            try
            {
                m_ipEndPoint = new IPEndPoint(IPAddress.Parse(m_ipAddress), m_port);
                m_socket.Listen(MaxListen);

                while (true)
                {
                    allDone.Reset();
                    Console.WriteLine("等待客户端连接...");
                    m_socket.BeginAccept(new AsyncCallback(AcceptCallBack), m_socket);
                }

            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return error;
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listen = (Socket)ar.AsyncState;
                Socket handler = listen.EndAccept(ar);

                StateObject state = new StateObject(1024);
                state.WorkSocket = handler;

                handler.BeginReceive(state.Buffer, 0, state.DataLength, 0, new AsyncCallback(ReceiveCallBack), state);
            }
            catch (Exception ex)
            {

            }
        }

        private string Content = string.Empty;

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Content = string.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.WorkSocket;

                int dataRead = handler.EndReceive(ar);
                if (dataRead > 0)
                {
                    state.ContentMsg.Append(Encoding.ASCII.GetString(state.Buffer, 0, dataRead));
                }

                Content = state.ContentMsg.ToString();

                Console.WriteLine(Content);

            }
            catch (Exception e)
            {

            }
        }

        public string Send(string data)
        {
            string error = string.Empty;
            if (m_socket == null) return error = "服务端未初始化！";
            if (!m_socket.Connected) return error = "服务端未连接到客户端！";

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                m_socket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallBack), m_socket);
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return error;

        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;

                socket.EndSend(ar);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool SafeClose()
        {
            try
            {
                if (m_socket == null) return false;
                if (!m_socket.Connected) return false;

                m_socket.Shutdown(SocketShutdown.Both);
                m_socket.Close();
                m_socket.Dispose();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
