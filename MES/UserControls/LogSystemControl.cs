using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;

namespace MES.UserControls
{
    public partial class LogSystemControl : UserControl
    {
        private FormMain m_formMain;

        private ILogNet m_logNet;

        public LogSystemControl()
        {
            InitializeComponent();
        }

        public LogSystemControl(FormMain main)
        {
            InitializeComponent();

            //设定按字体来缩放控件  
            this.AutoScaleMode = AutoScaleMode.Font;
            //设定字体大小为12px       
            this.Font = new Font("Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(134)));

            m_formMain = main;
            m_logNet = main.LogNetUser;
        }

        private void LogSystem_Load(object sender, System.EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            cmbLogLv.DataSource = SoftBasic.GetEnumValues<HslMessageDegree>();//日志等级
            cmbLogLv.SelectedItem = HslMessageDegree.INFO;

            cmbLogKey.DataSource = SoftBasic.GetEnumValues<MessageResult>();//日志结果
            cmbLogKey.SelectedItem = MessageResult.正常;

        }

        //日志等级改变
        private void cmbLogLv_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_logNet.SetMessageDegree(HslMessageDegree.INFO);
        }

        //手动写入日志
        private void btnWriteLog_Click(object sender, System.EventArgs e)
        {
            Write();
        }

        private void Write()
        {
            string text = txtLogContent.Text;
            if (String.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("日志内容不能为空！");
                return;
            }

            try
            {
                HslMessageDegree degree = HslMessageDegree.INFO;
                //HslMessageDegree degree = (HslMessageDegree)cmbLogLv.SelectedItem;
                WriteLog(degree, txtLogKey.Text /*cmbLogKey.Text*/, text);
                Thread.Sleep(50);
                LoadLog();
                m_formMain.AddTips("写入成功！", false);

            }
            catch (Exception ex)
            {
                m_formMain.AddTips("写入失败", true);
                m_formMain.LogNetProgramer.WriteError("写入日志异常---->", ex.Message);
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="degree">日志等级</param>
        /// <param name="result">日志结果</param>
        /// <param name="txt">日志内容</param>
        public void WriteLog(HslMessageDegree degree, string result, string txt)
        {
            m_logNet.RecordMessage(degree, result, txt);
        }

        private void btnLoadLogFile_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        //加载日志
        private void LoadLog()
        {
            if (File.Exists(m_formMain.UserLogName))
            {
                using (StreamReader sr = new StreamReader(m_formMain.UserLogName, Encoding.UTF8))
                {
                    string log = sr.ReadToEnd();

                    //txtLogInfo.Text = log;

                    listBox.Items.Clear();
                    string[] logs = log.Split('\n');
                    listBox.Items.AddRange(logs);
                    listBox.TopIndex = listBox.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("未找到日志文件！");
            }
        }

        //清空日志
        private void btnClearLogFile_Click(object sender, EventArgs e)
        {
            if (!m_formMain.CheckUserAuth())
            {
                return;
            }

            File.WriteAllBytes(m_formMain.UserLogName, new byte[0]);
            m_formMain.AddTips("清空成功！", false);
        }
    }
}
