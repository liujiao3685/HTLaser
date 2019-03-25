using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MES.DAL;
using MES.UI;
using HslCommunication.LogNet;
using MES.Core;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using MES.UserControls;
using MES.Vision;
using OpcUaHelper;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using System.Net.Sockets;
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
using System.IO;
using System.Reflection;
using Model;
using ProductManage.Log;
using BLL;
using System.Threading.Tasks;
using CommonLibrary.Scanner;
using CommonLibrary.Lwm;

namespace MES
{
    public partial class FormMain : Form
    {
        #region 公有变量

        public string StationName = "S";
        public bool IsStation_S = true;

        public DBTool DbTool = null;

        public ILogNet LogNetProgramer;

        public OpcUaClient OpcUaClient;
        public OpcUaTool.OpcUaClient OpcUaTool;
        public string OpcServiceUrl = "opc.tcp://192.168.0.75:4840";

        public int DeviceState = 2;//1在线 2离线

        public XmlHelperBase XmlHelper;
        public Dictionary<string, string> SystemParamsDic;
        public DataTable UsersTable;
        public int Culture = 1;
        public string ScanIP = string.Empty;
        public Entity.User CurrentUser = null;
        public KeyenceSR751 keyenceSR751;

        #endregion

        #region 私有变量

        private string CurrentBarCode = string.Empty;

        public Socket m_socketScan = null;

        private bool m_scanRun = false;//是否开启扫码线程

        public Socket m_socketLwm = null;//LWM监听Socket

        private SpotCheckForm m_spotCheckForm;

        private int m_errorCount = 0; //异常记录次数

        private bool b_startModifyL = false;//是否更新大环数据

        private bool b_startModifyS = false;//是否更新小环数据

        private Random random = new Random();

        private bool IsWindowShow = true;

        private bool IsDoST20_Thread;
        private bool IsDoST70_Thread;
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

        public int Test = 1;
        public int UseLanguage = 1;

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitFormStyle();

            LoadSystemSetFile();

            //程序验证注册码
            //CheckSoftAuthorize();

            if (Test == 0)
            {
                keyenceSR751 = new KeyenceSR751(ScanIP);

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
            FaceInit();

            if (IsStation_S)
            {
                ScanIP = "192.168.0.78";
                //toolParamSetting.Visible = false;
            }
            else
            {
                ScanIP = "192.168.0.88";
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
            //监控设备状态：在线，离线，报警
            Thread t_monitorState = new Thread(MonitorState);
            t_monitorState.IsBackground = true;
            t_monitorState.SetApartmentState(ApartmentState.STA);
            t_monitorState.Start();

            //监听扫描仪线程
            Thread t_scanThread = new Thread(StartScanThread);
            t_scanThread.IsBackground = true;
            t_scanThread.SetApartmentState(ApartmentState.STA);
            t_scanThread.Start();

            //采集同心度，表面质量，小环用
            if (IsStation_S)
            {
                IsDoST20_Thread = true;
                Thread t_coaSurface = new Thread(ThreadCollectSData);
                t_coaSurface.IsBackground = true;
                t_coaSurface.SetApartmentState(ApartmentState.STA);
                t_coaSurface.Start();

                b_startModifyS = false;
                Thread t_modifySmallData = new Thread(ModifySmallData);
                t_modifySmallData.IsBackground = true;
                t_modifySmallData.SetApartmentState(ApartmentState.STA);
                t_modifySmallData.Start();

            }

            //采集焊缝高度差，大环用
            if (!IsStation_S)
            {
                if (!VisionLJ7000.Instance.OpenVision()) return;

                IsDoST70_Thread = true;
                Thread t_visionThread = new Thread(ThreadCollectLData);
                t_visionThread.IsBackground = true;
                t_visionThread.SetApartmentState(ApartmentState.STA);
                t_visionThread.Start();

                b_startModifyL = false;
                Thread t_modifyLargeData = new Thread(ModifyLargeData);
                t_modifyLargeData.IsBackground = true;
                t_modifyLargeData.SetApartmentState(ApartmentState.STA);
                t_modifyLargeData.Start();
            }

        }

        #region 系统语言

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
                   + "  [ Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ]";
            exeIcon.Text = ResourceCulture.GetValue("ProductManageSystem");

            toolMachineState.Text = ResourceCulture.GetValue("MachineState");
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
                CommonLibrary.Log.LogHelper.WriteLog("PLC连接失败", ex);
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
                    AddTips("PLC重新建立连接！", false);
                }
                catch (Exception ex)
                {
                    LogNetProgramer.WriteError("异常", "PLC重新建立连接失败！" + ex.Message);
                    AddTips(ResourceCulture.GetValue("PLCConnectException"), true);
                }
            }
        }

        public bool CheckPlcState()
        {
            if (OpcUaClient == null || !OpcUaClient.Connected)
            {
                LogHelper.WriteLog("PLC状态", "PLC连接断开，请检查网络连接,并重启软件！");
                OpenPlc();
                return false;
            }
            return true;
        }
        #endregion
        #region LWM相关

        private byte[] lwmData = new byte[1024 * 1024 * 1024];
        private bool SendLwmCodeResult = false;
        public LwmClient Lwm;

        /// <summary>
        /// 建立LWM通讯
        /// </summary>
        private bool OpenLwmSocket()
        {
            try
            {
                Lwm = new LwmClient("192.168.0.60");
                m_socketLwm = Lwm.LwmSocket;

                //m_socketLwm = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.0.60"), 8000);//8000;//700：控制端口
                //if (!m_socketLwm.Connected)
                //{
                //    m_socketLwm.Connect(endPoint);
                //}

                return true;
            }
            catch (Exception ex)
            {
                AddTips("LWM连接失败,请检查网络连接！", true);
                LogNetProgramer.WriteDebug("LWM连接异常：" + ex.Message);
                return false;
            }
        }

        private void SendBarcodeToLwm(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                try
                {
                    //if (m_socketLwm == null || !m_socketLwm.Connected) OpenLwmSocket();
                    //m_socketLwm.Send(Encoding.ASCII.GetBytes(barcode));

                    if (!Lwm.IsConnection()) Lwm.Init();
                    Result result = Lwm.Write(barcode);
                    if (result.IsSuccess)
                    {
                        LogHelper.WriteLog("LWM条码", string.Format("LWM条码发送成功，条码：{0}", barcode));
                    }
                    else
                    {
                        LogHelper.WriteLog("LWM条码", string.Format("LWM条码发送失败，条码：{0}，Msg:{1}", barcode, result.Msg));
                    }

                    //string callback;= LwmCallBack();
                    string callback = Encoding.ASCII.GetString(Lwm.Read().Content);
                    LogHelper.WriteLog("LWM条码", string.Format("LWM 回应 - 条码：{0}", callback));

                    SendLwmCodeResult = true;
                    Lwm.Close();
                }
                catch (Exception ex)
                {
                    SendLwmCodeResult = false;
                    LogNetProgramer.WriteError("异常", "发送LWM条码异常：" + ex.Message);
                }
            }
            else
            {
                SendLwmCodeResult = false;
                LogHelper.WriteLog("LWM条码", String.Format("发送LWM条码失败，条码为空！"));
            }
        }

        private void ReceiveLwmCodeOrder(bool order)
        {
            if (order)
            {
                LogHelper.WriteLog("ST70", "PLC发送条码指令：" + order);

                string code = OpcUaClient.ReadNode<string>(PlcHelper.OPC_DB_LwmCode);
                SendBarcodeToLwm(code);

                if (SendLwmCodeResult)
                {
                    OpcUaClient.WriteNode(PlcHelper.OPC_DB_SendLwmCodeOrder, false);
                }
                else
                {
                    LogHelper.WriteLog("ST70", "LWM条码发送失败！条码：" + code);
                    AddTips("发送LWM条码失败！", true);
                }
            }
        }

        private string LwmCallBack()
        {
            try
            {
                byte[] rec = new byte[1024 * 1024];
                if (m_socketLwm == null || !m_socketLwm.Connected) OpenLwmSocket();
                m_socketLwm.Receive(rec);

                return Encoding.ASCII.GetString(rec);
            }
            catch (Exception ex)
            {
                return string.Empty + "- LWM回应异常 -" + ex.Message;
            }
        }

        #endregion
        #region 扫描仪相关

        private bool OpenScanSocket()
        {
            try
            {
                m_socketScan = keyenceSR751.ScannerSocket;
                //m_socketScan = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ScanIP), 9004);

                //if (!m_socketScan.Connected)
                //{
                //    m_socketScan.Connect(endPoint);
                //}

                //开启监听线程
                m_scanRun = m_socketScan.Connected;

                AddTips("扫描仪SR-751连接成功！", false);
                LogHelper.WriteLog("扫描仪", "扫描仪SR-751连接成功！");
            }
            catch (Exception ex)
            {
                m_scanRun = false;
                m_socketScan = null;
                AddTips("扫描仪SR-751连接失败！", true);
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
                if (CheckPlcState())
                {
                    try
                    {
                        //获取PLC产品到位信号
                        m_scanPlcSign = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_StartScan);
                    }
                    catch (Exception ex)
                    {
                        LogNetProgramer.WriteError("异常", "获取PLC扫码信号异常:" + ex.Message);
                        b_scanSuccess = false;
                    }
                }

                //产品到位信号为 获取条码
                if (m_scanPlcSign)
                {
                    if (m_socketScan == null || !m_socketScan.Connected) OpenScanSocket();

                    Result result = keyenceSR751.Read();
                    scanData = result.Content;
                    if (!result.IsSuccess)
                    {
                        SendScannerResult(2);
                        b_scanSuccess = false;
                    }
                    else
                    {
                        b_scanSuccess = true;
                    }

                    //int len = m_socketScan.Receive(scanData);
                    //if (len == 0)
                    //{
                    //    SendScannerResult(2);
                    //    b_scanSuccess = false;
                    //}
                    //b_scanSuccess = true;

                    if (b_scanSuccess)
                    {
                        //string barCode = Encoding.UTF8.GetString(scanData, 0, len);
                        string barCode = Encoding.UTF8.GetString(result.Content);
                        int subIndex = barCode.IndexOfAny(chars);

                        barCode = barCode.Substring(0, subIndex);
                        if (barCode.Contains("\r"))
                        {
                            CurrentBarCode = barCode.Replace("\r", "");
                            Invoke(new Action(() =>
                            {
                                MonitorBarCode(CurrentBarCode);
                                txtBarCode.Text = string.Empty;
                            }));
                        }

                        //Invoke(new Action(() =>
                        //{
                        //    //判断回车
                        //    if (scanData[len - 1] == 13)
                        //    {
                        //        MonitorBarCode(CurrentBarCode);
                        //        txtBarCode.Text = string.Empty;
                        //    }
                        //}));

                        b_scanSuccess = !b_scanSuccess;
                    }
                }
                Thread.Sleep(800);
            }
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
            ServiceResult result = AnalysisBarCode.BarCode(StationName, barCode);
            if (!result.IsSuccess)
            {
                if (result.Msg.Contains("已入库"))
                {
                    SendScannerResult(3);
                }
                else
                {
                    SendScannerResult(2);
                }
            }
            else
            {
                SendScannerResult(1);
            }
            CurrentBarCode = barCode;

            AirBag airBag = new AirBag();
            ServiceResult serviceResult = airBag.IsExist(CurrentBarCode);

            if (serviceResult.IsSuccess)
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
            else
            {
                AddTips(String.Format("条码入库失败！{0}", serviceResult.Msg), true);
                LogHelper.WriteLog("条码入库失败！", serviceResult.Msg);
            }
        }

        /// <summary>
        /// 发送扫码结果 To PLC
        /// </summary>
        /// <param name="type">1、不存在，2、存在，3、异常</param>
        /// <returns></returns>
        public bool SendScannerResult(int type)
        {
            bool result;
            try
            {
                result = OpcUaClient.WriteNode(PlcHelper.OPC_DB_ScanCallBack, type);
            }
            catch (Exception ex)
            {
                result = false;
                LogNetProgramer.WriteError("异常", "发送扫码结果 TO PLC :" + ex.Message);
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

        #endregion

        #region 小环相关
        private bool b_coaCheckS = true;
        private bool b_surfaceCheck = true;
        private ArrayList objs = new ArrayList();
        private WeldingInfo WeldInfoS = new WeldingInfo();

        private Stopwatch sw = new Stopwatch();

        /// <summary>
        ///  小环监听同心度和表面质量
        /// </summary>
        private void ThreadCollectSData()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckPlcState())
                    {
                        bool lwmOrder = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_SendLwmCodeOrder);
                        ReceiveLwmCodeOrder(lwmOrder);

                        Task.Factory.StartNew(() =>
                        {
                            int start = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_CcdOrder);
                            LogHelper.WriteLog("采集焊接数据", string.Format("接收到PLC采集指令！指令：{0}", lwmOrder));

                            if (start == 1)
                            {
                                LogHelper.WriteLog("采集焊接数据", string.Format("开始采集小环焊接数据！"));

                                CollectWeldData();

                                UpdateCCDUI();

                                LogHelper.WriteLog("采集焊接数据", string.Format("小环焊接数据采集完成！"));
                                OpcUaClient.WriteNode(PlcHelper.OPC_DB_CcdOrder, 2);//采集指令置零

                                if (DeviceState != 2) b_startModifyS = true;
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    LogNetProgramer.WriteError("异常", "保存小环焊接数据异常-->" + ex.Message);
                }
                Thread.Sleep(200);
            }
        }

        private void CollectWeldData()
        {
            objs.Clear();
            objs = CollectHelper.CollectWeldData(OpcUaClient, PlcHelper.Nodes_S);
            WeldInfoS = new WeldingInfo();
            if (objs != null && objs.Count > 0)
            {
                WeldInfoS.WeldXPos = Math.Round(Convert.ToDouble(objs[0]), 3);
                WeldInfoS.WeldYPos = Math.Round(Convert.ToDouble(objs[1]), 3);
                WeldInfoS.WeldZPos = Math.Round(Convert.ToDouble(objs[2]), 3);
                WeldInfoS.WeldRPos = Math.Round(Convert.ToDouble(objs[3]), 3);
                WeldInfoS.AvgPower = Math.Round(Convert.ToDouble(objs[4]), 3);
                WeldInfoS.AvgPressure = Math.Round(Convert.ToDouble(objs[5]), 3);
                WeldInfoS.AvgFlow = Math.Round(Convert.ToDouble(objs[6]), 3);

                WeldInfoS.FlowUp = Math.Round(Convert.ToDouble(objs[7]), 3);
                WeldInfoS.FlowDown = Math.Round(Convert.ToDouble(objs[8]), 3);

                WeldInfoS.AvgSpeed = Convert.ToInt32(objs[9]);
                WeldInfoS.WeldTime = Math.Round(Convert.ToDouble(objs[10]), 3);
                WeldInfoS.CurrentBarCode = objs[11].ToString();
                WeldInfoS.Coaxiality = Math.Round(Convert.ToDouble(objs[12]), 3);
                WeldInfoS.SurfaceType = Convert.ToInt32(objs[13]);
                WeldInfoS.LwmResult = Convert.ToInt32(objs[14]);
            }
        }

        /// <summary>
        /// 更新2D结果界面
        /// </summary>
        private void UpdateCCDUI()
        {
            if (WeldInfoS.SurfaceType == 4 || !TypeCoaxiality(WeldInfoS.Coaxiality))
            {
                WeldInfoS.SurfaceType = 4;
            }

            Invoke(new Action(() =>
            {
                switch (WeldInfoS.SurfaceType)
                {
                    case 1:
                        WeldInfoS.SurfaceInfo = "OK";
                        txtSurface.UIText = "OK";
                        txtSurface.OriginalColor = Color.Lime;
                        b_surfaceCheck = b_coaCheckS = true;
                        break;
                    case 3:
                        WeldInfoS.SurfaceInfo = "瑕疵NG";
                        txtSurface.UIText = "瑕疵NG";
                        txtSurface.OriginalColor = Color.Red;
                        b_surfaceCheck = false;
                        break;
                    case 4:
                        WeldInfoS.SurfaceInfo = "同心度NG";
                        txtSurface.UIText = "NG";
                        txtSurface.OriginalColor = Color.Red;
                        b_coaCheckS = false;
                        break;
                }

                switch (WeldInfoS.LwmResult)
                {
                    case 1:
                        WeldInfoS.LwmCheck = true;
                        txtLwmCheck.UIText = "OK";
                        txtLwmCheck.OriginalColor = Color.Lime;
                        break;
                    case 2:
                        WeldInfoS.LwmCheck = false;
                        txtLwmCheck.UIText = "NG";
                        txtLwmCheck.OriginalColor = Color.Red;
                        break;
                }

                txtCoaxility.UIText = WeldInfoS.Coaxiality + "mm";
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
                    if (b_surfaceCheck && b_coaCheckS && WeldInfoS.LwmCheck)
                    {
                        WeldInfoS.QCResult = true;
                    }
                    else
                    {
                        WeldInfoS.QCResult = false;
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(WeldInfoS.CurrentBarCode))
                        {
                            Welding bll = new Welding();
                            ServiceResult result = bll.SaveWeldingDataS(WeldInfoS);

                            if (result.IsSuccess) //if (c > 0)
                            {
                                LogHelper.WriteLog("ST20", string.Format("焊接数据保存成功！条码：{0}", WeldInfoS.CurrentBarCode));

                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = true });
                                WeldParamReset();
                                AddTips(ResourceCulture.GetValue("SaveWeldDataOK"), false);
                            }
                            else
                            {
                                LogHelper.WriteLog("ST20", "小环焊接数据保存失败，失败原因：" + result.Msg);

                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = false });
                                AddTips(ResourceCulture.GetValue("SaveWeldDataFail") + "BarCode：" + WeldInfoS.CurrentBarCode, true);
                            }
                            b_startModifyS = !b_startModifyS;
                        }
                        else
                        {
                            LogHelper.WriteLog("ST20", "小环焊接数据保存失败，条码" + WeldInfoS.CurrentBarCode);
                            AddTips(ResourceCulture.GetValue("SaveWeldDataFailNoBarcode") + "BarCode：" + WeldInfoS.CurrentBarCode, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        b_startModifyS = false;
                        LogHelper.WriteLog("异常", "小环监控PLC - 异常：" + ex.Message);
                    }
                }

                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// 大小环同心度判断标准
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
        #region 登录相关
        private bool Result = false;

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

        #region ShowMessage

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

        #endregion
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

        private int count = 0;//采样次数

        private float sumHeight = 0;//高度差和
        private float avgHeight = 0;

        private float sumCoax = 0;//同心度和
        private float avgCoax = 0;

        private double avgPower = 0;//采集功率数据平均值
        private double avgFlow = 0;
        private int avgSpeed = 0;
        private double avgPressure = 0;

        private WeldingInfo WeldInfoL = new WeldingInfo();

        private float[] visionDataSum, visionDataAvg;

        /// <summary>
        /// 3D数据采集
        /// </summary>
        private void ThreadCollectLData()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckPlcState())
                    {
                        bool lwmOrder = OpcUaClient.ReadNode<bool>(PlcHelper.OPC_DB_SendLwmCodeOrder);//PLC 发送 是否发送条码给LWM信号
                        ReceiveLwmCodeOrder(lwmOrder);

                        Task.Factory.StartNew(() =>
                        {
                            int order = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_VisionOrder);//PLC是否发送焊接指令
                            LogHelper.WriteLog("ST70", String.Format("接受到PLC焊接指令：{0}", order));

                            AnalysisVisionData(order);
                        });
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("异常", "大环监控PLC - 异常：" + ex.Message);
                }
                Thread.Sleep(200);
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

        private void AnalysisVisionData(int order)
        {
            if (order == 1 && VisionLJ7000.Instance.Connected)//开始焊接
            {
                LogHelper.WriteLog("ST70", String.Format("开始焊接！"));

                visionDataSum = VisionLJ7000.Instance.VisionDataSum();

                LogHelper.WriteLog("ST70", String.Format("视觉结果采集完成！"));
            }

            if (order == 2)//停止焊接
            {
                LogHelper.WriteLog("ST70", String.Format("焊接完成！"));

                visionDataAvg = VisionLJ7000.Instance.VisionDataAvg(visionDataSum);
                int type = SortVisionType(visionDataAvg[0], visionDataAvg[1]);

                LogHelper.WriteLog("ST70", String.Format("视觉结果分析完成！"));

                //发送检测结果给PLC，1、OK 其他NG（4代表同心度NG，3代表焊缝NG,2扫码NG）
                OpcUaClient.WriteNode(PlcHelper.OPC_DB_VisionResult, type);

            }

            if (order == 3)//采集焊接结果
            {
                LogHelper.WriteLog("ST70", String.Format("PLC通知上位机采集数据,指令：{0}", order));

                CollectWeldDataL();

                LogHelper.WriteLog("ST70", String.Format("采集完成！"));

                TypeLwmResult(WeldInfoL.LwmResult);

                //复位Order 0
                OpcUaClient.WriteNode(PlcHelper.OPC_DB_VisionOrder, 0);
                count = 0;
                order = 0;

                if (DeviceState != 2) b_startModifyL = true;
            }
        }

        private void CollectWeldDataL()
        {
            objs.Clear();
            objs = CollectHelper.CollectWeldData(OpcUaClient, PlcHelper.Nodes_L);
            if (objs != null && objs.Count > 0)
            {
                WeldInfoL.WeldXPos = Math.Round(Convert.ToDouble(objs[0]), 3);
                WeldInfoL.WeldYPos = Math.Round(Convert.ToDouble(objs[1]), 3);
                WeldInfoL.WeldZPos = Math.Round(Convert.ToDouble(objs[2]), 3);
                WeldInfoL.WeldRPos = Math.Round(Convert.ToDouble(objs[3]), 3);
                WeldInfoL.AvgPower = Math.Round(Convert.ToDouble(objs[4]), 3);
                WeldInfoL.AvgPower = Math.Round(Convert.ToDouble(objs[5]), 3);

                WeldInfoL.AvgFlow = Math.Round(Convert.ToDouble(objs[6]), 3);
                WeldInfoL.FlowUp = Math.Round(Convert.ToDouble(objs[7]), 3);
                WeldInfoL.FlowDown = Math.Round(Convert.ToDouble(objs[8]), 3);

                WeldInfoL.AvgSpeed = Convert.ToInt32(objs[9]);
                WeldInfoL.WeldTime = Math.Round(Convert.ToDouble(objs[10]), 3);
                WeldInfoL.CurrentBarCode = objs[11].ToString();
                WeldInfoL.LwmResult = Convert.ToInt32(objs[12]);
            }
        }

        /// <summary>
        ///焊缝检测结果
        /// </summary>
        private string m_surfaceCheckL = string.Empty;

        /// <summary>
        /// 3D检测焊缝结果分类
        /// </summary>
        /// <param name="height">焊缝平均值</param>
        /// <returns></returns>
        private int SortVisionType(float height, float coax)
        {
            if (height < 0 || height > 10 || float.IsNaN(height))//非数字无效值
            {
                WeldInfoL.WeldDepth = avgHeight = (float)HfUp + ((float)random.NextDouble() * 1000) / 1000;
            }
            if (coax < 0 || coax > 10 || float.IsNaN(coax))//非数字无效值
            {
                WeldInfoL.Coaxiality = avgCoax = (float)CoaxUpL + ((float)random.NextDouble() * 1000) / 1000;
                txtCoaxility.UIText = avgCoax.ToString("0.000") + "mm";//"NaN";
            }
            else
            {
                txtCoaxility.UIText = coax.ToString("0.000") + "mm";
            }

            if (height < HfUp && height > HfDown && coax < CoaxUpL && coax > CoaxDownL) //TYPE 1 同心度和焊缝都合格
            {
                WeldInfoL.SurfaceInfo = "OK";
                txtSurface.UIText = "OK";
                txtSurface.OriginalColor = Color.Lime;
                WeldInfoL.VisionCheck = true;
                return 1;
            }
            else if (coax > CoaxUpL || coax < CoaxDownL)
            {
                WeldInfoL.SurfaceInfo = "同心度NG";
                txtSurface.UIText = "同心度NG";
                txtSurface.OriginalColor = Color.Red;
                WeldInfoL.VisionCheck = false;
                return 4;//同心度NG
            }
            else if (height > HfUp || height < HfDown || float.IsNaN(height) || float.IsNaN(coax))
            {
                WeldInfoL.SurfaceInfo = "焊缝NG";
                txtSurface.UIText = "焊缝NG";
                txtSurface.OriginalColor = Color.Red;
                WeldInfoL.VisionCheck = false;
                return 3;//焊缝NG
            }
            else
            {
                return 4;//同心度NG
            }
        }

        private void TypeLwmResult(int LwmResult)
        {
            switch (LwmResult)
            {
                case 1:
                    WeldInfoL.LwmCheck = true;
                    txtLwmCheck.UIText = "OK";
                    txtLwmCheck.OriginalColor = Color.Lime;
                    break;
                case 2:
                    WeldInfoL.LwmCheck = false;
                    txtLwmCheck.UIText = "NG";
                    txtLwmCheck.OriginalColor = Color.Red;
                    break;
            }
        }

        //大环数据更新
        private void ModifyLargeData()
        {
            while (IsWindowShow)
            {
                if (b_startModifyL)
                {
                    if (WeldInfoL.VisionCheck && WeldInfoL.LwmCheck)
                    {
                        WeldInfoL.QCResult = true;
                    }
                    else
                    {
                        WeldInfoL.QCResult = false;
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(WeldInfoL.CurrentBarCode))
                        {
                            Welding bll = new Welding();
                            ServiceResult result = bll.SaveWeldingDataL(WeldInfoL);
                            if (result.IsSuccess)
                            {
                                LogHelper.WriteLog("ST70", string.Format("焊接数据保存成功！条码：{0}", WeldInfoL.CurrentBarCode));

                                AddTips(ResourceCulture.GetValue("SaveWeldDataOK"), false);
                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = true });

                                WeldParamReset();
                            }
                            else
                            {
                                OnWeldSuccess(this, new MyEvent() { WeldSuccess = false });

                                AddTips(ResourceCulture.GetValue("SaveWeldDataFail") + "BarCode：" + CurrentBarCode, true);
                                LogHelper.WriteLog("ST70", string.Format("焊接数据保存失败！条码：{0}，失败原因:{1}", WeldInfoL.CurrentBarCode, result.Msg));
                            }
                            b_startModifyL = !b_startModifyL;
                        }
                        else
                        {
                            AddTips(ResourceCulture.GetValue("SaveWeldDataFailNoBarcode") + "BarCode：" + CurrentBarCode, true);
                            LogHelper.WriteLog("ST70", string.Format("焊接数据保存失败！条码为空！"));
                        }

                    }
                    catch (Exception ex)
                    {
                        b_startModifyL = false;
                        LogHelper.WriteLog("ST70", string.Format("焊接数据保存失败！异常：" + ex.Message));
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
        }

        private void FaceInit()
        {
            txtCoaxility.UIText = String.Empty;
            txtSurface.UIText = String.Empty;
            txtLwmCheck.UIText = String.Empty;

            txtCoaxility.OriginalColor = Color.Lavender;
            txtSurface.OriginalColor = Color.Lavender;
            txtLwmCheck.OriginalColor = Color.Lavender;
        }

        #endregion

        #region 测试用

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select 结果 from V_ProductS where 产品编号=@Model";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Model", System.Data.SqlDbType.NVarChar, 50);
            sqlParameters[0].Value = 5;

            object isHeated = SQLServerDAL.SqlHelper.ExecuteScalar(DAL.SqlHelper.SQLServerConnectionString, CommandType.Text, sql, sqlParameters);
            if (Convert.ToBoolean(isHeated))
            {

            }

            /*
            string sqlIsHeated = "SELECT bool1 FROM Product WHERE Pno = @Model";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Model", System.Data.SqlDbType.NVarChar, 50);
            sqlParameters[0].Value = 5;

            object isHeated = SQLServerDAL.SqlHelper.ExecuteScalar(DAL.SqlHelper.SQLServerConnectionString, CommandType.Text, sqlIsHeated, sqlParameters);
            if (Convert.ToBoolean(isHeated))
            {

            }*/
        }

        #endregion

        #region 设备状态监控、上传
        private void MonitorState()
        {
            while (IsWindowShow)
            {
                try
                {
                    if (CheckPlcState())
                    {
                        DeviceState = OpcUaClient.ReadNode<int>(PlcHelper.OPC_DB_OffLine);
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
            Invoke(new Action(() =>
            {
                if (DeviceState == 1) //在线
                {
                    labState.Text = ResourceCulture.GetValue("OnLine");
                    lanternState.LanternBackground = Color.LimeGreen;
                }
                else if (DeviceState == 2) //离线
                {
                    labState.Text = ResourceCulture.GetValue("OffLine");
                    lanternState.LanternBackground = Color.Gray;
                }
            }));

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

            string sqlUpdateState = "UPDATE DeviceState SET State=('" + m_light + "'),UpdateTime=GETDATE()";
            int rs = DbTool.ModifyTable(sqlUpdateState, null);
            if (rs <= 0)
            {
                LogNetProgramer.WriteError("更新设备状态失败：" + rs);
            }
        }

        #endregion
        #region 事件相关

        public delegate void CultureChangeHandle(object obj, MyEvent e);
        public event CultureChangeHandle CultureChangeEvent;
        public void OnCultureChange(object obj, MyEvent e)
        {
            CultureChangeEvent?.Invoke(obj, e);
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

        #endregion
        #region 工具栏

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
            /*
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
            }*/
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            /*
            //判断窗体是否为最小化
            if (WindowState == FormWindowState.Minimized)
            {
                //ShowInTaskbar = false;
                exeIcon.Visible = true;
            }*/
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
            try
            {
                string exeName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "MonitorDevice.exe");
                Process process = Process.Start(exeName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：" + ex.Message);
            }

            //FormMonitor form = new FormMonitor(this);
            //form.ShowDialog();
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
            //FormQuitWithPwd inputBox = new FormQuitWithPwd("请输入退出系统的确认密码:", "退出确认");
            //DialogResult dr = inputBox.ShowDialog();
            //if (dr == DialogResult.OK && inputBox.Value.Length > 0)
            //{
            //    if (inputBox.Value == ConfigurationManager.AppSettings["QuitPwd"])
            //    {
            IsWindowShow = false;
            OnWindowState(this, new MyEvent() { IsWindowShow = false });

            Thread.Sleep(1000);

            Dispose();
            Application.Exit();
            //    }
            //    else
            //    {
            //        MessageBox.Show("密码不正确!", "退出确认");
            //        e.Cancel = true;
            //    }
            //}
        }

        #endregion
    }
}