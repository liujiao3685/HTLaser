using System;
using System.Windows.Forms;
using csLTDMC;

namespace HuaTianProject.UI
{
    public partial class LaserControlForm : Form
    {
        private ushort m_cardId;

        private FormMain m_main;

        public LaserControlForm()
        {
            InitializeComponent();
        }

        public LaserControlForm(FormMain main)
        {
            InitializeComponent();
            this.m_main = main;
        }

        private void LaserControlForm_Load(object sender, EventArgs e)
        {
            m_cardId = FormMain.CardId;
            cmbDAChannel.SelectedIndex = 0;
            cmbChannel.SelectedIndex = 0;
        }

        private ushort GetChannel()
        {
            ushort channel = Convert.ToUInt16(this.cmbChannel.SelectedItem);
            return channel;
        }

        private ushort GetEnable()
        {
            ushort enable = (ushort)(this.rabEnable.Checked ? 1 : 0);
            return enable;
        }

        private ushort GetPwmMode()
        {
            ushort mode = 0;
            //switch (cmbFllow.SelectedIndex)
            //{
            //    case 0:
            //        mode = 0;
            //        break;
            //    case 1:
            //        mode = 1;
            //        break;
            //    case 2:
            //        mode = 2;
            //        break;
            //    case 3:
            //        mode = 3;
            //        break;
            //    case 4:
            //        mode = 4;
            //        break;
            //    default:
            //        break;
            //}
            return mode;
        }

        //设置PWM参数
        private void SetPwm()
        {
            ushort channel = GetChannel();
            double duty = Convert.ToDouble(this.txtDuty.Value) / 100;
            double freq = Convert.ToDouble(this.txtFreq.Value);

            //设置PWM输出使能状态
            LTDMC.dmc_set_pwm_enable(m_cardId, GetEnable());

            //设置PWM输出参数
            LTDMC.dmc_set_pwm_output(m_cardId, channel, duty, freq);

            //0-100

            //100 持续2S

            //100-0

        }

        //设置PWM连续插补
        private void SetVPwm() 
        {
            ushort channel = GetChannel();
            double duty = Convert.ToDouble(this.txtDuty.Value) / 100;
            double freq = Convert.ToDouble(this.txtFreq.Value);

            m_main.PWMChannel = channel;
            m_main.PWMDuty = duty;
            m_main.PWMFreq = freq;

            LTDMC.dmc_set_pwm_onoff_duty(m_cardId, 0, 0.8, 0.05);//设置PWM开关状态对应的占空比

            LTDMC.dmc_set_pwm_enable(m_cardId, GetEnable());
            LTDMC.dmc_set_pwm_output(m_cardId, channel, duty, freq);

            //设置插补轴脉冲
            LTDMC.dmc_set_equiv(m_cardId, 0, 100);
            LTDMC.dmc_set_equiv(m_cardId, 1, 100);

            //设置插补速度曲线参数,Crd坐标系
            LTDMC.dmc_set_vector_profile_unit(m_cardId, 0, 0, 100, 0.1, 0, 0);
            //设置跟随速度参数
            LTDMC.dmc_conti_set_pwm_follow_speed(m_cardId, 0, channel, GetPwmMode(), 100, 0, 0);

            //PWM跟随模式模式为0、1、2时，MaxValue/MaxVel/OutValue此三个参数无效

            ushort onOff = 1; //PWM输出状态为：打开
            ushort deMode = 0; //滞后模式为：滞后时间   
            double deTime = 2; //滞后时间：2S
            double revTime = 0; //保留参数：固定为0

            //设置轨迹段起点滞后时间
            LTDMC.dmc_conti_delay_pwm_to_start(m_cardId, 0, channel, onOff, deTime, deMode, revTime);

            //打开连续插补缓冲区
            LTDMC.dmc_conti_open_list(m_cardId, 0, 2, new ushort[] { 0, 1 });

            //第一段轨迹直线插补，绝对模式
            ushort[] axiss = { 0, 1 };
            //目标位置
            double[] tPos = { 200, 0 };
            LTDMC.dmc_conti_line_unit(m_cardId, 0, 2, axiss, tPos, 0, 1);

            //相当于轨迹终点，提前1S关闭使能
            double ahValue = 1; //提前1秒
            ushort ahMode = 0; //输出提前模式：提前时间
            LTDMC.dmc_conti_ahead_pwm_to_stop(m_cardId, 0, channel, 0, ahValue, ahMode, 0);

            //禁止PWM输出
            //LTDMC.dmc_set_pwm_enable(m_cardId, 0);

            //设置第二段轨迹直线插补，绝对模式
            //目标位置
            double[] ePos = { 0, 0 };
            LTDMC.dmc_conti_line_unit(m_cardId, 0, 2, axiss, ePos, 0, 1);

            //开始连续插补
            LTDMC.dmc_conti_start_list(m_cardId, 0);

            //关闭连续插补缓冲区
            LTDMC.dmc_conti_close_list(m_cardId, 0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "启动")
            {
                btnStart.Text = "停止";
                SetVPwm();

            }
            else
            {
                btnStart.Text = "启动";
                timer1.Enabled = false;
                LTDMC.dmc_set_pwm_enable(m_cardId, 0);
            }
        }

        //DA 启动
        private void button1_Click(object sender, EventArgs e)
        {
            if (btnDARun.Text == "启动")
            {
                btnDARun.Text = "停止";

                SetDA();
            }
            else
            {
                btnDARun.Text = "启动";
                LTDMC.dmc_set_da_enable(m_cardId, 0);
            }
        }

        //设置DA参数
        private void SetDA()
        {
            //设置DA使能
            LTDMC.dmc_set_da_enable(m_cardId, 1);

            ushort channel = Convert.ToUInt16(this.cmbDAChannel.Text);
            double voltage = Convert.ToDouble(this.txtOutPutVol.Value);

            m_main.DAChannel = channel;
            m_main.DAVoltage = voltage;

            LTDMC.dmc_set_da_output(m_cardId, channel, voltage);
        }

        private void cmbChannel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ushort channel = GetChannel();
            double freq = Convert.ToDouble(this.txtFreq.Value);

            //设置PWM输出使能状态
            LTDMC.dmc_set_pwm_enable(m_cardId, GetEnable());

            //设置PWM输出参数
            LTDMC.dmc_set_pwm_output(m_cardId, channel, this.timer1.Interval / 100, freq);
        }

    }
}
