using ProductManage.TcpCommunicate;
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
    /// TCP客户端-异步
    /// </summary>
    public class MyTcpClient : TcpBase
    {
        private Socket m_socket;

        private IPEndPoint m_ipEndPoint;

        public string IpAddress { set; get; }
        private string m_ipAddress;

        public int Port { set; get; }
        private int m_port;

        private static ManualResetEvent connectDone = new ManualResetEvent(false);

        private static ManualResetEvent sendDone = new ManualResetEvent(false);

        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        private static String response = String.Empty;

        public MyTcpClient(string ip, int port)
        {
            m_ipAddress = ip;
            m_port = port;
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public string ConnectAsync()
        {
            string error = string.Empty;

            try
            {
                m_ipEndPoint = new IPEndPoint(IPAddress.Parse(m_ipAddress), m_port);
                m_socket.BeginConnect(m_ipEndPoint, new AsyncCallback(ConnectCallBack), m_socket);

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return error;
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;

                socket.EndConnect(ar);

                connectDone.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string SendAsync(string data)
        {
            string error = string.Empty;

            if (m_socket == null) return error = "客户端未初始化！";
            if (!m_socket.Connected) return error = "客户端未连接成功！";

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                m_socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallBack), m_socket);

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error;
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                socket.EndSend(ar);

                sendDone.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
