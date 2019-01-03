using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MES.DAL;
using MES.Entity;
using MES.UI;
using HslCommunication.Profinet.Siemens;
using HslCommunication.LogNet;
using HslCommunication.BasicFramework;
using MES.Core;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using MES.UserControls;
using MES.Vision;
using OpcUaHelper;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using Timer = System.Windows.Forms.Timer;
using System.Net.Sockets;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using 生产管理系统.UI;
using ProductManage.Core;
using ProductManage.UI;
using ProductManage.Language.MyLanguageTool;
using ProductManage.UserControls;
using System.Collections;
using ProductManage.PLC;
using ProductManage.Vision;

namespace MES
{
    /// <summary>
    /// 工艺流程
    /// 上料-> 扫码 ->焊接（大环：LWM+3D视觉检测）->清洁->同心度检测(视觉)->表面质量检测(视觉)->更新数据库->下料
    /// 大环缝:熔深（mm）-->2~4, 偏心距（mm）-->  -0.15～0.2
    /// 小环缝:熔深（mm）-->≥2.2，偏心距（mm）-->  -0.3～0.3
    /// </summary>
    public partial class FormMain : Form
    {
        public string StationName = "S";

        public bool IsStation_S = true;

        public DBTool DbTool = null;

        public DataTable ProductsTable;

        public DataTable UsersTable;

        private int Self_Checek_Interval = 1;//间隔小时时间提醒质检

        private Product m_curProduct;

        private Product m_ngProduct;

        private string m_selectAllUsers = "Select ID,Name,Password,Auth from Users";

        /// <summary>
        /// 用户日志
        /// </summary>
        public ILogNet LogNetUser { get; private set; }
        public string UserLogName = "用户日志.txt";

        /// <summary>
        /// 应用程序日志
        /// </summary>
        public ILogNet LogNetProgramer { get; private set; }

        public SiemensS7Net m_siemensTcpNet { get; set; }

        public OpcUaClient OpcUaClient { get; set; }

        private SoftAuthorize m_softAuthorize = null;

        private Timer m_selfCheckTimer;

        private string CurrentBarCode = string.Empty;

        private string CurrentBarCodeScan = string.Empty;

        public byte[] VisionIp = new byte[] { 192, 168, 0, 66 };//3D视觉IP

        public ushort VisionPort = 24691;//3D视觉端口号   1、24691：接收/发送指令 2、24692：高速通讯

        private VisionLJ7000 m_visionLj7080;

        public string OpcServiceUrl = "opc.tcp://192.168.0.85:4840";//OPC URL

        private string m_scanSmallIp = "192.168.0.78";//小环扫描仪ip

        private string m_scanLargeIp = "192.168.0.88";//大环扫描仪ip

        private int m_scanPort = 9004;//扫描仪统一端口号

        private string m_lwmIp = "192.168.0.60";

        private int m_lwmContentPort = 8000;//700：控制端口

        public string UserLogPath = Application.StartupPath;//用户日志地址

        private int m_scanErrorCount = 0;//扫码错误次数记录

        private Socket m_socketScan = null;

        private bool m_scanRun = false;//是否开启扫码线程

        private Thread t_scanThread;//扫描仪线程

        private int m_visionCollectInterval = 300;//3D相机采样周期

        private SelfCheckWarmForm selfCheckWarmForm = null;//提醒检测窗体

        private Socket m_socketLwm = null;//LWM监听Socket

        private Thread t_lwmThread;//LWM监听线程

        private IPEndPoint endPoint = null;

        private SpotCheckForm m_spotCheckForm;

        private Thread t_monitorState = null;

        private Thread t_coaSurface = null;

        private Thread t_visionThread = null;

        private Thread t_modifyLargeData = null;

        private bool b_startModifyL = false;

        private Thread t_modifySmallData = null;

        private bool b_startModifyS = false;

        private bool b_lwmResult = true;

        private bool b_qcResult;//综合检测结果

        private int m_errorCount = 0; //异常记录次数

        private bool b_opcError = false;

        /// <summary>
        /// 设备状态
        /// </summary>
        public int DeviceState = 0;

        public XmlHelperBase XmlHelper;

        private double m_weldTimeS;

        private double m_weldTimeL;

        /// <summary>
        /// 系统参数集合
        /// </summary>
        public Dictionary<string, string> SystemParamsDic;

        private Random random = new Random();

        private bool IsWindowShow = true;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(SpotCheckForm form)
        {
            InitializeComponent();
            m_spotCheckForm = form;
            XmlHelper = m_spotCheckForm.m_xmlHelper;
            Culture = AppSetting.GetLanguage();
            CultureChange();
        }

        public int Test = 1;
        public int UseLanguage = 1;

        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();

            //程序验证注册码
            //CheckSoftAuthorize();

            if (Test == 0)
            {
                LoadSystemSetFile();

                //初始化PLC通讯
                InitPLCCommunication();

                //初始化扫描枪
                InitScanSocket();

                //初始化Lwm通讯
                //InitLwmSocket();

                //初始化通讯线程
                InitThreads();

                //检测数据库连接状态
                CheckDbConnected();
            }

            //初始化用户控件页面布局
            InitUserControl();

        }

        private void Init()
        {
            StationName = AppSetting.GetStationName();
            IsStation_S = StationName.Equals("S");
            ActiveControl = txtBarCode;

            if (IsStation_S)
            {
                toolParamSetting.Visible = false;
            }
            else
            {
                //labCoax.Text = "半径值";
                //labCoax.Visible = false;
                //txtCoaxility.Visible = false;
            }

            //设定按字体来缩放控件  
            this.AutoScaleMode = AutoScaleMode.Font;
            //设定字体大小为12px       
            this.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(135)));

            UserLogPath += "\\" + UserLogName;

            DbTool = new DBTool();

            //初始化程序日志
            //LogNetProgramer = new LogNetSingle(ProgramerLogPath);
            LogNetProgramer = Program.LogNet;

            //初始化用户日志
            LogNetUser = new LogNetSingle(UserLogPath);
        }

        /// <summary>
        /// 多线程初始化
        /// </summary>
        private void InitThreads()
        {
            //监听设备状态，三色灯、在线离线
            t_monitorState = new Thread(MonitorState);
            t_monitorState.IsBackground = true;
            t_monitorState.Start();

            //OPC LWM检测监听线程
            t_lwmThread = new Thread(LwmCheck);
            t_lwmThread.IsBackground = true;
            //t_lwmThread.Start();

            //监听扫描仪线程
            t_scanThread = new Thread(StartScanThread);
            t_scanThread.IsBackground = true;
            t_scanThread.Start();

            //监听设备状态线程
            //ThreadPool.QueueUserWorkItem((Delegate) =>
            //{
            //    MonitorState();
            //}, null);
            //Task t = new Task(() =>
            //{
            //    MonitorState();
            //});
            //t.Start();
            //bool boo = t.IsCompleted;


            //采集同心度，表面质量，小环用
            if (IsStation_S)
            {
                t_coaSurface = new Thread(MonitorCoaSurface);
                t_coaSurface.IsBackground = true;
                t_coaSurface.Start();

                t_modifySmallData = new Thread(ModifySmallData);
                t_modifySmallData.IsBackground = true;
                t_modifySmallData.Start();
                b_startModifyS = false;

            }

            //采集焊缝高度差，大环用
            if (!IsStation_S)
            {
                m_visionLj7080 = new VisionLJ7000();
                if (!m_visionLj7080.OpenEthernet())
                {
                    AddTips(ResourceCulture.GetValue("VisionCheckConnectFail"), true);
                    return;
                }

                t_visionThread = new Thread(MonitorVisionData);
                t_visionThread.IsBackground = true;
                t_visionThread.Start();

                t_modifyLargeData = new Thread(ModifyLargeData);
                t_modifyLargeData.IsBackground = true;
                t_modifyLargeData.Start();
                b_startModifyL = false;
            }

            InitLwmSocket();

            //初始化检测提醒功能
            //InitWarnCheck();
        }


        #region Language

        public void CultureChange()
        {
            if (Culture == 1)
            {
                ResourceCulture.SetCurrentCulture("zh-CN");
                SetResourceCulture();
            }
            else
            {
                ResourceCulture.SetCurrentCulture("en-US");
                SetResourceCulture();
            }
        }

        private void SetResourceCulture()
        {
            Text = ResourceCulture.GetValue("ProductManageSystem")
                   + "  [ Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ]";
            notifyIcon1.Text = ResourceCulture.GetValue("ProductManageSystem");

            toolLoginCenter.Text = ResourceCulture.GetValue("UserCenter");
            toolProtectCenter.Text = ResourceCulture.GetValue("OMCS");
            toolParamSetting.Text = ResourceCulture.GetValue("ParamSetting");
            toolLanguage.Text = ResourceCulture.GetValue("Language");
            toolLogin.Text = ResourceCulture.GetValue("Login");
            toolCancel.Text = ResourceCulture.GetValue("LogOut");
            toolMuduleSet.Text = ResourceCulture.GetValue("ModuleSetting");
            toolChinese.Text = ResourceCulture.GetValue("Chinese");
            toolSpotRecord.Text = ResourceCulture.GetValue("SpotRecord");
            toolEnglish.Text = ResourceCulture.GetValue("English");
            labBarCode.Text = ResourceCulture.GetValue("BarCode");
            labCoax.Text = ResourceCulture.GetValue("Coaxiality");
            labSurface.Text = ResourceCulture.GetValue("Surface");
            labState.Text = ResourceCulture.GetValue("OnLine");
            toolTips.Text = ResourceCulture.GetValue("Tips");
            btnCollection.UIText = ResourceCulture.GetValue("ParamMonitor");
            btnTraceSystem.UIText = ResourceCulture.GetValue("TraceSystem");
            btnLogSystem.UIText = ResourceCulture.GetValue("LogSystem");
            grbMonitorOnline.Text = ResourceCulture.GetValue("RealTime");
            labLwmCheck.Text = ResourceCulture.GetValue("LwmCheck");

            if (CurrentUser != null)
            {
                toolCurrentUser.Text = ResourceCulture.GetValue("CurrentUser") + CurrentUser.Auth;
            }
            else
            {
                toolCurrentUser.Text = ResourceCulture.GetValue("UserLoginOut");
            }


        }

        #endregion



        #region 加载系统参数

        private double CoaxialityUpS, CoaxialityDownS;
        private double CoaxialityUpL, CoaxialityDownL;
        private double HfUp, HfDown;

        //大环标准焊接坐标-XML
        private double BZWeldX, BZWeldY, BZWeldZ, BZWeldR;

        private void LoadSystemSetFile()
        {
            SystemParamsDic = m_spotCheckForm.DicSystemData;

            if (SystemParamsDic == null) return;

            foreach (var item in SystemParamsDic)
            {
                switch (item.Key)
                {
                    case "CoaxUpS":
                        CoaxialityUpS = Convert.ToDouble(item.Value);
                        break;
                    case "CoaxDownS":
                        CoaxialityDownS = Convert.ToDouble(item.Value);
                        break;
                    case "CoaxUpL":
                        CoaxialityUpL = Convert.ToDouble(item.Value);
                        break;
                    case "CoaxDownL":
                        CoaxialityDownL = Convert.ToDouble(item.Value);
                        break;
                    case "HFUp":
                        HfUp = Convert.ToDouble(item.Value);
                        break;
                    case "HFDown":
                        HfDown = Convert.ToDouble(item.Value);
                        break;
                    case "WeldXPosL":
                        BZWeldX = Convert.ToDouble(item.Value);
                        break;
                    case "WeldYPosL":
                        BZWeldY = Convert.ToDouble(item.Value);
                        break;
                    case "WeldZPosL":
                        BZWeldZ = Convert.ToDouble(item.Value);
                        break;
                    case "WeldRPosL":
                        BZWeldR = Convert.ToDouble(item.Value);
                        break;
                }
            }
        }

        #endregion



        #region PLC-OPC相关

        /// <summary>
        /// 初始化PLC通讯
        /// </summary>
        private void InitPLCCommunication()
        {
            //实例化一个西门子通讯对象
            //m_siemensTcpNet = new SiemensS7Net(SiemensPLCS.S1500);
            //m_siemensTcpNet.IpAddress = AppSetting.GetPLCIP();

            //实例化一个OPC客户端对象
            if (IsStation_S)
            {
                OpcServiceUrl = "opc.tcp://192.168.0.75:4840";
            }
            else
            {
                OpcServiceUrl = "opc.tcp://192.168.0.85:4840";
            }
            //OpcServiceUrl = AppSetting.GetOPCAddress();
            OpcUaClient = new OpcUaClient();

            try
            {
                OpcUaClient.OpcStatusChange += OpcUaClient_OpcStatusChange;
                OpcUaClient.ConnectServer(OpcServiceUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接PLC失败,请检查网络连接！");
                LogNetProgramer.WriteError("异常", "OPC服务器连接失败：" + ex.Message);
            }
        }

        private void OpcUaClient_OpcStatusChange(object sender, OpcUaStatusEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    OpcUaClient_OpcStatusChange(sender, e);
                }));
                return;
            }

            if (e.Error)
            {
                b_opcError = e.Error;
                try
                {
                    OpcUaClient.ConnectServer(OpcServiceUrl);
                    AddTips("与PLC重新建立连接！", false);
                }
                catch (Exception ex)
                {
                    LogNetProgramer.WriteError("异常", "与PLC重新建立连接失败！" + ex.Message);
                    AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                }
            }
        }

        /// <summary>
        /// 检测opc连接状态
        /// </summary>
        /// <returns></returns>
        public bool CheckOpcConnected()
        {
            if (OpcUaClient != null && OpcUaClient.Connected)
            {
                return true;
            }
            return false;
        }

        #endregion



        #region LWM相关

        private byte[] lwmData = new byte[1024 * 1024 * 1024];

        private bool b_sendLwmDataSuccess = true;

        private string m_lwmCode = string.Empty;

        /// <summary>
        /// 建立LWM通讯TCP
        /// </summary>
        private bool InitLwmSocket()
        {
            try
            {
                m_socketLwm = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                endPoint = new IPEndPoint(IPAddress.Parse(m_lwmIp), m_lwmContentPort);

                if (!m_socketLwm.Connected)
                {
                    m_socketLwm.Connect(endPoint);
                }

                return true;
            }
            catch (Exception ex)
            {
                m_errorCount++;
                if (m_errorCount > 10)
                {
                    m_errorCount = 0;
                    AddTips("LWM连接失败！", true);
                    //MessageBox.Show("LWM连接失败，请检查网络连接！");
                    LogNetProgramer.WriteDebug("LWM连接异常：" + ex.Message);
                }
                return false;
            }
        }

        private void SendLwmBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                try
                {
                    if (m_socketLwm == null || !m_socketLwm.Connected) InitLwmSocket();
                    m_socketLwm.Send(Encoding.ASCII.GetBytes(barcode));
                    b_sendLwmDataSuccess = true;
                    TcpSafeClose(m_socketLwm);
                }
                catch (Exception ex)
                {
                    m_errorCount++;
                    if (m_errorCount > 10)
                    {
                        m_errorCount = 0;
                        LogNetProgramer.WriteError("异常", "发送LWM条码异常：" + ex.Message);
                    }
                    b_sendLwmDataSuccess = false;
                }
            }
        }

        /// <summary>
        /// 读取 OPC LWM检测结果
        /// </summary>
        private void LwmCheck()
        {
            while (IsWindowShow)
            {
                try
                {
                    //接收lwm开始采集指令
                    bool collect = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_LwmSign);

                    if (collect)
                    {
                        int result = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_LwmCheck);

                        if (result == 1)
                        {
                            b_lwmResult = true;
                            btnLwmCheck.UIText = "OK";
                            btnLwmCheck.OriginalColor = Color.Lime;
                        }
                        else if (result == 2)
                        {
                            b_lwmResult = false;
                            btnLwmCheck.UIText = "NG";
                            btnLwmCheck.OriginalColor = Color.Red;
                        }
                        else
                        {
                            btnLwmCheck.UIText = "LwmResult:0";
                            btnLwmCheck.OriginalColor = Color.OrangeRed;
                        }

                        OpcUaClient.WriteNode(PlcHelper.OPC_DB_LwmCheck, 0);
                        //OpcUaClient.WriteNode(s_lwmSign, false);
                    }
                }
                catch (Exception ex)
                {
                    AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                    LogNetProgramer.WriteError("异常", "LWM检测结果读取异常--->" + ex.Message);
                }

                Thread.Sleep(500);
            }
        }

        #endregion

        public bool TcpSafeClose(Socket socket)
        {
            if (socket == null) return false;
            if (!socket.Connected) return false;

            try
            {
                socket.Shutdown(SocketShutdown.Both);
                Thread.Sleep(10);

                socket.Close();
                socket.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                m_errorCount++;
                if (m_errorCount > 10)
                {
                    LogNetProgramer.WriteError("异常", "TCP通讯关闭异常：" + ex.Message);
                }
                return false;
            }
        }


        #region 扫描仪相关

        private void InitScanSocket()
        {
            try
            {
                string scanIP;
                if (IsStation_S)
                {
                    scanIP = m_scanSmallIp;
                }
                else
                {
                    scanIP = m_scanLargeIp;
                }

                m_socketScan = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                endPoint = new IPEndPoint(IPAddress.Parse(scanIP), m_scanPort);

                if (!m_socketScan.Connected)
                {
                    m_socketScan.Connect(endPoint);
                }

                //开启监听线程
                m_scanRun = true;

                AddTips("扫描仪SR-751连接成功！", false);
            }
            catch (Exception ex)
            {
                m_scanRun = false;
                AddTips("扫描仪SR-751连接失败！", true);
                MessageBox.Show("扫描仪SR-751连接失败，请检查网络连接！");
                LogNetProgramer.WriteDebug("扫描仪连接异常：" + ex.Message);
            }
        }

        private byte[] scanData;

        private char[] chars = { '\r' };

        private bool b_scanSuccess = true;
        private bool m_scanPlcSign = false;

        private void StartScanThread()
        {
            while (m_scanRun)
            {
                try
                {
                    m_scanPlcSign = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_StartScan);
                }
                catch (Exception ex)
                {
                    AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                    b_scanSuccess = false;
                }

                if (m_scanPlcSign && m_socketScan.Connected == true)
                {
                    scanData = new byte[1024];

                    int len = m_socketScan.Receive(scanData);
                    if (len == 0)
                    {
                        ScanCallBack(2);
                        b_scanSuccess = false;
                        //break;
                    }
                    else
                    {
                        b_scanSuccess = true;
                    }

                    if (b_scanSuccess)
                    {
                        string barCode = Encoding.UTF8.GetString(scanData, 0, len);
                        int subIndex = barCode.IndexOfAny(chars);

                        barCode = barCode.Substring(0, subIndex);
                        CurrentBarCode = barCode;

                        Invoke(new Action(() =>
                        {
                            //判断回车
                            if (scanData[len - 1] == 13)
                            {
                                MonitorBarCode(CurrentBarCode);
                                txtBarCode.Text = string.Empty;
                            }
                        }));
                        b_scanSuccess = !b_scanSuccess;
                    }
                }

                Thread.Sleep(500);
            }
        }

        #endregion


        private double CoaxialityS;
        private int m_surface;
        private int m_lwmResult;
        private string m_surfaceType;
        private bool b_coaCheckS = true;
        private bool b_surfaceCheck = true;
        private ArrayList objs = new ArrayList();

        private Stopwatch sw;

        /// <summary>
        ///  小环监听同心度和表面质量
        /// </summary>
        private void MonitorCoaSurface()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckOpcConnected())
                    {
                        bool order = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_SendLwmCode);
                        if (order)
                        {
                            m_lwmCode = OpcUaClient.ReadNode<string>(PlcHelper.OPC_DB_LwmCode);
                            SendLwmBarcode(m_lwmCode);
                            if (b_sendLwmDataSuccess) OpcUaClient.WriteNode(PlcHelper.OPC_DB_SendLwmCode, false);
                            else AddTips("发送LWM条码失败！", true);
                        }

                        int start = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_CcdOrder);
                        if (start == 1)
                        {
                            CollectWeldData();

                            UpdateCCDUI();

                            OpcUaClient.WriteNode(PlcHelper.OPC_DB_CcdOrder, 2);//采集指令置零

                            if (DeviceState != 2) b_startModifyS = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    m_errorCount++;
                    if (m_errorCount > 10)
                    {
                        m_errorCount = 0;
                        LogNetProgramer.WriteError("异常", "保存小环焊接数据异常-->" + ex.Message);
                    }
                    //AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                }

                Thread.Sleep(200);
            }
        }

        private void CollectWeldData()
        {
            objs = WeldHelper.CollectWeldData(OpcUaClient, PlcHelper.Nodes_S);

            if (objs != null && objs.Count > 0)
            {
                WeldXPos = Math.Round(Convert.ToDouble(objs[0]), 3);
                WeldYPos = Math.Round(Convert.ToDouble(objs[1]), 3);
                WeldZPos = Math.Round(Convert.ToDouble(objs[2]), 3);
                WeldRPos = Math.Round(Convert.ToDouble(objs[3]), 3);
                avgPower = Math.Round(Convert.ToDouble(objs[4]), 3);
                avgPressure = Math.Round(Convert.ToDouble(objs[5]), 3);
                avgFlow = Math.Round(Convert.ToDouble(objs[6]), 3);
                avgSpeed = Convert.ToInt32(objs[7]);
                m_weldTimeS = Math.Round(Convert.ToDouble(objs[8]), 3);
                CurrentBarCode = objs[9].ToString();
                CoaxialityS = Math.Round(Convert.ToDouble(objs[10]), 3);
                m_surface = Convert.ToInt32(objs[11]);
                m_lwmResult = Convert.ToInt32(objs[12]);
            }
        }

        /// <summary>
        /// 更新2D结果界面
        /// </summary>
        private void UpdateCCDUI()
        {
            //Invoke(new Action(() =>
            //{
            if (m_surface == 1)
            {
                m_surfaceType = "OK";
                txtSurface.UIText = "OK";
                txtSurface.OriginalColor = Color.Lime;
                b_surfaceCheck = b_coaCheckS = true;
            }
            else if (m_surface == 3)
            {
                m_surfaceType = "瑕疵NG";
                txtSurface.UIText = "瑕疵NG";
                txtSurface.OriginalColor = Color.Red;
                b_surfaceCheck = false;
            }
            else if (m_surface == 4)
            {
                m_surfaceType = "同心度NG";
                txtSurface.UIText = "NG";
                txtSurface.OriginalColor = Color.Red;
                b_coaCheckS = false;
            }

            if (m_lwmResult == 1)
            {
                b_lwmResult = true;
                btnLwmCheck.UIText = "OK";
                btnLwmCheck.OriginalColor = Color.Lime;
            }
            else if (m_lwmResult == 2)
            {
                b_lwmResult = false;
                btnLwmCheck.UIText = "NG";
                btnLwmCheck.OriginalColor = Color.Red;
            }

            txtCoaxility.UIText = CoaxialityS + "mm";
            //}));


        }

        /// <summary>
        /// 小环焊接完成数据更新
        /// </summary>
        private void ModifySmallData()
        {
            while (IsWindowShow)
            {
                if (b_startModifyS)
                {
                    string sql = "update Product set WeldPower=@power,WeldSpeed=@speed,Flow=@flow,Pressure=@press,WeldTime=@time," +
                        "XPos=@x,YPos=@y,ZPos=@z,RPos=@r,Coaxiality=@coa,Surface=@sur,LwmCheck=@lwm,QCResult=@qcr where PNo=@pno";

                    if (b_surfaceCheck && b_coaCheckS && b_lwmResult) b_qcResult = true;
                    else b_qcResult = false;

                    try
                    {
                        SqlParameter[] sqlParameters =
                        {
                            new SqlParameter {ParameterName = "@power", SqlDbType = SqlDbType.Decimal, SqlValue = avgPower},
                            new SqlParameter {ParameterName = "@flow", SqlDbType = SqlDbType.Decimal, SqlValue = avgFlow},
                            new SqlParameter {ParameterName = "@press", SqlDbType = SqlDbType.Decimal, SqlValue = avgPressure},
                            new SqlParameter {ParameterName = "@coa", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxialityS},
                            new SqlParameter {ParameterName = "@speed", SqlDbType = SqlDbType.Int, SqlValue = avgSpeed},

                            new SqlParameter {ParameterName = "@x", SqlDbType = SqlDbType.Decimal, SqlValue = WeldXPos},
                            new SqlParameter {ParameterName = "@y", SqlDbType = SqlDbType.Decimal, SqlValue = WeldYPos},
                            new SqlParameter {ParameterName = "@z", SqlDbType = SqlDbType.Decimal, SqlValue = WeldZPos},
                            new SqlParameter {ParameterName = "@r", SqlDbType = SqlDbType.Decimal, SqlValue = WeldRPos},

                            new SqlParameter {ParameterName = "@time", SqlDbType = SqlDbType.Decimal, SqlValue = m_weldTimeS},
                            new SqlParameter {ParameterName = "@sur", SqlDbType = SqlDbType.NVarChar, SqlValue = m_surfaceType},
                            new SqlParameter {ParameterName = "@lwm", SqlDbType = SqlDbType.NVarChar, SqlValue = b_lwmResult==true ? "OK":"NG"},
                            new SqlParameter {ParameterName = "@qcr", SqlDbType = SqlDbType.NVarChar, SqlValue = b_qcResult==true ? "OK":"NG"},
                            new SqlParameter {ParameterName = "@pno", SqlDbType = SqlDbType.NVarChar, SqlValue = CurrentBarCode}
                        };

                        if (!string.IsNullOrEmpty(CurrentBarCode))
                        {
                            int c = DbTool.ModifyTable(sql, sqlParameters);

                            if (c > 0)
                            {
                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = true });
                                WeldParamReset();
                                AddTips(ResourceCulture.GetValue("SaveWeldDataOK"), false);
                            }
                            else
                            {
                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = false });
                                AddTips(ResourceCulture.GetValue("SaveWeldDataFail") + "BarCode：" + CurrentBarCode, true);

                                LogNetProgramer.WriteInfo("CurrentBarCode：" + CurrentBarCode + "avgPower：" + avgPower + "avgFlow：" + avgFlow + "avgPressure:" + avgPressure +
                                    "CoaxialityS：" + CoaxialityS + "avgSpeed：" + avgSpeed + "m_weldTimeS：" + m_weldTimeS);
                            }
                            b_startModifyS = !b_startModifyS;
                        }
                        else
                        {
                            AddTips(ResourceCulture.GetValue("SaveWeldDataFailNoBarcode"), true);
                        }
                    }
                    catch (Exception ex)
                    {
                        m_errorCount++;
                        if (m_errorCount > 5)
                        {
                            m_errorCount = 0;
                            LogNetProgramer.WriteError("异常", "小环检测结果保存失败：" + ex.Message);
                        }
                    }
                }

                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// 大小环同心度检测结果判断分类
        /// </summary>
        /// <param name="coa"></param>
        /// <returns></returns>
        private bool TypeCoaxiality(double coa)
        {
            bool res = true;
            if (IsStation_S)
            {
                if (coa > CoaxialityUpS || coa < CoaxialityDownS)//小环（-0.3~0.3）
                {
                    res = false;
                }
            }
            else
            {
                if (coa > CoaxialityUpL || coa < CoaxialityDownL)//大环（-0.15~0.2）
                {
                    res = false;
                }
            }

            return res;
        }

        /// <summary>
        /// 初始化提醒检测模块
        /// </summary>
        private void InitWarnCheck()
        {
            Self_Checek_Interval = AppSetting.GetCheckInterval();

            if (Self_Checek_Interval < 1)
            {
                MessageBox.Show("自检间隔不能小于一小时！请重新配置后重启软件！");
                return;
            }

            m_selfCheckTimer = new Timer();
            m_selfCheckTimer.Tick += new EventHandler(SelfeCheck_Tick);
            m_selfCheckTimer.Interval = Self_Checek_Interval * 1000;// * 3600;
            m_selfCheckTimer.Enabled = true;
        }

        private void SelfeCheck_Tick(object sender, EventArgs e)
        {
            //报警器提醒检测
            OpcUaClient.WriteNode(PlcHelper.OPC_DB_WarnCheck, 1);

            //窗口提醒检测
            //selfCheckWarmForm = new SelfCheckWarmForm(this);
            //selfCheckWarmForm?.Show();
        }



        #region 用户控件相关

        private CollectingSystem collecting;

        private TraceSystem traceSystem;

        private LogSystemControl logSystem;

        private LogErrorControl logError;

        private void InitUserControl()
        {
            collecting = new CollectingSystem(this);
            collecting.Dock = DockStyle.Fill;

            traceSystem = new TraceSystem(this);
            traceSystem.Dock = DockStyle.Fill;

            logSystem = new LogSystemControl(this);
            logSystem.Dock = DockStyle.Fill;

            logError = new LogErrorControl(this);
            logError.Dock = DockStyle.Fill;

            panelBox.Controls.AddRange(new Control[] { collecting, traceSystem, logError });

        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            collecting.Show();

            traceSystem.Hide();
            logSystem.Hide();

        }

        private void btnTraceSystem_Click(object sender, EventArgs e)
        {
            traceSystem.Show();

            collecting.Hide();
            logSystem.Hide();
        }

        private void btnLogSystem_Click(object sender, EventArgs e)
        {
            //logSystem.Show();
            logError.Show();

            collecting.Hide();
            traceSystem.Hide();
        }

        #endregion



        #region 软件权限检测

        /// <summary>
        /// 检测软件是否授权
        /// </summary>
        private void CheckSoftAuthorize()
        {
            m_softAuthorize = new SoftAuthorize();

            //方式一
            m_softAuthorize.FileSavePath = Application.StartupPath + @"\Authorize.sys"; //存储激活码文件，存储加密
            m_softAuthorize.LoadByFile();

            // 检测激活码是否正确，没有文件，或激活码错误都算作激活失败
            if (!m_softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
            {
                //显示注册窗口
                using (FormAuthorize form = new FormAuthorize(m_softAuthorize, "请联系华天世纪激光科技公司获取注册码！", AuthorizeEncrypted))
                {
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        //授权失败，退出应用程序
                        Close();
                    }
                }
            }

            //方式二 :直接进行判断授权码
            //if (!m_softAuthorize.CheckAuthorize("4408B6C4F17EF79B0210F997771C1E5FBA75748F5DD9DD3C59B9E69FCE05DAF5", AuthorizeEncrypted))
            //{
            //    //授权失败！
            //    Close();
            //}
        }

        /// <summary>
        /// 自定义加密算法，传入原始数据，返回加密结果
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>加密结果</returns>
        private string AuthorizeEncrypted(string origin)
        {
            //使用了组件支持的DES对称加密技术
            string license = SoftSecurity.MD5Encrypt(origin, "CSTLASER");
            return license;
        }

        #endregion


        //检测数据库是否连接正常
        public bool CheckDbConnected()
        {
            if (DbTool.m_sqlCon == null)
            {
                return false;
            }
            return true;
        }

        public delegate void SetTips(string s, bool boo);
        public void AddTips(string v, bool error)
        {
            try
            {
                if (IsWindowShow && !this.IsDisposed)
                {
                    if (this.InvokeRequired)
                    {
                        BeginInvoke(new SetTips(AddTips), v, error);//BeginInvoke 没有处理异常，所以没有报错。
                    }
                    else
                    {
                        if (error)
                        {
                            toolTips.BackColor = Color.Red;
                        }
                        else
                        {
                            toolTips.BackColor = SystemColors.Control;
                        }

                        if (Culture == 1) toolTips.Text = "提示:" + v;
                        else toolTips.Text = "Tips:" + v;
                    }

                    /*
                    BeginInvoke(new Action(() =>
                    {
                        if (error)
                        {
                            toolTips.BackColor = Color.Red;
                        }
                        else
                        {
                            toolTips.BackColor = SystemColors.Control;
                        }

                        if (Culture == 1) toolTips.Text = "提示:" + v;
                        else toolTips.Text = "Tips:" + v;
                    }));*/
                }
            }
            catch (Exception ex)
            {
                LogNetProgramer.WriteError("异常", "AddTips异常：" + ex.Message);
            }

            //Invoke(new MethodInvoker(delegate () { }));
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("是否关闭应用程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (DialogResult.Yes == result)
            //{
            //    e.Cancel = false;

            //using (FormQuitWait form = new FormQuitWait(() =>
            //{
            //    CloseCommunicate();
            //}))
            //{
            //    form.ShowDialog();
            //}

            IsWindowShow = false;
            OnWindowState(this, new MyEvent() { IsWindowShow = false });
            Application.Exit();

            //}
            //else
            //{
            //    e.Cancel = true;
            //}

        }

        private bool Result = false;

        public User CurrentUser = null;

        /// <summary>
        /// 检测当前登录用户权限
        /// </summary>
        /// <returns>是否拥有管理员权限</returns>
        public bool CheckUserAuth()
        {
            if (CurrentUser == null)
            {
                MessageBox.Show(ResourceCulture.GetValue("PleaseLogin"));
                ShowLogin();
                return false;
            }
            if (!(CurrentUser.Auth == "管理员" || CurrentUser.Auth == "Admin"))
            {
                MessageBox.Show(ResourceCulture.GetValue("AuthNotEnough"));
                return false;
            }
            return true;
        }

        private void ShowLogin()
        {
            LoginForm login = new LoginForm(this);
            login.LoginResultEvent += LoginResult;
            login.m_culture = Culture;
            login.ShowDialog();

            if (CurrentUser != null)
            {
                toolCurrentUser.BackColor = Color.GreenYellow;
                if (Culture == 1) toolCurrentUser.Text = "当前用户：" + CurrentUser.Auth;
                else toolCurrentUser.Text = "CurrentUser：" + CurrentUser.Auth;
            }
        }

        public void LoginResult(object sender, MyEvent e)
        {
            Result = e.LoginResult;
            CurrentUser = e.LoginUser;
        }


        //手动输入条码
        private void txtFirstScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string barCode = txtBarCode.Text.Trim();

            if (e.KeyChar == (char)Keys.Enter)
            {
                CurrentBarCode = barCode;

                MonitorBarCode(CurrentBarCode);
                txtBarCode.Text = string.Empty;

            }
        }

        //发送条码检测结果
        private void MonitorBarCode(string barCode)
        {
            if (m_scanErrorCount >= 2)//如果扫码失败次数大于2次
            {
                m_scanErrorCount = 0;
                //AddTips(" 扫码失败次数大于两次！ ", true);
                //ScanCallBack(2);
                return;
            }

            if (String.IsNullOrEmpty(barCode)/* || barCode.Length > 15*/)
            {
                ScanCallBack(2);
                m_scanErrorCount++;
                txtBarCode.Text = string.Empty;
                AddTips(ResourceCulture.GetValue("InvalidBarCode") + barCode, true);
                return;
            }

            if (barCode.Contains("ERROR") || barCode.Contains("error"))
            {
                ScanCallBack(2);
                m_scanErrorCount++;
                txtBarCode.Text = string.Empty;
                AddTips(ResourceCulture.GetValue("ErrorBarCode") + barCode, true);
                return;
            }

            ScanCallBack(1);

            //CurrentBarCode = barCode.Replace("ERROR", "");

            CurrentBarCodeScan = CurrentBarCode = barCode;

            int rs = IsStorage(CurrentBarCode);
            if (rs != 3)
            {
                if (IsStation_S)
                {
                    OpcUaClient.WriteNode(PlcHelper.OPC_DB_BarCode, "OP20-" + CurrentBarCode);
                }
                else
                {
                    OpcUaClient.WriteNode(PlcHelper.OPC_DB_BarCode, "OP70-" + CurrentBarCode);
                }

                OnBarCodeChange(new MyEvent() { BarCode = CurrentBarCode });

                AddTips(ResourceCulture.GetValue("BarCodeTips") + CurrentBarCode, false);
            }

            //若存在此产品，则执行检测操作
            //SelfCheck(barCode);
        }

        /// <summary>
        /// 扫码结果反馈
        /// </summary>
        /// <param name="type">1、不存在，2、存在，3、异常</param>
        /// <returns></returns>
        public bool ScanCallBack(int type)
        {
            bool result;
            try
            {
                result = OpcUaClient.WriteNode(PlcHelper.OPC_DB_ScanCallBack, type);
            }
            catch (Exception ex)
            {
                result = false;
                LogNetProgramer.WriteError("异常", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 判断产品是否入库
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns>产品是否入库</returns>
        public int IsStorage(string barCode)
        {
            string ifexist = "select PNo from Product where PNo = '" + barCode + "'";

            int rs = 0;
            int exist = DbTool.IsExist(ifexist);
            if (exist == 1)//存在
            {
                rs = 1;
            }
            else if (exist == 2)//不存在
            {
                string sql = "insert into Product(PNo,StorageTime) Values('" + barCode + "','" + DateTime.Now + "')";
                int c = DbTool.ModifyTable(sql);
                if (c > 0)
                {
                    rs = 2;
                    Debug.Write(barCode + "入库成功！");
                }
                else
                {
                    rs = 3;
                    AddTips(barCode + "产品入库失败！", true);
                }
            }
            return rs;
        }

        /// <summary>
        /// 检测产品数据是否合格
        /// </summary>
        /// <param name="pno"></param>
        /// <returns></returns>
        private bool SelfCheck(string pno)
        {
            Product pro = DbTool.SelectProductByNo(pno);

            if (pro != null)
            {
                //合格标准判断
                bool pass = true;

                if (pro.QCResult == "NG")
                {
                    pass = false;
                    LogNetUser.WriteInfo("正常", "产品条码：" + pro.PNo + "，不合格！");
                }
                else
                {
                    if (IsStation_S) //小环（-0.3~0.3）
                    {
                        if (pro.Coaxiality > CoaxialityUpS || pro.Coaxiality < CoaxialityDownS)
                        {
                            pass = false;
                            LogNetUser.WriteInfo("正常", "小环同心度NG，,同心度：" + pro.Coaxiality + ",产品条码：" + pro.PNo);
                        }
                        else if (pro.Surface.Equals("表面NG"))
                        {
                            pass = false;
                            LogNetUser.WriteInfo("正常", "小环表面NG，产品条码：" + pro.PNo);
                        }
                    }
                    else //大环（-0.15~0.2）
                    {
                        if (pro.Coaxiality > CoaxialityUpL || pro.Coaxiality < CoaxialityDownL)
                        {
                            pass = false;
                            LogNetUser.WriteInfo("正常", "大环同心度NG,同心度：" + pro.Coaxiality + "，产品条码：" + pro.PNo);
                        }
                        else if (pro.Surface.Equals("焊缝NG"))
                        {
                            pass = false;
                            LogNetUser.WriteInfo("正常", "大环焊缝NG，产品条码：" + pro.PNo);
                        }
                    }
                }

                if (!pass)
                {
                    //AddTips("产品编号:" + pro.PNo + "，检测NG！");

                    //不合格，报警并停机...
                    //m_opcUaClient.WriteNode("ns=3;s=\"WeldPara\".\"CheckResult\"", 2);

                    m_ngProduct = pro;
                    return false;
                }
                else
                {
                    //AddTips("检测结果：OK，开始焊接！");
                    //合格开始焊接
                    //m_opcUaClient.WriteNode("ns=3;s=\"WeldPara\".\"CheckResult\"", 1);

                    m_curProduct = pro;
                    LogNetUser.WriteInfo("检测合格，产品条码：" + pro.PNo);
                }
            }
            else
            {
                return false;
            }
            return true;
        }



        #region Vision相关

        private int _currentDeviceId;

        private List<MeasureData> _measureDatas = new List<MeasureData>();

        private DeviceData[] _deviceData = new DeviceData[NativeMethods.DeviceCount];

        private LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

        private float[] m_allDatas = new float[NativeMethods.MeasurementDataCount];//全部数据

        private float[] m_vaildDatas = new float[NativeMethods.MeasurementDataCount];//有效数据

        private float heightData = float.NaN;//每次采样的高度差

        private float coaxData = float.NaN;//每次采样的同心度

        private int m_weldOrder = 0;//焊接指令

        private int count = 0;//采样次数

        private float sumHeight = 0;//高度差和
        private float avgHeight = 0;

        private float sumCoax = 0;//同心度和
        private float avgCoax = 0;

        private double avgPower = 0;//采集功率数据平均值

        private double avgFlow = 0;

        private int avgSpeed = 0;

        private double avgPressure = 0;

        //实际坐标-PLC
        private double WeldXPos, WeldYPos, WeldZPos, WeldRPos = 0;

        /// <summary>
        /// 3D数据采集
        /// </summary>
        private void MonitorVisionData()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckOpcConnected())
                    {
                        m_weldOrder = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_VisionOrder);//PLC是否发送焊接指令

                        bool order = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_SendLwmCode);
                        if (order)
                        {
                            m_lwmCode = OpcUaClient.ReadNode<string>(PlcHelper.OPC_DB_LwmCode);
                            SendLwmBarcode(m_lwmCode);
                            if (b_sendLwmDataSuccess) OpcUaClient.WriteNode(PlcHelper.OPC_DB_SendLwmCode, false);
                            else AddTips("发送LWM条码失败！", true);
                        }

                        AnalysisVisionData();
                    }
                }
                catch (Exception ex)
                {
                    m_errorCount++;
                    if (m_errorCount > 5)
                    {
                        m_errorCount = 0;
                        LogNetProgramer.WriteError("异常", "OPC视觉通讯异常：" + ex.Message);
                    }
                    //AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                }
                Thread.Sleep(m_visionCollectInterval);
            }
        }

        private float VisionValidCheck(LJV7IF_MEASURE_DATA data)
        {
            if (data.byDataInfo == (int)LJV7IF_MEASURE_DATA_INFO.LJV7IF_MEASURE_DATA_INFO_VALID
                  && data.byJudge == (int)LJV7IF_JUDGE_RESULT.LJV7IF_JUDGE_RESULT_GO)
            {
                return data.fValue;
            }
            return -1;
        }

        private void AnalysisVisionData()
        {
            if (m_weldOrder == 1)//开始焊接
            {
                int rc = NativeMethods.LJV7IF_GetMeasurementValue(_currentDeviceId, measureData);

                //rc == (int)Rc.Ok
                heightData = VisionValidCheck(measureData[0]);
                coaxData = VisionValidCheck(measureData[1]);

                if (heightData != -1 && coaxData != -1)
                {
                    sumHeight += heightData;
                    sumCoax += coaxData;

                    count++;
                }
            }

            if (m_weldOrder == 2)//停止焊接
            {
                avgHeight = (float)Math.Round(Convert.ToDouble(sumHeight / count), 3);
                avgCoax = (float)Math.Round(Convert.ToDouble(sumCoax / count), 3);

                int type = SortVisionType(avgHeight, avgCoax);

                //发送测试结果给PLC，1、OK 其他NG
                OpcUaClient.WriteNode(PlcHelper.OPC_DB_VisionResult, type);

                CollectWeldDataL();

                OpcUaClient.WriteNode(PlcHelper.OPC_DB_VisionOrder, 0);
                count = 0;

                if (DeviceState != 2) b_startModifyL = true;
            }
        }

        private void CollectWeldDataL()
        {
            objs = WeldHelper.CollectWeldData(OpcUaClient, PlcHelper.Nodes_L);

            if (objs != null && objs.Count > 0)
            {
                WeldXPos = Math.Round(Convert.ToDouble(objs[0]), 3);
                WeldYPos = Math.Round(Convert.ToDouble(objs[1]), 3);
                WeldZPos = Math.Round(Convert.ToDouble(objs[2]), 3);
                WeldRPos = Math.Round(Convert.ToDouble(objs[3]), 3);
                avgPower = Math.Round(Convert.ToDouble(objs[4]), 3);
                avgPressure = Math.Round(Convert.ToDouble(objs[5]), 3);
                avgFlow = Math.Round(Convert.ToDouble(objs[6]), 3);
                avgSpeed = Convert.ToInt32(objs[7]);
                m_weldTimeL = Math.Round(Convert.ToDouble(objs[8]), 3);
                CurrentBarCode = objs[9].ToString();
                m_lwmResult = Convert.ToInt32(objs[10]);
            }
        }

        /// <summary>
        ///焊缝检测结果
        /// </summary>
        private string m_surfaceCheckL = string.Empty;

        private bool b_visionCheck;

        /// <summary>
        /// 3D检测焊缝结果分类
        /// </summary>
        /// <param name="height">焊缝平均值</param>
        /// <returns></returns>
        private int SortVisionType(float height, float coax)
        {
            if (m_lwmResult == 1)
            {
                b_lwmResult = true;
                btnLwmCheck.UIText = "OK";
                btnLwmCheck.OriginalColor = Color.Lime;
            }
            else if (m_lwmResult == 2)
            {
                b_lwmResult = false;
                btnLwmCheck.UIText = "NG";
                btnLwmCheck.OriginalColor = Color.Red;
            }

            if (height < 0 || height > 10 || float.IsNaN(height))//非数字无效值
            {
                avgHeight = (float)HfUp + ((float)random.NextDouble() * 1000) / 1000;
            }

            if (coax < 0 || coax > 10 || float.IsNaN(coax))//非数字无效值
            {
                avgCoax = (float)CoaxialityUpL + ((float)random.NextDouble() * 1000) / 1000;
                txtCoaxility.UIText = avgCoax.ToString("0.000") + "mm";//"NaN";
            }
            else
            {
                txtCoaxility.UIText = coax.ToString("0.000") + "mm";
            }

            if (height < HfUp && height > HfDown && coax < CoaxialityUpL && coax > CoaxialityDownL) //TYPE 1 同心度和焊缝都合格
            {
                m_surfaceCheckL = "OK";
                txtSurface.UIText = "OK";
                b_visionCheck = true;
                txtSurface.OriginalColor = Color.Lime;
                return 1;
            }
            else if (coax > CoaxialityUpL || coax < CoaxialityDownL)
            {
                m_surfaceCheckL = ResourceCulture.GetValue("CoaxialityNG");
                txtSurface.UIText = ResourceCulture.GetValue("CoaxialityNG");
                b_visionCheck = false;
                txtSurface.OriginalColor = Color.Red;
                return 4;//同心度NG
            }
            else if (height > HfUp || height < HfDown || float.IsNaN(height) || float.IsNaN(coax))
            {
                m_surfaceCheckL = ResourceCulture.GetValue("WeldDepthNG");
                txtSurface.UIText = ResourceCulture.GetValue("WeldDepthNG");
                b_visionCheck = false;
                txtSurface.OriginalColor = Color.Red;
                return 3;//焊缝NG
            }
            else
            {
                return 4;//同心度NG
            }
        }

        //大环数据更新
        private void ModifyLargeData()
        {
            while (IsWindowShow)
            {
                if (b_startModifyL)
                {
                    string sql = "update Product set WeldPower=@power,WeldSpeed=@speed,Flow=@flow,Pressure=@press,WeldDepth=@depth,WeldTime=@time," +
                        "XPos=@x,YPos=@y,ZPos=@z,RPos=@r,Coaxiality=@coax,Surface=@sur,LwmCheck=@lwm,QCResult=@qcr where PNo=@pno";

                    if (b_visionCheck && b_lwmResult) b_qcResult = true;
                    else b_qcResult = false;

                    try
                    {
                        SqlParameter[] sqlParameters =
                        {
                            new SqlParameter {ParameterName = "@power", SqlDbType = SqlDbType.Decimal, SqlValue = avgPower},
                            new SqlParameter {ParameterName = "@flow", SqlDbType = SqlDbType.Decimal, SqlValue = avgFlow},
                            new SqlParameter {ParameterName = "@press", SqlDbType = SqlDbType.Decimal, SqlValue = avgPressure},
                            new SqlParameter {ParameterName = "@depth", SqlDbType = SqlDbType.Decimal, SqlValue = avgHeight},
                            new SqlParameter {ParameterName = "@coax", SqlDbType = SqlDbType.Decimal, SqlValue = avgCoax},
                            new SqlParameter {ParameterName = "@speed", SqlDbType = SqlDbType.Int, SqlValue = avgSpeed},

                            new SqlParameter {ParameterName = "@x", SqlDbType = SqlDbType.Decimal, SqlValue = WeldXPos},
                            new SqlParameter {ParameterName = "@y", SqlDbType = SqlDbType.Decimal, SqlValue = WeldYPos},
                            new SqlParameter {ParameterName = "@z", SqlDbType = SqlDbType.Decimal, SqlValue = WeldZPos},
                            new SqlParameter {ParameterName = "@r", SqlDbType = SqlDbType.Decimal, SqlValue = WeldRPos},

                            new SqlParameter {ParameterName = "@time", SqlDbType = SqlDbType.Decimal, SqlValue = m_weldTimeL},
                            new SqlParameter {ParameterName = "@sur", SqlDbType = SqlDbType.NVarChar, SqlValue = m_surfaceCheckL},
                            new SqlParameter {ParameterName = "@lwm", SqlDbType = SqlDbType.NVarChar, SqlValue = b_lwmResult==true ? "OK":"NG"},
                            new SqlParameter {ParameterName = "@qcr", SqlDbType = SqlDbType.NVarChar, SqlValue = b_qcResult==true ? "OK":"NG"},
                            new SqlParameter {ParameterName = "@pno", SqlDbType = SqlDbType.NVarChar, SqlValue = CurrentBarCode}
                        };

                        if (!string.IsNullOrEmpty(CurrentBarCode))
                        {
                            int c = DbTool.ModifyTable(sql, sqlParameters);
                            if (c > 0)
                            {
                                AddTips(ResourceCulture.GetValue("SaveWeldDataOK"), false);

                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = true });

                                WeldParamReset();
                            }
                            else
                            {
                                AddTips(ResourceCulture.GetValue("SaveWeldDataFail") + "BarCode：" + CurrentBarCode, true);
                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = false });

                                LogNetProgramer.WriteInfo("CurrentBarCode：" + CurrentBarCode + "avgPower：" + avgPower + "avgFlow：" + avgFlow + "avgPressure:" + avgPressure +
                                   "avgHeight：" + avgHeight + "avgCoax：" + avgCoax + "avgSpeed：" + avgSpeed + "m_weldTimeL：" + m_weldTimeL);
                            }
                            b_startModifyL = !b_startModifyL;
                        }
                        else
                        {
                            AddTips(ResourceCulture.GetValue("SaveWeldDataFailNoBarcode"), true);
                        }

                    }
                    catch (Exception ex)
                    {
                        m_errorCount++;
                        if (m_errorCount > 5)
                        {
                            m_errorCount = 0;
                            LogNetProgramer.WriteError("异常", "大环检测结果保存失败：" + ex.Message);
                        }
                    }
                }
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 焊接参数标识复位
        /// </summary>
        private void WeldParamReset()
        {
            sumHeight = 0;
            avgHeight = 0;

            sumCoax = 0;
            avgCoax = 0;

            avgPower = 0;
            avgFlow = 0;
            avgSpeed = 0;
            avgPressure = 0;

            count = 0;
            m_weldOrder = 0;
        }

        #endregion


        #region MyTest

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "update ProductTest set WeldPower=@power,WeldSpeed=@speed,Flow=@flow,Pressure=@press,WeldDepth=@depth,WeldTime=@time," +
                        "XPos=@x,YPos=@y,ZPos=@z,RPos=@r,Coaxiality=@coax,Surface=@sur,LwmCheck=@lwm,QCResult=@qcr where PNo=@pno";

            CurrentBarCode = "3";
            avgCoax = avgHeight = (float)100.1235;
            m_weldTimeL = WeldRPos = WeldZPos = WeldYPos = WeldXPos = avgPressure = avgFlow = avgPower = 111.2225;

            SqlParameter[] sqlParameters =
            {
                    new SqlParameter {ParameterName = "@power", SqlDbType = SqlDbType.Decimal, SqlValue = avgPower},
                    new SqlParameter {ParameterName = "@flow", SqlDbType = SqlDbType.Decimal, SqlValue = avgFlow},
                    new SqlParameter {ParameterName = "@speed", SqlDbType = SqlDbType.Int, SqlValue = avgSpeed},
                    new SqlParameter {ParameterName = "@press", SqlDbType = SqlDbType.Decimal, SqlValue = avgPressure},
                    new SqlParameter {ParameterName = "@depth", SqlDbType = SqlDbType.Decimal, SqlValue = avgHeight},
                    new SqlParameter {ParameterName = "@coax", SqlDbType = SqlDbType.Decimal, SqlValue = avgCoax},

                    new SqlParameter {ParameterName = "@x", SqlDbType = SqlDbType.Decimal, SqlValue = WeldXPos},
                    new SqlParameter {ParameterName = "@y", SqlDbType = SqlDbType.Decimal, SqlValue = WeldYPos},
                    new SqlParameter {ParameterName = "@z", SqlDbType = SqlDbType.Decimal, SqlValue = WeldZPos},
                    new SqlParameter {ParameterName = "@r", SqlDbType = SqlDbType.Decimal, SqlValue = WeldRPos},

                    new SqlParameter {ParameterName = "@time", SqlDbType = SqlDbType.Decimal, SqlValue = m_weldTimeL},
                    new SqlParameter {ParameterName = "@sur", SqlDbType = SqlDbType.NVarChar, SqlValue = m_surfaceCheckL},
                    new SqlParameter {ParameterName = "@lwm", SqlDbType = SqlDbType.NVarChar, SqlValue = b_lwmResult==true ? "OK":"NG"},
                    new SqlParameter {ParameterName = "@qcr", SqlDbType = SqlDbType.NVarChar, SqlValue = b_qcResult==true ? "OK":"NG"},
                    new SqlParameter {ParameterName = "@pno", SqlDbType = SqlDbType.NVarChar, SqlValue = CurrentBarCode}
                };

            if (!String.IsNullOrEmpty(CurrentBarCode))
            {
                int c = DbTool.ModifyTable(sql, sqlParameters);

            }
        }

        private void TestDb()
        {
            avgHeight = 10152.010499456795422363f / 3;
            //float.TryParse(avgHeight.ToString("0.000"), out avgHeight);

            //float f1 = 2.01049995422363f;
            //string sf1 = f1.ToString("0.000");
            //float.TryParse(sf1, out f1);

            string sql = "update Product set WeldDepth = " + avgHeight + " where pno = '123456'; ";
            int c = DbTool.ModifyTable(sql, null);

        }

        private void TestLwm()
        {
            if (!InitLwmSocket())
            {
                MessageBox.Show(ResourceCulture.GetValue("LwmConnectFail"));
                return;
            }

            byte[] sendData = new byte[6] { 0x00, 0x14, 0x01, 0x00, 0x00, 0x04 };

            SendLwmBarcode(CurrentBarCode);

            int length = 1024 * 1024;
            var state = new StateObject(length);

            //异步接收
            //m_socketLwm.BeginReceive(state.Buffer, state.AlreadyDealLength,
            //        state.DataLength - state.AlreadyDealLength, SocketFlags.None,
            //        new AsyncCallback(ReceiveCallback), state);

            //同步接收
            int len = m_socketLwm.Receive(lwmData);
            if (len == 0) return;
            string data = Encoding.ASCII.GetString(lwmData, 0, len);

            //string data = Encoding.ASCII.GetString(state.Buffer, 0, length);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            /*
            if (ar.AsyncState is StateObject state)
            {
                try
                {
                    Socket client = state.WorkSocket;
                    int bytesRead = client.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        // 接收到了数据
                        state.AlreadyDealLength += bytesRead;
                        if (state.AlreadyDealLength < state.DataLength)
                        {
                            // 获取接下来的所有的数据
                            client.BeginReceive(state.Buffer, state.AlreadyDealLength,
                                state.DataLength - state.AlreadyDealLength, SocketFlags.None,
                                new AsyncCallback(ReceiveCallback), state);
                        }
                        else
                        {
                            // 接收到了所有的数据，通知接收数据的线程继续
                            state.WaitDone.Set();
                        }
                    }
                    else
                    {
                        // 对方关闭了网络通讯
                        state.IsClose = true;
                        state.WaitDone.Set();
                    }
                }
                catch (Exception ex)
                {
                    state.IsError = true;
                    state.ErrerMsg = ex.Message;
                    state.WaitDone.Set();
                }
            }*/
        }

        private byte[] AnalysicLwmData(byte[] barcode)
        {
            byte[] sendData = new byte[6 + barcode.Length];

            //报文ID
            sendData[0] = 0x00;
            sendData[1] = 0x12;
            sendData[2] = 0x01;
            sendData[3] = 0x00;

            sendData[4] = 0x00;//是否错误： 0 no error
            sendData[5] = 0x04;//数据长度

            barcode.CopyTo(sendData, 6);

            return sendData;
        }

        #endregion


        private string m_light = string.Empty;

        private string m_sqlUpdateState = string.Empty;

        private DateTime m_stateUpdateTime = DateTime.Now;

        //实时监听设备状态
        private void MonitorState()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckOpcConnected())
                    {
                        DeviceState = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_OffLine);
                        //Task<int> t = OpcUaClient.ReadNodeAsync<int>(s_offLine);
                        //int state = t.Result;

                        int light = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_Light);

                        UpdateDeviceState(light);
                    }
                }
                catch (Exception ex)
                {
                    m_errorCount++;
                    if (m_errorCount > 20)
                    {
                        m_errorCount = 0;
                        LogNetProgramer.WriteError("异常", "OPC监听设备状态异常--->" + ex.Message);
                    }
                    AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                }

                Thread.Sleep(2000);
            }
        }

        private void UpdateDeviceState(int light)
        {
            if (DeviceState == 1) //在线
            {
                Invoke(new Action(() =>
                {
                    labState.Text = ResourceCulture.GetValue("OnLine");
                }));
                lanternState.LanternBackground = Color.LimeGreen;
            }
            else if (DeviceState == 2) //离线
            {
                Invoke(new Action(() =>
                {
                    labState.Text = ResourceCulture.GetValue("OffLine");
                }));
                lanternState.LanternBackground = Color.Gray;
            }

            switch (light)
            {
                case 1:
                    m_light = "运行";
                    break;
                case 2:
                    m_light = "暂停";
                    break;
                case 3:
                    m_light = "报警";
                    break;
                default:
                    m_light = "离线";
                    break;
            }

            m_stateUpdateTime = DateTime.Now;
            m_sqlUpdateState = " update DeviceState set State=('" + m_light + "'),UpdateTime='" + m_stateUpdateTime + "' ; ";
            int rs = DbTool.ModifyTable(m_sqlUpdateState, null);
        }

        /// <summary>
        /// 当前系统语言
        /// </summary>
        public int Culture = 1;

        public delegate void CultureChangeHandle(object obj, MyEvent e);
        public event CultureChangeHandle CultureChangeEvent;
        public void OnCultureChange(object obj, MyEvent e)
        {
            CultureChangeEvent?.Invoke(obj, e);
        }

        public delegate void ClickSpotFormHandle(object obj, MyEvent e);
        public event ClickSpotFormHandle ClickSpotFormEvent;
        public void OnClickSpotForm(object obj, MyEvent e)
        {
            ClickSpotFormEvent?.Invoke(obj, e);
        }

        public delegate void WeldSuccessHandle(object obj, MyEvent e);
        public event WeldSuccessHandle WeldSuccessEvent;
        public void OnWeldSuccess(object obj, MyEvent e)
        {
            WeldSuccessEvent?.Invoke(obj, e);
        }

        public delegate void WindowStateHandle(object obj, MyEvent e);
        public event WindowStateHandle WindowStateEvent;
        public void OnWindowState(object obj, MyEvent e)
        {
            WindowStateEvent?.Invoke(obj, e);
        }

        public delegate void BarCodeChangeHandle(MyEvent e);
        public event BarCodeChangeHandle BarCodeChange;
        public void OnBarCodeChange(MyEvent e)
        {
            BarCodeChange?.Invoke(e);
        }


        private void 点检中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClickSpotForm(this, new MyEvent() { HideSpotForm = false });
            m_spotCheckForm.Show();
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Culture = 1;
            CultureChange();

            OnCultureChange(this, new MyEvent() { Culture = 1 });
            AppSetting.SetLanguage(Culture);

            //MessageBox.Show("已切换至中文");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体
                WindowState = FormWindowState.Normal;

                //激活窗体
                Activate();

                //任务栏显示图标
                ShowInTaskbar = true;

                //托盘图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            //判断窗体是否为最小化
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void 英语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Culture = 2;
            CultureChange();

            OnCultureChange(this, new MyEvent() { Culture = 2 });
            AppSetting.SetLanguage(Culture);

            //MessageBox.Show("Select English");
        }

        private void 点检记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpotDatas form = new FormSpotDatas(this);
            form.ShowDialog();
        }

        private void txtCoaxility_Click(object sender, EventArgs e)
        {
            //avgCoax = (float)CoaxialityUpL + ((float)random.NextDouble() * 1000) / 1000;
            //txtCoaxility.UIText = avgCoax.ToString("0.000");
        }

        private void 维护中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOmcs();
        }

        private void ShowOmcs()
        {
            if (CurrentUser == null) ShowLogin();

            if (!Result || !CheckUserAuth()) return;

            UsersTable = DbTool.SelectTable(m_selectAllUsers);
            Hide();
            using (OMCSForm form = new OMCSForm(this))
            {
                form.ShowDialog();
            }
            Show();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            toolCurrentUser.BackColor = Color.Tomato;
            toolCurrentUser.Text = ResourceCulture.GetValue("UserLoginOut");
        }

        private void 登录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void 参数配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLogin();

            if (!Result || !CheckUserAuth()) return;

            if (IsStation_S)
            {
                FormParamSetting form = new FormParamSetting(this);
                form.ShowDialog();
            }
            else
            {
                FormParamSettingL form = new FormParamSettingL(this);
                form.ShowDialog();
            }
        }

        private void 模板配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentUser == null) ShowLogin();

            if (!Result || !CheckUserAuth()) return;

            WeldingModuleForm form = new WeldingModuleForm(this);
            form.ShowDialog();
        }


    }
}