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
using System.Runtime.InteropServices;
using ProductManage.Scanner;
using ProductManage.Lwm;

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
        #region 共有变量

        public string StationName = "S";

        public bool IsStation_S = true;

        public DBTool DbTool = null;

        public ILogNet LogNetUser;
        public string UserLogName = "用户日志.txt";

        public ILogNet LogNetProgramer;

        public OpcUaClient OpcUaClient;
        public string OpcServiceUrl = "opc.tcp://192.168.0.75:4840";

        public int DeviceState = 2;

        public XmlHelperBase XmlHelper;
        public Dictionary<string, string> SystemParamsDic;
        public DataTable UsersTable;
        public string WorkNo { set; get; }
        #endregion

        #region 私有变量


        private SoftAuthorize m_softAuthorize = null;

        private Timer m_selfCheckTimer;

        private string CurrentBarCode = string.Empty;

        private VisionLJ7000 m_visionLj7080;

        private int m_scanErrorCount = 0;//扫码错误次数记录

        private Socket m_socketScan = null;

        private bool m_scanRun = false;//是否开启扫码线程

        private Socket m_socketLwm = null;//LWM监听Socket

        private SpotCheckForm m_spotCheckForm;

        private int m_errorCount = 0; //异常记录次数

        private bool b_opcState = false;//PLC连接状态

        private bool b_startModifyL = false;//是否更新大环数据

        private bool b_startModifyS = false;//是否更新小环数据

        private bool b_lwmResult = true;//LWM检查结果

        private bool b_qcResult;//综合检测结果

        private double m_weldTime;//焊接时间

        private Random random = new Random();

        private bool IsWindowShow = true;

        public string ScanIP = string.Empty;
        #endregion

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

        public int Test = 0;
        public int UseLanguage = 1;

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitFormStyle();

            LoadSystemSetFile();

            //程序验证注册码
            //CheckSoftAuthorize();

            if (Test == 0)
            {
                //初始化PLC通讯
                OpenPlc();

                //初始化扫描枪
                OpenScanSocket();

                //初始化LWM通讯
                OpenLwmSocket();

                //初始化通讯线程
                InitThreads();
            }

            //初始化用户控件页面布局
            InitUserControl();

            //初始化检测提醒功能
            //InitWarnCheck();
        }

        private void InitFormStyle()
        {
            StationName = AppSetting.GetStationName();
            IsStation_S = StationName.Equals("S");
            ActiveControl = txtBarCode;

            if (IsStation_S)
            {
                //toolParamSetting.Visible = false;
            }
            else
            {

            }

            //设定按字体来缩放控件  
            this.AutoScaleMode = AutoScaleMode.Font;
            //设定字体大小为12px       
            this.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(135)));

            DbTool = new DBTool();

            //初始化程序日志
            LogNetProgramer = Program.LogNet;
        }

        /// <summary>
        /// 多线程初始化
        /// </summary>
        private void InitThreads()
        {
            //监听设备状态，三色灯、在线离线
            Thread t_monitorState = new Thread(MonitorState);
            t_monitorState.IsBackground = true;
            t_monitorState.Start();

            //OPC LWM检测监听线程
            //Thread t_lwmThread = new Thread(GetLwmDataFromPlc);
            //t_lwmThread.IsBackground = true;
            //t_lwmThread.Start();

            //监听扫描仪线程
            Thread t_scanThread = new Thread(StartScanThread);
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
                Thread t_coaSurface = new Thread(MonitorCoaSurface);
                t_coaSurface.IsBackground = true;
                t_coaSurface.Start();

                Thread t_modifySmallData = new Thread(ModifySmallData);
                t_modifySmallData.IsBackground = true;
                t_modifySmallData.Start();
                b_startModifyS = false;

            }

            //采集焊缝高度差，大环用
            if (!IsStation_S)
            {
                if (!VisionLJ7000.Instance.OpenVision()) return;

                Thread t_visionThread = new Thread(MonitorVisionData);
                t_visionThread.IsBackground = true;
                t_visionThread.Start();

                Thread t_modifyLargeData = new Thread(ModifyLargeData);
                t_modifyLargeData.IsBackground = true;
                t_modifyLargeData.Start();
                b_startModifyL = false;
            }

        }


        #region CheckState

        public bool CheckPlcState()
        {
            if (OpcUaClient == null || OpenPlc() ||
                !OpcUaClient.Connected || !b_opcState)
            {
                AddTips("PLC连接断开，请检查网络连接！", true);
                return false;
            }
            AddTips("PLC重新建立连接！", false);
            return true;
        }

        public bool CheckDbState()
        {
            if (!DBHelper.Instance.Open())
            {
                AddTips("数据库连接断开，请检查网络连接！", true);
                return false;
            }
            AddTips("数据库重新建立连接！", false);
            return true;
        }

        #endregion



        #region 语言

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
            exeIcon.Text = ResourceCulture.GetValue("ProductManageSystem");

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
            labState.Text = ResourceCulture.GetValue("OffLine");
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

        private double CoaxUpS, CoaxDownS;
        private double CoaxUpL, CoaxDownL;
        private double HfUp, HfDown;
        private double FlowUp, FlowDown;

        //大环标准焊接坐标-XML
        private double BZWeldX, BZWeldY, BZWeldZ, BZWeldR;

        //加载系统参数
        private void LoadSystemSetFile()
        {
            SystemParamsDic = m_spotCheckForm.DicSystemData;

            if (SystemParamsDic == null) return;

            foreach (var item in SystemParamsDic)
            {
                switch (item.Key)
                {
                    case "CoaxUpS":
                        CoaxUpS = Convert.ToDouble(item.Value);
                        break;
                    case "CoaxDownS":
                        CoaxDownS = Convert.ToDouble(item.Value);
                        break;
                    case "CoaxUpL":
                        CoaxUpL = Convert.ToDouble(item.Value);
                        break;
                    case "CoaxDownL":
                        CoaxDownL = Convert.ToDouble(item.Value);
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



        #region PLC相关

        /// <summary>
        /// 初始化PLC通讯
        /// </summary>
        private bool OpenPlc()
        {
            OpcServiceUrl = string.Empty;
            //实例化一个OPC客户端对象
            if (IsStation_S)
            {
                OpcServiceUrl = "opc.tcp://192.168.0.75:4840";
            }
            else
            {
                OpcServiceUrl = "opc.tcp://192.168.0.85:4840";
            }
            OpcUaClient = new OpcUaClient();

            try
            {
                OpcUaClient.OpcStatusChange += OpcUaClient_OpcStatusChange;
                OpcUaClient.ConnectServer(OpcServiceUrl);
            }
            catch (Exception ex)
            {
                m_errorCount++;
                if (m_errorCount > 50)
                {
                    m_errorCount = 0;
                    LogNetProgramer.WriteError("异常", "PLC连接失败：" + ex.Message);
                }
                return false;
            }
            return true;
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
                try
                {
                    OpcUaClient.ConnectServer(OpcServiceUrl);
                    b_opcState = true;
                    AddTips("PLC重新建立连接！", false);
                }
                catch (Exception ex)
                {
                    b_opcState = false;
                    LogNetProgramer.WriteError("异常", "PLC重新建立连接失败！" + ex.Message);
                    AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                }
            }
        }

        #endregion



        #region LWM相关

        private byte[] lwmData = new byte[1024 * 1024 * 1024];

        private bool b_sendLwmDataSuccess = true;

        private string m_lwmCode = string.Empty;

        /// <summary>
        /// 建立LWM通讯
        /// </summary>
        private bool OpenLwmSocket()
        {
            try
            {
                m_socketLwm = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.0.60"), 8000);//8000;//700：控制端口

                if (!m_socketLwm.Connected)
                {
                    m_socketLwm.Connect(endPoint);
                }

                return true;
            }
            catch (Exception ex)
            {
                AddTips("LWM连接失败,请检查网络连接！", true);
                m_errorCount++;
                if (m_errorCount > 10)
                {
                    m_errorCount = 0;
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
                    if (m_socketLwm == null || !m_socketLwm.Connected) OpenLwmSocket();
                    m_socketLwm.Send(Encoding.ASCII.GetBytes(barcode));
                    b_sendLwmDataSuccess = true;
                    LwmHelper.GetInstance().SafeClose(m_socketLwm);
                    //TcpSafeClose(m_socketLwm);
                }
                catch (Exception ex)
                {
                    b_sendLwmDataSuccess = false;
                    m_errorCount++;
                    if (m_errorCount > 10)
                    {
                        m_errorCount = 0;
                        LogNetProgramer.WriteError("异常", "发送LWM条码异常：" + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 读取 PLC LWM检测结果
        /// </summary>
        private void GetLwmDataFromPlc()
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
                            txtLwmCheck.UIText = "OK";
                            txtLwmCheck.OriginalColor = Color.Lime;
                        }
                        else if (result == 2)
                        {
                            b_lwmResult = false;
                            txtLwmCheck.UIText = "NG";
                            txtLwmCheck.OriginalColor = Color.Red;
                        }
                        else
                        {
                            txtLwmCheck.UIText = "LwmResult:0";
                            txtLwmCheck.OriginalColor = Color.OrangeRed;
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

                socket.Close();
                socket.Dispose();
                socket = null;
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

        private bool OpenScanSocket()
        {
            try
            {
                if (IsStation_S)
                {
                    ScanIP = "192.168.0.78";
                }
                else
                {
                    ScanIP = "192.168.0.88";
                }

                m_socketScan = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ScanIP), 9004);

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
                AddTips("扫描仪SR-751连接失败,请检查网络连接！", true);
                LogNetProgramer.WriteDebug("扫描仪连接异常：" + ex.Message);
            }
            return m_scanRun;
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


        #region 小环相关

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
                    if (CheckPlcState())
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
                }

                Thread.Sleep(200);
            }
        }

        private void CollectWeldData()
        {
            objs.Clear();
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

                FlowUp = Math.Round(Convert.ToDouble(objs[7]), 3);
                FlowDown = Math.Round(Convert.ToDouble(objs[8]), 3);

                avgSpeed = Convert.ToInt32(objs[7]);
                m_weldTime = Math.Round(Convert.ToDouble(objs[8]), 3);
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
            Invoke(new Action(() =>
            {
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
                else if (m_surface == 4 || !TypeCoaxiality(CoaxialityS))
                {
                    m_surfaceType = "同心度NG";
                    txtSurface.UIText = "NG";
                    txtSurface.OriginalColor = Color.Red;
                    b_coaCheckS = false;
                }

                if (m_lwmResult == 1)
                {
                    b_lwmResult = true;
                    txtLwmCheck.UIText = "OK";
                    txtLwmCheck.OriginalColor = Color.Lime;
                }
                else if (m_lwmResult == 2)
                {
                    b_lwmResult = false;
                    txtLwmCheck.UIText = "NG";
                    txtLwmCheck.OriginalColor = Color.Red;
                }
                txtCoaxility.UIText = CoaxialityS + "mm";
            }));

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
                    string sql = "update Product set WeldPower=@power,WeldSpeed=@speed,Flow=@flow,FlowUp=@flowUp,FlowDown=@flowDown,Pressure=@press,WeldTime=@time," +
                        "XPos=@x,YPos=@y,ZPos=@z,RPos=@r,Coaxiality=@coa,CoaxUp=@coaxUp,CoaxDown=@coaxDown,Surface=@sur,LwmCheck=@lwm,QCResult=@qcr where PNo=@pno";

                    if (b_surfaceCheck && b_coaCheckS && b_lwmResult) b_qcResult = true;
                    else b_qcResult = false;

                    try
                    {
                        SqlParameter[] sqlParameters =
                        {
                            //new SqlParameter {ParameterName = "@workNo", SqlDbType = SqlDbType.Decimal, SqlValue = WorkNo},
                            new SqlParameter {ParameterName = "@power", SqlDbType = SqlDbType.Decimal, SqlValue = avgPower},
                            new SqlParameter {ParameterName = "@press", SqlDbType = SqlDbType.Decimal, SqlValue = avgPressure},
                            new SqlParameter {ParameterName = "@speed", SqlDbType = SqlDbType.Int, SqlValue = avgSpeed},
                            new SqlParameter {ParameterName = "@flow", SqlDbType = SqlDbType.Decimal, SqlValue = avgFlow},

                            new SqlParameter {ParameterName = "@flowUp", SqlDbType = SqlDbType.Decimal, SqlValue = FlowUp},
                            new SqlParameter {ParameterName = "@flowDown", SqlDbType = SqlDbType.Decimal, SqlValue = FlowDown},

                            new SqlParameter {ParameterName = "@coa", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxialityS},
                            new SqlParameter {ParameterName = "@coaxUp", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxUpS},
                            new SqlParameter {ParameterName = "@coaxDown", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxDownS},

                            new SqlParameter {ParameterName = "@x", SqlDbType = SqlDbType.Decimal, SqlValue = WeldXPos},
                            new SqlParameter {ParameterName = "@y", SqlDbType = SqlDbType.Decimal, SqlValue = WeldYPos},
                            new SqlParameter {ParameterName = "@z", SqlDbType = SqlDbType.Decimal, SqlValue = WeldZPos},
                            new SqlParameter {ParameterName = "@r", SqlDbType = SqlDbType.Decimal, SqlValue = WeldRPos},

                            new SqlParameter {ParameterName = "@time", SqlDbType = SqlDbType.Decimal, SqlValue = m_weldTime},
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
                                    "CoaxialityS：" + CoaxialityS + "avgSpeed：" + avgSpeed + "m_weldTimeS：" + m_weldTime);
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
                if (coa > CoaxUpS || coa < CoaxDownS)//小环
                {
                    res = false;
                }
            }
            else
            {
                if (coa > CoaxUpL || coa < CoaxDownL)//大环
                {
                    res = false;
                }
            }

            return res;
        }


        #endregion


        /// <summary>
        /// 初始化提醒检测模块
        /// </summary>
        private void InitWarnCheck()
        {
            int interval = AppSetting.GetCheckInterval();

            if (interval < 1)
            {
                MessageBox.Show("自检间隔不能小于一小时！请重新配置后重启软件！");
                return;
            }

            m_selfCheckTimer = new Timer();
            m_selfCheckTimer.Tick += new EventHandler(SelfeCheck_Tick);
            m_selfCheckTimer.Interval = 1 * 1000;// * 3600;
            m_selfCheckTimer.Enabled = true;
        }

        private void SelfeCheck_Tick(object sender, EventArgs e)
        {
            //窗口提醒检测
            SelfCheckWarmForm selfCheckWarmForm = new SelfCheckWarmForm(this);
            selfCheckWarmForm.Show();
        }



        #region 用户控件相关

        private CollectingSystem collecting;

        private TraceSystem traceSystem;

        private LogErrorControl logError;

        private void InitUserControl()
        {
            collecting = new CollectingSystem(this);
            collecting.Dock = DockStyle.Fill;

            traceSystem = new TraceSystem(this);
            traceSystem.Dock = DockStyle.Fill;

            logError = new LogErrorControl(this);
            logError.Dock = DockStyle.Fill;

            panelBox.Controls.AddRange(new Control[] { collecting, traceSystem, logError });

        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            collecting.Show();
            traceSystem.Hide();
            logError.Hide();
        }

        private void btnTraceSystem_Click(object sender, EventArgs e)
        {
            traceSystem.Show();
            collecting.Hide();
            logError.Hide();
        }

        private void btnLogSystem_Click(object sender, EventArgs e)
        {
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

        public void HideTips()
        {
            try
            {
                if (IsWindowShow && !this.IsDisposed)
                {
                    if (this.InvokeRequired)
                    {
                        toolTips.Text = ResourceCulture.GetValue("Tips");
                    }
                }
            }
            catch (Exception ex)
            {
                LogNetProgramer.WriteError("异常", "HideTips:" + ex.Message);
            }
        }


        #region 登录相关

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

        #endregion



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

            CurrentBarCode = barCode;

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
        /// 产品是否入库
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
                string sql = "INSERT INTO Product(PNo,StorageTime) Values('" + barCode + "','" + DateTime.Now + "')";
                int c = DbTool.ModifyTable(sql);
                if (c > 0)
                {
                    rs = 2;
                }
                else
                {
                    rs = 3;
                    AddTips(barCode + "产品入库失败！", true);
                }
            }
            return rs;
        }


        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion


        #region 大环相关

        private int _currentDeviceId = 0;

        private LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

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
                    if (CheckPlcState())
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
                Thread.Sleep(300);
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
            if (m_weldOrder == 1 && VisionLJ7000.Instance.Connected)//开始焊接
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
            objs.Clear();
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

                FlowUp = Math.Round(Convert.ToDouble(objs[7]), 3);
                FlowDown = Math.Round(Convert.ToDouble(objs[8]), 3);

                avgSpeed = Convert.ToInt32(objs[7]);
                m_weldTime = Math.Round(Convert.ToDouble(objs[8]), 3);
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
                txtLwmCheck.UIText = "OK";
                txtLwmCheck.OriginalColor = Color.Lime;
            }
            else if (m_lwmResult == 2)
            {
                b_lwmResult = false;
                txtLwmCheck.UIText = "NG";
                txtLwmCheck.OriginalColor = Color.Red;
            }

            if (height < 0 || height > 10 || float.IsNaN(height))//非数字无效值
            {
                avgHeight = (float)HfUp + ((float)random.NextDouble() * 1000) / 1000;
            }

            if (coax < 0 || coax > 10 || float.IsNaN(coax))//非数字无效值
            {
                avgCoax = (float)CoaxUpL + ((float)random.NextDouble() * 1000) / 1000;
                txtCoaxility.UIText = avgCoax.ToString("0.000") + "mm";//"NaN";
            }
            else
            {
                txtCoaxility.UIText = coax.ToString("0.000") + "mm";
            }

            if (height < HfUp && height > HfDown && coax < CoaxUpL && coax > CoaxDownL) //TYPE 1 同心度和焊缝都合格
            {
                m_surfaceCheckL = "OK";
                txtSurface.UIText = "OK";
                b_visionCheck = true;
                txtSurface.OriginalColor = Color.Lime;
                return 1;
            }
            else if (coax > CoaxUpL || coax < CoaxDownL)
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
                    string sql = "update Product set WeldPower=@power,WeldSpeed=@speed,Flow=@flow,FlowUp=@flowUp,FlowDown=@flowDown,Pressure=@press,WeldDepth=@depth,WeldTime=@time," +
                        "XPos=@x,YPos=@y,ZPos=@z,RPos=@r,Coaxiality=@coax,CoaxUp=@coaxUp,CoaxDown=@coaxDown,Surface=@sur,LwmCheck=@lwm,QCResult=@qcr where PNo=@pno";

                    if (b_visionCheck && b_lwmResult) b_qcResult = true;
                    else b_qcResult = false;

                    try
                    {
                        SqlParameter[] sqlParameters =
                        {
                            //new SqlParameter {ParameterName = "@workNo", SqlDbType = SqlDbType.Decimal, SqlValue = WorkNo},
                            new SqlParameter {ParameterName = "@power", SqlDbType = SqlDbType.Decimal, SqlValue = avgPower},
                            new SqlParameter {ParameterName = "@press", SqlDbType = SqlDbType.Decimal, SqlValue = avgPressure},
                            new SqlParameter {ParameterName = "@speed", SqlDbType = SqlDbType.Int, SqlValue = avgSpeed},
                            new SqlParameter {ParameterName = "@depth", SqlDbType = SqlDbType.Decimal, SqlValue = avgHeight},
                            new SqlParameter {ParameterName = "@flow", SqlDbType = SqlDbType.Decimal, SqlValue = avgFlow},

                            new SqlParameter {ParameterName = "@flowUp", SqlDbType = SqlDbType.Decimal, SqlValue = FlowUp},
                            new SqlParameter {ParameterName = "@flowDown", SqlDbType = SqlDbType.Decimal, SqlValue = FlowDown},

                            new SqlParameter {ParameterName = "@coax", SqlDbType = SqlDbType.Decimal, SqlValue = avgCoax},
                            new SqlParameter {ParameterName = "@coaxUp", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxUpL},
                            new SqlParameter {ParameterName = "@coaxDown", SqlDbType = SqlDbType.Decimal, SqlValue = CoaxDownL},

                            new SqlParameter {ParameterName = "@x", SqlDbType = SqlDbType.Decimal, SqlValue = WeldXPos},
                            new SqlParameter {ParameterName = "@y", SqlDbType = SqlDbType.Decimal, SqlValue = WeldYPos},
                            new SqlParameter {ParameterName = "@z", SqlDbType = SqlDbType.Decimal, SqlValue = WeldZPos},
                            new SqlParameter {ParameterName = "@r", SqlDbType = SqlDbType.Decimal, SqlValue = WeldRPos},

                            new SqlParameter {ParameterName = "@time", SqlDbType = SqlDbType.Decimal, SqlValue = m_weldTime},
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
                                   "avgHeight：" + avgHeight + "avgCoax：" + avgCoax + "avgSpeed：" + avgSpeed + "m_weldTimeL：" + m_weldTime);
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


        #region 测试用

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "update ProductTest set WeldPower=@power,WeldSpeed=@speed,Flow=@flow,Pressure=@press,WeldDepth=@depth,WeldTime=@time," +
                        "XPos=@x,YPos=@y,ZPos=@z,RPos=@r,Coaxiality=@coax,Surface=@sur,LwmCheck=@lwm,QCResult=@qcr where PNo=@pno";

            CurrentBarCode = "3";
            avgCoax = avgHeight = (float)100.1235;
            m_weldTime = WeldRPos = WeldZPos = WeldYPos = WeldXPos = avgPressure = avgFlow = avgPower = 111.2225;

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

                    new SqlParameter {ParameterName = "@time", SqlDbType = SqlDbType.Decimal, SqlValue = m_weldTime},
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
            if (!OpenLwmSocket())
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
            }
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


        //实时监听设备状态
        private void MonitorState()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckPlcState())
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

            string m_light = string.Empty;
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

            string sqlUpdateState = " update DeviceState set State=('" + m_light + "'),UpdateTime='" + DateTime.Now + "' ; ";
            int rs = DbTool.ModifyTable(sqlUpdateState, null);
            if (rs <= 0) LogNetProgramer.WriteError("更新设备状态失败：" + rs);
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
            //OnClickSpotForm(this, new MyEvent() { HideSpotForm = false });
            //m_spotCheckForm.Show();
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
                //notifyIcon1.Visible = false;
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            //判断窗体是否为最小化
            if (WindowState == FormWindowState.Minimized)
            {
                //ShowInTaskbar = false;
                exeIcon.Visible = true;
            }
        }

        //垃圾定时回收
        private void timerGC_Tick(object sender, EventArgs e)
        {
            ClearMemory();
        }

        private void 英语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Culture = 2;
            CultureChange();

            OnCultureChange(this, new MyEvent() { Culture = 2 });
            AppSetting.SetLanguage(Culture);

            //MessageBox.Show("Select English");
        }

        private void 通讯监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonitor form = new FormMonitor(this);
            form.ShowDialog();
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

            string sql = "Select ID,Name,Password,Auth from Users";
            UsersTable = DbTool.SelectTable(sql);
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

            exeIcon.Visible = false;
            IsWindowShow = false;
            OnWindowState(this, new MyEvent() { IsWindowShow = false });

            Dispose();
            Application.Exit();

            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

    }
}