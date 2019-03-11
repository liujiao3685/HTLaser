using CommonLibrary.Common;
using CommonLibrary.Lwm;
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
        private string PlcIp;
        private string LwmIp;
        private string ScannerIp;
        private string VisionIp;
        private string DBSMDIP;

        public FormMonitorForm()
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings["StationName"].ToString() == "S")
            {
                IsStation_S = true;
                PlcIp = "192.168.0.75";
                ScannerIp = "192.168.0.78";
            }
            else
            {
                IsStation_S = false;
                PlcIp = "192.168.0.85";
                ScannerIp = "192.168.0.88";
            }
            LwmIp = "192.168.0.60";
            VisionIp = "192.168.0.66";
            DBSMDIP = "18.7.0.150";
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
            bool boo = false;
            Invoke(new Action(() =>
            {
                //if (!PlcHelper.GetInstance().IsConnection())
                if (!SoftBasic.IsPingOk(PlcIp))
                {
                    lanPlcState.LanternBackground = Color.Gray;
                    boo = false;
                }
                else
                {
                    lanPlcState.LanternBackground = Color.LimeGreen;
                    boo = true;
                }
            }));
            return boo;
        }

        public bool CheckLwmState()
        {
            bool boo = false;
            Invoke(new Action(() =>
            {
                //if (!LwmClient.GetInstance().IsConnection())
                if (!SoftBasic.IsPingOk(LwmIp))
                {
                    lanLwmState.LanternBackground = Color.Gray;
                    boo = false;
                }
                else
                {
                    lanLwmState.LanternBackground = Color.LimeGreen;
                    boo = true;
                }
            }));
            return boo;
        }


        public bool CheckVisionState()
        {
            bool boo = false;
            Invoke(new Action(() =>
            {
                // if (!VisionLJ7000.Instance.OpenVision())
                if (!SoftBasic.IsPingOk(LwmIp))
                {
                    lanVisionState.LanternBackground = Color.Gray;
                    boo = false;
                }
                else
                {
                    lanVisionState.LanternBackground = Color.LimeGreen;
                    boo = true;
                }
            }));
            return boo;
        }

        public bool CheckScanState()
        {
            bool boo = false;
            Invoke(new Action(() =>
            {
                //if (!KeyenceSR751.GetInstance().IsConnection())
                if (!SoftBasic.IsPingOk(VisionIp))
                {
                    lanScanState.LanternBackground = Color.Gray;
                    boo = false;
                }
                else
                {
                    lanScanState.LanternBackground = Color.LimeGreen;
                    boo = true;
                }
            }));
            return boo;
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

        #region 数据库

        private void timerDB_Tick(object sender, EventArgs e)
        {
            CheckDbState();
            CheckSMDState();
        }

        public bool CheckDbState()
        {
            bool boo = false;
            // if (!SQLServerDAL.SqlHelper.IsConnection(SqlHelper.SQLServerConnectionString))
            if (!SoftBasic.IsPingOk("127.0.0.1"))
            {
                lanDbState.LanternBackground = Color.Gray;
                boo = false;
            }
            else
            {
                lanDbState.LanternBackground = Color.LimeGreen;
                boo = true;
            }
            return boo;
        }

        public bool CheckSMDState()
        {
            bool boo = false;
            Invoke(new Action(() =>
            {
                // if (!SQLServerDAL.SqlHelper.IsConnection(SqlHelper.SQLServerConnectionStringTPOS))
                if (!SoftBasic.IsPingOk(DBSMDIP))
                {
                    lanDbState.LanternBackground = Color.Gray;
                    boo = false;
                }
                else
                {
                    lanDbState.LanternBackground = Color.LimeGreen;
                    boo = true;
                }
            }));
            return boo;
        }
        #endregion

        private void timerTPOS_Tick(object sender, EventArgs e)
        {
            CheckScanState();
            CheckLwmState();
            if (!IsStation_S) CheckVisionState();
        }
    }
}
