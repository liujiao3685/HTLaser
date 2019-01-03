using System;
using System.Threading;
using System.Windows.Forms;
using csLTDMC;
using HuaTianProject.UI;

namespace HuaTianProject.UserControls
{
    public partial class MontionControlForm : FormBase
    {
        //绝对运动Form
        private AbsoluteControlForm absoluteControl;

        //手动IOForm
        //  private ManualIOForm manualForm;

        //回零
        private BackHomeForm backHomeForm;

        //运动参数
        private UI.ParamSetForm montionParamForm;

        //登录界面
        private LoginRightsForm m_loginForm;

        //使用控制卡ID
        private ushort m_cardID;

        //原点信号
        private bool m_homeSginal;

        //正限位信号
        private bool m_posSginal;

        //负限位信号
        private bool m_negSginal;

        //定义委托
        public delegate void LoginResultHandle(object sender, MyEvent args);

        //定义事件
        public event LoginResultHandle LoginResult;

        //是否登录成功
        public static bool Result;

        private Thread m_updateLocation;

        private FormMain m_formMain;

        //调用事件函数
        public void OnLoginResult(object sender, MyEvent args)
        {
            Result = args.Result;
        }

        public MontionControlForm()
        {
            InitializeComponent();
        }

        public MontionControlForm(FormMain main)
        {
            InitializeComponent();
            m_formMain = main;
        }

        private void MontionControlForm_Load(object sender, EventArgs e)
        {
            this.ControlName = "运动控制";

            this.m_cardID = FormMain.CardId;

            m_updateLocation = new Thread(new ThreadStart(DoWork)) { IsBackground = true };
            m_updateLocation.Start();

            //this.timer1.Start();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //MyEvent mye = new MyEvent(this.ControlName + ":" + this.textBox1.Text);
                //OnDataChange(this, mye);
            }
        }

        //Open绝对运动界面
        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginRightsForm.CurrencyManager))
            {
                ShowLogin();
            }
            if (Result)
            {
                absoluteControl = new AbsoluteControlForm();
                absoluteControl.ShowDialog();
                //Result = false;
            }

        }

        //Open手动IO界面
        private void button10_Click(object sender, EventArgs e)
        {
            /*
            ShowLogin();
            if (result)
            {
                manualForm = new ManualIOForm();
                manualForm.ShowDialog();
                result = false;
            }*/
        }

        //Open回零界面
        private void btnBackHome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginRightsForm.CurrencyManager))
            {
                ShowLogin();
            }
            if (Result)
            {
                backHomeForm = new BackHomeForm();
                backHomeForm.ShowDialog();
                //Result = false;
            }
        }

        //Open运动参数界面
        private void btnMontionParam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginRightsForm.CurrencyManager))
            {
                ShowLogin();
            }
            if (Result)
            {
                montionParamForm = new UI.ParamSetForm();
                montionParamForm.ShowDialog();
                //Result = false;
            }

        }

        //Open权限界面
        private void ShowLogin()
        {
            m_loginForm = new LoginRightsForm();
            m_loginForm.LoginResult += new LoginRightsForm.LoginResultHandle(OnLoginResult);
            m_loginForm.ShowDialog();
        }

        //停止运动
        private void StopMove(ushort cardId, ushort axis)
        {
            ushort stopMode = 0;//0-减速停止，1-紧急停止
            LTDMC.dmc_stop(cardId, axis, stopMode);
        }

        #region 线程更新

        //将text更新的界面控件的委托类型
        private delegate void SetXPosHandle(Control control, string txt);

        //线程的主体方法
        private void DoWork()
        {
            while (true)
            {
                if (FormMain.IsInit)
                {
                    UpdatePosition(txtXLocation, LTDMC.dmc_get_position(m_cardID, 0).ToString());
                    UpdatePosition(txtYLocation, LTDMC.dmc_get_position(m_cardID, 1).ToString());
                    UpdatePosition(txtZLocation, LTDMC.dmc_get_position(m_cardID, 2).ToString());
                    UpdatePosition(txtWLocation, LTDMC.dmc_get_position(m_cardID, 3).ToString());
                    Thread.Sleep(5);
                }
            }
        }

        //定义更新UI控件的方法
        private void UpdatePosition(Control control, string txt)
        {
            if (control.InvokeRequired)
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    while (!control.IsHandleCreated)
                    {
                        if (control.Disposing || control.IsDisposed)
                        {
                            return;
                        }
                    }
                    SetXPosHandle set = new SetXPosHandle(UpdatePosition);
                    control.Invoke(set, new object[] { control, txt });
                });
            }
            else
            {
                control.Text = txt;
            }
        }
        #endregion

        //Timer-定时器更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FormMain.IsInit)
            {
                this.txtXLocation.Text = LTDMC.dmc_get_position(m_cardID, 0).ToString();
                this.txtYLocation.Text = LTDMC.dmc_get_position(m_cardID, 1).ToString();
                this.txtZLocation.Text = LTDMC.dmc_get_position(m_cardID, 2).ToString();
                this.txtWLocation.Text = LTDMC.dmc_get_position(m_cardID, 3).ToString();
            }
        }

        #region 连续运动

        private void ContinueMove(ushort cardId, ushort axis, ushort dir)
        {
            //设置脉冲输出方式
            LTDMC.dmc_set_pulse_outmode(cardId, axis, 0);
            //设置脉冲当量
            LTDMC.dmc_set_equiv(cardId, axis, FormMain.PulseEquiv);
            //设置速度参数
            LTDMC.dmc_set_profile_unit(cardId, axis, FormMain.StartSpeed, FormMain.MoveSpeed, FormMain.AccTime, FormMain.DecTime, FormMain.StopSpeed);
            //设置S段速度参数
            LTDMC.dmc_set_s_profile(cardId, axis, 0, FormMain.SParamSpeed);
            //减速停止时间
            LTDMC.dmc_set_dec_stop_time(cardId, axis, FormMain.DecStopTime);
            //开始连续运动
            LTDMC.dmc_vmove(cardId, axis, dir);

        }

        private void labXAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 0, 1);
            }
        }

        private void labXAdd_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 0);
        }

        private void labXDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 0, 0);
            }
        }

        private void labXDec_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 0);
        }

        private void labYAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 1, 1);
            }
        }

        private void labYAdd_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 1);
        }

        private void labYDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 1, 0);
            }
        }

        private void labYDec_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 1);
        }

        private void labZAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 2, 1);
            }
        }

        private void labZAdd_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 2);
        }

        private void labZDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 2, 0);
            }
        }

        private void labZDec_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 2);
        }

        private void labWAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 3, 1);
            }
        }

        private void labWAdd_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 3);
        }

        private void labWDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 3, 0);
            }
        }

        private void labWDec_MouseUp(object sender, MouseEventArgs e)
        {
            StopMove(m_cardID, 3);
        }
        #endregion

        #region 点位运动

        private void SetPara(ushort axis, double dist)
        {
            LTDMC.dmc_set_equiv(FormMain.CardId, axis, FormMain.PulseEquiv);
            LTDMC.dmc_set_profile_unit(FormMain.CardId, axis, FormMain.StartSpeed, FormMain.MoveSpeed, FormMain.AccTime, FormMain.DecTime, FormMain.StopSpeed);
            LTDMC.dmc_set_s_profile(FormMain.CardId, axis, 0, FormMain.SParamSpeed);
            LTDMC.dmc_set_dec_stop_time(FormMain.CardId, axis, FormMain.DecStopTime);
            LTDMC.dmc_pmove_unit(m_cardID, 0, dist, 0);

        }

        private void labXAdd_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(0, GetMoveDistance());
            }
        }

        private void labXDec_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(0, -GetMoveDistance());
            }
        }

        private double GetMoveDistance()
        {
            return FormMain.PointDistance;

        }
        private void labYAdd_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(1, GetMoveDistance());
            }
        }

        private void labYDec_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(1, -GetMoveDistance());
            }
        }

        private void labZAdd_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(2, GetMoveDistance());
            }
        }

        private void labZDec_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(2, -GetMoveDistance());
            }
        }

        private void labWAdd_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(3, GetMoveDistance());
            }
        }

        private void labWDec_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                SetPara(3, -GetMoveDistance());
            }
        }
        #endregion

    }

}
