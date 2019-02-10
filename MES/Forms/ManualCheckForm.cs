using System;
using System.Windows.Forms;
using MES.Core;
using ProductManage.Language.MyLanguageTool;

namespace MES.UI
{
    public partial class ManualCheckForm : Form
    {
        private string ManualInfo;

        private string FinalResult;

        public delegate void ModifyManualHandle(object sender, MyEvent e);

        public event ModifyManualHandle ModifyManual;

        private bool UpdateClick = false;

        private int m_culture = 1;

        public ManualCheckForm()
        {
            InitializeComponent();
        }

        public ManualCheckForm(int culture, string manual, string result)
        {
            InitializeComponent();
            ManualInfo = manual;
            FinalResult = result;

            m_culture = culture;
            CultureChange();
        }

        private void ManualCheckForm_Load(object sender, EventArgs e)
        {
            txtManualInfo.Text = ManualInfo;
            if (FinalResult == "OK") cmbLwmCheckUpdate.SelectedIndex = 0;
            else cmbLwmCheckUpdate.SelectedIndex = 1;
        }

        private void CultureChange()
        {
            if (m_culture == 1)
            {
                ResourceCulture.SetCurrentCulture("zh-CN");
                SetResourceCulture();
            }
            else
            {
                ResourceCulture.SetCurrentCulture("en-US");
                SetResourceCulture();
            }
        }

        private void SetResourceCulture()
        {
            Text = ResourceCulture.GetValue("ManualCheck");

            labReason.Text = ResourceCulture.GetValue("ModifyReason");
            labFinalResult.Text = ResourceCulture.GetValue("FinalResult");
            btnUpdate.UIText = ResourceCulture.GetValue("Modify");

        }

        public void OnModifyManual(object sender, MyEvent e)
        {
            ModifyManual?.Invoke(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modify(sender, true);
            UpdateClick = true;
            Close();
        }

        /// <summary>
        /// 执行修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ifupdate"></param>
        private void Modify(object sender, bool ifupdate)
        {
            string info = txtManualInfo.Text.Replace("\n", "").Replace("\t", "").Replace("\r", "");
            string result = cmbLwmCheckUpdate.SelectedItem.ToString();
            if (String.IsNullOrEmpty(info))
            {
                MessageBox.Show(ResourceCulture.GetValue("ReasonEmpty"));
                return;
            }
            if (info.Length > 100)
            {
                MessageBox.Show(ResourceCulture.GetValue("ContentHundredWord"));
                return;
            }

            OnModifyManual(sender, new MyEvent() { ManualInfo = info, QCResult = result, IfUpdateResult = ifupdate });
        }

        private void cmbLwmCheckUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ManualCheckForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UpdateClick)
            {
                DialogResult result = MessageBox.Show(ResourceCulture.GetValue("IsSaved"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.Yes == result)
                {
                    Modify(sender, true);
                }
                else
                {
                    Modify(sender, false);
                    e.Cancel = false;
                }
            }
        }
    }
}
