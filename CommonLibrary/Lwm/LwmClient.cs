using Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommonLibrary.Lwm
{
    public class LwmClient
    {
        public string IpAddress;
        public Socket LwmSocket;
        public bool Connected = false;


        private static LwmClient lwmClient;
        private static readonly object locker = new object();
        public static LwmClient GetInstance()
        {
            if (lwmClient == null)
            {
                lock (locker)
                {
                    lwmClient = new LwmClient();
                }
            }
            return lwmClient;
        }
        public LwmClient()
        {
            Init();
        }
        public LwmClient(string ipAddress)
        {
            Init(ipAddress);
        }
        public void Init(string ipAddress = "192.168.0.60")
        {
            try
            {
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    IpAddress = ipAddress;
                }

                if (LwmSocket == null || !LwmSocket.Connected)
                {
                    IPAddress ip = IPAddress.Parse(IpAddress);
                    IPEndPoint ipe = new IPEndPoint(ip, 8000);

                    LwmSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    LwmSocket.Connect(ipe);
                    Connected = true;
                }
            }
            catch (System.Exception)
            {
                Connected = false;
            }
        }

        public bool IsConnection()
        {
            if (LwmSocket != null && LwmSocket.Connected)
            {
                Connected = true;
            }
            Connected = false;
            return Connected;
        }


        #region 读写
        private static object WriteReadLock = new object();
        public Result Write(string content)
        {
            if ((LwmSocket == null || !LwmSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            return Write(LwmSocket, content);
        }
        private Result Write(Socket socket, string content)
        {
            Result result = new Result(false, string.Format("写失败"), null);
            try
            {
                lock (WriteReadLock)
                {
                    LwmSocket.Send(Encoding.ASCII.GetBytes(content));

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

        public Result Read()
        {
            if ((LwmSocket == null || !LwmSocket.Connected) && !string.IsNullOrEmpty(IpAddress))
            {
                Init();
            }
            return Read(LwmSocket);
        }

        private Result Read(Socket socket, string order = "")
        {
            Result result = new Result(false, string.Format("读失败"), null);
            try
            {
                lock (WriteReadLock)
                {
                    var content = new byte[1024];
                    LwmSocket.Receive(content);

                    result.IsSuccess = true;
                    result.Content = content;
                    result.Msg = "读成功";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = string.Format("写异常：{0}", ex.Message);
                result = null;
            }
            return result;
        }
        #endregion

        public void Close()
        {
            if (LwmSocket != null)
            {
                LwmSocket.Shutdown(SocketShutdown.Both);
                LwmSocket.Close();
                LwmSocket.Dispose();
                LwmSocket = null;
            }
        }
    }
}
