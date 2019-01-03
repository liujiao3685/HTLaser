using HuaTianProject.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using csLTDMC;
using HuaTianProject.Core;
using HuaTianProject.Entity;
using HuaTianProject.Libs;
using HuaTianProject.Libs.Hardware;
using HuaTianProject.Libs.Parameter;
using HuaTianProject.UserControls;

namespace HuaTianProject
{
    public partial class FormMain : Form
    {
        private UserControls.ParamSetForm m_paramSet;

        private MontionControlForm m_montionControl;

        private TeachingUserControl m_teachingControl;

        private List<FormBase> m_listForm;

        public CDMC5400A MotionCard = new CDMC5400A();

        public string ProjectPath = Application.StartupPath + "\\Project\\";

        private ushort m_cardID = 0;

        private int width, height;

        //PWM数据
        public int PWMChannel { set; get; }//PWM通道

        public double PWMDuty { set; get; }//占空比

        public double PWMFreq { set; get; }//频率

        //DA数据
        public int DAChannel { set; get; }//Da通道

        public double DAVoltage { set; get; }//DA输出电压

        public List<string> ListParams = new List<string>();//在线编程指令

        #region 静态参数

        /// <summary>
        /// 本地数据库工具
        /// </summary>
        public static DBTool DbTool { set; get; }

        /// <summary>
        /// 临时数据存储对象
        /// </summary>
        public static Dictionary<string, string> XmlData { set; get; }

        /// <summary>
        /// 控制卡是否初始化成功
        /// </summary>
        public static bool IsInit { set; get; }

        /// <summary>
        /// 控制卡号
        /// </summary>
        public static ushort CardId { set; get; }

        /// <summary>
        /// 运行速度
        /// </summary>
        public static double MoveSpeed { set; get; }

        /// <summary>
        /// 起始速度
        /// </summary>
        public static double StartSpeed { set; get; }

        /// <summary>
        /// 停止速度
        /// </summary>
        public static double StopSpeed { set; get; }

        /// <summary>
        /// 加速时间
        /// </summary>
        /// 
        public static double AccTime { set; get; }

        /// <summary>
        /// 减速时间
        /// </summary>
        public static double DecTime { set; get; }

        /// <summary>
        /// 减速停止时间
        /// </summary>
        public static double DecStopTime { set; get; }

        /// <summary>
        /// 脉冲当量
        /// </summary>
        public static double PulseEquiv { set; get; }

        /// <summary>
        /// S段模式
        /// </summary>
        public static ushort SParamModle { set; get; }

        /// <summary>
        /// S段速度
        /// </summary>
        public static double SParamSpeed { set; get; }
        /// <summary>
        /// 回原点速度
        /// </summary>
        public static double HomeSpeed { set; get; }

        /// <summary>
        /// 绝对速度
        /// </summary>
        public static double AbsoulteSpeed { set; get; }

        /// <summary>
        /// 相对速度
        /// </summary>
        public static double ReletiveSpeed { set; get; }

        /// <summary>
        /// JOG速度
        /// </summary>
        public static double JogSpeed { set; get; }

        /// <summary>
        /// 圆弧插补速度
        /// </summary>
        public static double ArcInterSpeed { set; get; }

        /// <summary>
        /// 直线插补速度
        /// </summary>
        public static double LineInterSpeed { set; get; }

        /// <summary>
        /// 点位运动距离
        /// </summary>
        public static double PointDistance { set; get; }
        /// <summary>
        /// 起始位置
        /// </summary>
        public static double StartPositionX { set; get; }
        public static double StartPositionY { set; get; }
        public static double StartPositionZ { set; get; }
        public static double StartPositionW { set; get; }
        /// <summary>
        /// 焊接位置1
        /// </summary>
        public static double WeltPosition1X { set; get; }
        public static double WeltPosition1Y { set; get; }
        public static double WeltPosition1Z { set; get; }
        public static double WeltPosition1W { set; get; }
        /// <summary>
        /// 焊接位置2
        /// </summary>
        public static double WeltPosition2X { set; get; }
        public static double WeltPosition2Y { set; get; }
        public static double WeltPosition2Z { set; get; }
        public static double WeltPosition2W { set; get; }
        /// <summary>
        /// 终点位置
        /// </summary>
        public static double EndPositionX { set; get; }
        public static double EndPositionY { set; get; }
        public static double EndPositionZ { set; get; }
        public static double EndPositionW { set; get; }
        /// <summary>
        /// 备用位置1
        /// </summary>
        public static double Reserve1X { set; get; }
        public static double Reserve1Y { set; get; }
        public static double Reserve1Z { set; get; }
        public static double Reserve1W { set; get; }
        /// <summary>
        /// 备用位置2
        /// </summary>
        public static double Reserve2X { set; get; }
        public static double Reserve2Y { set; get; }
        public static double Reserve2Z { set; get; }
        public static double Reserve2W { set; get; }
        /// <summary>
        /// 极限软限位
        /// </summary>
        public static double AxisPosLimitPosition0 { set; get; }
        public static double AxisNegLimitPosition0 { set; get; }
        public static double AxisPosLimitPosition1 { set; get; }
        public static double AxisNegLimitPosition1 { set; get; }
        public static double AxisPosLimitPosition2 { set; get; }
        public static double AxisNegLimitPosition2 { set; get; }
        public static double AxisPosLimitPosition3 { set; get; }
        public static double AxisNegLimitPosition3 { set; get; }

        #endregion

        /// <summary>
        /// 默认参数值设置
        /// </summary>
        private void DefaultParam()
        {
            PWMChannel = 0;
            PWMDuty = 0.5;
            PWMFreq = 500;

            DAChannel = 0;
            DAVoltage = 0;

            CardId = 0;
            MoveSpeed = 200;
            StartSpeed = 0;
            StopSpeed = 0;
            SParamSpeed = 0.1;
            HomeSpeed = 80;

            AccTime = 0.1;
            DecTime = 0.1;
            DecStopTime = 0.1;
            PulseEquiv = 100;
            SParamModle = 0;

            ReletiveSpeed = 150;
            AbsoulteSpeed = 150;
            JogSpeed = 200;
            ArcInterSpeed = 100;
            LineInterSpeed = 100;
            PointDistance = 10;

            StartPositionX = 50;
            StartPositionY = -60;
            StartPositionZ = 0;
            StartPositionW = 0;

            WeltPosition1X = 100;
            WeltPosition1Y = -120;
            WeltPosition1Z = 0;
            WeltPosition1W = 0;

            WeltPosition2X = 150;
            WeltPosition2Y = -180;
            WeltPosition2Z = 0;
            WeltPosition2W = 0;

            EndPositionX = 200;
            EndPositionY = -250;
            EndPositionZ = 0;
            EndPositionW = 0;

            Reserve1X = 0;
            Reserve1Y = 0;
            Reserve1Z = 30;
            Reserve1W = 40;

            Reserve2X = 0;
            Reserve2Y = 0;
            Reserve2Z = 60;
            Reserve2W = 80;

            AxisPosLimitPosition0 = 800;
            AxisNegLimitPosition0 = -80;
            AxisPosLimitPosition1 = 800;
            AxisNegLimitPosition1 = -80;
            AxisPosLimitPosition2 = 800;
            AxisNegLimitPosition2 = -80;
            AxisPosLimitPosition3 = 800;
            AxisNegLimitPosition3 = -80;
        }

        /// <summary>
        /// 把formmain里面静态参数写到配置文件中
        /// </summary>
        public static void DefaultXml()
        {
            XmlData.Clear();
            XmlData.Add("CardId", CardId.ToString());
            XmlData.Add("MoveSpeed", MoveSpeed.ToString());
            XmlData.Add("StartSpeed", StartSpeed.ToString());
            XmlData.Add("StopSpeed", StopSpeed.ToString());

            XmlData.Add("AccTime", AccTime.ToString());
            XmlData.Add("DecTime", DecTime.ToString());
            XmlData.Add("DecStopTime", DecStopTime.ToString());
            XmlData.Add("PointDistance", PointDistance.ToString());

            XmlData.Add("PulseEquiv", PulseEquiv.ToString());
            XmlData.Add("SParamSpeed", SParamSpeed.ToString());
            XmlData.Add("SParamModle", SParamModle.ToString());
            XmlData.Add("ReletiveSpeed", ReletiveSpeed.ToString());
            XmlData.Add("AbsoulteSpeed", AbsoulteSpeed.ToString());

            XmlData.Add("StartPositionX", StartPositionX.ToString());
            XmlData.Add("StartPositionY", StartPositionY.ToString());
            XmlData.Add("StartPositionZ", StartPositionZ.ToString());
            XmlData.Add("StartPositionW", StartPositionW.ToString());

            XmlData.Add("WeltPosition1X", WeltPosition1X.ToString());
            XmlData.Add("WeltPosition1Y", WeltPosition1Y.ToString());
            XmlData.Add("WeltPosition1Z", WeltPosition1Z.ToString());
            XmlData.Add("WeltPosition1W", WeltPosition1W.ToString());

            XmlData.Add("WeltPosition2X", WeltPosition2X.ToString());
            XmlData.Add("WeltPosition2Y", WeltPosition2Y.ToString());
            XmlData.Add("WeltPosition2Z", WeltPosition2Z.ToString());
            XmlData.Add("WeltPosition2W", WeltPosition2W.ToString());

            XmlData.Add("EndPositionX", EndPositionX.ToString());
            XmlData.Add("EndPositionY", EndPositionY.ToString());
            XmlData.Add("EndPositionZ", EndPositionZ.ToString());
            XmlData.Add("EndPositionW", EndPositionW.ToString());

            XmlData.Add("Reserve1X", Reserve1X.ToString());
            XmlData.Add("Reserve1Y", Reserve1Y.ToString());
            XmlData.Add("Reserve1Z", Reserve1Z.ToString());
            XmlData.Add("Reserve1W", Reserve1W.ToString());

            XmlData.Add("Reserve2X", Reserve2X.ToString());
            XmlData.Add("Reserve2Y", Reserve2Y.ToString());
            XmlData.Add("Reserve2Z", Reserve2Z.ToString());
            XmlData.Add("Reserve2W", Reserve2W.ToString());

            XmlData.Add("HomeSpeed", HomeSpeed.ToString());
            XmlData.Add("JogSpeed", JogSpeed.ToString());
            XmlData.Add("LineInterSpeed", LineInterSpeed.ToString());
            XmlData.Add("ArcInterSpeed", ArcInterSpeed.ToString());

            XmlData.Add("AxisPosLimitPosition0", AxisPosLimitPosition0.ToString());
            XmlData.Add("AxisNegLimitPosition0", AxisNegLimitPosition0.ToString());
            XmlData.Add("AxisPosLimitPosition1", AxisPosLimitPosition1.ToString());
            XmlData.Add("AxisNegLimitPosition1", AxisNegLimitPosition1.ToString());
            XmlData.Add("AxisPosLimitPosition2", AxisPosLimitPosition2.ToString());
            XmlData.Add("AxisNegLimitPosition2", AxisNegLimitPosition2.ToString());
            XmlData.Add("AxisPosLimitPosition3", AxisPosLimitPosition3.ToString());
            XmlData.Add("AxisNegLimitPosition3", AxisNegLimitPosition3.ToString());

            SaveXmlData(XmlData);
        }

        //初始化静态参数值
        public static void InitPara()
        {
            foreach (var item in XmlData)
            {
                switch (item.Key)
                {
                    case "CardId":
                        CardId = Convert.ToUInt16(item.Value);
                        break;
                    case "MoveSpeed":
                        MoveSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "StartSpeed":
                        StartSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "StopSpeed":
                        StopSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "AccTime":
                        AccTime = Convert.ToDouble(item.Value);
                        break;
                    case "DecTime":
                        DecTime = Convert.ToDouble(item.Value);
                        break;
                    case "DecStopTime":
                        DecStopTime = Convert.ToDouble(item.Value);
                        break;
                    case "PulseEquiv":
                        PulseEquiv = Convert.ToDouble(item.Value);
                        break;
                    case "SParamSpeed":
                        SParamSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "HomeSpeed":
                        HomeSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "AbsoulteSpeed":
                        AbsoulteSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "ReletiveSpeed":
                        ReletiveSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "JogSpeed":
                        JogSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "LineInterSpeed":
                        LineInterSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "ArcInterSpeed":
                        ArcInterSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "SParamModle":
                        SParamModle = Convert.ToUInt16(item.Value);
                        break;
                    case "PointDistance":
                        PointDistance = Convert.ToDouble(item.Value);
                        break;
                    case "StartPositionX":
                        StartPositionX = Convert.ToDouble(item.Value);
                        break;
                    case "StartPositionY":
                        StartPositionY = Convert.ToDouble(item.Value);
                        break;
                    case "StartPositionZ":
                        StartPositionZ = Convert.ToDouble(item.Value);
                        break;
                    case "StartPositionW":
                        StartPositionW = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition1X":
                        WeltPosition1X = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition1Y":
                        WeltPosition1Y = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition1Z":
                        WeltPosition1Z = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition1W":
                        WeltPosition1W = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition2X":
                        WeltPosition2X = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition2Y":
                        WeltPosition2Y = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition2Z":
                        WeltPosition2Z = Convert.ToDouble(item.Value);
                        break;
                    case "WeltPosition2W":
                        WeltPosition2W = Convert.ToDouble(item.Value);
                        break;
                    case "EndPositionX":
                        EndPositionX = Convert.ToDouble(item.Value);
                        break;
                    case "EndPositionY":
                        EndPositionY = Convert.ToDouble(item.Value);
                        break;
                    case "EndPositionZ":
                        EndPositionZ = Convert.ToDouble(item.Value);
                        break;
                    case "EndPositionW":
                        EndPositionW = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve1X":
                        Reserve1X = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve1Y":
                        Reserve1Y = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve1Z":
                        Reserve1Z = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve1W":
                        Reserve1W = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve2X":
                        Reserve2X = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve2Y":
                        Reserve2Y = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve2Z":
                        Reserve2Z = Convert.ToDouble(item.Value);
                        break;
                    case "Reserve2W":
                        Reserve2W = Convert.ToDouble(item.Value);
                        break;
                    case "AxisPosLimitPosition0":
                        AxisPosLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisNegLimitPosition0":
                        AxisNegLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisPosLimitPosition1":
                        AxisPosLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisNegLimitPosition1":
                        AxisNegLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisPosLimitPosition2":
                        AxisPosLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisNegLimitPosition2":
                        AxisNegLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisPosLimitPosition3":
                        AxisPosLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                    case "AxisNegLimitPosition3":
                        AxisNegLimitPosition0 = Convert.ToDouble(item.Value);
                        break;
                }
            }

            SaveXmlData(XmlData);
            //AnalysisDictionary();
            //FillDictionary();
        }

        public FormMain()
        {
            InitializeComponent();

            AppLog.Instance().InitLogPath();

            DbTool = DBTool.GetInstance();              //本地数据库工具
            XmlData = new Dictionary<string, string>(); //新建一个空字典
            m_listForm = new List<FormBase>();          //

            this.Text += "  [ Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ] ";
        }

        ~FormMain()
        {
            CDMC5400A.CloseCard();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DefaultParam();               //给formmian静态变量赋默认值
            XmlData = ReadXmlData();    //加载主界面时读配置文件放在字典里面
            InitPara();                //把字典里值赋值给formmain静态变量 
            InitControl();            //初始化控制卡（成功）

            InitTeaching();//初始化示教界面

            this.timer1.Start();//时间定时器
        }

        private void InitTeaching()
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
        }

        private void InitUI()
        {
            axisSignalX = new bool[3];
            axisSignalY = new bool[3];
            axisSignalZ = new bool[3];
            axisSignalW = new bool[3];

            int count = GetAxisCount();

            for (ushort i = 0; i < count; i++)
            {
                MontionCard_MontorPosChange(i);
            }

        }

        private Thread t_limitMonitor;

        //初始化事件委托
        private void InitHandle()
        {
            MotionCard.MonitorPosChangeCallBack += new CDMC5400A.MonitorPosChangeDelegate(MontionCard_MontorPosChange);

            t_limitMonitor = new Thread(MonitorAxisLimit);
            t_limitMonitor.IsBackground = true;
            //t_limitMonitor.Start();

        }

        private void MonitorAxisLimit()
        {
            while (IsWindowShow)
            {

            }

        }

        //实时坐标更新
        private void MontionCard_MontorPosChange(ushort axis)
        {
            double pos = MotionCard.GetAxisPulsePos(axis) / PulseEquiv;
            string sPos = pos.ToString("0.00");
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

        private void MontionCard_MontorError(string error)
        {
            AddLog(error, true, true);
        }

        private void LoadCurrentProject()
        {
            if (!Directory.Exists(ProjectPath)) Directory.CreateDirectory(ProjectPath);

            SMACConfig.Instance().InitFilePath(ProjectPath + CurrentProject.Instance.CurrentProjectName + "\\");
            SMACConfig.Instance().ReadConfig();
        }

        #region 静态函数

        /// <summary>
        /// 读取配置文件数据
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ReadXmlData()
        {
            Dictionary<string, string> dic = XMLHelper.LoadAppSettings();
            return dic;
        }

        /// <summary>
        /// 保存数据至配置文件
        /// </summary>
        /// <returns></returns>
        public static void SaveXmlData(Dictionary<string, string> dic)
        {
            XMLHelper.SaveAppSetting(dic);
        }

        /// <summary>
        /// 读取数据库所有用户信息
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsers()
        {
            List<User> list = DbTool.SelectDataList("users");
            return list;
        }
        #endregion


        /// <summary>
        /// 解析配置信息
        /// </summary>
        public static Dictionary<string, string> AnalysisDictionary()
        {
            XmlData = ReadXmlData();
            InitPara();
            return XmlData;
        }

        //初始化控制卡、用户控件
        private void InitControl()
        {
            m_teachingControl = new TeachingUserControl(this);
            m_teachingControl.Dock = DockStyle.Fill;

            m_paramSet = new UserControls.ParamSetForm();
            m_paramSet.Dock = DockStyle.Fill;

            m_montionControl = new MontionControlForm();
            m_montionControl.Dock = DockStyle.Fill;

            m_listForm.Add(m_teachingControl);
            m_listForm.Add(m_paramSet);
            m_listForm.Add(m_montionControl);

            short cardNum = 0;
            if (!CDMC5400A.InitMotionCard(ref cardNum, false))
            {
                IsInit = false;
                AddLog("初始化控制卡失败!", true, false);
                return;
            }

            if (MotionCard.Initialize(0, this, Application.StartupPath + "\\DMC5400A.ini"))
            {
                IsInit = true;
                AddLog("读取控制卡信息成功！", false, false);
                MessageBox.Show("读取控制卡信息成功！");

                MotionCard.MonitorErrorCallBack += new CDMC5400A.MonitorErrorDelegate(MontionCard_MontorError);
                MotionCard.StartMonitorThread();
            }
        }

        public int GetAxisCount()
        {
            return (int)MotionCard.AxisCount;
        }

        ///定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.systemTime.Text = "北京时间：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.currentUser.Text = "当前用户：" + LoginRightsForm.CurrencyManager;

            LoadCurrentProject();

            //监控限位变化
            MontionLimitChange();
        }


        #region 示教功能

        private Dictionary<string, string> dic = new Dictionary<string, string>();

        private bool[] axisSignalX, axisSignalY, axisSignalZ, axisSignalW;

        private double absolutePosX;//目标位置
        private double absolutePosY;
        private double absolutePosZ;
        private double absolutePosW;

        public void GetAxisLimitedSensor(ushort axis, ref bool homeSensor, ref bool positiveLtd, ref bool negativeLtd)
        {
            uint portValue;

            portValue = LTDMC.dmc_read_inport(0, (ushort)1);
            homeSensor = ((portValue & (0x1 << (axis))) == 0) ? true : false;

            portValue = LTDMC.dmc_read_inport(0, (ushort)0);
            positiveLtd = ((portValue & (0x1 << (axis + 16))) == 0) ? true : false;
            negativeLtd = ((portValue & (0x1 << (axis + 24))) == 0) ? true : false;
        }

        private void MontionLimitChange()
        {
            GetAxisLimitedSensor(0, ref axisSignalX[0], ref axisSignalX[1], ref axisSignalX[2]);
            GetAxisLimitedSensor(1, ref axisSignalY[0], ref axisSignalY[1], ref axisSignalY[2]);
            GetAxisLimitedSensor(2, ref axisSignalZ[0], ref axisSignalZ[1], ref axisSignalZ[2]);
            GetAxisLimitedSensor(3, ref axisSignalW[0], ref axisSignalW[1], ref axisSignalW[2]);

            if (axisSignalX[0]) btnXHome.BackColor = Color.Red; else btnXHome.BackColor = Color.Green;
            if (axisSignalY[0]) btnYHome.BackColor = Color.Red; else btnYHome.BackColor = Color.Green;
            if (axisSignalZ[0]) btnZHome.BackColor = Color.Red; else btnZHome.BackColor = Color.Green;
            if (axisSignalW[0]) btnWHome.BackColor = Color.Red; else btnWHome.BackColor = Color.Green;

            if (axisSignalX[1]) btnXPosDir.BackColor = Color.Red; else btnXPosDir.BackColor = Color.Green;
            if (axisSignalY[1]) btnYPosDir.BackColor = Color.Red; else btnYPosDir.BackColor = Color.Green;
            if (axisSignalZ[1]) btnZPosDir.BackColor = Color.Red; else btnZPosDir.BackColor = Color.Green;
            if (axisSignalW[1]) btnWPosDir.BackColor = Color.Red; else btnWPosDir.BackColor = Color.Green;

            if (axisSignalX[2]) btnXNegDir.BackColor = Color.Red; else btnXNegDir.BackColor = Color.Green;
            if (axisSignalY[2]) btnYNegDir.BackColor = Color.Red; else btnYNegDir.BackColor = Color.Green;
            if (axisSignalZ[2]) btnZNegDir.BackColor = Color.Red; else btnZNegDir.BackColor = Color.Green;
            if (axisSignalW[2]) btnWNegDir.BackColor = Color.Red; else btnWNegDir.BackColor = Color.Green;

        }

        private void PointMove(ushort axis, double myspeed, double distance, ushort mode)
        {
            LTDMC.dmc_set_equiv(0, axis, PulseEquiv);  //设置脉冲当量

            LTDMC.dmc_set_profile_unit(0, axis, StartSpeed, myspeed, AccTime, DecTime, StopSpeed);//设置速度参数

            LTDMC.dmc_set_s_profile(0, axis, 0, SParamSpeed);//设置S段速度参数

            LTDMC.dmc_set_dec_stop_time(0, axis, DecTime); //设置减速停止时间

            LTDMC.dmc_pmove_unit(m_cardID, axis, distance, mode);
        }

        private void btnXPosDir_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (radioRlt.Checked)
            {
                string axisTag = (string)btn.Tag;
                double distance = Convert.ToDouble(txtRltDis.Text);

                switch (axisTag)
                {
                    case "X+":
                        PointMove(0, ReletiveSpeed, distance, 0);
                        break;
                    case "X-":
                        PointMove(0, ReletiveSpeed, -distance, 0);
                        break;
                    case "Y+":
                        PointMove(1, ReletiveSpeed, distance, 0);
                        break;
                    case "Y-":
                        PointMove(1, ReletiveSpeed, -distance, 0);
                        break;
                    case "Z+":
                        PointMove(2, ReletiveSpeed, distance, 0);
                        break;
                    case "Z-":
                        PointMove(2, ReletiveSpeed, -distance, 0);
                        break;
                    case "W+":
                        PointMove(3, ReletiveSpeed, distance, 0);
                        break;
                    case "W-":
                        PointMove(3, ReletiveSpeed, -distance, 0);
                        break;
                    default:
                        break;
                }
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
            Button btn = sender as Button;
            string axisTag = (string)btn.Tag;

            if (radioJog.Checked)
            {
                switch (axisTag)
                {
                    case "X+":
                    case "X-":
                        StopMove(m_cardID, 0);
                        break;
                    case "Y+":
                    case "Y-":
                        StopMove(m_cardID, 1);
                        break;
                    case "Z+":
                    case "Z-":
                        StopMove(m_cardID, 2);
                        break;
                    case "W+":
                    case "W-":
                        StopMove(m_cardID, 3);
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnXPosDir_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            string axisTag = btn.Tag as string;

            if (radioJog.Checked)
            {
                switch (axisTag)
                {
                    case "X+":
                        ContinueMove(m_cardID, 0, 1);
                        break;
                    case "X-":
                        ContinueMove(m_cardID, 0, 0);
                        break;
                    case "Y+":
                        ContinueMove(m_cardID, 1, 1);
                        break;
                    case "Y-":
                        ContinueMove(m_cardID, 1, 0);
                        break;
                    case "Z+":
                        ContinueMove(m_cardID, 2, 1);
                        break;
                    case "Z-":
                        ContinueMove(m_cardID, 2, 0);
                        break;
                    case "W+":
                        ContinueMove(m_cardID, 3, 1);
                        break;
                    case "W-":
                        ContinueMove(m_cardID, 3, 0);
                        break;
                    default:
                        break;
                }
            }

        }

        private void btnSavePos_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioStartePos.Checked)
                {
                    StartPositionX = double.Parse(lbPointX.Text);
                    StartPositionY = double.Parse(lbPointY.Text);
                    StartPositionZ = double.Parse(lbPointZ.Text);
                    StartPositionW = double.Parse(lbPointW.Text);

                }
                if (radioEndPos.Checked)
                {
                    EndPositionX = double.Parse(lbPointX.Text);
                    EndPositionY = double.Parse(lbPointY.Text);
                    EndPositionZ = double.Parse(lbPointZ.Text);
                    EndPositionW = double.Parse(lbPointW.Text);

                }
                if (radioWeldPos1.Checked)
                {
                    WeltPosition1X = double.Parse(lbPointX.Text);
                    WeltPosition1Y = double.Parse(lbPointY.Text);
                    WeltPosition1Z = double.Parse(lbPointZ.Text);
                    WeltPosition1W = double.Parse(lbPointW.Text);

                }
                if (radioWeldPos2.Checked)
                {
                    WeltPosition2X = double.Parse(lbPointX.Text);
                    WeltPosition2Y = double.Parse(lbPointY.Text);
                    WeltPosition2Z = double.Parse(lbPointZ.Text);
                    WeltPosition2W = double.Parse(lbPointW.Text);

                }
                if (rabReserve1.Checked)
                {
                    Reserve1X = double.Parse(lbPointX.Text);
                    Reserve1Y = double.Parse(lbPointY.Text);
                    Reserve1Z = double.Parse(lbPointZ.Text);
                    Reserve1W = double.Parse(lbPointW.Text);

                }
                if (rabReserve2.Checked)
                {
                    Reserve2X = double.Parse(lbPointX.Text);
                    Reserve2Y = double.Parse(lbPointY.Text);
                    Reserve2Z = double.Parse(lbPointZ.Text);
                    Reserve2W = double.Parse(lbPointW.Text);

                }

                AddLog("修改示教位置成功！", false, false);
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                AddLog("修改示教位置失败！", false, false);
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }

        private void radioWeldPos1_Click(object sender, EventArgs e)
        {
            if (radioStartePos.Checked)
            {
                lbPointX.Text = FormMain.StartPositionX.ToString();
                lbPointY.Text = FormMain.StartPositionY.ToString();
                lbPointZ.Text = FormMain.StartPositionZ.ToString();
                lbPointW.Text = FormMain.StartPositionW.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
            }
            if (radioEndPos.Checked)
            {
                lbPointX.Text = FormMain.EndPositionX.ToString();
                lbPointY.Text = FormMain.EndPositionY.ToString();
                lbPointZ.Text = FormMain.EndPositionZ.ToString();
                lbPointW.Text = FormMain.EndPositionW.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
            }
            if (radioWeldPos1.Checked)
            {
                lbPointX.Text = FormMain.WeltPosition1X.ToString();
                lbPointY.Text = FormMain.WeltPosition1Y.ToString();
                lbPointZ.Text = FormMain.WeltPosition1Z.ToString();
                lbPointW.Text = FormMain.WeltPosition1W.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
            }
            if (radioWeldPos2.Checked)
            {
                lbPointX.Text = FormMain.WeltPosition2X.ToString();
                lbPointY.Text = FormMain.WeltPosition2Y.ToString();
                lbPointZ.Text = FormMain.WeltPosition2Z.ToString();
                lbPointW.Text = FormMain.WeltPosition2W.ToString();
                lbPointX.Visible = true;
                labelX.Visible = true;
                lbPointY.Visible = true;
                labelY.Visible = true;
            }
            if (rabReserve1.Checked)
            {
                lbPointX.Text = FormMain.Reserve1X.ToString();
                lbPointY.Text = FormMain.Reserve1Y.ToString();
                lbPointZ.Text = FormMain.Reserve1Z.ToString();
                lbPointW.Text = FormMain.Reserve1W.ToString();
                lbPointZ.Visible = true;
                labelZ.Visible = true;
                lbPointW.Visible = true;
                labelW.Visible = true;
            }
            if (rabReserve2.Checked)
            {
                lbPointX.Text = FormMain.Reserve2X.ToString();
                lbPointY.Text = FormMain.Reserve2Y.ToString();
                lbPointZ.Text = FormMain.Reserve2Z.ToString();
                lbPointW.Text = FormMain.Reserve2W.ToString();
                lbPointZ.Visible = true;
                labelZ.Visible = true;
                lbPointW.Visible = true;
                labelW.Visible = true;
            }
        }

        private void RunPosXy()
        {
            absolutePosX = Convert.ToDouble(lbPointX.Text);
            absolutePosY = Convert.ToDouble(lbPointY.Text);
            PointMove(0, AbsoulteSpeed, absolutePosX, 1);
            PointMove(1, AbsoulteSpeed, absolutePosY, 1);
        }
        private void RunPosZw()
        {
            absolutePosZ = Convert.ToDouble(lbPointZ.Text);
            absolutePosW = Convert.ToDouble(lbPointW.Text);
            PointMove(2, AbsoulteSpeed, absolutePosZ, 1);
            PointMove(3, AbsoulteSpeed, absolutePosW, 1);
        }
        private void RunPosXyzw()
        {
            absolutePosX = Convert.ToDouble(lbPointX.Text);
            absolutePosY = Convert.ToDouble(lbPointY.Text);
            absolutePosZ = Convert.ToDouble(lbPointZ.Text);
            absolutePosW = Convert.ToDouble(lbPointW.Text);
            PointMove(0, AbsoulteSpeed, absolutePosX, 1);
            PointMove(1, AbsoulteSpeed, absolutePosY, 1);
            PointMove(2, AbsoulteSpeed, absolutePosZ, 1);
            PointMove(3, AbsoulteSpeed, absolutePosW, 1);
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                RunPosXyzw();
                /*
                if (radioStartePos.Checked)
                {
                    RunPosXy();
                }
                if (radioEndPos.Checked)
                {
                    RunPosXy();
                }
                if (radioWeldPos1.Checked)
                {
                    RunPosXy();
                }
                if (radioWeldPos2.Checked)
                {
                    RunPosXy();
                }
                if (rabReserve1.Checked)
                {
                    RunPosZw();
                }
                if (rabReserve2.Checked)
                {
                    RunPosZw();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            MotionCard.StopAllMotion();
        }

        private void cbxMotionTrail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMotionTrail.SelectedIndex == 0)
            {
                Point A = new Point(width / 3, height / 3);
                Point B = new Point(width * 2 / 3, height / 3);
                Point C = new Point(width * 5 / 6, height / 3 + width / 6);
                Point D = new Point(width * 5 / 6, height * 5 / 6 - 50);

                //A = new Point(Convert.ToInt32(labelX.Text), Convert.ToInt32(labelY.Text));

                DrawMotionTrail1(A, B, C, D);
            }
            if (cbxMotionTrail.SelectedIndex == 1)
            {
                Point A = new Point(width * 2 / 5, height * 4 / 5);
                Point B = new Point(width * 2 / 5, height * 2 / 5);
                Point C = new Point(width * 3 / 5, height * 2 / 5);
                Point D = new Point(width * 3 / 5, height * 4 / 5);
                DrawMotionTrail2(A, B, C, D);
            }
            if (cbxMotionTrail.SelectedIndex == 2)
            {
                Point A = new Point(width * 1 / 5, height / 5);
                Point B = new Point(width * 3 / 5, height / 5);
                Point C = new Point(width * 3 / 5, height * 3 / 5);
                Point D = new Point(width * 1 / 5, height * 3 / 5);
                DrawMotionTrail3(A, B, C, D);
            }
            if (cbxMotionTrail.SelectedIndex == 3)
            {
                Point A = new Point(width / 5, height / 5);
                Point B = new Point(width * 3 / 5, height / 5);
                Point C = new Point(width * 4 / 5, height * 2 / 5);
                Point D = new Point(width * 4 / 5, height * 3 / 5);
                Point E = new Point(width * 3 / 5, height * 4 / 5);
                Point F = new Point(width * 1 / 5, height * 4 / 5);
                DrawMotionTrail4(A, B, C, D, E, F);
            }
        }

        private void DrawMotionTrail1(Point A, Point B, Point C, Point D)
        {
            Bitmap bm;
            Graphics g;
            Pen pen, penRed;
            InitGriphic(out bm, out g, out pen, out penRed);

            g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            g.DrawString("A", this.Font, new SolidBrush(Color.Blue), width / 3 - 5, height / 3 - 15);
            g.DrawString("B", this.Font, new SolidBrush(Color.Blue), width * 2 / 3 - 5, height / 3 - 15);
            g.DrawString("C", this.Font, new SolidBrush(Color.Blue), width * 5 / 6 + 5, height / 3 + width / 6 - 3);
            g.DrawString("D", this.Font, new SolidBrush(Color.Blue), width * 5 / 6 - 5, height * 5 / 7 + 2);
            g.Dispose();
            pictureBox1.Image = bm;
        }

        private void InitGriphic(out Bitmap bm, out Graphics g, out Pen pen, out Pen penRed)
        {
            bm = new Bitmap(width, height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen2 = new Pen(Color.Black, 4);
            pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen2, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen2, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            penRed = new Pen(Color.Red, 2);
        }

        private void DrawMotionTrail2(Point A, Point B, Point C, Point D)
        {
            Bitmap bm;
            Graphics g;
            Pen pen, penRed;
            InitGriphic(out bm, out g, out pen, out penRed);

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

        private void DrawMotionTrail3(Point A, Point B, Point C, Point D)
        {
            Bitmap bm;
            Graphics g;
            Pen pen, penRed;
            InitGriphic(out bm, out g, out pen, out penRed);

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
        private void DrawMotionTrail4(Point A, Point B, Point C, Point D, Point E, Point F)
        {
            Bitmap bm;
            Graphics g;
            Pen pen, penRed;
            InitGriphic(out bm, out g, out pen, out penRed);

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
        private Thread MyAutoThread;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbxMotionTrail.SelectedItem == null)
            {
                MessageBox.Show("请选择轨迹");
                return;
            }
            MyAutoThread = new Thread(new ThreadStart(MotionThread));
            MyAutoThread.IsBackground = true;
            MyAutoThread.Start();
            // PathMotion();
        }
        private void MotionThread()
        {
            MethodInvoker myin = new MethodInvoker(PathMotion);
            this.BeginInvoke(myin);
        }

        private void PathMotion()
        {
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

                //开始插补运动
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
            {
                //直线 直线 圆弧 直线
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
            {
                //直线 圆弧 直线 圆弧 直线 直线 
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

        private void btnSaveVector_Click(object sender, EventArgs e)
        {
            //WriteSpeed();
            //dic.Clear();
            //try
            //{
            //    dic.Add("HomeSpeed", this.txtZeroVector.Text.Trim());
            //    dic.Add("AbsoulteSpeed", this.txtAbsVector.Text.Trim());
            //    dic.Add("ReletiveSpeed", this.txtRltVector.Text.Trim());
            //    dic.Add("JogSpeed", txtJogVector.Text.Trim());
            //    dic.Add("LineInterSpeed", this.txtLineVector.Text.Trim());
            //    dic.Add("ArcInterSpeed", this.txtArcVector.Text.Trim());

            //    XMLHelper.SaveAppSetting(dic);
            //    AddLog("保存速度成功！", false);
            //    MessageBox.Show("保存速度成功！");
            //}
            //catch (Exception ex)
            //{
            //    AddLog("保存速度失败！" + ex.Message, true);
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void ReadVector()
        {
            //txtZeroVector.Text = FormMain.HomeSpeed.ToString();
            //txtAbsVector.Text = FormMain.AbsoulteSpeed.ToString();
            //txtRltVector.Text = FormMain.ReletiveSpeed.ToString();
            //txtJogVector.Text = FormMain.JogSpeed.ToString();
            //txtLineVector.Text = FormMain.LineInterSpeed.ToString();
            //txtArcVector.Text = FormMain.ArcInterSpeed.ToString();
        }
        private void WriteSpeed()
        {
            //FormMain.HomeSpeed = Convert.ToDouble(txtZeroVector.Text.Trim());
            //FormMain.AbsoulteSpeed = Convert.ToDouble(txtAbsVector.Text.Trim());
            //FormMain.ReletiveSpeed = Convert.ToDouble(txtRltVector.Text.Trim());
            //FormMain.JogSpeed = Convert.ToDouble(txtJogVector.Text.Trim());
            //FormMain.LineInterSpeed = Convert.ToDouble(txtLineVector.Text.Trim());
            //FormMain.ArcInterSpeed = Convert.ToDouble(txtArcVector.Text.Trim());

            //HomeSpeed = FormMain.HomeSpeed;
            //AbsoulteSpeed = FormMain.AbsoulteSpeed;
            //ReletiveSpeed = FormMain.ReletiveSpeed;
            //JogSpeed = FormMain.JogSpeed;
            //LineInterSpeed = FormMain.LineInterSpeed;
            //ArcInterSpeed = FormMain.ArcInterSpeed;
        }

        #endregion


        /// <summary>
        /// 增加日志信息
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="isError">是否是异常信息</param>
        /// <param name="showMsgBox">是否显示消息框</param>
        /// <returns></returns>
        public DialogResult AddLog(string content, bool isError, bool showMsgBox)
        {
            DialogResult result = DialogResult.OK;

            string msg = content;

            if (isError)
            {
                msg += "-----Error";
            }

            lock (this)
            {
                listLogs.Items.Add(DateTime.Now.ToString() + "," + content);
                AppLog.Instance().ApendLog(msg);
            }

            if (showMsgBox)
            {
                result = MessageBox.Show(msg);
            }

            return result;
        }

        public bool IsWindowShow = true;

        //程序关闭
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否关闭软件?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == result)
            {
                DefaultXml();
                timer1.Stop();

                AddLog("程序正常退出！", false, false);

                IsWindowShow = false;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void iO监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOStateForm IOform = new IOStateForm();
            IOform.Show();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginRightsForm.CurrencyManager = string.Empty;
            MessageBox.Show("注销成功！");
            AddLog("注销成功！", false, false);
        }

        //激光控制
        private void toolLaserControl_Click(object sender, EventArgs e)
        {
            LaserControlForm laserControl = new LaserControlForm(this);
            laserControl.Show();
        }

        private void 在线编程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginRightsForm.CurrencyManager))
            {
                ShowLogin();
            }
            if (Result)
            {
                OnlineProgramForm onlineProgram = new OnlineProgramForm(this);
                onlineProgram.Show();
            }
        }

        private bool Result;

        //继续之前未完成的运动
        private void btnContinue_Click(object sender, EventArgs e)
        {


        }

        private void ShowLogin()
        {
            LoginRightsForm logon = new LoginRightsForm(this);
            logon.LoginResult += new LoginRightsForm.LoginResultHandle(OnLoginResult);
            logon.ShowDialog();
        }

        public void OnLoginResult(object sender, MyEvent args)
        {
            Result = args.Result;
        }

        private void 回零ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginRightsForm.CurrencyManager))
            {
                ShowLogin();
            }
            if (Result)
            {
                BackHomeForm backHome = new BackHomeForm(this);
                backHome.ShowDialog();
            }
        }

        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginRightsForm.CurrencyManager))
            {
                ShowLogin();
            }
            if (Result)
            {
                UI.ParamSetForm paramForm = new UI.ParamSetForm();
                paramForm.ShowDialog();
            }
        }
    }
}
