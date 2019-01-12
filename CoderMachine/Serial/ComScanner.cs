using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;

namespace CoderMachine.Serial
{
    public class ComScanner
    {
        public SerialPort m_serivalPort;

        public Action<Result> DataCallBack;

        private ComQueue<byte> ComDatas = new ComQueue<byte>(200);

        public void OpenCom(string PortName, int BaudRate, int DataBits, StopBits stopbit, Parity parity)
        {
            try
            {
                m_serivalPort = new SerialPort();
                m_serivalPort.PortName = PortName;
                m_serivalPort.BaudRate = BaudRate;
                m_serivalPort.DataBits = DataBits;
                m_serivalPort.StopBits = stopbit; //StopBits.None StopBits.Two;
                m_serivalPort.Parity = parity;//Parity.None Parity.Even);
                m_serivalPort.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                m_serivalPort.Open();

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] datas = new byte[m_serivalPort.BytesToRead];
            m_serivalPort.Read(datas, 0, datas.Length);
            Array.ForEach(datas, data =>
            {
                ComDatas.Enqueue(data);
                if (data == 0x0a || data == 0x0d)//结束
                {
                    Analysis_Received(ref ComDatas);
                    ComDatas.Clear();
                }
                else
                {
                    ComDatas.Clear();
                }
            });

        }

        private void Analysis_Received(ref ComQueue<byte> rec)
        {
            byte[] lastBytes = rec.Reverse().ToArray();
            List<byte> checkBytes = new List<byte>();
            for (int i = 0; i < lastBytes.Count(); i++)
            {
                if (lastBytes[i] != 0x0a && lastBytes[i] != 0x0d)
                {
                    checkBytes.Add(lastBytes[i]);
                }
            }
            Result result = new Result(true, "ScannReceived OK!", checkBytes.Reverse<byte>().ToArray());
            DoCallBack(result);
        }

        private void DoCallBack(Result result)
        {
            DataCallBack?.Invoke(result);
        }
    }
}
