using HslCommunication.LogNet;
using MES;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApplication1.DAL;

namespace WindowsFormsApplication1.UI
{
    public partial class FormGuid : Form
    {
        private string m_676 = SqlHelper.Sql_676;
        private string m_last676 = string.Empty;
        private string m_lastModel = string.Empty;

        private string m_677 = SqlHelper.Sql_677;
        private string m_last677 = string.Empty;

        private ILogNet file;

        private string path = Application.StartupPath + "\\HO-\\";

        private string curPath = string.Empty;


        public FormGuid()
        {
            InitializeComponent();
        }

        //GUID生成
        private void button7_Click(object sender, EventArgs e)
        {
            // 格式字符串只能是“D”、“d”、“N”、“n”、“P”、“p”、“B”、“b”、“X”或“x”
            txtGuid.Text = GetGuid();
            txtGuid.Focus();

            timer1.Enabled = true;
            timer1.Interval = 2000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtGuid.Text = GetGuid();
            txtGuid.SelectAll();

        }

        private string GetGuid()
        {
            return Guid.NewGuid().ToString("D");
        }

        private void FormGuid_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            file = new LogNetSingle(path);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string model = txtModel.Text.Trim();
            string sql = string.Empty;

            if (string.IsNullOrEmpty(model)) return;

            curPath = path = Application.StartupPath + "\\HO-\\" + model + ".txt";//
            file = new LogNetSingle(path);

            if (String.IsNullOrEmpty(m_lastModel))
            {
                m_lastModel = ConfigurationManager.AppSettings["LastModel676"];
                sql = m_676.Replace(m_lastModel, model);
                m_lastModel = model;
                AppSetting.SetAppSettingValue("LastModel676", m_lastModel);
            }
            else
            {
                sql = m_676.Replace(m_lastModel, model);
                m_lastModel = model;
                AppSetting.SetAppSettingValue("LastModel676", m_lastModel);
            }

            file.WriteInfo(sql);

        }

        private string ReplaceWord(string str, string olds, string news)
        {
            return str.Replace(olds, news);
        }


        private string FormatSql()
        {
            string finalSql = string.Empty;
            string g_product = GetGuid();

            string[] g_mains = new string[17];
            for (int i = 0; i < 17; i++)
            {
                g_mains[i] = GetGuid();
            }
            

            return finalSql;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(curPath)) Process.Start("Notepad.exe", curPath);
        }
    }
}
