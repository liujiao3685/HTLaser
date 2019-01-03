using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoderMachine.Core
{
    public class SerialPortCommTwo
    {
        public delegate void EventHandle(byte[] buffer);

        public event EventHandle DataReceive;

        private SerialPort m_serialPort;

        private Thread m_thread;

        volatile bool m_keepReading;

        public SerialPortCommTwo()
        {
            m_serialPort = new SerialPort();
            m_thread = null;
            m_keepReading = false;
        }

        public bool IsOpen
        {
            get
            {
                return m_serialPort.IsOpen;
            }
        }

        private void StartReading()
        {
            if (!m_keepReading)
            {
                m_keepReading = true;
                m_thread = new Thread(ReadPort);
                m_thread.Start();
                Console.WriteLine("打开串口，开始接收数据...");
            }
        }

        private void StopReading()
        {
            if (m_keepReading)
            {
                m_keepReading = false;
                m_thread.Join();
                m_thread = null;
            }
        }

        /// <summary>
        /// 开始读取串口数据
        /// </summary>
        private void ReadPort()
        {

            while (m_keepReading)
            {
                if (m_serialPort.IsOpen)
                {
                    int size = m_serialPort.BytesToRead;
                    if (size > 0)
                    {
                        byte[] buffer = new byte[size];

                        try
                        {
                            Application.DoEvents();

                            m_serialPort.Read(buffer, 0, size);

                            DataReceive?.Invoke(buffer);

                            Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        public void Open()
        {
            Close();
            m_serialPort.Open();
            if (m_serialPort.IsOpen)
            {
                StartReading();
            }
            else
            {
                MessageBox.Show("串口打开失败！");
            }
        }

        public void Close()
        {
            StopReading();
            m_serialPort.Close();
        }

        /// <summary>
        /// 写入串口数据
        /// </summary>
        public void Write(byte[] data, int offset, int size)
        {
            if (IsOpen)
            {
                m_serialPort.Write(data, offset, size);
            }
        }

    }
}
