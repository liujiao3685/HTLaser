using Model;
using ProductManage.TcpCommunicate;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProductManage.Scanner
{
    public class KeyenceSR751 : TcpBase
    {
        public static string IpAddress; //"192.168.0.78";
        private static int ScanPort;
        public Socket ScannerSocket;

        public KeyenceSR751(string ipAddress)
        {
            Init(ipAddress);
        }

        public void Init(string address = "")
        {
            ScanPort = 9004;
            if (!string.IsNullOrEmpty(address))
            {
                IpAddress = address;
            }
            else
            {
                IpAddress = ConfigurationManager.AppSettings["ScanIP"].ToString();
            }
            if (ScannerSocket == null || !ScannerSocket.Connected)
            {
                IPAddress ip = IPAddress.Parse(IpAddress);
                IPEndPoint ipe = new IPEndPoint(ip, ScanPort);

                ScannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ScannerSocket.Connect(ipe);
                IsConn = true;
            }
        }

        public KeyenceSR751(string ip, int port)
        {
            IpAddress = ip;
            ScanPort = port;
            Init();
        }

        public bool IsConnection()
        {
            if (ScannerSocket != null && ScannerSocket.Connected)
            {
                IsConn = true;
            }
            IsConn = false;
            return IsConn;
        }

        #region 异步连接，可设置连接超时

        /// <summary>
        /// 打开扫码枪连接
        /// timeOut 设置连接延迟
        /// </summary>
        /// <param name="timeOut">连接延迟</param>
        /// <returns></returns>
        public bool OpenAsync(int timeOut)
        {
            ScannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsConn = false;
            TimeOutEvent = new ManualResetEvent(false);
            try
            {
                ScannerSocket.BeginConnect(IpAddress, ScanPort, new AsyncCallback(ScanCallBackMethod), ScannerSocket);

                //阻止当前线程，直到ManualResetEvent对象被set或者超过timeout时间
                //waitone收到信号返回true，否则返回false
                if (!TimeOutEvent.WaitOne(timeOut, false))
                {
                    SafeClose(ScannerSocket);
                }
            }
            catch (Exception ex)
            {
                IsConn = false;
            }

            return IsConn;
        }

        private void ScanCallBackMethod(IAsyncResult ar)
        {
            try
            {
                ScannerSocket = ar.AsyncState as Socket;
                if (ScannerSocket != null)
                {
                    ScannerSocket.EndConnect(ar);
                    IsConn = true;
                }
            }
            catch (Exception ex)
            {
                IsConn = false;
            }
            finally
            {
                TimeOutEvent.Set();//解除被阻塞的连接线程
            }
        }

        #endregion

        #region 读写扫描枪
        private static object WriteReadLock = new object();
        public Result Write(string address, string content)
        {
            if ((ScannerSocket == null || !ScannerSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            return Write(ScannerSocket, address, content);
        }
        private Result Write(Socket socket, string address, string content)
        {
            Result result = new Result(false, string.Format("写失败"), null);
            try
            {
                lock (WriteReadLock)
                {
                    ScannerSocket.Send(Encoding.ASCII.GetBytes(content));

                    result.IsSuccess = true;
                    result.Content = null;
                    result.Msg = "写成功";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = String.Format("写异常：{0}", ex.Message);
                result = null;
            }
            return result;
        }

        public Result Read(string address)
        {
            if ((ScannerSocket == null || !ScannerSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            return Read(ScannerSocket, address);
        }
        private Result Read(Socket socket, string address, string order = "")
        {
            Result result = new Result(false, string.Format("读失败"), null);
            try
            {
                lock (WriteReadLock)
                {
                    int len = ScannerSocket.Send(Encoding.ASCII.GetBytes(order));

                    var content = new byte[len + 1024];
                    ScannerSocket.Receive(content);

                    result.IsSuccess = true;
                    result.Content = content;
                    result.Msg = "读成功";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = String.Format("写异常：{0}", ex.Message);
                result = null;
            }
            return result;
        }
        #endregion

        public bool Open()
        {
            try
            {
                ScannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), ScanPort);
                ScannerSocket.Connect(endPoint);
                IsConn = true;
            }
            catch (Exception ex)
            {
                IsConn = false;
            }
            return IsConn;
        }

        public bool Close()
        {
            IsConn = false;
            return SafeClose(ScannerSocket);
        }

    }
}
