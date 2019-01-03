using MES;
using MES.Core;
using ProductManage.Language.MyLanguageTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProductManage.UI
{
    public partial class FormParamSettingL : Form
    {
        private FormMain m_main;

        private Dictionary<string, string> m_dicSystemSet;

        private XmlHelperBase m_xmlHelper;
        
        /// <summary>
        /// 是否设置大环参数
        /// </summary>
        public bool ChkCheckData{ set; get; }

        /// <summary>
        /// 大环同心度上限
        /// </summary>
        public double CoaxUp { set; get; }

        /// <summary>
        /// 大环同心度下限
        /// </summary>
        public double CoaxDown { set; get; }

        /// <summary>
        /// 大环焊缝上限
        /// </summary>
        public double HfUp { set; get; }

        /// <summary>
        /// 大环焊缝下限
        /// </summary>
        public double HfDown { set; get; }

        private int m_culture = 1;

        public FormParamSettingL()
        {
            InitializeComponent();
        }

        public FormParamSettingL(FormMain main)
        {
            InitializeComponent();
            m_main = main;
            m_culture = m_main.Culture;
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

            chkCheckData.Text = ResourceCulture.GetValue("CheckDataSet");
            labDepthUp.Text = ResourceCulture.GetValue("AvgDepthUp");
            labDepthDown.Text = ResourceCulture.GetValue("AvgDepthDown");
            labCoaxUp.Text = ResourceCulture.GetValue("CoaxialityUp");
            labCoaxDown.Text = ResourceCulture.GetValue("CoaxialityDown");

            btnSave.UIText = ResourceCulture.GetValue("Save");
            btnExist.UIText = ResourceCulture.GetValue("Close");

        }

        private void FormParamSettingL_Load(object sender, EventArgs e)
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
                    case "ChkCheckData":
                        ChkCheckData = Convert.ToBoolean(item.Value);
                        chkCheckData.Checked = ChkCheckData;
                        break;
                    case "HFUp":
                        HfUp = Convert.ToDouble(item.Value);
                        numHFUp.Value = Convert.ToDecimal(HfUp);
                        break;
                    case "HFDown":
                        HfDown = Convert.ToDouble(item.Value);
                        numHFDown.Value = Convert.ToDecimal(HfDown);
                        break;
                    case "CoaxUpL":
                        CoaxUp = Convert.ToDouble(item.Value);
                        numCoaxUpL.Value = Convert.ToDecimal(CoaxUp);
                        break;
                    case "CoaxDownL":
                        CoaxDown = Convert.ToDouble(item.Value);
                        numCoaxDownL.Value = Convert.ToDecimal(CoaxDown);
                        break;
                }
            }
        }

        private void InitFormSet()
        {
            chkCheckData.Checked = ChkCheckData;
            numHFDown.Enabled = ChkCheckData;
            numHFUp.Enabled = ChkCheckData;
            numCoaxDownL.Enabled = ChkCheckData;
            numCoaxUpL.Enabled = ChkCheckData;
            if (ChkCheckData == true)
            {
                chkCheckData.ForeColor = Color.Green;
            }
            else
            {
                chkCheckData.ForeColor = Color.Red;
            }

        }


        private void chkParamL_CheckedChanged(object sender, EventArgs e)
        {
            bool boo = chkCheckData.Checked;

            if (boo)
            {
                chkCheckData.ForeColor = Color.Green;
            }
            else
            {
                chkCheckData.ForeColor = Color.Red;
            }

            ChkCheckData = boo;
            numHFDown.Enabled = boo;
            numHFUp.Enabled = boo;
            numCoaxDownL.Enabled = boo;
            numCoaxUpL.Enabled = boo;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            CompareFormData();
        }

        private double HfUpNew, HfDownNew, CoaxUpLNew, CoaxDownLNew;

        private void CompareFormData()
        {
            HfUpNew = Convert.ToDouble(numHFUp.Value);
            HfDownNew = Convert.ToDouble(numHFDown.Value);
            CoaxUpLNew = Convert.ToDouble(numCoaxUpL.Value);
            CoaxDownLNew = Convert.ToDouble(numCoaxDownL.Value);

            bool largeChange = HfUp != HfUpNew | HfDown != HfDownNew | CoaxDown != CoaxDownLNew | CoaxUp != CoaxUpLNew;
            
            if (largeChange)
            {
                SaveDataToXml();
            }
        }

        private void SaveDataToXml()
        {
            m_dicSystemSet.Clear();

            m_dicSystemSet.Add("ChkCheckData", ChkCheckData.ToString());
            m_dicSystemSet.Add("HFUp", HfUpNew.ToString());
            m_dicSystemSet.Add("HFDown", HfDownNew.ToString());
            m_dicSystemSet.Add("CoaxUpL", CoaxUpLNew.ToString());
            m_dicSystemSet.Add("CoaxDownL", CoaxDownLNew.ToString());


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


        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
