using csLTDMC;
using System;
using System.Threading;
using System.Windows.Forms;

namespace HuaTianProject.UI
{
    public partial class BackHomeForm : Form
    {
        private ushort m_cardId = FormMain.CardId;
        private double m_equiv = FormMain.PulseEquiv;
        private double m_startSpeed = FormMain.StartSpeed;
        private double m_moveSpeed = FormMain.HomeSpeed;
        private double m_stopSpeed = FormMain.StopSpeed;
        private double m_acc = FormMain.AccTime;
        private double m_dec = FormMain.DecTime;
        private ushort axisGoHome = 0;
        bool homeSensor0 = false, posLimited0 = false, negLimited0 = false;
        //   bool homeSensor1 = false, posLimited1 = false, negLimited1 = false;
        //    bool homeSensor2 = false, posLimited2 = false, negLimited2 = false;

        private object globalLock = new object();
        private bool HomeThreadLive = false;
        private Thread selfThread;

        private FormMain m_main;

        public BackHomeForm()
        {
            InitializeComponent();
        }

        public BackHomeForm(FormMain main)
        {
            InitializeComponent();
            m_main = main;
        }

        private void BackHomeForm_Load(object sender, EventArgs e)
        {

        }

        private ushort GetAxis()
        {
            ushort axis = 0;
            if (rabX.Checked)
            {
                axis = 0;
            }
            else if (rabY.Checked)
            {
                axis = 1;
            }
            else if (rabZ.Checked)
            {
                axis = 2;
            }
            else if (rabW.Checked)
            {
                axis = 3;
            }
            return axis;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bool result = m_main.MotionCard.WaitForAllAxisMotionDone();

            if (result)
            {
                Close();
            }
            else
            {
                m_main.AddLog("正在执行回零操作,请稍等！", false, true);
            }
        }

        private ushort GetHomeDir()
        {
            ushort dir = 0;
            return dir;
        }
        private double GetHomeSpeed()
        {
            double speed = m_moveSpeed;
            return speed;
        }
        private ushort GetHomeMode()
        {
            ushort mode = 2;
            return mode;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            selfThread = new Thread(new ThreadStart(SingleHomeThread));
            selfThread.IsBackground = true;
            selfThread.Start();

        }
        private void SingleHomeThread()
        {
            AxisBackHome(GetAxis());
            bool doneState = WaitAxisMotionDone(GetAxis(), 10000);
            if (doneState)
            {
                setZero(GetAxis());
            }
            selfThread.Abort();
        }
        private void AxisBackHome(ushort axis)
        {
            axisGoHome = axis;
            LTDMC.dmc_set_home_pin_logic(m_cardId, axis, 0, 0);//设置原点低电平有效,保留参数
            LTDMC.dmc_set_pulse_outmode(m_cardId, axis, 0);//设置脉冲模式
            LTDMC.dmc_set_equiv(m_cardId, axis, m_equiv);//设置脉冲当量
            LTDMC.dmc_set_profile_unit(m_cardId, axis, m_startSpeed, m_moveSpeed, m_acc, m_dec, m_stopSpeed);//设置起始速度、运行速度、停止速度、加速时间、减速时间
            LTDMC.dmc_set_homemode(m_cardId, axis, GetHomeDir(), GetHomeSpeed(), GetHomeMode(), 0);//设置回零模式
            LTDMC.dmc_home_move(m_cardId, axis);//启动回零


            if (m_main.MotionCard.WaitForAxisMoveDone(axis, 5000))
            {
                setZero(axis);
            }

        }

        private void btnOneKeyBack_Click(object sender, EventArgs e)
        {
            StartHome(2);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (selfThread != null)
            {
                selfThread.Abort();
            }

            LTDMC.dmc_stop(m_cardId, GetAxis(), 0);
        }

        public void GetAxisLimitedSensor(ushort axis, ref bool homeSensor, ref bool positiveLtd, ref bool negativeLtd)
        {
            uint portValue;

            portValue = LTDMC.dmc_read_inport(m_cardId, (ushort)1);
            homeSensor = ((portValue & (0x1 << (axis))) == 0) ? true : false;

            portValue = LTDMC.dmc_read_inport(m_cardId, (ushort)0);
            positiveLtd = ((portValue & (0x1 << (axis + 16))) > 0) ? true : false;
            negativeLtd = ((portValue & (0x1 << (axis + 24))) > 0) ? true : false;
        }

        public void StartHome(int axis)
        {
            string axisName = Convert.ToString(axis);
            selfThread = new Thread(new ParameterizedThreadStart(HomeThread));
            selfThread.IsBackground = true;
            selfThread.Name = axisName;
            selfThread.Start(axis);
        }

        private void HomeThread(object obj)
        {
            ushort axis = Convert.ToUInt16(obj);
            HomeThreadLive = true;

            //switch (axis)
            //{
            //    case 2:
            //        OrderByAxis(axis);
            //        break;
            //    case 1:
            //        OrderByAxis(axis);
            //        break;
            //    case 0:
            //        OrderByAxis(axis);
            //        break;
            //    default:
            //        break;
            //}
            AxisBackHome(2);
            bool doneState = WaitAxisMotionDone(2, 10000);

            if (doneState)
            {
                setZero(2);
                AxisBackHome(1);
                if (WaitAxisMotionDone(1, 10000))
                {
                    setZero(1);
                    AxisBackHome(0);
                    if (WaitAxisMotionDone(0, 10000))
                    {
                        setZero(0);
                        selfThread.Abort();
                    }
                }
            }

            #region TWO
            /*
            if (axis == 2)
            {
                AxisBackHome(2);
                Thread.Sleep(100);
                while (true)
                {
                    GetAxisLimitedSensor(2, ref homeSensor0, ref posLimited0, ref negLimited0);
                    if (homeSensor0)
                    {
                        LTDMC.dmc_stop(0, 2, 1);
                    }
                    short state = LTDMC.dmc_check_done(0, 2);
                    if (state == 1)
                    {
                        LTDMC.dmc_set_position(0, 2, 0);
                        LTDMC.dmc_set_encoder(0, 2, 0);
                        StartHome(1);
                        break;
                    }
                }
            }
            if (axis == 1)
            {
                AxisBackHome(1);
                Thread.Sleep(100);
                while (true)
                {
                    GetAxisLimitedSensor(1, ref homeSensor0, ref posLimited0, ref negLimited0);
                    if (homeSensor0)
                    {
                        LTDMC.dmc_stop(0, 1, 1);
                    }
                    short state = LTDMC.dmc_check_done(0, 1);
                    if (state == 1)
                    {
                        LTDMC.dmc_set_position(0, 1, 0);
                        LTDMC.dmc_set_encoder(0, 1, 0);
                        StartHome(0);
                        break;
                    }
                }
            }
            if (axis == 0)
            {
                AxisBackHome(0);
                Thread.Sleep(100);
                while (true)
                {
                    GetAxisLimitedSensor(0, ref homeSensor0, ref posLimited0, ref negLimited0);
                    if (homeSensor0)
                    {
                        LTDMC.dmc_stop(0, 0, 1);
                    }
                    short state = LTDMC.dmc_check_done(0, 0);
                    if (state == 1)
                    {
                        LTDMC.dmc_set_position(0, 0, 0);
                        LTDMC.dmc_set_encoder(0, 0, 0);
                        break;
                    }
                }
            } 
            */
            #endregion

        }
        private void setZero(ushort axis)
        {
            LTDMC.dmc_set_position(m_cardId, axis, 0);
            LTDMC.dmc_set_encoder(m_cardId, axis, 0);
        }

        private void BackHomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool result = m_main.MotionCard.WaitForAllAxisMotionDone();

            if (result)
            {
                e.Cancel = false;
            }
            else
            {
                m_main.AddLog("正在执行回零操作,请稍等！", false, true);
                e.Cancel = true;
            }
        }

        private void OrderByAxis(ushort axis)
        {
            AxisBackHome(axis);
            Thread.Sleep(100);
            while (true)
            {
                GetAxisLimitedSensor(axis, ref homeSensor0, ref posLimited0, ref negLimited0);
                if (homeSensor0)
                {
                    LTDMC.dmc_stop(0, axis, 1);
                }
                short state = LTDMC.dmc_check_done(0, axis);
                if (state == 1)
                {
                    if (axis != 0)
                    {
                        StartHome(axis - 1);
                    }
                    break;
                }
            }
        }
        private bool WaitAxisMotionDone(int axis, int uMilliSeconds)
        {

            short status = 0;
            int nMillSec = uMilliSeconds;
            while (true)
            {
                if (nMillSec-- == 0) return false;
                lock (globalLock)
                {
                    status = LTDMC.dmc_check_done(0, (ushort)axis);
                    if (status == 1) return true;
                }
                Thread.Sleep(1);
            }
        }
    }
}
