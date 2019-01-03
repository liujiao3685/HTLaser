using HslCommunication.BasicFramework;
using MES.Core;
using MES.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheckProject
{
    public partial class FormMesSpotCheck : Form
    {

        private double m_weldPower, WeldPower;

        private double m_weldSpeed, WeldSpeed;

        private double m_weldFlow, WeldFlow;

        private double m_weldPressure, WeldPressure;

        private string m_empNo;

        private DBTool m_tool;

        private SoftAuthorize m_softAuthorize = null;

        private string m_exeName = "HT 生产管理系统.exe";

        public FormMesSpotCheck()
        {
            InitializeComponent();
        }

        private void FormMesSpotCheck_Load(object sender, EventArgs e)
        {
            //CheckSoftAuthorize();
            m_tool = new DBTool();
            InitData();

        }

        private void InitData()
        {
            WeldFlow = 4;
            WeldSpeed = 3;
            WeldPressure = 2;
            WeldPower = 1;

        }

        private void btnSpotCheck_Click(object sender, EventArgs e)
        {
            m_empNo = txtEmpNo.Text.Trim();
            m_weldFlow = Convert.ToDouble(numWeldFlow.Value);
            m_weldPower = Convert.ToDouble(numWeldPower.Value);
            m_weldPressure = Convert.ToDouble(numWeldPressure.Value);
            m_weldSpeed = Convert.ToDouble(numWeldSpeed.Value);

            if (String.IsNullOrEmpty(m_empNo))
            {
                MessageBox.Show("请输入员工编号！");
                return;
            }

            string ifexist = "select * from Users where EmpNo = '" + m_empNo + "'";
            int type = m_tool.IsExist(ifexist);

            if (type == -1)
            {
                MessageBox.Show("数据库连接异常，请检查网络连接是否正常！");
                return;
            }

            if (type != 1)
            {
                MessageBox.Show("您输入的员工编号不存在！");
                return;
            }

            if (m_weldFlow < WeldFlow)
            {
                MessageBox.Show("焊接流量未达标！");
                return;
            }
            else if (m_weldPower < WeldPower)
            {
                MessageBox.Show("焊接功率未达标！");
                return;
            }
            else if (m_weldPressure < WeldPressure)
            {
                MessageBox.Show("焊接压力未达标！");
                return;
            }
            else if (m_weldSpeed < WeldSpeed)
            {
                MessageBox.Show("焊接转速未达标！");
                return;
            }
            else
            {
                MessageBox.Show("点检成功！");

                DateTime now = DateTime.Now;

                StartBack(m_empNo, m_weldFlow, m_weldSpeed, m_weldPressure, m_weldFlow, now);

                if (File.Exists(m_exeName))
                {
                    this.Close();
                    //AppSetting.UpdateAppSetting("Cipher", "true");
                    //直接启动exe
                    Process.Start(m_exeName);

                    //传入数据
                    //Process process = new Process();
                    //process.StartInfo.FileName = m_exeName;
                    //process.StartInfo.UseShellExecute = true;

                    //process.StartInfo.Arguments = "true";
                    //process.Start();

                }
                else
                {
                    MessageBox.Show("未找到生产管理系统主程序！");
                }

            }
        }

        /// <summary>
        /// 保存点检信息
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
               new SqlParameter{ParameterName="@empno",SqlDbType = SqlDbType.NVarChar,SqlValue = empNo},
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
                result = -1;
                Program.LogNet.WriteError("异常", ex.Message);
            }

            return result;
        }


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
                File.SetAttributes(m_softAuthorize.FileSavePath, FileAttributes.ReadOnly);

                using (FormAuthorize form = new FormAuthorize(m_softAuthorize, "请联系华天世纪激光科技公司获取注册码！", AuthorizeEncrypted))
                {
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        Close();
                    }
                }
            }

            //方式二 :直接进行判断授权码
            //if (!m_softAuthorize.CheckAuthorize("CC2A56387E05A1953ABCE666892B916617CA21808A35ABE1B7592DF20DB44CF6", AuthorizeEncrypted))
            //{
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


    }
}
