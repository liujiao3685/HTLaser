using CommonLibrary.DB;
using CommonLibrary.Lwm;
using CommonLibrary.PLC;
using CommonLibrary.Scanner;
using CommonLibrary.Vision;
using MES.DAL;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace MonitorDevice
{
    public partial class FormMonitorForm : Form
    {
        private bool IsStation_S;

        public FormMonitorForm()
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings["StationName"].ToString() == "S")
            {
                IsStation_S = true;
            }
            else
            {
                IsStation_S = false;
            }
        }

        private void FormMonitor_Load(object sender, EventArgs e)
        {
            labTips.Text = "绿色：连接正常 ，灰色：连接失败，若连接失败请检查网络连接！\r\n" +
                "Lwm连接失败：请检查Lwm电脑客户端软件是否开启，并重启LWM客户端软件！";

            if (IsStation_S) labVision.Visible = lanVisionState.Visible = !IsStation_S;

            timerMonitor.Interval = 1500;
            timerMonitor.Tick += TimerMonitor_Tick;
            timerMonitor.Enabled = true;
        }

        private void TimerMonitor_Tick(object sender, EventArgs e)
        {
            CheckPlcState();
        }

        public bool CheckPlcState()
        {
            if (!PlcHelper.GetInstance().IsConnection())
            {
                lanPlcState.LanternBackground = Color.Gray;
                return false;
            }
            lanPlcState.LanternBackground = Color.LimeGreen;
            return true;
        }

        public bool CheckLwmState()
        {
            if (!LwmHelper.GetInstance().IsConn)
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

        public bool CheckVisionState()
        {
            if (!VisionLJ7000.Instance.OpenVision())
            {
                lanVisionState.LanternBackground = Color.Gray;
                return false;
            }
            lanVisionState.LanternBackground = Color.LimeGreen;
            return true;
        }


        public bool CheckScanState()
        {
            if (!KeyenceSR751.GetInstance().IsConn)
            {
                lanScanState.LanternBackground = Color.Gray;
                return false;
            }
            lanScanState.LanternBackground = Color.LimeGreen;
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

        private void timerDB_Tick(object sender, EventArgs e)
        {
            CheckDbState();
            //CheckSMDState();
        }

        public bool CheckSMDState()
        {
            if (!SqlHelper.IsConnection(SqlHelper.SQLServerConnectionStringTPOS))
            {
                lanDbState.LanternBackground = Color.Gray;
                return false;
            }
            lanDbState.LanternBackground = Color.LimeGreen;
            return true;
        }

        private void timerTPOS_Tick(object sender, EventArgs e)
        {
            CheckScanState();
            CheckLwmState();
            if (!IsStation_S) CheckVisionState();
        }
    }
}
