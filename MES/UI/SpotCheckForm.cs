using MES.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using System.IO;
using System.Collections.Generic;
using MES.Core;
using MES.Entity;
using ProductManage.Entity;
using ProductManage.Language.MyLanguageTool;

namespace MES.UI
{
    public partial class SpotCheckForm : Form
    {
        private double m_weldPower, WeldPowerUp, WeldPower;

        private double m_weldSpeed, WeldSpeedUp, WeldSpeed;

        private double m_weldFlow, WeldFlowUp, WeldFlow;

        private double m_weldPressure, WeldPressureUp, WeldPressure;

        private double m_x, WeldX;

        private double m_y, WeldY;

        private double m_z, WeldZ;

        private double m_r, WeldR;

        private string m_empNo, m_moduleName;

        private DBTool m_dbTool = null;

        private string m_dbColumnNames = string.Empty;

        private SoftAuthorize m_softAuthorize = null;

        private FormMain m_main;

        private LoginForm m_loginForm;

        public Dictionary<string, string> DicSystemData;

        private string SystemSetFileName = "SystemParam";

        private string SystemSetFilePath;

        public XmlHelperBase m_xmlHelper = new XmlHelperBase();

        public bool Success;//是否登录成功

        public User CurrentUser;

        public bool Hide = false;

        private List<string> m_listNames = new List<string>();

        private List<WeldModule> m_listModules = new List<WeldModule>();

        private int m_culture = 1;

        public SpotCheckForm()
        {
            InitializeComponent();
        }

        public SpotCheckForm(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            //m_main.ClickSpotFormEvent += M_main_ClickSpotFormEvent;
        }

        public SpotCheckForm(LoginForm form)
        {
            InitializeComponent();
            m_loginForm = form;
            m_loginForm.LoginResultEvent += M_loginForm_LoginResultEvent;
        }

        private void SpotCheck_Load(object sender, EventArgs e)
        {
            m_culture = AppSetting.GetLanguage();
            InitLanguage();

            m_dbColumnNames = "ID,EmpNo,Name,Password,Auth";

            //CheckSoftAuthorize();
            m_main = new FormMain(this);
            m_dbTool = new DBTool();

            m_xmlHelper.FileName = SystemSetFileName;
            m_xmlHelper.XmlDirPath = Application.StartupPath;
            m_xmlHelper.XmlFilePath = SystemSetFilePath = m_xmlHelper.XmlDirPath + @"\" + SystemSetFileName + ".xml";

            if (!File.Exists(SystemSetFilePath)) CreateSystemSetFile();

            InitData();

            GetModuleNames();

            if (AppSetting.GetTest() != 1) ResetFormData();

        }

        private void ResetFormData()
        {
            numWeldFlow.Value = 0;
            numWeldPower.Value = 0;
            numWeldPressure.Value = 0;
            numWeldSpeed.Value = 0;

            numX.Value = 0;
            numY.Value = 0;
            numZ.Value = 0;
            numR.Value = 0;

            txtEmpNo.Text = string.Empty;
        }

        private void InitFormFormXml()
        {
            numWeldFlow.Value = Convert.ToDecimal(WeldFlow);
            numWeldPower.Value = Convert.ToDecimal(WeldPower);
            numWeldSpeed.Value = Convert.ToDecimal(WeldSpeed);
            numWeldPressure.Value = Convert.ToDecimal(WeldPressure);
            numX.Value = Convert.ToDecimal(WeldX);
            numY.Value = Convert.ToDecimal(WeldY);
            numZ.Value = Convert.ToDecimal(WeldZ);
            numR.Value = Convert.ToDecimal(WeldR);
        }


        private void InitLanguage()
        {
            if (m_culture == 1)
            {
                ResourceCulture.SetCurrentCulture("zh-CN");
                SetCulture();
            }
            else
            {
                ResourceCulture.SetCurrentCulture("en-US");
                SetCulture();
            }

        }

        private void SetCulture()
        {
            Text = ResourceCulture.GetValue("SpotCenter");
            labCurModule.Text = ResourceCulture.GetValue("CurrentModule");
            btnSelectModule.UIText = ResourceCulture.GetValue("ChoseSpotModule");
            btnCreateModule.UIText = ResourceCulture.GetValue("CreateModule");
            grbSpotCheck.Text = ResourceCulture.GetValue("SpotParmSet");
            labPower.Text = ResourceCulture.GetValue("WeldPower");
            labFlow.Text = ResourceCulture.GetValue("WeldFlow");
            labSpeed.Text = ResourceCulture.GetValue("WeldSpeed");
            labPress.Text = ResourceCulture.GetValue("Pressure");
            labX.Text = ResourceCulture.GetValue("WeldXPos");
            labY.Text = ResourceCulture.GetValue("WeldYPos");
            labZ.Text = ResourceCulture.GetValue("WeldZPos");
            labR.Text = ResourceCulture.GetValue("WeldRPos");
            labEmpNo.Text = ResourceCulture.GetValue("SpotUser");
            btnSpotCheck.UIText = ResourceCulture.GetValue("SpotCheck");

        }

        private void GetModuleNames()
        {
            string sql = "select ModuleName from WeldModule";

            DataTable names = m_dbTool.SelectTable(sql);

            for (int row = 0; row < names.Rows.Count; row++)
            {
                for (int col = 0; col < names.Columns.Count; col++)
                {
                    string name = String.Format("\t{0}", names.Rows[row][col]);
                    m_listNames.Add(name);
                }
            }

            //cmbModules.Items.AddRange(m_listNames.ToArray());
            //cmbModules.SelectedIndex = 0;

        }

        private void M_main_ClickSpotFormEvent(object obj, MyEvent e)
        {
            Hide = e.HideSpotForm;
        }

        private void M_loginForm_LoginResultEvent(object sender, MyEvent e)
        {
            Success = e.LoginResult;
            CurrentUser = e.LoginUser;
        }

        private void CreateSystemSetFile()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("ChkSmallCheck", "false");
            dic.Add("CoaxUpS", "0.6");
            dic.Add("CoaxDownS", "0");

            dic.Add("ChkLargeCheck", "false");
            dic.Add("CoaxUpL", "0.9");
            dic.Add("CoaxDownL", "0");
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
                //File.SetAttributes(m_softAuthorize.FileSavePath, FileAttributes.ReadOnly);
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



        private void btnCreateModule_Click(object sender, EventArgs e)
        {
            if (CurrentUser == null) ShowLogin();

            if (!Result || !CheckUserAuth()) return;

            using (WeldingModuleForm form = new WeldingModuleForm())
            {
                form.ShowDialog();
            }

        }

        private void ShowLogin()
        {
            LoginForm login = new LoginForm();
            login.LoginResultEvent += LoginResult;
            login.ShowDialog();
        }

        private bool Result;

        public void LoginResult(object sender, MyEvent e)
        {
            Result = e.LoginResult;
            CurrentUser = e.LoginUser;
        }

        public bool CheckUserAuth()
        {
            if (!(CurrentUser.Auth == "管理员" || CurrentUser.Auth == "Admin"))
            {
                MessageBox.Show(ResourceCulture.GetValue("AuthNotEnough"));
                return false;
            }
            return true;
        }

        private bool b_success = true;

        private string m_failReason = string.Empty;

        private void cmbModules_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSelectModule_Click(object sender, EventArgs e)
        {
            SelectModule();
        }

        private void SelectModule()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = ResourceCulture.GetValue("ChooseModule");
            dialog.Filter = "文本|*.xml";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Application.StartupPath + @"\Module";

            if (DialogResult.OK == dialog.ShowDialog())
            {
                string filePath = dialog.FileName;

                int start = filePath.LastIndexOf("\\") + 1;
                int end = filePath.LastIndexOf(".");

                string moduleName = filePath.Substring(start, end - start);
                XmlModuleHelper.ModuleName = moduleName;
                XmlModuleHelper.XmlFilePath = filePath;

                Dictionary<string, string> dic = XmlModuleHelper.LoadModuleFile();

                if (dic == null)
                {
                    MessageBox.Show(ResourceCulture.GetValue("ChoseModuleFail"));
                    return;
                }

                txtCurrentModule.Text = moduleName;

                foreach (var item in dic)
                {
                    switch (item.Key)
                    {
                        case "WeldFlow":
                            WeldFlow = Convert.ToDouble(item.Value);
                            break;
                        case "WeldPower":
                            WeldPower = Convert.ToDouble(item.Value);
                            break;
                        case "WeldSpeed":
                            WeldSpeed = Convert.ToDouble(item.Value);
                            break;
                        case "WeldPressure":
                            WeldPressure = Convert.ToDouble(item.Value);
                            break;

                        case "WeldPowerUp":
                            WeldPowerUp = Convert.ToDouble(item.Value);
                            break;
                        case "WeldSpeedUp":
                            WeldSpeedUp = Convert.ToDouble(item.Value);
                            break;
                        case "WeldFlowUp":
                            WeldFlowUp = Convert.ToDouble(item.Value);
                            break;
                        case "WeldPressureUp":
                            WeldPressureUp = Convert.ToDouble(item.Value);
                            break;

                        case "WeldX":
                            WeldX = Convert.ToDouble(item.Value);
                            break;
                        case "WeldY":
                            WeldY = Convert.ToDouble(item.Value);
                            break;
                        case "WeldZ":
                            WeldZ = Convert.ToDouble(item.Value);
                            break;
                        case "WeldR":
                            WeldR = Convert.ToDouble(item.Value);
                            break;
                    }
                }
                //加载模板数据
                //InitFormFormXml();
            }
        }

        private void btnSpotCheck_Click(object sender, EventArgs e)
        {
            m_empNo = txtEmpNo.Text.Trim();
            m_moduleName = txtCurrentModule.Text.Trim();
            m_weldFlow = Convert.ToDouble(numWeldFlow.Value);
            m_weldPower = Convert.ToDouble(numWeldPower.Value);
            m_weldPressure = Convert.ToDouble(numWeldPressure.Value);
            m_weldSpeed = Convert.ToDouble(numWeldSpeed.Value);
            m_x = Convert.ToDouble(numX.Value);
            m_y = Convert.ToDouble(numY.Value);
            m_z = Convert.ToDouble(numZ.Value);
            m_r = Convert.ToDouble(numR.Value);

            if (String.IsNullOrEmpty(m_moduleName))
            {
                MessageBox.Show(ResourceCulture.GetValue("PleaseChoseSpotModule"));
                btnCreateModule.Visible = true;
                return;
            }

            if (String.IsNullOrEmpty(m_empNo))
            {
                MessageBox.Show(ResourceCulture.GetValue("PleaseInputEmpNo"));
                return;
            }

            string ifexist = "select * from Users where EmpNo = '" + m_empNo + "'";
            int type = m_dbTool.IsExist(ifexist);
            if (type != 1)
            {
                MessageBox.Show(ResourceCulture.GetValue("TheEmpNoNotExist"));
                return;
            }

            if (m_weldFlow < WeldFlow || m_weldFlow > WeldFlowUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldFlowOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason = "焊接流量未达标,";
            }
            else if (m_weldPower < WeldPower || m_weldPower > WeldPowerUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldPowerOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接功率未达标,";
            }
            else if (m_weldSpeed < WeldSpeed || m_weldSpeed > WeldSpeedUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldSpeedOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接速度未达标";
            }
            else if (m_weldPressure < WeldPressure || m_weldPressure > WeldPressureUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldPressureOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接压力未达标,";
            }
            else if (m_x != WeldX)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldXPosOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接坐标X未达标";
            }
            else if (m_y != WeldY)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldYPosOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接坐标Y未达标";
            }
            else if (m_z != WeldZ)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldZPosOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接坐标Z未达标";
            }
            else if (m_r != WeldR)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldRPosOut"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                b_success = false;
                m_failReason += "焊接坐标R未达标";
            }
            else
            {
                b_success = true;
            }

            if (b_success)
            {
                MessageBox.Show(ResourceCulture.GetValue("SpotOK"));

                ModifyData();

                Hide();
                Hide = true;
                //Close();

                m_main?.Show();
            }
            else
            {
                ModifyData();
            }
        }

        private void ModifyData()
        {
            DateTime now = DateTime.Now;

            StartBack(m_empNo, m_weldFlow, m_weldSpeed, m_weldPressure, m_weldFlow, m_x, m_y, m_z, m_r, now, b_success, m_failReason);
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
        private int StartBack(string empNo, double power, double speed, double press, double flow, double x, double y, double z, double r,
            DateTime time, bool success, string fialResaon)
        {
            string sql = "insert into SpotCheck(EmpNo,PWeldPower,PWeldSpeed,PWeldPressure,PWeldFlow,PWeldXPos,PWeldYPos,PWeldZPos,PWeldRPos," +
                "SpotTime,SpotResult,FailReason) " +
                "values(@empno,@power,@speed,@press,@flow,@x,@y,@z,@r,@time,@res,@resaon)";

            int result;

            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter{ParameterName="@empno",SqlDbType = SqlDbType.NVarChar,SqlValue = empNo},
               new SqlParameter{ParameterName="@power",SqlDbType = SqlDbType.Float,SqlValue = power},
               new SqlParameter{ParameterName="@speed",SqlDbType = SqlDbType.Float,SqlValue = speed},
               new SqlParameter{ParameterName="@press",SqlDbType = SqlDbType.Float,SqlValue = press},
               new SqlParameter{ParameterName="@flow",SqlDbType = SqlDbType.Float,SqlValue = flow},

               new SqlParameter{ParameterName="@x",SqlDbType = SqlDbType.Float,SqlValue = x},
               new SqlParameter{ParameterName="@y",SqlDbType = SqlDbType.Float,SqlValue = y},
               new SqlParameter{ParameterName="@z",SqlDbType = SqlDbType.Float,SqlValue = z},
               new SqlParameter{ParameterName="@r",SqlDbType = SqlDbType.Float,SqlValue = r},

               new SqlParameter{ParameterName="@time",SqlDbType = SqlDbType.DateTime,SqlValue = time},
               new SqlParameter{ParameterName="@res",SqlDbType = SqlDbType.NVarChar,SqlValue = success==true?"成功":"失败"},
               new SqlParameter{ParameterName="@resaon",SqlDbType = SqlDbType.NVarChar,SqlValue =  success==true?string.Empty:fialResaon}
            };

            try
            {
                result = m_dbTool.ModifyTable(sql, parameters);
            }
            catch (Exception ex)
            {
                result = -1;
                Program.LogNet.WriteError("异常", ex.Message);
            }

            return result;
        }

        private void SpotCheckForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Hide)
            {
                Application.Exit();
            }
        }
    }
}
