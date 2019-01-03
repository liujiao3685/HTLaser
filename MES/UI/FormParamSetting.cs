using MES;
using MES.Core;
using ProductManage.Language.MyLanguageTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 生产管理系统.UI
{
    public partial class FormParamSetting : Form
    {
        private FormMain m_main;

        private Dictionary<string, string> m_dicSystemSet;

        private XmlHelperBase m_xmlHelper;

        /// <summary>
        /// 是否设置小环参数
        /// </summary>
        public bool ChkSmallCheck { set; get; }

        /// <summary>
        /// 小环同心度上限
        /// </summary>
        public double CoaxUpS { set; get; }

        /// <summary>
        /// 小环同心度下限
        /// </summary>
        public double CoaxDownS { set; get; }

        /// <summary>
        /// 是否设置大环参数
        /// </summary>
        public bool ChkLargeCheck { set; get; }

        /// <summary>
        /// 大环同心度上限
        /// </summary>
        public double CoaxUpL { set; get; }

        /// <summary>
        /// 大环同心度下限
        /// </summary>
        public double CoaxDownL { set; get; }

        /// <summary>
        /// 大环焊缝上限
        /// </summary>
        public double HfUp { set; get; }

        /// <summary>
        /// 大环焊缝下限
        /// </summary>
        public double HfDown { set; get; }

        /// <summary>
        /// 是否设置点检参数
        /// </summary>
        public bool ChkSpotCheck { set; get; }

        /// <summary>
        /// 点检焊接功率
        /// </summary>
        public double WeldPower { set; get; }

        /// <summary>
        /// 点检焊接转速
        /// </summary>
        public double WeldSpeed { set; get; }

        /// <summary>
        /// 点检焊接流量
        /// </summary>
        public double WeldFlow { set; get; }

        /// <summary>
        /// 点检焊接压力值
        /// </summary>
        public double WeldPressure { set; get; }

        private int m_culture = 1;

        public FormParamSetting()
        {
            InitializeComponent();
        }

        public FormParamSetting(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            m_culture = main.Culture;
            if (m_main.UseLanguage == 1) CultureChange();
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
            Text = ResourceCulture.GetValue("ParamSetting");

            chkSpotCheck.Text = ResourceCulture.GetValue("SpotDataSet");
            chkCheckData.Text = ResourceCulture.GetValue("CheckDataSet");
            labPower.Text = ResourceCulture.GetValue("WeldPower");
            labFlow.Text = ResourceCulture.GetValue("WeldFlow");
            labSpeed.Text = ResourceCulture.GetValue("WeldSpeed");
            labPress.Text = ResourceCulture.GetValue("Pressure");
            labCoaxUp.Text = ResourceCulture.GetValue("CoaxialityUp");
            labCoaxDown.Text = ResourceCulture.GetValue("CoaxialityDown");

            btnSave.UIText = ResourceCulture.GetValue("Save");
            btnExist.UIText = ResourceCulture.GetValue("Close");

        }

        private void FormParamSetting_Load(object sender, EventArgs e)
        {
            m_dicSystemSet = m_main.SystemParamsDic;
            m_xmlHelper = m_main.XmlHelper;

            LoadXmlData();

            InitFormSet();

        }

        private void LoadXmlData()
        {
            if (m_dicSystemSet == null) return;

            foreach (var item in m_dicSystemSet)
            {
                switch (item.Key)
                {
                    case "ChkSmallCheck":
                        ChkSmallCheck = Convert.ToBoolean(item.Value);
                        chkCheckData.Checked = ChkSmallCheck;
                        break;
                    case "CoaxUpS":
                        CoaxUpS = Convert.ToDouble(item.Value);
                        numCoaxUpS.Value = Convert.ToDecimal(CoaxUpS);
                        break;
                    case "CoaxDownS":
                        CoaxDownS = Convert.ToDouble(item.Value);
                        numCoaxDownS.Value = Convert.ToDecimal(CoaxDownS);
                        break;
                    case "ChkSpotCheck":
                        ChkSpotCheck = Convert.ToBoolean(item.Value);
                        chkSpotCheck.Checked = ChkLargeCheck;
                        break;
                    case "WeldPower":
                        WeldPower = Convert.ToDouble(item.Value);
                        numWeldPower.Value = Convert.ToDecimal(WeldPower);
                        break;
                    case "WeldSpeed":
                        WeldSpeed = Convert.ToDouble(item.Value);
                        numWeldSpeed.Value = Convert.ToDecimal(WeldSpeed);
                        break;
                    case "WeldFlow":
                        WeldFlow = Convert.ToDouble(item.Value);
                        numWeldFlow.Value = Convert.ToDecimal(WeldFlow);
                        break;
                    case "WeldPressure":
                        WeldPressure = Convert.ToDouble(item.Value);
                        numWeldPressure.Value = Convert.ToDecimal(WeldPressure);
                        break;
                }
            }
        }

        private void InitFormSet()
        {
            //点检
            chkSpotCheck.Checked = ChkSpotCheck;
            numWeldFlow.Enabled = ChkSpotCheck;
            numWeldPower.Enabled = ChkSpotCheck;
            numWeldPressure.Enabled = ChkSpotCheck;
            numWeldSpeed.Enabled = ChkSpotCheck;
            if (ChkSpotCheck == true)
            {
                chkSpotCheck.ForeColor = Color.Green;
            }
            else
            {
                chkSpotCheck.ForeColor = Color.Red;
            }

            //小环
            chkCheckData.Checked = ChkSmallCheck;
            numCoaxUpS.Enabled = ChkSmallCheck;
            numCoaxDownS.Enabled = ChkSmallCheck;
            if (ChkSmallCheck == true)
            {
                chkCheckData.ForeColor = Color.Green;
            }
            else
            {
                chkCheckData.ForeColor = Color.Red;
            }

        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            CompareFormData();

            sw.Stop();
            Console.WriteLine("XML保存耗时：" + sw.ElapsedMilliseconds + "ms");

        }

        private double CoaxUpSNew, CoaxDownSNew;
#pragma warning disable CS0649 // 从未对字段“FormParamSetting.CoaxUpLNew”赋值，字段将一直保持其默认值 0
#pragma warning disable CS0649 // 从未对字段“FormParamSetting.HfUpNew”赋值，字段将一直保持其默认值 0
#pragma warning disable CS0649 // 从未对字段“FormParamSetting.HfDownNew”赋值，字段将一直保持其默认值 0
#pragma warning disable CS0649 // 从未对字段“FormParamSetting.CoaxDownLNew”赋值，字段将一直保持其默认值 0
        private double CoaxUpLNew, CoaxDownLNew, HfUpNew, HfDownNew;
#pragma warning restore CS0649 // 从未对字段“FormParamSetting.CoaxDownLNew”赋值，字段将一直保持其默认值 0
#pragma warning restore CS0649 // 从未对字段“FormParamSetting.HfDownNew”赋值，字段将一直保持其默认值 0
#pragma warning restore CS0649 // 从未对字段“FormParamSetting.HfUpNew”赋值，字段将一直保持其默认值 0
#pragma warning restore CS0649 // 从未对字段“FormParamSetting.CoaxUpLNew”赋值，字段将一直保持其默认值 0
        private double WeldPowerNew, WeldSpeedNew, WeldFlowNew, WeldPressureNew;

        private void CompareFormData()
        {
            ChkSmallCheck = chkCheckData.Checked;
            ChkSpotCheck = chkSpotCheck.Checked;

            CoaxUpSNew = Convert.ToDouble(numCoaxUpS.Value);
            CoaxDownSNew = Convert.ToDouble(numCoaxDownS.Value);

            WeldPowerNew = Convert.ToDouble(numWeldPower.Value);
            WeldSpeedNew = Convert.ToDouble(numWeldSpeed.Value);
            WeldFlowNew = Convert.ToDouble(numWeldFlow.Value);
            WeldPressureNew = Convert.ToDouble(numWeldPressure.Value);


            bool smallChange = CoaxUpS != CoaxUpSNew | CoaxDownS != CoaxDownSNew;
            bool largeChange = CoaxUpL != CoaxUpLNew | CoaxDownL != CoaxDownLNew | HfUp != HfUpNew | HfDown != HfDownNew;
            bool spotChange = WeldPower != WeldPowerNew | WeldSpeed != WeldSpeedNew | WeldFlow != WeldFlowNew | WeldPressure != WeldPressureNew;

            if (smallChange || largeChange || spotChange)
            {
                SaveDataToXml();
            }
        }

        private void SaveDataToXml()
        {
            m_dicSystemSet.Clear();

            m_dicSystemSet.Add("ChkSmallCheck", ChkSmallCheck.ToString());
            m_dicSystemSet.Add("CoaxUpS", CoaxUpSNew.ToString());
            m_dicSystemSet.Add("CoaxDownS", CoaxDownSNew.ToString());

            m_dicSystemSet.Add("ChkLargeCheck", ChkLargeCheck.ToString());
            m_dicSystemSet.Add("CoaxUpL", CoaxUpLNew.ToString());
            m_dicSystemSet.Add("CoaxDownL", CoaxDownLNew.ToString());
            m_dicSystemSet.Add("HFUp", HfUpNew.ToString());
            m_dicSystemSet.Add("HFDown", HfDownNew.ToString());

            m_dicSystemSet.Add("ChkSpotCheck", ChkSpotCheck.ToString());
            m_dicSystemSet.Add("WeldPower", WeldPowerNew.ToString());
            m_dicSystemSet.Add("WeldSpeed", WeldSpeedNew.ToString());
            m_dicSystemSet.Add("WeldFlow", WeldFlowNew.ToString());
            m_dicSystemSet.Add("WeldPressure", WeldPressureNew.ToString());


            bool success = m_xmlHelper.SaveFile(m_dicSystemSet);

            if (success)
            {
                MessageBox.Show("修改保存成功，重启软件后生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void chkParamS_CheckedChanged(object sender, EventArgs e)
        {
            bool boo = chkCheckData.Checked;
            if (boo == true)
            {
                chkCheckData.ForeColor = Color.Green;
            }
            else
            {
                chkCheckData.ForeColor = Color.Red;
            }

            numCoaxUpS.Enabled = boo;
            numCoaxDownS.Enabled = boo;
        }

        private void chkSpotCheck_CheckedChanged(object sender, EventArgs e)
        {
            bool boo = chkSpotCheck.Checked;
            if (boo == true)
            {
                chkSpotCheck.ForeColor = Color.Green;
            }
            else
            {
                chkSpotCheck.ForeColor = Color.Red;
            }

            numWeldFlow.Enabled = boo;
            numWeldPower.Enabled = boo;
            numWeldPressure.Enabled = boo;
            numWeldSpeed.Enabled = boo;

        }

    }
}
