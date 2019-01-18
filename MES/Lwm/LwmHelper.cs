using ProductManage.TcpCommunicate;
using System;
using System.Net;
using System.Net.Sockets;

namespace ProductManage.Lwm
{
    public class LwmHelper : TcpBase
    {
        public string LwmIp = "192.168.0.60";

        public int LwmPort = 8000;//8000;//700：控制端口

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

        private byte[] RecDatas;

        private int DataLength = 1024 * 1024;

        public LwmHelper()
        {

        }

        public bool Open(int timeout)
        {
            LwmSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsConn = false;
            TimeOutEvent = new System.Threading.ManualResetEvent(false);
            try
            {
                LwmSocket.BeginConnect(LwmIp, LwmPort, new AsyncCallback(LwmCallBack), LwmSocket);

                //阻止当前线程，直到TimeOutEvent被set或超过timeout时间
                //waitone收到信号返回true 否则返回false
                if (!TimeOutEvent.WaitOne(timeout, false))
                {
                    SafeClose(LwmSocket);
                }
            }
            catch (Exception ex)
            {
                IsConn = false;
            }
            return IsConn;
        }

        private void LwmCallBack(IAsyncResult ar)
        {
            try
            {
                LwmSocket = ar.AsyncState as Socket;
                if(LwmSocket != null)
                {
                    LwmSocket.EndConnect(ar);
                    IsConn = true;
                }

            }
            catch (Exception)
            {
                IsConn = false;
            }
            finally
            {
                TimeOutEvent.Set();//解除阻塞线程
            }
        }

        public bool Open()
        {
            try
            {
                LwmSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(LwmIp), LwmPort);
                LwmSocket.Connect(endPoint);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public byte[] Read()
        {
            byte[] datas = new byte[DataLength];

            if (LwmSocket != null && LwmSocket.Connected)
            {
                LwmSocket.BeginReceive(datas, 0, DataLength, SocketFlags.None,
                    new AsyncCallback(ReceiveCallBack), LwmSocket);
            }


            return datas;
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }

        public bool Close()
        {
            return base.SafeClose(LwmSocket);
        }

    }
}
