using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MES.Core.PLC
{
    public class SocketTCP
    {
        private static readonly object padlock = new object();

        private byte[] data = new byte[1024];//接收远程端发出的数据

        private IPAddress _IP;

        private IPEndPoint _ipEnd;

        private Socket socket;

        private int errorCount = 0;

        private static Object thisLock = new Object();

        public SocketTCP()
        { }

        public SocketTCP(string IP, int Port)
        {
            InitSocket(IP, Port);
        }

        public bool InitSocket(string IP, int Port)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                _IP = IPAddress.Parse(IP);
                _ipEnd = new IPEndPoint(_IP, Port);//远程PLC(ip、port)

                socket.ReceiveTimeout = 800;
                socket.SendTimeout = 800;

                Thread thread = new Thread(Recevice);
                thread.IsBackground = true;


                return ConnectServer() ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void Recevice()
        {
            while (true)
            {


            }

        }

        public bool Connected
        {
            get
            {
                if (socket == null)
                    return false;
                return socket.Connected;
            }
        }

        public bool ConnectServer()
        {
            try
            {
                socket.Connect(_ipEnd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                if (socket.Connected)
                    socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                return true;
            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {
                return false;
            }
        }

        public int StatusCode
        { get; set; }

        /// <summary>
        /// 发送并接收远程端数据
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public byte[] SendCommand(byte[] cmd)
        {
            lock (thisLock)
            {
                try
                {
                    if (socket != null)
                    {
                        if (socket.Connected)
                        {
                            socket.Send(cmd);

                            int count = socket.Receive(data);
                            if (count < 0) count = 0;

                            errorCount = 0;
                            byte[] value = new byte[count];

                            Array.ConstrainedCopy(data, 0, value, 0, count);
                            //Array.Copy(data, 0, value, 0, count);
                            return value;
                        }
                    }

                    return null;
                }
                catch (SocketException)
                {
                    System.Threading.Thread.Sleep(1000);
                    errorCount++;
                    if (errorCount > 3)
                    {
                        errorCount = 0;
                        throw new Exception("SocketError");
                    }
                    else
                    {
                        return SendCommand(cmd);
                    }
                }
                catch (Exception e)
                {
                    System.Threading.Thread.Sleep(1000);
                    throw e;
                }
            }
        }
    }
}