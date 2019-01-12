using MES;
using MES.DAL;
using OpcUaHelper;
using ProductManage.Lwm;
using ProductManage.Scanner;
using ProductManage.Vision;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
            CheckPlcState();
            CheckLwmState();
            CheckScanState();
            if (!IsStation_S) CheckVisionState();
        }

        public bool CheckVisionState()
        {
            if (VisionLJ7000.Instance.OpenVision())
            {
                lanVisionState.LanternBackground = Color.Gray;
                return false;
            }
            lanVisionState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckScanState()
        {
            KeyenceSR751.Ip = main.ScanIP;
            KeyenceSR751.Port = 9004;
            if (!KeyenceSR751.GetInstance().Open())
            {
                lanScanState.LanternBackground = Color.Gray;
                return false;
            }
            lanScanState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckLwmState()
        {
            if (!LwmHelper.GetInstance().Open())
            {
                lanLwmState.LanternBackground = Color.Gray;
                return false;
            }
            lanLwmState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckDbState()
        {
            if (!DBHelper.Instance.Open())
            {
                lanDbState.LanternBackground = Color.Gray;
                return false;
            }
            lanDbState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckPlcState()
        {
            if (!main.CheckPlcState())
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
            LwmHelper.GetInstance().SafeClose(LwmHelper.GetInstance().LwmSocket);
            KeyenceSR751.GetInstance().SafeClose(KeyenceSR751.GetInstance().ScanSocket);
            Dispose();
            Close();
        }
    }
}
