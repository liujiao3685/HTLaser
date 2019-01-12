using MES;
using MES.Vision;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ProductManage.Vision
{
    public class VisionLJ7000
    {
        public byte[] VisionIp = new byte[] { 192, 168, 0, 66 };//3D视觉IP

        public ushort VisionPort = 24691;//3D视觉端口号   1、24691：接收/发送指令 2、24692：高速通讯

        private bool m_connnectState = false;
        public bool Connected
        {
            get
            {
                return m_connnectState;
            }
        }

        private static VisionLJ7000 lJ7000 = null;
        public static VisionLJ7000 Instance
        {
            get
            {
                if (lJ7000 == null)
                {
                    lJ7000 = new VisionLJ7000();
                }
                return lJ7000;
            }
        }

        public VisionLJ7000()
        {

        }

        public VisionLJ7000(byte[] ip, ushort port)
        {
            VisionIp = ip;
            VisionPort = port;
        }

        /// <summary>
        /// 打开视觉通讯
        /// </summary>
        /// <returns>是否连接成功</returns>
        public bool OpenVision()
        {
            bool boo = true;

            for (int i = 0; i < NativeMethods.DeviceCount; i++)
            {
                _deviceData[i] = new DeviceData();
            }

            //using (OpenEthernetForm openEthernetForm = new OpenEthernetForm())
            //{
            //    if (DialogResult.OK == openEthernetForm.ShowDialog())
            //    {
            LJV7IF_ETHERNET_CONFIG ethernetConfig = new LJV7IF_ETHERNET_CONFIG(); //= openEthernetForm.EthernetConfig;
            ethernetConfig.abyIpAddress = VisionIp;
            ethernetConfig.wPortNo = VisionPort;
            try
            {
                int rc = NativeMethods.LJV7IF_EthernetOpen(_currentDeviceId, ref ethernetConfig);
                if (rc == (int)Rc.Ok)
                {
                    _deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
                    _deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
                    m_connnectState = boo = true;
                }
                //else
                //{
                //    _deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
                //}
            }
            catch (Exception ex)
            {
                m_connnectState = boo = false;
                //Program.LogNet.WriteError("异常", "3D相机连接失败！--> " + ex.Message);
            }
            //    }
            //}
            return boo;
        }


        public enum SendCommand
        {
            GetMeasurementValue,
            GetProfile,
            GetBatchProfile,
            GetProfileAdvance,
        }

        private SendCommand _sendCommand = SendCommand.GetMeasurementValue;

        private int _currentDeviceId;

        private List<MeasureData> _measureDatas = new List<MeasureData>();

        private DeviceData[] _deviceData = new DeviceData[NativeMethods.DeviceCount];

        private LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

        private float[] m_allDatas = new float[NativeMethods.MeasurementDataCount];//全部数据

        private float[] m_vaildDatas = new float[NativeMethods.MeasurementDataCount];//有效数据

        private float heightData = float.NaN;//每次采样的高度差

        private float coaxData = float.NaN;//每次采样的同心度

        /// <summary>
        /// 输出所有有效数据
        /// </summary>
        /// <returns></returns>
        public float[] CollectAllVaildData()
        {
            if (!OpenVision()) return null;

            int rc = NativeMethods.LJV7IF_GetMeasurementValue(_currentDeviceId, measureData);
            if (rc == (int)Rc.Ok)
            {
                _measureDatas.Clear();
                _measureDatas.Add(new MeasureData(0, measureData));

                m_allDatas = new float[NativeMethods.MeasurementDataCount];//所有数据
                m_vaildDatas = new float[NativeMethods.MeasurementDataCount];//有效数据

                try
                {
                    for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
                    {
                        Debug.Write(String.Format("  OUT{0:00}: {1}\r\n", (i + 1), Utility.ConvertToLogString(measureData[i]).ToString()));
                        m_allDatas[i] = measureData[i].fValue;

                        //判断是否是有效数据
                        if (measureData[i].byDataInfo == (int)LJV7IF_MEASURE_DATA_INFO.LJV7IF_MEASURE_DATA_INFO_VALID
                            && measureData[i].byJudge == (int)LJV7IF_JUDGE_RESULT.LJV7IF_JUDGE_RESULT_GO)
                        {
                            m_vaildDatas[i] = measureData[i].fValue;
                        }
                    }
                    return m_vaildDatas;
                }
                catch (Exception ex)
                {
                    Program.LogNet.WriteError("异常", "获取视觉有效数据异常：" + ex.Message);
                    return null;
                }
            }
            return m_vaildDatas;
        }

        /// <summary>
        /// 输出所有数据
        /// </summary>
        /// <returns></returns>
        public float[] CollectAllData()
        {
            if (!OpenVision()) return null;

            int rc = NativeMethods.LJV7IF_GetMeasurementValue(_currentDeviceId, measureData);
            if (rc == (int)Rc.Ok)
            {
                _measureDatas.Clear();
                _measureDatas.Add(new MeasureData(0, measureData));
                m_allDatas = new float[NativeMethods.MeasurementDataCount];

                try
                {
                    for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
                    {
                        Debug.Write(String.Format("  OUT{0:00}: {1}\r\n", (i + 1), Utility.ConvertToLogString(measureData[i]).ToString()));
                        m_allDatas[i] = measureData[i].fValue;
                    }
                    return m_allDatas;
                }
                catch (Exception ex)
                {
                    Program.LogNet.WriteError("异常", "获取视觉所有数据异常：" + ex.Message);
                    return null;
                }
            }
            return m_allDatas;
        }


    }
}
