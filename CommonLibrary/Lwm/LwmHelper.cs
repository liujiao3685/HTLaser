﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommonLibrary.Lwm
{
    public delegate void LwmDataRevice(LwmData Receive);

    public class LwmHelper : TcpBase
    {
        public event LwmDataRevice LwmDataReviceEvent;
        public string LwmIp = "192.168.0.60";

        public int LwmPort = 8000;//8000;//700：控制端口

        public Socket LwmSocket;
        private Thread OnReadThread;

        private static readonly object locker = new object();
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
            OnReadThread = new Thread(DoReadThread);
            OnReadThread.IsBackground = true;
            OnReadThread.SetApartmentState(ApartmentState.STA);
            OnReadThread.Start();
        }

        private void DoReadThread()
        {
            while (true)
            {
                while (Connected)
                {
                    RecDatas = new byte[1024];
                    RecDatas = Read();
                    Thread.Sleep(50);
                }
                if (!Connected)
                {
                    Open(LwmIp, LwmPort);
                    Thread.Sleep(2000);
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 根据报文ID读取数据
        /// </summary>
        /// <param name="telegramID"></param>
        /// <returns></returns>
        public LwmData ReceiveByTelegram(int telegramID)
        {
            return ReceiveByTelegram(BitConverter.GetBytes(telegramID));
        }

        public LwmData ReceiveByTelegram(byte[] telegramID)
        {
            LwmData lwmData = new LwmData();
            try
            {
                if (!Connected) Open(LwmIp, LwmPort);

                byte[] temp = new byte[1024];
                int offset = 0;
                LwmSocket.Receive(temp);
                lwmData.TelegramId = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.Statue = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.Length = BitConverter.ToInt32(temp, offset);
                offset += 32;

                byte[] datas = new byte[lwmData.Length];
                lwmData.ProgramNo = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.ConfigId = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.ConfigVersion = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.TotalResult = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.MoreResult = BitConverter.ToInt32(temp, offset);
                offset += 32;
                offset += 32;// reserved
                lwmData.ErrorSignOutput = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.MeasurementID = BitConverter.ToInt32(temp, offset);
                offset += 32;
                lwmData.CommentLength = BitConverter.ToInt32(temp, offset);
                offset += 32;

                for (int i = 0; i < 80; i++)
                {
                    lwmData.Comment[i] = BitConverter.ToChar(temp, offset + i);
                }
                offset += 80;

                for (int i = 0; i < 6; i++)
                {
                    lwmData.LwmDataTime[i] = BitConverter.ToInt16(temp, offset + i);
                }

                LwmDataReviceEvent?.Invoke(lwmData);

            }
            catch (Exception)
            {
                return null;
            }
            return lwmData;
        }

        /// <summary>
        /// 发送报文ID
        /// </summary>
        /// <param name="telegramID"></param>
        /// <returns></returns>
        public bool SendTelegramId(int telegramID)
        {
            return SendTelegramId(BitConverter.GetBytes(telegramID));
        }

        public bool SendTelegramId(byte[] telegramID)
        {
            try
            {
                if (!Connected) Open(LwmIp, LwmPort);

                LwmSocket.Send(telegramID);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Open(int timeout)
        {
            LwmSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Connected = false;
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
                Connected = false;
            }
            return Connected;
        }

        private void LwmCallBack(IAsyncResult ar)
        {
            try
            {
                LwmSocket = ar.AsyncState as Socket;
                if (LwmSocket != null)
                {
                    LwmSocket.EndConnect(ar);
                    Connected = true;
                }

            }
            catch (Exception)
            {
                Connected = false;
            }
            finally
            {
                TimeOutEvent.Set();//解除阻塞线程
            }
        }

        public bool Open(string ip, int port)
        {
            return Open(LwmSocket, ip, port);
        }

        public bool Open(Socket socket, string ip, int port)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.Connect(endPoint);
                Connected = true;
                return true;
            }
            catch (Exception)
            {
                Connected = false;
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

    }
}
