using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderMachine.Core
{
    public class BSerialPortPackage : EventArgs
    {
        public Byte[] Data;
    }

    public class SerialPortCommOne
    {
        private SerialPort serialPort;
        private BackgroundWorker recieveBW;

        public string PortName
        {
            get { return serialPort.PortName; }
            set { serialPort.PortName = value; }
        }

        public int BaudRate
        {
            get { return serialPort.BaudRate; }
            set { serialPort.BaudRate = value; }
        }

        public Parity Parity
        {
            get { return serialPort.Parity; }
            set { serialPort.Parity = value; }
        }

        public int DataBits
        {
            get { return serialPort.DataBits; }
            set { serialPort.DataBits = value; }
        }

        public StopBits StopBits
        {
            get { return serialPort.StopBits; }
            set { serialPort.StopBits = value; }
        }

        public bool IsOpen
        {
            get { return serialPort.IsOpen; }
        }

        public int BytesToRead
        {
            get { return serialPort.BytesToRead; }
        }

        //接收信息间隔（毫秒）
        public int RecieveInterval = 10;

        //每个数据包的大小（byte）
        public int PackageSize = 2 + 20 * 10 + 2;

        //收到信息的事件
        public event EventHandler PackageRecieved;

        public SerialPortCommOne()
        {
            serialPort = new SerialPort();

            recieveBW = new BackgroundWorker();
            recieveBW.WorkerSupportsCancellation = true;
            recieveBW.WorkerReportsProgress = true;
            recieveBW.DoWork += new DoWorkEventHandler(recieveBW_DoWork);
            recieveBW.ProgressChanged += new ProgressChangedEventHandler(recieveBW_ProgressChanged);
        }

        private void recieveBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                if (PackageRecieved != null)
                {
                    PackageRecieved(this, (BSerialPortPackage)e.UserState);
                }
            }
        }

        private void recieveBW_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!recieveBW.CancellationPending)
            {
                if (serialPort.IsOpen && serialPort.BytesToRead >= PackageSize)//有一个包的数据才读
                {
                    byte[] recvData = new byte[PackageSize];
                    serialPort.Read(recvData, 0, PackageSize);
                    BSerialPortPackage bsp = new BSerialPortPackage();
                    bsp.Data = recvData;

                    recieveBW.ReportProgress(1, bsp);
                }

                System.Threading.Thread.Sleep(RecieveInterval);
            }
        }

        public void DiscardInBuffer()
        {
            serialPort.DiscardInBuffer();
        }

        public void DiscardOutBuffer()
        {
            serialPort.DiscardOutBuffer();
        }

        public bool Open()
        {
            if (serialPort.IsOpen)
            {
                return true;
            }
            else
            {
                try
                {
                    serialPort.Open();
                    recieveBW.RunWorkerAsync();
                    return true;
                }
                catch
                {
                    recieveBW.CancelAsync();
                    serialPort.Close();
                    return false;
                }
            }
        }

        public void Close()
        {
            recieveBW.CancelAsync();
            serialPort.Close();
        }

        //大于PackageSize的data将不会被发送
        public void Write(byte[] data)
        {
            if (data.Length > PackageSize)
            { return; }

            byte[] sendData = new byte[PackageSize];
            for (int i = 0; i < data.Length; i++)
            {
                sendData[i] = data[i];
            }

            serialPort.Write(sendData, 0, sendData.Length);
        }
    }


}
