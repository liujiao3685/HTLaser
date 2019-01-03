using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using csLTDMC;
using HuaTianProject.Core;
using HuaTianProject.Interface.Impl;
using HuaTianProject.Libs;

namespace HuaTianProject.UserControls
{
    public partial class TeachingUserControl : FormBase
    {
        private ushort m_cardID = FormMain.CardId;
        private double PulseEquiv = FormMain.PulseEquiv;
        private double StartSpeed = FormMain.StartSpeed;
        private double AccTime = FormMain.AccTime;
        private double DecTime = FormMain.DecTime;
        private double StopSpeed = FormMain.StopSpeed;
        private double SParamSpeed = FormMain.SParamSpeed;
        private double LineInterSpeed = FormMain.LineInterSpeed;
        private double ArcInterSpeed = FormMain.ArcInterSpeed;
        private double AbsoulteSpeed = FormMain.AbsoulteSpeed;
        private double ReletiveSpeed = FormMain.ReletiveSpeed;
        private double JogSpeed = FormMain.JogSpeed;
        private double HomeSpeed = FormMain.HomeSpeed;
        private double absolutePosX;//目标位置
        private double absolutePosY;
        private double absolutePosZ;
        private double absolutePosW;

        private static int width = 500;
        private static int height = 500;

        private SignalX m_signalX = new SignalX();
        private SignalY m_signalY = new SignalY();
        private SignalY m_signalZ = new SignalY();

        private FormMain m_formMain;

        bool homeSensor0 = false, posLimited0 = false, negLimited0 = false;
        bool homeSensor1 = false, posLimited1 = false, negLimited1 = false;
        bool homeSensor2 = false, posLimited2 = false, negLimited2 = false;
        bool homeSensor3 = false, posLimited3 = false, negLimited3 = false;

        private bool[] axisSignalX, axisSignalY, axisSignalZ, axisSignalW;

        private Dictionary<string, string> dic = new Dictionary<string, string>();

        public TeachingUserControl()
        {
            InitializeComponent();
        }

        public TeachingUserControl(FormMain form)
        {
            InitializeComponent();
            m_formMain = form;
        }

        private void TeachingUserControl_Load(object sender, EventArgs e)
        {
            width = pictureBox1.Width;
            height = pictureBox1.Height;

            InitUI();
            InitHandle();

            ReadVector();
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen2 = new Pen(Color.Black, 4);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen2, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen2, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            pictureBox1.Image = bm;

            //Thread ReadPositionThread = new Thread(new ThreadStart(ReadPosition));
            //ReadPositionThread.IsBackground = true;
            //ReadPositionThread.Start();

        }

        private void InitUI()
        {
            axisSignalX = new bool[3];
            axisSignalY = new bool[3];
            axisSignalZ = new bool[3];
            axisSignalW = new bool[3];

            int count = m_formMain.GetAxisCount();

            for (ushort i = 0; i < count; i++)
            {
                MontionCard_MontorPosChange(i);
            }

        }

        //初始化事件委托
        private void InitHandle()
        {
            m_formMain.MotionCard.MonitorPosChangeCallBack += new CDMC5400A.MonitorPosChangeDelegate(MontionCard_MontorPosChange);
        }

        private void MontionCard_MontorPosChange(ushort axis)
        {
            double pos = m_formMain.MotionCard.GetAxisPulsePos(axis);
            string sPos = Convert.ToString(pos);
            switch (axis)
            {
                case 0:
                    lbRealX.Text = sPos;
                    break;
                case 1:
                    lbRealY.Text = sPos;
                    break;
                case 2:
                    lbRealZ.Text = sPos;
                    break;
                case 3:
                    lbRealW.Text = sPos;
                    break;
                default:
                    break;
            }
        }

        public void GetAxisLimitedSensor(ushort axis, ref bool homeSensor, ref bool positiveLtd, ref bool negativeLtd)
        {
            uint portValue;

            portValue = LTDMC.dmc_read_inport(0, (ushort)1);
            homeSensor = ((portValue & (0x1 << (axis))) == 0) ? true : false;

            portValue = LTDMC.dmc_read_inport(0, (ushort)0);
            positiveLtd = ((portValue & (0x1 << (axis + 16))) == 0) ? true : false;
            negativeLtd = ((portValue & (0x1 << (axis + 24))) == 0) ? true : false;
        }

        private delegate void SetXPosHandle(Control control, string txt);
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
        private void SetPara(ushort axis, double myspeed)
        {
            LTDMC.dmc_set_equiv(0, axis, PulseEquiv);  //设置脉冲当量

            LTDMC.dmc_set_profile_unit(0, axis, StartSpeed, myspeed, AccTime, DecTime, StopSpeed);//设置速度参数

            LTDMC.dmc_set_s_profile(0, axis, 0, SParamSpeed);//设置S段速度参数

            LTDMC.dmc_set_dec_stop_time(0, axis, DecTime); //设置减速停止时间
        }

        private void btnXPosDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(0, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 0, dDist, 0);//定长运动
            }

        }

        private void btnXNegDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(0, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 0, -dDist, 0);//定长运动
            }

        }

        private void btnYPosDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(1, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 1, dDist, 0);//定长运动
            }

        }

        private void btnYNegDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(1, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 1, -dDist, 0);//定长运动
            }


        }

        private void btnZPosDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(2, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 2, dDist, 0);//定长运动
            }

        }

        private void btnZNegDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(2, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 2, -dDist, 0);//定长运动
            }

        }

        private void btnWPosDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(3, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 3, dDist, 0);//定长运动
            }
        }

        private void btnWNegDir_Click(object sender, EventArgs e)
        {
            if (radioRlt.Checked)
            {
                double dDist;//目标位置
                dDist = Convert.ToDouble(txtRltDis.Text);
                SetPara(3, ReletiveSpeed);
                LTDMC.dmc_pmove_unit(m_cardID, 3, -dDist, 0);//定长运动
            }
        }

        private void ContinueMove(ushort cardId, ushort axis, ushort dir)
        {
            //设置脉冲输出方式
            LTDMC.dmc_set_pulse_outmode(cardId, axis, 0);
            //设置脉冲当量
            LTDMC.dmc_set_equiv(cardId, axis, PulseEquiv);
            //设置速度参数
            LTDMC.dmc_set_profile_unit(cardId, axis, StartSpeed, JogSpeed, AccTime, DecTime, StopSpeed);
            //设置S段速度参数
            LTDMC.dmc_set_s_profile(cardId, axis, 0, SParamSpeed);
            //减速停止时间
            LTDMC.dmc_set_dec_stop_time(cardId, axis, DecTime);
            //开始连续运动
            LTDMC.dmc_vmove(cardId, axis, dir);

        }

        private void StopMove(ushort cardId, ushort axis)
        {
            ushort stopMode = 0;//0-减速停止，1-紧急停止
            LTDMC.dmc_stop(cardId, axis, stopMode);
        }

        private void btnXPosDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 0);
        }

        private void btnXNegDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 0);
        }

        private void btnYPosDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 1);
        }

        private void btnYNegDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 1);
        }

        private void btnZPosDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 2);
        }

        private void btnZNegDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 2);
        }

        private void btnWPosDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 3);
        }

        private void btnWNegDir_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
                StopMove(m_cardID, 3);
        }

        private void btnXPosDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 0, 1);


            }

        }

        private void btnXNegDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 0, 0);

            }
        }
        private void btnYPosDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 1, 1);

            }
        }

        private void btnYNegDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 1, 0);

            }
        }

        private void btnZPosDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 2, 1);

            }
        }

        private void btnZNegDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 2, 0);

            }

        }

        private void btnWPosDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 3, 1);
            }
        }

        private void btnWNegDir_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioJog.Checked)
            {
                ContinueMove(m_cardID, 3, 0);
            }
        }
        private void btnSavePos_Click(object sender, EventArgs e)
        {
            try
            {
                dic.Clear();
                if (radioStartePos.Checked)
                {
                    dic.Add("StartPositionX", lbPointX.Text);
                    dic.Add("StartPositionY", lbPointY.Text);
                }
                if (radioEndPos.Checked)
                {
                    dic.Add("EndPositionX", lbPointX.Text);
                    dic.Add("EndPositionY", lbPointY.Text);
                }
                if (radioWeldPos1.Checked)
                {
                    dic.Add("WeltPosition1X", lbPointX.Text);
                    dic.Add("WeltPosition1Y", lbPointY.Text);
                }
                if (radioWeldPos2.Checked)
                {
                    dic.Add("WeltPosition2X", lbPointX.Text);
                    dic.Add("WeltPosition2Y", lbPointY.Text);
                }
                if (rabReserve1.Checked)
                {
                    dic.Add("Reserve1Z", lbPointZ.Text);
                    dic.Add("Reserve1W", lbPointW.Text);
                }
                if (rabReserve2.Checked)
                {
                    dic.Add("Reserve2Z", lbPointZ.Text);
                    dic.Add("Reserve2W", lbPointW.Text);
                }

                FormMain.SaveXmlData(dic);
                FormMain.AnalysisDictionary();

                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }

        private void radioWeldPos1_Click(object sender, EventArgs e)
        {
            if (radioStartePos.Checked == true)
            {
                lbPointX.Text = FormMain.StartPositionX.ToString();
                lbPointY.Text = FormMain.StartPositionY.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
                lbPointZ.Visible = false;
                labelZ.Visible = false;
                lbPointW.Visible = false;
                labelW.Visible = false;
            }
            if (radioEndPos.Checked == true)
            {
                lbPointX.Text = FormMain.EndPositionX.ToString();
                lbPointY.Text = FormMain.EndPositionY.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
                lbPointZ.Visible = false;
                labelZ.Visible = false;
                lbPointW.Visible = false;
                labelW.Visible = false;
            }
            if (radioWeldPos1.Checked == true)
            {
                lbPointX.Text = FormMain.WeltPosition1X.ToString();
                lbPointY.Text = FormMain.WeltPosition1Y.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
                lbPointZ.Visible = false;
                labelZ.Visible = false;
                lbPointW.Visible = false;
                labelW.Visible = false;
            }
            if (radioWeldPos2.Checked == true)
            {
                lbPointX.Text = FormMain.WeltPosition2X.ToString();
                lbPointY.Text = FormMain.WeltPosition2Y.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
                lbPointZ.Visible = false;
                labelZ.Visible = false;
                lbPointW.Visible = false;
                labelW.Visible = false;
            }
            if (rabReserve1.Checked == true)
            {
                lbPointZ.Text = FormMain.Reserve1Z.ToString();
                lbPointW.Text = FormMain.Reserve1W.ToString();
                lbPointX.Visible = false;
                labelX.Visible = false;
                lbPointY.Visible = false;
                labelY.Visible = false;
                lbPointZ.Visible = true;
                labelZ.Visible = true;
                lbPointW.Visible = true;
                labelW.Visible = true;
            }
            if (rabReserve2.Checked == true)
            {
                lbPointZ.Text = FormMain.Reserve2Z.ToString();
                lbPointW.Text = FormMain.Reserve2W.ToString();
                lbPointX.Visible = false;
                labelX.Visible = false;
                lbPointY.Visible = false;
                labelY.Visible = false;
                lbPointZ.Visible = true;
                labelZ.Visible = true;
                lbPointW.Visible = true;
                labelW.Visible = true;
            }
        }
        private void RunPosXy()
        {
            SetPara(0, AbsoulteSpeed);
            SetPara(1, AbsoulteSpeed);
            absolutePosX = Convert.ToDouble(lbPointX.Text);
            absolutePosY = Convert.ToDouble(lbPointY.Text);
            LTDMC.dmc_pmove_unit(0, 0, absolutePosX, 1);//定长运动
            LTDMC.dmc_pmove_unit(0, 1, absolutePosY, 1);//定长运动
        }
        private void RunPosZw()
        {
            SetPara(2, AbsoulteSpeed);
            SetPara(3, AbsoulteSpeed);
            absolutePosZ = Convert.ToDouble(lbPointZ.Text);
            absolutePosW = Convert.ToDouble(lbPointW.Text);
            LTDMC.dmc_pmove_unit(0, 0, absolutePosX, 1);//定长运动
            LTDMC.dmc_pmove_unit(0, 1, absolutePosY, 1);//定长运动
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            if (radioStartePos.Checked == true)
            {
                RunPosXy();
            }
            if (radioEndPos.Checked == true)
            {
                RunPosXy();
            }
            if (radioWeldPos1.Checked == true)
            {
                RunPosXy();
            }
            if (radioWeldPos2.Checked == true)
            {
                RunPosXy();
            }
            if (rabReserve1.Checked == true)
            {
                RunPosZw();
            }
            if (rabReserve2.Checked == true)
            {
                RunPosZw();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            ushort stop_mode = 1; //制动方式，0：减速停止，1：紧急停止
            LTDMC.dmc_stop(0, 0, stop_mode);
            LTDMC.dmc_stop(0, 1, stop_mode);
            LTDMC.dmc_stop(0, 2, stop_mode);
            LTDMC.dmc_stop(0, 3, stop_mode);
        }
        private void cbxMotionTrail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMotionTrail.SelectedIndex == 0)
            {
                DrawMotionTrail1();
            }
            if (cbxMotionTrail.SelectedIndex == 1)
            {
                DrawMotionTrail2();
            }
            if (cbxMotionTrail.SelectedIndex == 2)
            {
                DrawMotionTrail3();
            }
            if (cbxMotionTrail.SelectedIndex == 3)
            {
                DrawMotionTrail4();
            }
        }
        private void DrawMotionTrail1()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen2 = new Pen(Color.Black, 4);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen2, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen2, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 3, height / 3);
            Point B = new Point(width * 2 / 3, height / 3);
            Point C = new Point(width * 5 / 6, height / 3 + width / 6);
            Point D = new Point(width * 5 / 6, height * 5 / 6 - 50);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            g.DrawString("A", this.Font, new SolidBrush(Color.Blue), width / 3 - 5, height / 3 - 15);
            g.DrawString("B", this.Font, new SolidBrush(Color.Blue), width * 2 / 3 - 5, height / 3 - 15);
            g.DrawString("C", this.Font, new SolidBrush(Color.Blue), width * 5 / 6 + 5, height / 3 + width / 6 - 3);
            g.DrawString("D", this.Font, new SolidBrush(Color.Blue), width * 5 / 6 - 5, height * 5 / 6 + 2);
            g.Dispose();
            pictureBox1.Image = bm;
        }
        private void DrawMotionTrail2()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen2 = new Pen(Color.Black, 4);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen2, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen2, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width * 2 / 5, height * 4 / 5);
            Point B = new Point(width * 2 / 5, height * 2 / 5);
            Point C = new Point(width * 3 / 5, height * 2 / 5);
            Point D = new Point(width * 3 / 5, height * 4 / 5);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawArc(pen, width * 1 / 5, height * 2 / 5, width * 2 / 5, height * 2 / 5, 90, 180);
            g.DrawLine(penRed, B, C);
            g.DrawArc(pen, width * 2 / 5, height * 2 / 5, width * 2 / 5, height * 2 / 5, -270, -180);
            g.DrawLine(penRed, D, A);
            g.DrawString("D", this.Font, new SolidBrush(Color.Blue), width * 2 / 5 - 5, height * 4 / 5 + 3);
            g.DrawString("A", this.Font, new SolidBrush(Color.Blue), width * 2 / 5 - 5, height * 2 / 5 - 18);
            g.DrawString("B", this.Font, new SolidBrush(Color.Blue), width * 3 / 5 - 5, height * 2 / 5 - 18);
            g.DrawString("C", this.Font, new SolidBrush(Color.Blue), width * 3 / 5 - 5, height * 4 / 5 + 3);
            g.Dispose();
            pictureBox1.Image = bm;
        }
        private void DrawMotionTrail3()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen2 = new Pen(Color.Black, 4);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen2, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen2, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width * 1 / 5, height / 5);
            Point B = new Point(width * 3 / 5, height / 5);
            Point C = new Point(width * 3 / 5, height * 3 / 5);
            Point D = new Point(width * 1 / 5, height * 3 / 5);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            g.DrawLine(penRed, B, C);
            g.DrawArc(pen, width * 1 / 5, height * 2 / 5, width * 2 / 5, height * 2 / 5, 0, 180);
            g.DrawLine(penRed, D, A);
            g.DrawString("A", this.Font, new SolidBrush(Color.Blue), width * 1 / 5 - 15, height * 1 / 5 - 15);
            g.DrawString("B", this.Font, new SolidBrush(Color.Blue), width * 3 / 5 + 2, height * 1 / 5 - 15);
            g.DrawString("C", this.Font, new SolidBrush(Color.Blue), width * 3 / 5 + 5, height * 3 / 5 - 2);
            g.DrawString("D", this.Font, new SolidBrush(Color.Blue), width * 1 / 5 - 15, height * 3 / 5 - 2);

            g.Dispose();
            pictureBox1.Image = bm;
        }
        private void DrawMotionTrail4()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen2 = new Pen(Color.Black, 4);
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen2, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen2, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 5, height / 5);
            Point B = new Point(width * 3 / 5, height / 5);
            Point C = new Point(width * 4 / 5, height * 2 / 5);
            Point D = new Point(width * 4 / 5, height * 3 / 5);
            Point E = new Point(width * 3 / 5, height * 4 / 5);
            Point F = new Point(width * 1 / 5, height * 4 / 5);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 2 / 5, height * 1 / 5, width * 2 / 5, height * 2 / 5, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawArc(pen, width * 2 / 5, height * 2 / 5, width * 2 / 5, height * 2 / 5, -270, -90);
            g.DrawLine(penRed, E, F);
            g.DrawLine(penRed, F, A);
            g.DrawString("A", this.Font, new SolidBrush(Color.Blue), width * 1 / 5 - 15, height * 1 / 5 - 15);
            g.DrawString("B", this.Font, new SolidBrush(Color.Blue), width * 3 / 5 - 2, height * 1 / 5 - 15);
            g.DrawString("C", this.Font, new SolidBrush(Color.Blue), width * 4 / 5 + 5, height * 2 / 5 - 2);
            g.DrawString("D", this.Font, new SolidBrush(Color.Blue), width * 4 / 5 + 5, height * 3 / 5 - 2);
            g.DrawString("E", this.Font, new SolidBrush(Color.Blue), width * 3 / 5 + 2, height * 4 / 5 + 2);
            g.DrawString("F", this.Font, new SolidBrush(Color.Blue), width * 1 / 5 - 15, height * 4 / 5 - 2);

            g.Dispose();
            pictureBox1.Image = bm;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbxMotionTrail.SelectedItem == null)
            {
                MessageBox.Show("请选择轨迹");
                return;
            }
            ushort _CardID = 0;
            ushort AxisX = 0;
            ushort AxisY = 1;
            ushort crd = 0;
            //设置脉冲当量
            LTDMC.dmc_set_equiv(0, AxisX, FormMain.PulseEquiv);
            LTDMC.dmc_set_equiv(0, AxisY, FormMain.PulseEquiv);
            //   画图
            ushort axisnum = 2;
            ushort[] axises = new ushort[] { AxisX, AxisY };
            LTDMC.dmc_conti_open_list(0, crd, axisnum, axises);

            // LTDMC.dmc_conti_set_blend(0, crd, 1);
            if (cbxMotionTrail.SelectedIndex == 0)
            {
                double[] A = new double[] { 0, 0 };
                double[] B = new double[] { 200, 0 };
                double[] C = new double[] { 400, -200 };
                double[] D = new double[] { 400, -400 };
                //设置插补速度           
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, B, 1, 0);  //直线插补，绝对模式
                //设置插补速度           
                SetArcVecter();
                LTDMC.dmc_conti_arc_move_center_unit(_CardID, crd, axisnum, axises,
                    C, new double[] { 200, -200 }, 0, 0, 1, 0);
                //XY平面圆弧插补，顺时针，相对坐标模式。   此函数是基于圆心圆弧扩展的螺旋线插补运动（可作两轴圆弧插补）
                //终点坐标   圆心坐标
                //设置插补速度           
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises,
                    D, 1, 0);   //直线插补，绝对模式

                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises,
                     A, 1, 0);   //直线插补，绝对模式

                LTDMC.dmc_conti_start_list(_CardID, crd);
                Thread.Sleep(1000);
                LTDMC.dmc_conti_close_list(_CardID, crd);
            }
            if (cbxMotionTrail.SelectedIndex == 1)
            {
                //LTDMC.dmc_pmove_unit(0, 0, 100, 1);//定长运动
                //LTDMC.dmc_check_done(0, 0);
                double[] A = new double[] { 100, 0 };
                double[] B = new double[] { 300, 0 };
                double[] C = new double[] { 300, -200 };
                double[] D = new double[] { 100, -200 };
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises,
                B, 1, 0);  //直线插补，绝对模式
                SetArcVecter();
                LTDMC.dmc_conti_arc_move_center_unit(_CardID, crd, axisnum, axises,
                    C, new double[] { 300, -100 }, 0, 0, 1, 0);
                //XY平面圆弧插补，顺时针，绝对模式模式。   此函数是基于圆心圆弧扩展的螺旋线插补运动（可作两轴圆弧插补）
                //终点坐标   圆心坐标
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises,
                    D, 1, 0);   //直线插补，绝对模式
                SetArcVecter();
                LTDMC.dmc_conti_arc_move_center_unit(_CardID, crd, axisnum, axises,
                    A, new double[] { 100, -100 }, 0, 0, 1, 0);
                LTDMC.dmc_conti_start_list(_CardID, crd);
                Thread.Sleep(1000);
                LTDMC.dmc_conti_close_list(_CardID, crd);
            }
            if (cbxMotionTrail.SelectedIndex == 2)
            {//直线 直线 圆弧 直线
                double[] A = new double[] { 0, 0 };
                double[] B = new double[] { 200, 0 };
                double[] C = new double[] { 200, -200 };
                double[] D = new double[] { 0, -200 };
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, B, 1, 0);  //直线插补
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, C, 1, 0);  //直线插补
                SetArcVecter();
                LTDMC.dmc_conti_arc_move_center_unit(_CardID, crd, axisnum, axises,
                    D, new double[] { 100, -200 }, 0, 0, 1, 0);
                //XY平面圆弧插补，顺时针，相对坐标模式。   此函数是基于圆心圆弧扩展的螺旋线插补运动（可作两轴圆弧插补）
                //终点坐标   圆心坐标
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, A, 1, 0);  //直线插补
                LTDMC.dmc_conti_start_list(_CardID, crd);
                Thread.Sleep(1000);
                LTDMC.dmc_conti_close_list(_CardID, crd);
            }
            if (cbxMotionTrail.SelectedIndex == 3)
            {  //直线 圆弧 直线 圆弧 直线 直线 
                double[] A = new double[] { 0, 0 };
                double[] B = new double[] { 200, 0 };
                double[] C = new double[] { 300, -100 };
                double[] D = new double[] { 300, -300 };
                double[] E = new double[] { 200, -400 };
                double[] F = new double[] { 0, -400 };
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, B, 1, 0);  //直线插补
                SetArcVecter();
                LTDMC.dmc_conti_arc_move_center_unit(_CardID, crd, axisnum, axises,
                    C, new double[] { 200, -100 }, 0, 0, 1, 0);
                //XY平面圆弧插补，顺时针，相对坐标模式。   此函数是基于圆心圆弧扩展的螺旋线插补运动（可作两轴圆弧插补）
                //终点坐标   圆心坐标
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, D, 1, 0);  //直线插补
                SetArcVecter();
                LTDMC.dmc_conti_arc_move_center_unit(_CardID, crd, axisnum, axises,
                    E, new double[] { 200, -300 }, 0, 0, 1, 0);
                SetLineVecter();
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, F, 1, 0);  //直线插补
                LTDMC.dmc_conti_line_unit(_CardID, crd, axisnum, axises, A, 1, 0);  //直线插补
                LTDMC.dmc_conti_start_list(_CardID, crd);
                Thread.Sleep(1000);
                LTDMC.dmc_conti_close_list(_CardID, crd);
            }
        }
        private void SetArcVecter()
        {
            LTDMC.dmc_set_vector_profile_unit(0, 0, 0, ArcInterSpeed, 0.1, 0.1, 0);
        }
        private void SetLineVecter()
        {
            LTDMC.dmc_set_vector_profile_unit(0, 0, 0, LineInterSpeed, 0.1, 0.1, 0);
        }
        private void DrawMarkPoint(Graphics g, double x, double y, string txt)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            float nx = 2000f / 80f;
            float ny = 2000f / 80f;
            float _x = (float)(x / nx + width / 2);
            float _y = (float)(y / ny + height / 3);
            g.FillEllipse(new SolidBrush(Color.Blue), new RectangleF(_x - 2f, _y - 2f, 4f, 4f));
            //
            Matrix matrix = g.Transform;
            g.ResetTransform();
            g.DrawString(txt, this.Font, new SolidBrush(Color.Blue), _x, height - _y);
            g.Transform = matrix;
        }

        private void btnSaveVector_Click(object sender, EventArgs e)
        {
            WriteSpeed();
            dic.Clear();
            try
            {
                dic.Add("HomeSpeed", this.txtZeroVector.Text.Trim());
                dic.Add("AbsoulteSpeed", this.txtAbsVector.Text.Trim());
                dic.Add("ReletiveSpeed", this.txtRltVector.Text.Trim());
                dic.Add("JogSpeed", txtJogVector.Text.Trim());
                dic.Add("LineInterSpeed", this.txtLineVector.Text.Trim());
                dic.Add("ArcInterSpeed", this.txtArcVector.Text.Trim());

                XMLHelper.SaveAppSetting(dic);
                MessageBox.Show("保存速度成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReadVector()
        {
            txtZeroVector.Text = FormMain.HomeSpeed.ToString();
            txtAbsVector.Text = FormMain.AbsoulteSpeed.ToString();
            txtRltVector.Text = FormMain.ReletiveSpeed.ToString();
            txtJogVector.Text = FormMain.JogSpeed.ToString();
            txtLineVector.Text = FormMain.LineInterSpeed.ToString();
            txtArcVector.Text = FormMain.ArcInterSpeed.ToString();
        }
        private void WriteSpeed()
        {
            FormMain.HomeSpeed = Convert.ToDouble(txtZeroVector.Text.Trim());
            FormMain.AbsoulteSpeed = Convert.ToDouble(txtAbsVector.Text.Trim());
            FormMain.ReletiveSpeed = Convert.ToDouble(txtRltVector.Text.Trim());
            FormMain.JogSpeed = Convert.ToDouble(txtJogVector.Text.Trim());
            FormMain.LineInterSpeed = Convert.ToDouble(txtLineVector.Text.Trim());
            FormMain.ArcInterSpeed = Convert.ToDouble(txtArcVector.Text.Trim());

            HomeSpeed = FormMain.HomeSpeed;
            AbsoulteSpeed = FormMain.AbsoulteSpeed;
            ReletiveSpeed = FormMain.ReletiveSpeed;
            JogSpeed = FormMain.JogSpeed;
            LineInterSpeed = FormMain.LineInterSpeed;
            ArcInterSpeed = FormMain.ArcInterSpeed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAxisLimitedSensor(0, ref homeSensor0, ref posLimited0, ref negLimited0);
            GetAxisLimitedSensor(1, ref homeSensor1, ref posLimited1, ref negLimited1);
            GetAxisLimitedSensor(2, ref homeSensor2, ref posLimited2, ref negLimited2);
            GetAxisLimitedSensor(3, ref homeSensor3, ref posLimited3, ref negLimited3);
            if (posLimited0) btnXPosDir.BackColor = Color.Red; else btnXPosDir.BackColor = Color.Green;
            if (posLimited1) btnYPosDir.BackColor = Color.Red; else btnYPosDir.BackColor = Color.Green;
            if (posLimited2) btnZPosDir.BackColor = Color.Red; else btnZPosDir.BackColor = Color.Green;
            if (posLimited3) btnWPosDir.BackColor = Color.Red; else btnWPosDir.BackColor = Color.Green;

            if (negLimited0) btnXNegDir.BackColor = Color.Red; else btnXNegDir.BackColor = Color.Green;
            if (negLimited1) btnYNegDir.BackColor = Color.Red; else btnYNegDir.BackColor = Color.Green;
            if (negLimited2) btnZNegDir.BackColor = Color.Red; else btnZNegDir.BackColor = Color.Green;
            if (negLimited3) btnWNegDir.BackColor = Color.Red; else btnWNegDir.BackColor = Color.Green;

            if (homeSensor0) btnXHome.BackColor = Color.Red; else btnXHome.BackColor = Color.Green;
            if (homeSensor1) btnYHome.BackColor = Color.Red; else btnYHome.BackColor = Color.Green;
            if (homeSensor2) btnZHome.BackColor = Color.Red; else btnZHome.BackColor = Color.Green;
            if (homeSensor3) btnWHome.BackColor = Color.Red; else btnWHome.BackColor = Color.Green;

        }

    }
}
