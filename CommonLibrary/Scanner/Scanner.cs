using Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace CommonLibrary.Scanner
{
    public class Scanner
    {
        private bool IsRecive = false;
        public bool IsOpen = false;
        private SerialPort serialPort = null;
        private byte[] FlagEnds = { 0x0d, 0x0a};// 0d回车， 0a换行
        private byte[] PhotoEnds = { 0x0a };
        private string _PortName = "";

        public string str_result = "";
        public string ErrMsg = "";

        public Action<Result> DataCallBack;
        private ComQueue<byte> RecBytes = new ComQueue<byte>(200);
        private string[] _Param;

        public Scanner()
        {
            _Param = "COM1,9600,8,1,0".Split(',');
        }

        public bool OpenComm()
        {
            if (!IsOpen)
            {
                if (_Param.Length > 0)
                {
                    return Open(_Param[0], int.Parse(_Param[1]), int.Parse(_Param[2]), (Parity)int.Parse(_Param[3]), (StopBits)int.Parse(_Param[4]));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool OpenComm(string[] param)
        {
            _Param = param;
            return Open(_Param[0], int.Parse(_Param[1]), int.Parse(_Param[2]), (Parity)int.Parse(_Param[3]), (StopBits)int.Parse(_Param[4]));
        }

        #region FlagEnds Example
        public void SendPhotoCode(string code)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    byte[] flagByte = Encoding.ASCII.GetBytes(code);
                    List<byte> content = new List<byte>();
                    content.AddRange(flagByte);
                    content.AddRange(PhotoEnds);

                    serialPort.Write(content.ToArray(), 0, content.Count());
                }
                else
                {
                    ErrMsg = string.Format("串口未打开！");
                }
            }
            catch (Exception ex)
            {
                ErrMsg = string.Format("异常：{0}", ex.Message);
            }
        }
        #endregion

        public bool Open(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits)
        {
            try
            {
                if (serialPort == null || !serialPort.IsOpen)
                {
                    IsOpen = false;
                    _PortName = portName;
                    serialPort = new SerialPort();
                    serialPort.ReceivedBytesThreshold = 1;
                    serialPort.PortName = portName;
                    serialPort.BaudRate = baudRate;
                    serialPort.DataBits = dataBits;
                    serialPort.Parity = parity;
                    serialPort.StopBits = stopBits;
                    serialPort.Open();
                    IsRecive = true;
                    serialPort.DataReceived += SerialPort_DataReceived;
                    IsOpen = true;
                    return true;
                }
                else
                {
                    IsOpen = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrMsg = string.Format("Scanner Open:{0} --  Err：{1}", _PortName, ex.Message);
                return false;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen && IsRecive && serialPort.BytesToRead > 0)
            {
                byte[] rec = new byte[serialPort.BytesToRead];
                serialPort.Read(rec, 0, rec.Length);
                Array.ForEach(rec, p =>
                {
                    RecBytes.Enqueue(p);
                    if (p == 0x0a || p == 0x0d || p == 0x03)//(char)0x03特殊字符：文本结束的特征
                    {
                        if (RecBytes.Count > 0)
                        {
                            Analysic_Received(ref RecBytes);
                            RecBytes.Clear();
                        }
                        else
                        {
                            RecBytes.Clear();
                        }
                    }
                });
            }
        }

        private void Analysic_Received(ref ComQueue<byte> recBytes)
        {
            byte[] lastBytes = recBytes.Reverse().ToArray();
            List<byte> checkBytes = new List<byte>();
            for (int i = 0; i < lastBytes.Count(); i++)
            {
                if (lastBytes[i] != 0x0a && lastBytes[i] != 0x0d)
                {
                    checkBytes.Add(lastBytes[i]);
                }
            }
            Result result = new Result(true, string.Format("Scanner Received OK!"), checkBytes.Reverse<byte>().ToArray());
            DoCallBack(result);
        }

        private void DoCallBack(Result result)
        {
            DataCallBack?.Invoke(result);
        }

        public void Close()
        {
            IsRecive = false;
            IsOpen = false;
            Thread.Sleep(50);
            Stop();
        }

        private void Stop()
        {
            if (serialPort != null)
            {
                serialPort?.Close();
                serialPort?.Dispose();
                serialPort = null;
            }
        }
    }
}
