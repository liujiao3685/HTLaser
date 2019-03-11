using MES;
using MES.DAL;
using ProductManage.Lwm;
using ProductManage.Scanner;
using ProductManage.Vision;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ProductManage.UI
{
    public partial class FormMonitor : Form
    {
        private FormMain main;

        private bool IsStation_S;

        private string OpcServiceUrl;

        public FormMonitor()
        {
            InitializeComponent();
        }

        public FormMonitor(FormMain main)
        {
            InitializeComponent();
            this.main = main;
            this.IsStation_S = main.IsStation_S;
            this.OpcServiceUrl = main.OpcServiceUrl;
        }

        private void FromMonitor_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            labTips.Text = "绿色：连接正常 ，灰色：连接失败，若连接失败请检查网络连接！\r\n" +
                "Lwm连接失败：请检查Lwm电脑客户端软件是否开启，并重启LWM客户端软件！";

            if (IsStation_S) labVision.Visible = lanVisionState.Visible = !IsStation_S;

            timerMonitor.Interval = 1000;
            timerMonitor.Tick += TimerMonitor_Tick;
            timerMonitor.Enabled = true;
        }

        private void TimerMonitor_Tick(object sender, EventArgs e)
        {
            CheckDbState();
            CheckLwmState();
            CheckScanState();
            CheckPlcState();
            if (!IsStation_S) CheckVisionState();
        }

        Stopwatch sw = new Stopwatch();
        public bool CheckVisionState()
        {
            sw.Restart();
            if (!VisionLJ7000.Instance.OpenVision())
            {
                lanVisionState.LanternBackground = Color.Gray;

                sw.Stop();
                Console.WriteLine("CheckVisionState：" + sw.Elapsed.ToString());
                sw.Reset();
                return false;
            }
            lanVisionState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckScanState()
        {
            sw.Restart();
            KeyenceSR751.IpAddress = main.ScanIP;
            if (main.m_socketScan == null || !main.m_socketScan.Connected)  //if (!KeyenceSR751.GetInstance().Open(20))
            {
                lanScanState.LanternBackground = Color.Gray;
                sw.Stop();
                Console.WriteLine("CheckScanState：" + sw.Elapsed.ToString());
                return false;
            }
            lanScanState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckLwmState()
        {
            if (!LwmHelper.GetInstance().Open(20))//if (!main.m_socketLwm.Connected)  
            {
                lanLwmState.LanternBackground = Color.Gray;
                return false;
            }
            lanLwmState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckDbState()
        {
            sw.Restart();
            if (!DBHelper.Instance.Open())
            {
                lanDbState.LanternBackground = Color.Gray;
                sw.Stop();
                Console.WriteLine("CheckDbState：" + sw.Elapsed.ToString());
                return false;
            }
            lanDbState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckPlcState()
        {
            if (main.OpcUaClient == null || !main.OpcUaClient.Connected)
            {
                lanPlcState.LanternBackground = Color.Gray;
                return false;
            }
            lanPlcState.LanternBackground = Color.LimeGreen;
            return true;
        }

        private void FormMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeAll();
        }

        private void DisposeAll()
        {
            Dispose();
            Close();
        }
    }
}
