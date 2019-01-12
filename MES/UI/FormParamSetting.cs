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

            chkCheckData.Text = ResourceCulture.GetValue("CheckDataSet");
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
                }
            }
        }

        private void InitFormSet()
        {
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

        private void CompareFormData()
        {
            ChkSmallCheck = chkCheckData.Checked;

            CoaxUpSNew = Convert.ToDouble(numCoaxUpS.Value);
            CoaxDownSNew = Convert.ToDouble(numCoaxDownS.Value);

            bool smallChange = CoaxUpS != CoaxUpSNew | CoaxDownS != CoaxDownSNew;

            if (smallChange)
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

    }
}
