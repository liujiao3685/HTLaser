using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using csLTDMC;

namespace HuaTianProject.Libs
{
    public class CDMC5400A : State, IMontion
    {
        //回调函数
        public delegate void MonitorPosChangeDelegate(ushort axis);
        public delegate void MonitorLimitedChangeDelegate(ushort axis);
        public delegate void MonitorErrorDelegate(string error);

        public event MonitorLimitedChangeDelegate MonitorLimitedChangeCallBack;
        public event MonitorPosChangeDelegate MonitorPosChangeCallBack;
        public event MonitorErrorDelegate MonitorErrorCallBack;

        private object globalLock = new object();

        private static bool IsRun;//控制卡是否初始化

        private static ushort CardId;

        private ushort m_cardNo;//当前卡号

        private uint m_axisCount;//控制卡轴数量

        public uint AxisCount { get { return m_axisCount; } }

        private bool InitializeOK;//初始化控制卡是否成功

        private const int MIN_PULSE_CHANGE = 1;//脉冲值变化最小值

        private Form m_parentForm;

        private double[] m_axisEncPos, m_axisPrfPos, m_axisEncPosTemp, m_axisPrfPosTemp;

        private bool[] m_pAxisCmdDone, m_axisError, m_oldAxisError, m_posTrigger, m_oldPosTrigger, m_negTrigger, m_oldNegTrigger;

        private double[] m_axisRes;

        private uint[] m_axisIO;

        private AutoResetEvent[] m_hMotionDone;

        private Thread WorkThread;

        private short m_errorCode = 0;

        private const int DMC_SUCCESS = 0;
        private const int DMC_ERROR = 1;
        private int AdvErrorCode = 0, OldErrorCode = 0;
        private static StreamFile m_logFile = new StreamFile(Application.StartupPath + "\\MotionLog.txt", true);

        ~CDMC5400A()
        {
            StopMonitorThread();
        }

        /// <summary>
        /// 初始化运动控制卡，仅初始化一次
        /// </summary>
        /// <param name="cardNum">控制卡号</param>
        /// <param name="isRun">是否初始化</param>
        /// <returns>是否初始化成功</returns>
        public static bool InitMotionCard(ref short cardNum, bool isRun)
        {
            IsRun = isRun;
            if (IsRun)
            {
                return true;
            }

            try
            {
                cardNum = LTDMC.dmc_board_init();
                if (cardNum <= 0 || cardNum > 8)
                {
                    MessageBox.Show("初始化控制卡失败！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return false;
                }

                ushort _num = 0;
                ushort[] cardids = new ushort[8];
                uint[] cardtypes = new uint[8];
                short res = LTDMC.dmc_get_CardInfList(ref _num, cardtypes, cardids);
                if (res != 0)
                {
                    MessageBox.Show("获取卡信息失败！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                CardId = cardids[0];

            }
            catch (Exception ex)
            {
                m_logFile.AppendText("运动控制卡初始化异常：" + ex.Message);
                return false;
            }
            return true;

        }

        public bool Initialize(ushort cardId, Form form, string cfgFileName)
        {
            if (IsRun)
            {
                return true;
            }

            m_cardNo = cardId;
            m_parentForm = form;

            string fileName = cfgFileName;

            try
            {
                //if (!File.Exists(fileName))
                //{
                //    MotionError(DMC_ERROR, "配置文件不存在！");
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                m_logFile.AppendText(ex.StackTrace + "，异常：" + ex.Message);
                return false;
            }

            short errorCode = LTDMC.dmc_get_total_axes(cardId, ref m_axisCount);
            if (errorCode != 0)
            {
                MotionError(DMC_ERROR, "初始化控制卡失败！");
                return false;
            }

            InitializeOK = true;

            InitializeParam();

            return true;
        }

        private void InitializeParam()
        {
            if (m_axisCount > 0)
            {
                m_axisEncPos = new double[m_axisCount];
                m_axisPrfPos = new double[m_axisCount];
                m_axisEncPosTemp = new double[m_axisCount];
                m_axisPrfPosTemp = new double[m_axisCount];
                m_axisRes = new double[m_axisCount];
                m_pAxisCmdDone = new bool[m_axisCount];
                m_axisError = new bool[m_axisCount];
                m_axisError = new bool[m_axisCount];
                m_oldAxisError = new bool[m_axisCount];
                m_posTrigger = new bool[m_axisCount];
                m_oldPosTrigger = new bool[m_axisCount];
                m_negTrigger = new bool[m_axisCount];
                m_oldNegTrigger = new bool[m_axisCount];
                m_axisIO = new uint[m_axisCount];
                m_hMotionDone = new AutoResetEvent[m_axisCount];
            }

            for (byte i = 0; i < m_axisCount; i++)
            {
                m_hMotionDone[i] = new AutoResetEvent(false);
                m_hMotionDone[i].Set();
            }

        }


        /// <summary>
        /// 关闭监视线程，类析构时调用
        /// </summary>
        private void StopMonitorThread()
        {
            if (WorkThread != null && WorkThread.IsAlive)
            {
                WorkThread.Abort();
            }

            //300ms延迟关闭
            int nTimes = 0;
            do
            {
                ThreadSwitch = false;

                if (nTimes++ > 30)
                    break;
                Thread.Sleep(10);
            } while (ThreadLive);

        }

        #region 运动控制卡实时监控函数

        public bool StartMonitorThread()
        {
            if (ThreadLive || IsRun)
            {
                return true;
            }

            WorkThread = InitThread("CDMC5400A");

            return true;
        }

        public override void RunProcess(object obj)
        {
            if (obj is CDMC5400A)
            {
                ThreadLive = true;
                ThreadSwitch = true;

                while (ThreadSwitch)
                {
                    if (!MonitorDMCCard())
                    {
                        break;
                    }
                }
                ThreadSwitch = false;
            }
        }
        #endregion

        private bool MonitorDMCCard()
        {
            short state = 0;

            lock (globalLock)
            {
                for (ushort i = 0; i < m_axisCount; i++)
                {
                    m_axisPrfPos[i] = LTDMC.dmc_get_position(m_cardNo, i);
                    m_axisEncPos[i] = LTDMC.dmc_get_encoder(m_cardNo, i);

                    state = LTDMC.dmc_check_done(m_cardNo, i);

                    //轴状态
                    AnalyseMotionStatus(i, state);

                    //IO状态
                    AnalyseMotionIOStatus(i);
                }
            }

            return true;
        }

        private void AnalyseMotionIOStatus(ushort channel)
        {
            //轴 IO
            m_axisIO[channel] = LTDMC.dmc_axis_io_status(m_cardNo, channel);

            uint value = m_axisIO[channel];

            //报警     
            if ((value & 0x1) > 0)
            {
                m_axisError[channel] = true;
                if (m_axisError[channel] ^ m_oldAxisError[channel])//^ 异或运算符，只有一个true结果才为true
                {
                    m_logFile.AppendText("轴伺服驱动器报警，请断电重启！");
                }
            }
            else
            {
                m_axisError[channel] = false;
            }

            m_oldAxisError[channel] = m_axisError[channel];

            //正限位
            if ((value & 0x2) > 0)
            {
                m_posTrigger[channel] = true;
                if (m_posTrigger[channel] ^ m_oldPosTrigger[channel])
                {
                    m_logFile.AppendText("轴正限位触发报警！");
                }
            }
            else
            {
                m_posTrigger[channel] = false;
            }
            m_oldPosTrigger[channel] = m_posTrigger[channel];

            //负限位
            if ((value & 0x4) > 0)
            {
                m_negTrigger[channel] = true;
                if (m_negTrigger[channel] ^ m_oldNegTrigger[channel])
                {
                    m_logFile.AppendText("轴负限位触发报警！");
                }
            }
            else
            {
                m_negTrigger[channel] = false;
            }

            m_oldNegTrigger[channel] = m_negTrigger[channel];

        }

        /// <summary>
        /// 检测轴在指定延迟时间内是否完成动作
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public bool WaitForAxisMoveDone(ushort axis, int milliseconds)
        {
            if (axis < 0 || axis >= m_axisCount) return false;

            short state = 0;

            while (true)
            {
                if (milliseconds-- == 0) return false;//动作超时

                lock (globalLock)
                {
                    state = LTDMC.dmc_check_done(m_cardNo, axis);
                    if (state == 1) return true;
                }

                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 等待所有轴运动完成
        /// </summary>
        /// <returns></returns>
        public bool WaitForAllAxisMotionDone()
        {
            bool waitResult = true;

            for (ushort i = 0; i < m_cardNo; i++)
            {
                waitResult &= WaitForAxisMoveDone(i, 6000);
            }

            return waitResult;
        }

        /// <summary>
        /// 指定轴减速停止
        /// </summary>
        /// <param name="axis"></param>
        public void StopAxisMotion(ushort axis)
        {
            if (axis < 0 || axis >= m_axisCount) return;

            lock (globalLock)
            {
                m_errorCode = LTDMC.dmc_stop(m_cardNo, axis, 0);
                MotionError(m_errorCode, axis + " dmc_stop");
            }

        }

        /// <summary>
        /// 停止所有轴运动
        /// </summary>
        public void StopAllMotion()
        {
            lock (globalLock)
            {
                for (ushort x = 0; x < m_axisCount; x++)
                {
                    LTDMC.dmc_stop(m_cardNo, x, 1);
                }
            }
        }

        private void AnalyseMotionStatus(ushort axis, short state)
        {
            if (Math.Abs(m_axisPrfPosTemp[axis] - m_axisPrfPos[axis]) >= MIN_PULSE_CHANGE)//轴位置发生变化时
            {
                if (MonitorPosChangeCallBack != null)
                {
                    m_parentForm.BeginInvoke(MonitorPosChangeCallBack, axis);
                }
                m_axisPrfPosTemp[axis] = m_axisPrfPos[axis];

            }

            if (state > 0)
            {
                m_pAxisCmdDone[axis] = true;
                m_hMotionDone[axis].Set();
            }
            else
            {
                m_pAxisCmdDone[axis] = false;
                m_hMotionDone[axis].Reset();
            }

        }

        /// <summary>
        /// 获取轴正、负限位以及原点感应信号
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="homeSignal">是否到原点</param>
        /// <param name="posSignal">是否到正限位</param>
        /// <param name="negSignal">是否到负限位</param>
        public void GetAxisLimitedSignal(ushort axis, ref bool homeSignal, ref bool posSignal, ref bool negSignal)
        {
            uint portValue;

            lock (globalLock)
            {
                portValue = LTDMC.dmc_read_inport(m_cardNo, 1);
                homeSignal = (portValue & (0x1 << axis)) == 0;

                portValue = LTDMC.dmc_read_inport(m_cardNo, 0);
                posSignal = (portValue & (0x1 << (axis + 16))) > 0;
                negSignal = (portValue & (0x1 << (axis + 24))) > 0;
            }

        }

        public double GetAxisPulsePos(ushort axis)
        {
            double curPos = 0;

            curPos = LTDMC.dmc_get_position(m_cardNo, axis);

            return curPos; // * m_axisRes[axis];
        }

        public double GetAxisEncodePos(ushort axis)
        {
            double curPos = 0;

            curPos = LTDMC.dmc_get_encoder(m_cardNo, axis);

            return curPos;// * m_axisRes[axis];
        }

        /// <summary>
        /// 记录异常信息
        /// </summary>
        /// <param name="errorCode">异常码</param>
        /// <param name="info">异常信息</param>
        private void MotionError(short errorCode, string info)
        {
            if (errorCode != 0)
            {
                AdvErrorCode = errorCode;
                if (AdvErrorCode == OldErrorCode)
                {
                    return;
                }

                OldErrorCode = AdvErrorCode;
                string sTemp = errorCode.ToString();
                string msg1 = "运动控制卡：" + info + "错误码：" + sTemp;
                string msg2 = msg1 + "\n";

                m_logFile.AppendText(msg2);
                OnMontorErrorHappened(msg1);
            }
        }

        private void OnMontorErrorHappened(string msg1)
        {
            if (MonitorErrorCallBack != null)
            {
                MonitorErrorCallBack(msg1);
            }

        }

        /// <summary>
        /// 关闭所有控制卡
        /// </summary>
        public static void CloseCard()
        {
            try
            {
                LTDMC.dmc_board_close();
            }
            catch (Exception ex)
            {
                m_logFile.AppendText(ex.Message);
            }
        }


    }
}
