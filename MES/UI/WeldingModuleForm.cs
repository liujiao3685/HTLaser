using MES.Core;
using ProductManage.Language.MyLanguageTool;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MES.UI
{
    public partial class WeldingModuleForm : Form
    {
        private FormMain m_main;

        private double m_weldPower, m_weldPowerUp;

        private double m_weldSpeed, m_weldSpeedUp;

        private double m_weldFlow, m_weldFlowUp;

        private double m_weldPressure, m_weldPressureUp;

        private double m_x, m_y, m_z, m_r;

        private int m_culture = 1;

        public WeldingModuleForm()
        {
            InitializeComponent();
            m_culture = AppSetting.GetLanguage();
            CultureChange();
        }

        public WeldingModuleForm(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            m_culture = main.Culture;
            if (main.UseLanguage == 1) CultureChange();
        }

        private void CultureChange()
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
            Text = ResourceCulture.GetValue("ModuleSetting");
            labModuleName.Text = ResourceCulture.GetValue("ModuleName");
            labPower.Text = ResourceCulture.GetValue("WeldPower");
            labPressure.Text = ResourceCulture.GetValue("Pressure");
            labSpeed.Text = ResourceCulture.GetValue("WeldSpeed");
            labFlow.Text = ResourceCulture.GetValue("WeldFlow");
            labX.Text = ResourceCulture.GetValue("WeldXPos");
            labY.Text = ResourceCulture.GetValue("WeldYPos");
            labZ.Text = ResourceCulture.GetValue("WeldZPos");
            labR.Text = ResourceCulture.GetValue("WeldRPos");

            btnSave.UIText = ResourceCulture.GetValue("Save");
            btnLoadModule.UIText = ResourceCulture.GetValue("ChooseModule");
            btnClose.UIText = ResourceCulture.GetValue("Close");

        }

        private void WeldingModuleForm_Load(object sender, EventArgs e)
        {
            XmlModuleHelper.CreateXmlDir();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveModule();
        }

        private bool JudgeData()
        {
            m_weldFlow = Convert.ToDouble(numWeldFlow.Value);
            m_weldPower = Convert.ToDouble(numWeldPower.Value);
            m_weldSpeed = Convert.ToDouble(numWeldSpeed.Value);
            m_weldPressure = Convert.ToDouble(numWeldPressure.Value);

            m_weldFlowUp = Convert.ToDouble(numWeldFlowUp.Value);
            m_weldPowerUp = Convert.ToDouble(numWeldPowerUp.Value);
            m_weldSpeedUp = Convert.ToDouble(numWeldSpeedUp.Value);
            m_weldPressureUp = Convert.ToDouble(numWeldPressureUp.Value);

            if (m_weldFlow > m_weldFlowUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldFlowMoreLimit"));
                return false;
            }
            if (m_weldPower > m_weldPowerUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldPowerMoreLimit"));
                return false;
            }
            if (m_weldSpeed > m_weldSpeedUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldSpeedMoreLimit"));
                return false;
            }
            if (m_weldPressure > m_weldPressureUp)
            {
                MessageBox.Show(ResourceCulture.GetValue("WeldPressMoreLimit"));
                return false;
            }
            return true;
        }

        //保存
        private void SaveModule()
        {
            string moduleName = txtModule.Text.Trim();

            if (String.IsNullOrEmpty(moduleName))
            {
                MessageBox.Show(ResourceCulture.GetValue("ModuleNameEmpty"));
                return;
            }

            if (!JudgeData()) return;

            m_x = Convert.ToDouble(numX.Value);
            m_y = Convert.ToDouble(numY.Value);
            m_z = Convert.ToDouble(numZ.Value);
            m_r = Convert.ToDouble(numR.Value);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "保存模板";
            saveFile.Filter = "文本 |*.xml|所有文件 |*.*";
            saveFile.RestoreDirectory = true;
            saveFile.InitialDirectory = Application.StartupPath + @"\Module";
            saveFile.FileName = moduleName;

            if (DialogResult.OK == saveFile.ShowDialog())
            {
                string filePath = saveFile.FileName;
                XmlModuleHelper.XmlFilePath = filePath;

                int start = filePath.LastIndexOf("\\") + 1;

                int end = filePath.LastIndexOf(".");

                string name = filePath.Substring(start, end - start);
                XmlModuleHelper.ModuleName = name;

                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("WeldFlow", m_weldFlow.ToString());
                dic.Add("WeldPower", m_weldPower.ToString());
                dic.Add("WeldSpeed", m_weldSpeed.ToString());
                dic.Add("WeldPressure", m_weldPressure.ToString());

                dic.Add("WeldFlowUp", m_weldFlowUp.ToString());
                dic.Add("WeldPowerUp", m_weldPowerUp.ToString());
                dic.Add("WeldSpeedUp", m_weldSpeedUp.ToString());
                dic.Add("WeldPressureUp", m_weldPressureUp.ToString());

                dic.Add("WeldX", m_x.ToString());
                dic.Add("WeldY", m_y.ToString());
                dic.Add("WeldZ", m_z.ToString());
                dic.Add("WeldR", m_r.ToString());

                try
                {
                    bool result = XmlModuleHelper.SaveModuleFile(dic);
                    if (result)
                    {
                        MessageBox.Show(ResourceCulture.GetValue("SaveSuccess"));
                    }
                    else
                    {
                        MessageBox.Show(ResourceCulture.GetValue("SaveFail"));
                    }
                }
                catch (Exception ex)
                {
                    Program.LogNet.WriteError("异常" + ex.Message);
                }
            }
        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            OpenModule();
        }

        //打开
        private void OpenModule()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "打开模板";
            dialog.Filter = "文本 |*.xml|所有文件 |*.*";
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

                txtModule.Text = moduleName;

                if (dic == null) return;

                foreach (var item in dic)
                {
                    switch (item.Key)
                    {
                        case "WeldFlow":
                            numWeldFlow.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldPower":
                            numWeldPower.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldSpeed":
                            numWeldSpeed.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldPressure":
                            numWeldPressure.Value = Convert.ToDecimal(item.Value);
                            break;

                        case "WeldFlowUp":
                            numWeldFlowUp.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldPowerUp":
                            numWeldPowerUp.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldSpeedUp":
                            numWeldSpeedUp.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldPressureUp":
                            numWeldPressureUp.Value = Convert.ToDecimal(item.Value);
                            break;

                        case "WeldX":
                            numX.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldY":
                            numY.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldZ":
                            numZ.Value = Convert.ToDecimal(item.Value);
                            break;
                        case "WeldR":
                            numR.Value = Convert.ToDecimal(item.Value);
                            break;
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
