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
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using MES.UserControls;
using MES.Vision;
using OpcUaHelper;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using Timer = System.Windows.Forms.Timer;
using System.Net.Sockets;
using System.Net;

namespace MES
{
    /// <summary>
    /// 工艺流程
    /// 上料-> 扫码 ->焊接->清洁->同心度检测(视觉)->表面质量检测(视觉)->更新数据库->下料
    /// </summary>
    public partial class FormMain : Form
    {
        public string StationName = "S";

        private bool IsStation_S = true;

        public DBTool DbTool = new DBTool();

        public List<Product> ListProducts;

        public DataTable ProductsTable;

        public DataTable UsersTable;

        private int Self_Checek_Interval = 1;//间隔小时时间提醒质检

        private bool ifStartCheck = false;//提醒检测后是否执行检测

        private Product m_curProduct;

        private Product m_ngProduct;

        private string m_selectAllProducts = "Select * from Product";

        private string m_selectAllUsers = "Select ID,Name,Password,Auth from Users";

        public ILogNet LogNetUser;//用户日志

        public ILogNet LogNetProgramer;//程序日志

        public SiemensS7Net m_siemensTcpNet = null;

        public OpcUaClient OpcUaClient;

        private SoftAuthorize m_softAuthorize = null;

        private Timer m_selfCheckTimer;

        private string BarCode = String.Empty;

        public byte[] VisionPath = new byte[] { 192, 168, 0, 89 };//3D视觉URL

        public string OPCServiceURL = "opc.tcp://192.168.0.85:4840";//OPC URL

        public string ProgramerLogPath = Application.StartupPath + @"\Log\log.txt";//程序日志地址

        public string UserLogPath = Application.StartupPath + @"\UserLog.txt";//用户日志地址

        #region OPC地址相关

        private string s_coaxilitySign = "ns=3;s=\"WeldPara\".\"Coaxiality\"";//同心度

        private string s_surfaceSign = "ns=3;s=\"WeldPara\".\"Surface\"";//表面质量

        private string s_stateSign = "ns=3;s=\"WeldPara\".\"DeviceState\"";//设备状态

        private string s_visionSign = "ns=3;s=\"WeldPara\".\"VisionResult\"";//3D检测结果

        private string s_offLine = "ns=3;s=\"WeldPara\".\"OffLine\"";//离线功能 1：打开，2：关闭

        private string s_warnCheck = "ns=3;s=\"WeldPara\".\"WarnCheck\"";//提醒检测1：提醒，2：关闭 

        private string s_warmSign = "ns=3;s=\"WeldPara\".\"WarmSign\"";//报警信号

        private string s_dataCheckBack = "ns=3;s=\"WeldPara\".\"DataCheckBack\"";//扫码后反馈信号，1：存在，2:不存在

        #endregion

        private int m_scanErrorCount = 0;//扫码错误次数记录

        private bool m_mainThreadState = false;//核心线程运行状态

        private Thread m_mainThread;//核心线程

        private int m_collectInterval = 500;//3D相机采样周期

        private SelfCheckWarmForm selfCheckWarmForm = null;//提醒检测窗体

        public delegate void BarCodeChangeHandle(MyEvent e);

        public event BarCodeChangeHandle BarCodeChange;

        public void OnBarCodeChange(MyEvent e)
        {
            BarCodeChange?.Invoke(e);
        }

        private Thread t_change = null;

        private Socket m_socketScan = null;

        private IPEndPoint endPoint = null;

        private bool m_scanRun = false;

        public FormMain()
        {
            InitializeComponent();

            StationName = AppSetting.GetStationName();
            IsStation_S = StationName.Equals("S");
            Text += "  [ Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ]";

            //设定按字体来缩放控件  
            this.AutoScaleMode = AutoScaleMode.Font;
            //设定字体大小为12px       
            this.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(134)));

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //程序验证注册码
            //CheckSoftAuthorize();

            //初始化程序日志
            LogNetProgramer = new LogNetSingle(ProgramerLogPath);

            //初始化用户日志
            LogNetUser = new LogNetSingle(UserLogPath);

            //初始化扫描枪
            //InitSocket();

            //初始化PLC通讯
            //InitPLCCommunication();

            //初始化页面布局
            InitalizalForm();

            //打开视觉网络连接
            OpenEthernet();

            m_socketScan = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(IPAddress.Parse(AppSetting.GetScanIP()), 
                int.Parse(AppSetting.GetScanPort()));

            //检测数据库连接状态
            CheckDbConnected();

            //核心线程
            m_mainThread = new Thread(StartMainThread);
            m_mainThread.IsBackground = true;
            m_mainThreadState = true;
            m_mainThread.Start();

            //控件焦点自动切换
            t_change = new Thread(ChangeActiveControl);
            t_change.IsBackground = true;
            t_change.Start();

            //视觉通讯线程
            Thread tVisionThread = new Thread(VisionDataCollect);
            tVisionThread.IsBackground = true;
            //tVisionThread.Start();

            //初始化检测提醒功能
            InitWarnCheck();

        }

        private void InitSocket()
        {
            try
            {
                if (!m_socketScan.Connected)
                {
                    m_socketScan.Connect(endPoint);
                }

                m_scanRun = true;

                LogNetProgramer.WriteInfo("连接扫描枪成功！");
                AddTips("连接扫描枪成功！");
            }
            catch (Exception ex)
            {
                LogNetProgramer.WriteDebug("异常：" + ex.StackTrace + "--->" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void Test()
        {
            XmlHelper.ModuleName = "测试模板2";

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("焊接功率", 999.ToString());
            dic.Add("焊接流量", 555.ToString());

            bool result = XmlHelper.SaveModuleFile(dic);

            XmlHelper.ModuleName = "测试模板1";

            dic = XmlHelper.LoadModuleFile();

            if (result)
            {
                Debug.WriteLine("保存成功");
            }
            else
            {
                Debug.WriteLine("保存失败");
            }

        }

        //开启核心线程
        private void StartMainThread()
        {
            while (m_mainThreadState)
            {
                //一直接受扫描枪数据
                if (m_scanRun)
                {
                    byte[] data = new byte[1024 * 2];

                    int len = m_socketScan.Receive(data);
                    if (len == 0) break;

                    string barCode = Encoding.UTF8.GetString(data, 0, len);

                    LogNetProgramer.WriteInfo("条码", barCode);

                    barCode = barCode.Remove(len - 1);

                    Invoke(new Action(() =>
                    {
                        txtFirstScan.Text = barCode;

                        if (data[len - 1] == 13)
                        {
                            MonitorBarCode(barCode);
                        }

                    }));
                }

                //MonitorCoaSurface();

                //MonitorWarmSign();
            }
        }

        //监听报警信号
        private void MonitorWarmSign()
        {
            //1：红灯亮，2：绿灯亮，3：其他灯色
            int backSign = OpcUaClient.ReadNode<int>(s_warmSign);

            if (backSign != 1)//不是红灯
            {
                if (m_failed > 3 || m_scanErrorCount > 2)
                {
                    //发送报警信号
                    //SendWarmSign();
                }
                else
                {
                    AddTips("");
                }
            }
            else//其他灯
            {
                AddTips("WarmSign-->" + backSign);
                LogNetProgramer.WriteInfo("WarmSign", backSign + "");
            }
        }

        /// <summary>
        ///  监听同心度和表面质量
        /// </summary>
        private void MonitorCoaSurface()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    labCoaxility.Text = OpcUaClient.ReadNode<double>(s_coaxilitySign).ToString();
                    labSurface.Text = OpcUaClient.ReadNode<string>(s_surfaceSign);

                }));
            }
            catch (Exception ex)
            {
                LogNetProgramer.WriteError("异常", ex.Message);
            }
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
            m_selfCheckTimer.Interval = Self_Checek_Interval * 1000;// * 3600;
            m_selfCheckTimer.Tick += new EventHandler(SelfeCheck_Tick);
            m_selfCheckTimer.Enabled = true;
        }

        /// <summary>
        /// 定时切换控件焦点
        /// </summary>
        private void ChangeActiveControl()
        {
            while (true)
            {
                Thread.Sleep(9000);

                Invoke(new Action(() =>
                {
                    ActiveControl = txtFirstScan;
                }));
            }
        }

        private void SelfeCheck_Tick(object sender, EventArgs e)
        {
            //报警器提醒检测
            //OpcUaClient.WriteNode<int>(s_warnCheck, 1);

            //窗口提醒检测
            //selfCheckWarmForm = new SelfCheckWarmForm(this);
            //selfCheckWarmForm?.Show();
        }

        /// <summary>
        /// 初始化PLC通讯
        /// </summary>
        private void InitPLCCommunication()
        {
            //实例化一个西门子对象
            //m_siemensTcpNet = new SiemensS7Net(SiemensPLCS.S1500);
            //m_siemensTcpNet.IpAddress = AppSetting.GetPLCIP();

            //实例化一个OPC客户端对象
            OPCServiceURL = AppSetting.GetOPCAddress();
            OpcUaClient = new OpcUaClient();
            try
            {
                OpcUaClient.ConnectServer(OPCServiceURL);

            }
            catch (Exception ex)
            {
                MessageBox.Show("OPC服务器连接失败：" + ex.Message);
                LogNetProgramer.WriteError("OPC服务器连接失败：" + ex.Message);
            }
        }

        #region 用户控件相关

        private CollectingSystem collecting;

        private TraceSystem traceSystem;

        private LogSystemControl logSystem;

        #endregion

        /// <summary>
        ///加载用户控件
        /// </summary>
        private void InitalizalForm()
        {
            ActiveControl = txtFirstScan;

            collecting = new CollectingSystem(this);
            collecting.Dock = DockStyle.Fill;

            traceSystem = new TraceSystem(this);
            traceSystem.Dock = DockStyle.Fill;

            logSystem = new LogSystemControl(this);
            logSystem.Dock = DockStyle.Fill;

            panelBox.Controls.AddRange(new Control[] { collecting, traceSystem, logSystem });

        }

        /// <summary>
        /// 检测软件是否授权
        /// </summary>
        private void CheckSoftAuthorize()
        {
            m_softAuthorize = new SoftAuthorize();

            //方式一
            m_softAuthorize.FileSavePath = Application.StartupPath + @"\Authorize.txt"; //存储激活码文件，存储加密
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

        //检测数据库是否连接正常
        public bool CheckDbConnected()
        {
            if (DbTool.m_sqlCon == null)
            {
                MessageBox.Show("数据库连接失败，请检查配置文件后重启软件！");
                LogNetProgramer.WriteError("异常", "数据库连接失败，请检查配置文件后重启软件！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 强行结束应用程序
        /// </summary>
        private static void KillExe()
        {
            Process[] excelProc = Process.GetProcessesByName("生产管理系统");
            DateTime startTime = new DateTime();
            int m, killId = 0;
            for (m = 0; m < excelProc.Length; m++)
            {
                if (startTime < excelProc[m].StartTime)
                {
                    startTime = excelProc[m].StartTime;
                    killId = m;
                }
            }
            if (excelProc[killId].HasExited == false)
            {
                excelProc[killId].Kill();
            }
        }

        /// <summary>
        /// 操作信息界面提示
        /// </summary>
        /// <param name="v"></param>
        public void AddTips(string v)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                toolTips.Text = "提示:" + v;
            }));
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
                if (IsStation_S)//小环（-0.3~0.3）
                {
                    if (pro.Coaxiality > 0.3 || pro.Coaxiality < -0.3)
                    {
                        pass = false;
                        LogNetProgramer.WriteInfo("小环同心度检测结果：NG，编号：" + pro.PNo + ",同心度：" + pro.Coaxiality);
                    }
                }
                else//大环（-0.15~0.2）
                {
                    if (pro.Coaxiality > 0.2 || pro.Coaxiality < -0.15)
                    {
                        pass = false;
                        LogNetProgramer.WriteInfo("大环同心度检测结果：NG，编号：" + pro.PNo + ",同心度：" + pro.Coaxiality);
                    }
                }

                if (!pass)
                {
                    AddTips("产品编号:" + pro.PNo + "，检测NG！");

                    //不合格，报警并停机...
                    //m_opcUaClient.WriteNode("ns=3;s=\"WeldPara\".\"CheckResult\"", 2);

                    m_ngProduct = pro;
                    return false;
                }
                else
                {
                    AddTips("检测结果：Pass，开始焊接！");

                    //合格开始焊接
                    //m_opcUaClient.WriteNode("ns=3;s=\"WeldPara\".\"CheckResult\"", 1);

                    m_curProduct = pro;
                }
            }
            else
            {
                //未检测到产品，报警并停机...
                //m_opcUaClient.WriteNode("ns=3;s=\"WeldPara\".\"CheckResult\"", 2);

                return false;
            }
            return true;
        }

        public delegate void UpdateIdDelegate(string id);

        public event UpdateIdDelegate UpdateIdCallBack;

        private Thread selfThread;

        private bool startCheck = true;

        //应用程序关闭
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("是否关闭应用程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (DialogResult.Yes == result)
            //{
            //    e.Cancel = false;
            m_mainThread?.Abort();
            t_change?.Abort();
            Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}

        }

        /// <summary>
        ///记录程序日志
        /// </summary>
        /// <param name="degree">日志等级</param>
        /// <param name="key">关键字</param>
        /// <param name="txt">日志内容</param>
        public void WriteLog(HslMessageDegree degree, string key, string txt)
        {
            LogNetProgramer.RecordMessage(degree, key, txt);
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
                MessageBox.Show("请登录后再执行此操作！");
                return false;
            }
            if (CurrentUser.Auth != "管理员")
            {
                MessageBox.Show("您的权限不够，请联系管理员！");
                return false;
            }
            return true;
        }

        public void LoginResult(object sender, MyEvent e)
        {
            Result = e.LoginResult;
            CurrentUser = e.LoginUser;
        }

        //维护中心
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

        private void ShowLogin()
        {
            LoginForm login = new LoginForm();
            login.LoginResult += LoginResult;
            login.ShowDialog();

            if (CurrentUser != null)
            {
                toolCurrentUser.Text = "当前用户：" + CurrentUser.Auth;

                if (CurrentUser.Auth == "管理员")
                {
                    //btnManualCheck.Visible = true;
                }
                else
                {
                    //btnManualCheck.Visible = false;
                }
            }

        }

        #region 报警系统模块

        private System.Windows.Forms.Timer timer = null;

        private int m_failed = 0;//连续异常三次则报警

        //定时器
        private void TimerInitialization()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            //timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///启动定时器： 发送报警/错误/异常等信号
        /// </summary>
        private void SendWarmSign()
        {
            //OpcUaClient.WriteNode(s_warmSign, 1);
        }

        #endregion

        private static Process process;

        //启动第三方exe
        public void StartExe()
        {
            if (process == null)
            {
                process = new Process();
                process.StartInfo.FileName = Application.StartupPath + @"\HuaTianProject.exe";//进程名称
                process.Start();
            }
            else
            {
                if (process.HasExited) //是否正在运行
                {
                    process.Start();
                }
            }

            /*
            //关闭第三方exe
            Process[] pProcess;
            pProcess = Process.GetProcesses();
            for (int i = 1; i <= pProcess.Length - 1; i++)
            {
                if (pProcess[i].ProcessName == "ZCLaser.exe") //任务管理器应用程序的名称
                {
                    pProcess[i].Kill();
                    break;
                }
            }*/

        }

        //第一次扫码
        private void txtFirstScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string barCode = txtFirstScan.Text.Trim();

            if (e.KeyChar == (char)Keys.Enter)
            {
                MonitorBarCode(barCode);
            }
        }

        private void MonitorBarCode(string barCode)
        {
            if (String.IsNullOrEmpty(barCode) || barCode.Length > 14)
            {
                m_scanErrorCount++;
                txtFirstScan.Text = String.Empty;
                AddTips("异常条码-->" + barCode);
                return;
            }

            if (barCode.Contains("ERROR") || barCode.Contains("error"))
            {
                m_scanErrorCount++;
                txtFirstScan.Text = String.Empty;
                AddTips("未识别到条码！" + m_scanErrorCount);
                return;
            }

            BarCode = barCode.Replace("ERROR", "");

            OnBarCodeChange(new MyEvent() { BarCode = BarCode });

            AddTips("条码-->" + BarCode);

            if (!Storage(barCode))
            {
                //若存在此产品，则执行检测操作
                SelfCheck(barCode);

                //AddTips("");
            }
            txtFirstScan.Text = String.Empty;

        }

        /// <summary>
        /// 第一次扫码：产品入库
        /// </summary>
        /// <param name="barCode">产品条码</param>
        public bool Storage(string barCode)
        {
            int exist = DbTool.IsExist(barCode);

            if (exist == 1)
            {
                //AddTips("此产品已入库！");
                return false;
            }
            else if (exist == 2)
            {
                m_scanErrorCount = m_failed++;
            }

            string sql = "insert into Product(PNo,StorageTime) Values('" + barCode + "','" + DateTime.Now + "')";
            int c = DbTool.ModifyTable(sql);
            if (c > 0)
            {
                //AddTips("入库成功！");1
            }
            else
            {
                AddTips(barCode + "入库失败！！");
            }
            return true;
        }

        //数据采集系统
        private void btnCollection_Click(object sender, EventArgs e)
        {
            collecting.Show();

            traceSystem.Hide();
            logSystem.Hide();

        }

        //追溯系统
        private void btnTraceSystem_Click(object sender, EventArgs e)
        {
            traceSystem.Show();

            collecting.Hide();
            logSystem.Hide();
        }

        //日志系统
        private void btnLogSystem_Click(object sender, EventArgs e)
        {

            logSystem.Show();

            collecting.Hide();
            traceSystem.Hide();
        }

        #region Vision

        public enum SendCommand
        {
            /// <summary>Get measurement results</summary>
            GetMeasurementValue,
            /// <summary>Get profiles</summary>
            GetProfile,
            /// <summary>Get batch profiles (operation mode "high-speed (profile only)")</summary>
            GetBatchProfile,
            /// <summary>Get profiles (operation mode "advanced (with OUT measurement)")</summary>
            GetProfileAdvance,
        }

        private SendCommand _sendCommand = SendCommand.GetMeasurementValue;

        private int _currentDeviceId;

        private List<MeasureData> _measureDatas = new List<MeasureData>();

        private DeviceData[] _deviceData = new DeviceData[NativeMethods.DeviceCount];

        private LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MeasurementDataCount];

        private float[] m_allDatas;//全部数据

        private float[] m_vaildDatas;//有效数据

        /// <summary>
        //获取3D采集数据
        /// </summary>
        public void VisionDataCollect()
        {
            //if (!OpenEthernet()) return;

            while (true)
            {
                Thread.Sleep(m_collectInterval);//采样周期

                int rc = NativeMethods.LJV7IF_GetMeasurementValue(_currentDeviceId, measureData);
                if (rc == (int)Rc.Ok)
                {
                    AddTips("GetMeasurementValue-->OK");
                    _measureDatas.Clear();
                    _measureDatas.Add(new MeasureData(0, measureData));

                    m_allDatas = new float[NativeMethods.MeasurementDataCount];
                    m_vaildDatas = new float[NativeMethods.MeasurementDataCount];

                    for (int i = 0; i < NativeMethods.MeasurementDataCount; i++)
                    {
                        Debug.Write(String.Format("  OUT{0:00}: {1}\r\n", (i + 1), Utility.ConvertToLogString(measureData[i]).ToString()));

                        m_allDatas[i] = measureData[i].fValue;

                        if (measureData[i].byDataInfo == (int)LJV7IF_MEASURE_DATA_INFO.LJV7IF_MEASURE_DATA_INFO_VALID
                            && measureData[i].byJudge == (int)LJV7IF_JUDGE_RESULT.LJV7IF_JUDGE_RESULT_GO)
                        {
                            m_vaildDatas[i] = measureData[i].fValue;
                        }
                    }

                    //网口发送
                    OpcUaClient.WriteNode(s_visionSign, m_vaildDatas[0]);

                    //串口发送
                    //SerialSend(vaildDatas[0]);

                }
                else
                {
                    AddTips("GetMeasurementValue-->ERROR");
                }
            }
        }

        /// <summary>
        /// 打开视觉通讯
        /// </summary>
        /// <returns></returns>
        private bool OpenEthernet()
        {
            for (int i = 0; i < NativeMethods.DeviceCount; i++)
            {
                _deviceData[i] = new DeviceData();
            }

            bool boo = false;
            //using (OpenEthernetForm openEthernetForm = new OpenEthernetForm())
            //{
            //    if (DialogResult.OK == openEthernetForm.ShowDialog())
            //    {
            LJV7IF_ETHERNET_CONFIG ethernetConfig = new LJV7IF_ETHERNET_CONFIG(); //= openEthernetForm.EthernetConfig;

            ethernetConfig.abyIpAddress = VisionPath;

            int rc = NativeMethods.LJV7IF_EthernetOpen(_currentDeviceId, ref ethernetConfig);
            if (rc == (int)Rc.Ok)
            {
                Debug.WriteLine("3D相机连接成功-->OK");
                _deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
                _deviceData[_currentDeviceId].EthernetConfig = ethernetConfig;
                boo = true;
            }
            else
            {
                AddTips("3D相机连接失败！-->ERROR");
                _deviceData[_currentDeviceId].Status = DeviceStatus.NoConnection;
            }
            //    }
            //}
            return boo;
        }

        #endregion

        #region 串口通讯

        private SerialPort m_serivalPort = null;// 串口初始化

        private string m_servialName = "COM1";//串口名称

        private int m_rate = 9600;//串口波特率

        private int m_bits = 8;//串口数据位长度

        //串口（串口属于IO口，苹果与水果的区别）发数据
        private void SerialSend(float vaildData)
        {
            m_serivalPort = new SerialPort();
            m_serivalPort.PortName = m_servialName;
            m_serivalPort.BaudRate = m_rate;
            m_serivalPort.DataBits = m_bits;
            m_serivalPort.StopBits = StopBits.One; //StopBits.None StopBits.Two;
            m_serivalPort.Parity = Parity.Odd;//Parity.None Parity.Even);

            m_serivalPort.DataReceived += SP_ReadData_DataReceived;
            m_serivalPort.Open();

            //发送数据
            byte[] send = null;

            //二进制发送
            //send = HslCommunication.BasicFramework.SoftBasic.HexStringToBytes(vaildData);
            send = new[] { Convert.ToByte(vaildData) };//普通发送

            m_serivalPort?.Write(send, 0, send.Length);

        }

        private void SP_ReadData_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 接收数据
            byte[] buffer = null;
            byte[] data = new byte[2048];
            int receiveCount = 0;
            while (true)
            {
                System.Threading.Thread.Sleep(20);
                int count = m_serivalPort.Read(data, receiveCount, m_serivalPort.BytesToRead);
                receiveCount += count;

                if (count == 0)
                {
                    buffer = new byte[receiveCount];
                    Array.Copy(data, 0, buffer, 0, receiveCount);
                    break;
                }
            }

            if (receiveCount == 0) return;

            Invoke(new Action(() =>
            {
                string msg = string.Empty;

                //二进制显示
                if (true)
                {
                    msg = HslCommunication.BasicFramework.SoftBasic.ByteToHexString(buffer, ' ');
                }
                else
                {
                    msg = Encoding.ASCII.GetString(buffer);
                }
                AddTips("串口接收的数据-->" + msg);

            }));
        }

        #endregion

        private void visionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VisionDataCollect();
            InitSocket();

        }

        private void 维护中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOmcs();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            toolCurrentUser.Text = "当前用户：";
        }

        private void 登录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        //改变设备状态
        private void btnStateChange_Click(object sender, EventArgs e)
        {
            bool success;
            try
            {
                /*
                int state = OpcUaClient.ReadNode<int>(s_stateSign);

                //离线
                if (state == 1)
                {
                    success = OpcUaClient.WriteNode(s_stateSign, 2);
                    if (success)
                    {
                        btnStateChange.UIText = "在线";
                        btnStateChange.OriginalColor = Color.Lime;
                    }
                }
                //在线
                else if (state == 2)
                {
                    success = OpcUaClient.WriteNode(s_stateSign, 1);
                    if (success)
                    {
                        btnStateChange.UIText = "离线";
                        btnStateChange.OriginalColor = Color.Gray;
                    }
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 模板配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WeldingModuleForm form = new WeldingModuleForm();
            form.ShowDialog();
        }
    }
}