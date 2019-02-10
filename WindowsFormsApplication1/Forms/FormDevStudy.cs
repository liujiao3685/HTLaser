using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MES.DAL;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.UI
{
    public partial class FormDevStudy : Form
    {
        private DBTool m_dbTool;

        public FormDevStudy()
        {
            InitializeComponent();
        }

        private void FormDevStudy_Load(object sender, EventArgs e)
        {
            m_dbTool = new DBTool();

            UpdateTable();

            ComboBoxStyle();

            DGVStyle();

        }


        private void DGVStyle()
        {

        }

        private void ComboBoxStyle()
        {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.Add("Item1");
            comboBoxEdit1.SelectedIndex = 0;
        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            string sql = "Select * from Product";

            DataTable dt = DBTool.SelectTable(sql);

            gridControl1.DataSource = null;
            if (dt != null && dt.Rows.Count > 0)
                gridControl1.DataSource = dt;
        }

        private void userButton2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (View != null)
                View.ExportToPdf("ShowData.pdf");//pdf的文件名必须是英文
            try
            {
                Process pdfExport = new Process();

                pdfExport.StartInfo.FileName = "AcroRd32.exe";

                pdfExport.StartInfo.Arguments = "ShowData.pdf";

                pdfExport.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userButton3_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (View != null)
                View.ExportToCsv("ShowData.CSV");//pdf的文件名必须是英文
            try
            {
                Process pdfExport = new Process();

                pdfExport.StartInfo.FileName = @"C:\Users\liujiao\AppData\Local\Kingsoft\WPS Office\ksolaunch.exe";

                pdfExport.StartInfo.Arguments = "ShowData.csv";

                pdfExport.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //显示行号
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        bool alarm = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alarm)
            {
                hslLanternAlarm1.LightColor = Color.OrangeRed;
                alarm = false;
            }
            else
            {
                hslLanternAlarm1.LightColor = Color.Gray;
                alarm = true;
            }
        }
    }
}
