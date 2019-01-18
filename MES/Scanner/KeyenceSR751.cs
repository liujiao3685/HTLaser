using ProductManage.TcpCommunicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManage.Scanner
{
    public class KeyenceSR751 : TcpBase
    {
        public static string ScanIp = "192.168.0.78";

        public static int ScanPort = 9004;

        public Socket ScanSocket;

        private static readonly object myLock = new object();
        private static KeyenceSR751 sR751;
        public static KeyenceSR751 GetInstance()
        {
            if (sR751 == null)
            {
                lock (myLock)
                {
                    sR751 = new KeyenceSR751(ScanIp, ScanPort);
                }
            }
            return sR751;
        }

        public KeyenceSR751()
        {
        }

        public KeyenceSR751(string ip, int port)
        {
            ScanIp = ip;
            ScanPort = port;
        }


        /// <summary>
        /// 打开扫码枪连接
        /// timeOut 设置连接延迟
        /// </summary>
        /// <param name="timeOut">连接延迟</param>
        /// <returns></returns>
        public bool Open(int timeOut)
        {
            ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsConn = false;
            TimeOutEvent = new ManualResetEvent(false);
            try
            {
                ScanSocket.BeginConnect(ScanIp, ScanPort, new AsyncCallback(ScanCallBackMethod), ScanSocket);

                //阻止当前线程，直到ManualResetEvent对象被set或者超过timeout时间
                //waitone收到信号返回true，否则返回false
                if (!TimeOutEvent.WaitOne(timeOut, false))
                {
                    SafeClose(ScanSocket);
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
                ScanSocket = ar.AsyncState as Socket;
                if (ScanSocket != null)
                {
                    ScanSocket.EndConnect(ar);
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

        public bool Open()
        {
            try
            {
                ScanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ScanIp), ScanPort);
                ScanSocket.Connect(endPoint);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Close()
        {
            return SafeClose(ScanSocket);
        }


    }
}
