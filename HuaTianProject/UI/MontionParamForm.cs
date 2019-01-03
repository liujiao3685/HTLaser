using csLTDMC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuaTianProject.Entity;

namespace HuaTianProject.UI
{
    public partial class MontionParamForm : Form
    {
        private double MinValue = 0;

        private double MaxValue = 10000;

        private Dictionary<string, string> m_dictionary;

        private List<Param> m_listParams;

        public MontionParamForm()
        {
            InitializeComponent();
        }
        private void MontionParamForm_Load(object sender, EventArgs e)
        {
            m_dictionary = FormMain.XmlData;
            m_listParams = DicToParamClass(m_dictionary);
            InitDgv();
            InitValue();
        }

        private void InitDgv()
        {
            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = false;
            this.dataGridView1.Columns[4].ReadOnly = true;
            this.dataGridView1.Columns[5].ReadOnly = false;
        }

        private void InitValue()
        {
            int row = 0;
            try
            {
                dataGridView1.RowCount = m_listParams.Count;
                foreach (var item in m_listParams)
                {
                    for (int col = 0; col < dataGridView1.ColumnCount; col++)
                    {
                        switch (col)
                        {
                            case 0:
                                dataGridView1.Rows[row].Cells[col].Value = item.ParamName;
                                break;
                            case 1:
                                dataGridView1.Rows[row].Cells[col].Value = item.MinValue;
                                break;
                            case 2:
                                dataGridView1.Rows[row].Cells[col].Value = item.MaxValue;
                                break;
                            case 3:
                                dataGridView1.Rows[row].Cells[col].Value = item.ParamValue;
                                break;
                            case 4:
                                dataGridView1.Rows[row].Cells[col].Value = item.ParamUnit;
                                break;
                            case 5:
                                dataGridView1.Rows[row].Cells[col].Value = item.Remark;
                                break;
                            default:
                                break;
                        }
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Param> DicToParamClass(Dictionary<string, string> dic)
        {
            List<Param> list = new List<Param>();
            Param param;

            foreach (var item in dic)
            {
                param = new Param();
                switch (item.Key)
                {
                    case "MoveSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "运动速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "PulseEquiv":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "脉冲当量";
                        param.ParamUnit = "pulse";
                        break;
                    case "HomeSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "回原点速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "AbsoulteSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "相对速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "ReletiveSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "绝对速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "JogSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "JOG速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "ArcInterSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "圆弧插补速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "LineInterSpeed":
                        param.MaxValue = MaxValue;
                        param.MinValue = MinValue;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "直线插补速度";
                        param.ParamUnit = "pulse/s";
                        break;
                    case "AxisPosLimitPosition0":
                        param.MaxValue = 1000;
                        param.MinValue = 100;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "0轴正软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisNegLimitPosition0":
                        param.MaxValue = 0;
                        param.MinValue = -300;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "0轴负软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisPosLimitPosition1":
                        param.MaxValue = 1000;
                        param.MinValue = 100;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "1轴正软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisNegLimitPosition1":
                        param.MaxValue = 0;
                        param.MinValue = -300;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "1轴负软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisPosLimitPosition2":
                        param.MaxValue = 1000;
                        param.MinValue = 100;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "2轴正软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisNegLimitPosition2":
                        param.MaxValue = 0;
                        param.MinValue = -300;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "2轴负软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisPosLimitPosition3":
                        param.MaxValue = 1000;
                        param.MinValue = 100;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "3轴正软限位";
                        param.ParamUnit = "mm";
                        break;
                    case "AxisNegLimitPosition3":
                        param.MaxValue = 0;
                        param.MinValue = -300;
                        param.ParamValue = Convert.ToDouble(item.Value);
                        param.ParamName = "3轴负软限位";
                        param.ParamUnit = "mm";
                        break;
                    default:
                        break;
                }
                if (param.ParamName != null)
                {
                    list.Add(param);
                }
            }
            return list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain.XmlData.Clear();
                for (int row = 0; row < dataGridView1.RowCount; row++)
                {
                    string name = Convert.ToString(dataGridView1.Rows[row].Cells[0].Value);
                    switch (name)
                    {
                        case "运动速度":
                            FormMain.MoveSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("MoveSpeed", FormMain.MoveSpeed.ToString());
                            break;
                        case "脉冲当量":
                            FormMain.PulseEquiv = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("PulseEquiv", FormMain.PulseEquiv.ToString());
                            break;
                        case "回原点速度":
                            FormMain.HomeSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("HomeSpeed", FormMain.HomeSpeed.ToString());
                            break;
                        case "相对速度":
                            FormMain.AbsoulteSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AbsoulteSpeed", FormMain.AbsoulteSpeed.ToString());
                            break;
                        case "绝对速度":
                            FormMain.ReletiveSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("ReletiveSpeed", FormMain.ReletiveSpeed.ToString());
                            break;
                        case "JOG速度":
                            FormMain.JogSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("JogSpeed", FormMain.JogSpeed.ToString());
                            break;
                        case "圆弧插补速度":
                            FormMain.ArcInterSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("ArcInterSpeed", FormMain.ArcInterSpeed.ToString());
                            break;
                        case "直线插补速度":
                            FormMain.LineInterSpeed = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("LineInterSpeed", FormMain.LineInterSpeed.ToString());
                            break;
                        case "0轴正软限位":
                            FormMain.AxisPosLimitPosition0 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisPosLimitPosition0", FormMain.AxisPosLimitPosition0.ToString());
                            break;
                        case "0轴负软限位":
                            FormMain.AxisNegLimitPosition0 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisNegLimitPosition0", FormMain.AxisNegLimitPosition0.ToString());
                            break;
                        case "1轴正软限位":
                            FormMain.AxisPosLimitPosition1 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisPosLimitPosition1", FormMain.AxisPosLimitPosition1.ToString());
                            break;
                        case "1轴负软限位":
                            FormMain.AxisNegLimitPosition1 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisNegLimitPosition1", FormMain.AxisNegLimitPosition1.ToString());
                            break;
                        case "2轴正软限位":
                            FormMain.AxisPosLimitPosition2 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisPosLimitPosition2", FormMain.AxisPosLimitPosition2.ToString());
                            break;
                        case "2轴负软限位":
                            FormMain.AxisNegLimitPosition2 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisNegLimitPosition2", FormMain.AxisNegLimitPosition2.ToString());
                            break;
                        case "3轴正软限位":
                            FormMain.AxisPosLimitPosition3 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisPosLimitPosition3", FormMain.AxisPosLimitPosition3.ToString());
                            break;
                        case "3轴负软限位":
                            FormMain.AxisNegLimitPosition3 = Convert.ToDouble(dataGridView1.Rows[row].Cells["colValue"].Value);
                            FormMain.XmlData.Add("AxisNegLimitPosition3", FormMain.AxisNegLimitPosition3.ToString());
                            break;
                        default:
                            break;
                    }
                }
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 3)
            {
                e.CellStyle.ForeColor = Color.DodgerBlue;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridView grid = (DataGridView)sender;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colValue")
                {
                    double value = 0;
                    double max = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["colMax"].Value);
                    double min = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["colMin"].Value);
                    Double.TryParse(e.FormattedValue.ToString(), out value);

                    if (value > max || value < min )
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText = "数值超范围！";
                        MessageBox.Show("请输入范围内的参数值！");
                        e.Cancel = true;
                        return;
                    }
                }

            }

        }
    }
}
