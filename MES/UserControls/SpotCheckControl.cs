using HslCommunication.BasicFramework;
using MES.Core;
using MES.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace MES.UserControls
{
    public partial class SpotCheckControl : UserControl
    {
        private double m_weldPower, WeldPower;

        private double m_weldSpeed, WeldSpeed;

        private double m_weldFlow, WeldFlow;

#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.m_xPos”
#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.XPos”
        private double m_xPos, XPos;
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.XPos”
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.m_xPos”

#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.YPos”
#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.m_yPos”
        private double m_yPos, YPos;
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.m_yPos”
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.YPos”

#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.m_zPos”
#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.ZPos”
        private double m_zPos, ZPos;
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.ZPos”
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.m_zPos”

#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.RPos”
#pragma warning disable CS0169 // 从不使用字段“SpotCheckControl.m_rPos”
        private double m_rPos, RPos;
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.m_rPos”
#pragma warning restore CS0169 // 从不使用字段“SpotCheckControl.RPos”

        private double m_weldPressure, WeldPressure;

        private string m_empNo;

        private DBTool m_tool = null;

#pragma warning disable CS0414 // 字段“SpotCheckControl.m_softAuthorize”已被赋值，但从未使用过它的值
        private SoftAuthorize m_softAuthorize = null;
#pragma warning restore CS0414 // 字段“SpotCheckControl.m_softAuthorize”已被赋值，但从未使用过它的值

#pragma warning disable CS0649 // 从未对字段“SpotCheckControl.m_main”赋值，字段将一直保持其默认值 null
        private FormMain m_main;
#pragma warning restore CS0649 // 从未对字段“SpotCheckControl.m_main”赋值，字段将一直保持其默认值 null

        public Dictionary<string, string> DicSystemData;

        private string SystemSetFileName = "SystemParam";

        private string SystemSetFilePath;

        public XmlHelperBase m_xmlHelper = new XmlHelperBase();

        public SpotCheckControl()
        {
            InitializeComponent();
        }

        private void SpotCheckControl_Load(object sender, System.EventArgs e)
        {
            m_tool = new DBTool();  

            m_xmlHelper.FileName = SystemSetFileName;
            m_xmlHelper.XmlDirPath = Application.StartupPath;
            m_xmlHelper.XmlFilePath = SystemSetFilePath = m_xmlHelper.XmlDirPath + @"\" + m_xmlHelper.FileName + ".xml";

            if (!File.Exists(SystemSetFilePath)) CreateSystemSetFile();

            InitData();
        }

        private void CreateSystemSetFile()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("ChkSmallCheck", "false");
            dic.Add("CoaxUpS", "0.3");
            dic.Add("CoaxDownS", "-0.3");

            dic.Add("ChkLargeCheck", "false");
            dic.Add("CoaxUpL", "0.2");
            dic.Add("CoaxDownL", "-0.15");
            dic.Add("HFUp", "2");
            dic.Add("HFDown", "0");

            dic.Add("ChkSpotCheck", "false");
            dic.Add("WeldPower", "1000");
            dic.Add("WeldSpeed", "1000");
            dic.Add("WeldFlow", "10.30");
            dic.Add("WeldPressure", "0.1");

            dic.Add("ChkWeldPos", "false");
            dic.Add("WeldXPosL", "-70.14");
            dic.Add("WeldYPosL", "-57.08");
            dic.Add("WeldZPosL", "-144.17");
            dic.Add("WeldRPosL", "-7.04");

            m_xmlHelper.SaveFile(dic);
        }

        private void InitData()
        {
            DicSystemData = m_xmlHelper.LoadFile();

            if (DicSystemData == null) return;

            foreach (var item in DicSystemData)
            {
                switch (item.Key)
                {
                    case "WeldPower":
                        WeldPower = Convert.ToDouble(item.Value);
                        break;
                    case "WeldSpeed":
                        WeldSpeed = Convert.ToDouble(item.Value);
                        break;
                    case "WeldFlow":
                        WeldFlow = Convert.ToDouble(item.Value);
                        break;
                    case "WeldPressure":
                        WeldPressure = Convert.ToDouble(item.Value);
                        break;
                }
            }
        }

        private void btnSpotCheck_Click(object sender, EventArgs e)
        {
            m_empNo = txtEmpNo.Text.Trim();
            m_weldFlow = Convert.ToDouble(numWeldFlow.Value);
            m_weldPower = Convert.ToDouble(numWeldPower.Value);
            m_weldPressure = Convert.ToDouble(numWeldPressure.Value);
            m_weldSpeed = Convert.ToDouble(numWeldSpeed.Value);

            CheckCondition();
        }

        private void CheckCondition()
        {
            if (String.IsNullOrEmpty(m_empNo))
            {
                MessageBox.Show("请输入员工编号！");
                return;
            }

            string ifexist = "select * from Users where EmpNo = '" + m_empNo + "'";
            int type = m_tool.IsExist(ifexist);
            if (type != 1)
            {
                MessageBox.Show("您输入的员工编号不存在！");
                return;
            }

            if (m_weldFlow < WeldFlow)
            {
                MessageBox.Show("点检失败：焊接流量未达标！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (m_weldPower < WeldPower)
            {
                MessageBox.Show("点检失败：焊接功率未达标！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (m_weldPressure < WeldPressure)
            {
                MessageBox.Show("点检失败：焊接压力未达标！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (m_weldSpeed < WeldSpeed)
            {
                MessageBox.Show("点检失败：焊接转速未达标！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("点检成功！");

                DateTime now = DateTime.Now;

                StartBack(m_empNo, m_weldFlow, m_weldSpeed, m_weldPressure, m_weldFlow, now);

                ShowFormMain();

            }
        }

        private void ShowFormMain()
        {
            Hide();

            m_main?.Show();
        }

        /// <summary>
        /// 开始追溯
        /// </summary>
        /// <param name="power"></param>
        /// <param name="speed"></param>
        /// <param name="press"></param>
        /// <param name="flow"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private int StartBack(string empNo, double power, double speed, double press, double flow, DateTime time)
        {
            string sql = "insert into SpotCheck(EmpNo,PWeldPower,PWeldSpeed,PWeldPressure,PWeldFlow,SpotTime) " +
                "values(@empno,@power,@speed,@press,@flow,@time)";

            int result;

            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter{ParameterName = "@empno",SqlDbType = SqlDbType.NVarChar,SqlValue = empNo},
               new SqlParameter{ParameterName="@power",SqlDbType = SqlDbType.Float,SqlValue = power},
               new SqlParameter{ParameterName="@speed",SqlDbType = SqlDbType.Float,SqlValue = speed},
               new SqlParameter{ParameterName="@press",SqlDbType = SqlDbType.Float,SqlValue = press},
               new SqlParameter{ParameterName="@flow",SqlDbType = SqlDbType.Float,SqlValue = flow},
               new SqlParameter{ParameterName="@time",SqlDbType = SqlDbType.DateTime,SqlValue = time}
            };

            try
            {
                result = m_tool.ModifyTable(sql, parameters);
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", ex.Message);
                result = -1;
            }

            return result;
        }

    }
}
