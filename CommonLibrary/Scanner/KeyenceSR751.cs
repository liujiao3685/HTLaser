using Model;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CommonLibrary.Scanner
{
    public class KeyenceSR751 : TcpBase
    {
        public static string IpAddress; //"192.168.0.78";
        private static int ScanPort;
        public Socket ScannerSocket;

        private System.Timers.Timer KeepAliveTimer;

        private static KeyenceSR751 keyenceSR751;
        private static readonly object locker = new object();
        public static KeyenceSR751 GetInstance()
        {
            if (keyenceSR751 == null)
            {
                lock (locker)
                {
                    keyenceSR751 = new KeyenceSR751(IpAddress);
                }
            }
            return keyenceSR751;
        }

        public KeyenceSR751(string ipAddress)
        {
            Init(ipAddress);
            IpAddress = ipAddress;

            KeepAliveTimer = new System.Timers.Timer();
            KeepAliveTimer.Elapsed += KeepAliveTimer_Elapsed;
            KeepAliveTimer.Interval = 1000;
            KeepAliveTimer.AutoReset = true;
            KeepAliveTimer.Enabled = true;

        }

        private void KeepAliveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!IsConnection())
            {
                ReConnect();
            }
        }

        public KeyenceSR751(string ip, int port = 9004)
        {
            IpAddress = ip;
            ScanPort = port;
            Init();
        }

        public void Init(string address = "127.0.0.1")
        {
            try
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
                    Open();
                }

            }
            catch (Exception ex)
            {
                Connected = false;
            }
        }

        public bool IsConnection()
        {
            if (ScannerSocket != null && ScannerSocket.Connected)
            {
                Connected = true;
            }
            else
            {
                Connected = false;
            }
            return Connected;
        }

        /// <summary>
        /// 异步重连
        /// </summary>
        public void ReConnect()
        {
            if (!ScannerSocket.Connected || !Connected)
            {
                //Init(IpAddress);
                OpenAsync(3000);
            }
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
                Connected = false;
            }

            return Connected;
        }

        private void ScanCallBackMethod(IAsyncResult ar)
        {
            try
            {
                ScannerSocket = ar.AsyncState as Socket;
                if (ScannerSocket != null)
                {
                    ScannerSocket.EndConnect(ar);
                    Connected = true;
                }
            }
            catch (Exception ex)
            {
                Connected = false;
            }
            finally
            {
                TimeOutEvent.Set();//解除被阻塞的连接线程
            }
        }

        #endregion

        #region 读写扫描枪
        private static object WriteReadLock = new object();
        public Result Write(string content)
        {
            if ((ScannerSocket == null || !ScannerSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            return Write(ScannerSocket, content);
        }
        private Result Write(Socket socket, string content)
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

        public string Read(string order = "")
        {
            if ((ScannerSocket == null || !ScannerSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            Result result = Read(ScannerSocket);
            if (result.IsSuccess)
            {
                return Encoding.ASCII.GetString(result.Content);
            }
            else
            {
                return result.Msg;
            }
        }

        public override byte[] Read()
        {
            if ((ScannerSocket == null || !ScannerSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            return Read(ScannerSocket).Content;
        }
        private Result Read(Socket socket, string order = "")
        {
            Result result = new Result(false, string.Format("读失败"), null);
            try
            {
                lock (WriteReadLock)
                {
                    if (order != "")
                    {
                        Write(order);
                    }

                    var content = new byte[1024];
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

        private bool Open()
        {
            try
            {
                ScannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), ScanPort);
                ScannerSocket.Connect(endPoint);
                Connected = true;
            }
            catch (Exception ex)
            {
                Connected = false;
            }
            return Connected;
        }

        private bool Open2()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(IpAddress);
                IPEndPoint ipe = new IPEndPoint(ip, ScanPort);

                ScannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ScannerSocket.Connect(ipe);
                Connected = true;
            }
            catch (Exception ex)
            {
                Connected = false;
            }
            return Connected;
        }

    }
}
