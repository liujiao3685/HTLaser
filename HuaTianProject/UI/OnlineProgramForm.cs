using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HuaTianProject.EXControl;

namespace HuaTianProject.UI
{
    public partial class OnlineProgramForm : Form
    {
        public static string CodeFileName = string.Empty;

        private EXListViewItem m_exListViewItem;

        private List<EXColumnHeader> m_listHeaders = new List<EXColumnHeader>();

        //直线插补参数
        private readonly string LINE_UNIT = "V:( );X_P:( ),Y_P:( );";

        //圆弧插补参数
        private readonly string ARC_UNIT = "V:( );X_P:( ),Y_P:( );C_X:( ),C_Y:( );";

        public List<string> m_listParams;

        private FormMain m_main;

        public OnlineProgramForm()
        {
            InitializeComponent();
        }

        public OnlineProgramForm(FormMain main)
        {
            InitializeComponent();
            this.m_main = main;
        }

        private void OnlineProgramForm_Load(object sender, EventArgs e)
        {
            InitColHeader();
            LoadColumns();
            AddItemText();

            m_listParams = new List<string>();

        }

        /// <summary>
        /// 初始化每列默认控件及数据
        /// </summary>
        private void AddItemText()
        {
            for (int i = 1; i < 2; i++)
            {
                exListView1.BeginUpdate();

                EXListViewItem item = new EXImageListViewItem(i.ToString());

                InitControls(item);

                exListView1.Items.Add(item);

                exListView1.EndUpdate();
            }
        }

        private void InitControls(EXListViewItem item)
        {
            EXControlListViewSubItem itemcBox = new EXControlListViewSubItem();
            ComboBox cbBox = new ComboBox();
            cbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBox.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            cbBox.Items.Add("直线插补");
            cbBox.Items.Add("圆弧插补");
            cbBox.SelectedIndex = 0;

            EXControlListViewSubItem itemText = new EXControlListViewSubItem();
            TextBox textBox = new TextBox();

            EXControlListViewSubItem itemLaser = new EXControlListViewSubItem();
            Button btnLaser = new Button();
            btnLaser.Click += Button_Click;
            btnLaser.AutoSize = true;
            btnLaser.Text = "OFF";

            EXControlListViewSubItem itemDelay = new EXControlListViewSubItem();
            NumericUpDown delayTime = new NumericUpDown();
            delayTime.Maximum = 10000;
            delayTime.Minimum = 0;
            delayTime.Value = 0;
            delayTime.TextAlign = HorizontalAlignment.Right;

            exListView1.AddControlToSubItem(cbBox, itemcBox);
            exListView1.AddControlToSubItem(textBox, itemText);
            exListView1.AddControlToSubItem(btnLaser, itemLaser);
            exListView1.AddControlToSubItem(delayTime, itemDelay);

            item.SubItems.Add(itemcBox);
            item.SubItems.Add(itemText);
            item.SubItems.Add(itemLaser);
            item.SubItems.Add(itemDelay);
        }

        /// <summary>
        /// 初始化列名
        /// </summary>
        private void InitColHeader()
        {
            DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["colOrder"];
            comboBoxColumn.Items.Add("圆弧插补");
            comboBoxColumn.Items.Add("直线插补");

            //string s = comboBoxColumn.Items.;

            m_listHeaders.Add(new EXColumnHeader("序号", 60));
            m_listHeaders.Add(new EXColumnHeader("指令", 100));
            m_listHeaders.Add(new EXColumnHeader("参数", 300));
            m_listHeaders.Add(new EXColumnHeader("激光状态", 150));
            m_listHeaders.Add(new EXColumnHeader("延时时间(ms)", 150));
        }

        /// <summary>
        /// 加载列名
        /// </summary>
        private void LoadColumns()
        {
            foreach (EXColumnHeader t in m_listHeaders)
            {
                this.exListView1.Columns.Add(t);
            }

            //美化Row样式
            ImageList il = new ImageList();
            il.ImageSize = new Size(1, 28);
            exListView1.SmallImageList = il;
        }

        #region 工具栏

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "打开文件";
            dialog.Filter = "文本 |*.txt| 所有文件|*.*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Application.StartupPath;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                string fileName = dialog.FileName;
                CodeFileName = fileName;

                string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

                int count = lines.Length / 5;

                int rate = 1;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        exListView1.BeginUpdate();

                        EXListViewItem it = exListView1.Items[exListView1.Items.Count - 1] as EXListViewItem;

                        string index = it.Text;

                        EXListViewItem item = new EXListViewItem(Convert.ToInt32(index) + 1 + "");

                        EXControlListViewSubItem itemcBox = new EXControlListViewSubItem();
                        ComboBox cbBox = new ComboBox();
                        cbBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbBox.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                        cbBox.Items.Add("直线插补");
                        cbBox.Items.Add("圆弧插补");
                        cbBox.Text = lines[rate].Split('#')[1];

                        EXControlListViewSubItem itemText = new EXControlListViewSubItem();
                        TextBox textBox = new TextBox();
                        textBox.Text = lines[rate + 1].Split('#')[1];
                        m_listParams.Add(textBox.Text);

                        EXControlListViewSubItem itemLaser = new EXControlListViewSubItem();
                        Button btnLaser = new Button();
                        btnLaser.AutoSize = true;
                        btnLaser.Click += Button_Click;
                        btnLaser.Text = lines[rate + 2].Split('#')[1];

                        EXControlListViewSubItem itemDelay = new EXControlListViewSubItem();
                        NumericUpDown delayTime = new NumericUpDown();
                        delayTime.Maximum = 10000;
                        delayTime.Minimum = 0;
                        delayTime.Value = Convert.ToDecimal(lines[rate + 3].Split('#')[1]);
                        delayTime.TextAlign = HorizontalAlignment.Right;

                        exListView1.AddControlToSubItem(cbBox, itemcBox);
                        exListView1.AddControlToSubItem(textBox, itemText);
                        exListView1.AddControlToSubItem(btnLaser, itemLaser);
                        exListView1.AddControlToSubItem(delayTime, itemDelay);

                        item.SubItems.Add(itemcBox);
                        item.SubItems.Add(itemText);
                        item.SubItems.Add(itemLaser);
                        item.SubItems.Add(itemDelay);

                        exListView1.Items.Add(item);

                        exListView1.EndUpdate();
                        rate += 5;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                int l = m_listParams.Count;

            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < exListView1.SelectedIndices.Count; i++)
            {
                int index = exListView1.SelectedIndices[i];

                exListView1.Items.RemoveAt(index);

            }
        }

        #endregion

        //指令选择
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmBox = sender as ComboBox;
            if (cmBox.SelectedIndex < 0)
            {
                return;
            }

            for (int j = 0; j < exListView1.SelectedItems.Count; j++)
            {
                int i = exListView1.SelectedIndices[j];

                EXListViewItem itemName = exListView1.Items[i] as EXListViewItem;

                EXControlListViewSubItem itemTxtBox = itemName.SubItems[2] as EXControlListViewSubItem;

                TextBox txtBox = itemTxtBox.MyControl as TextBox;

                switch (cmBox.SelectedIndex)
                {
                    case 0:
                        txtBox.Text = LINE_UNIT;
                        break;
                    case 1:
                        txtBox.Text = ARC_UNIT;
                        break;
                    default:
                        break;
                }

            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && "OFF".Equals(btn.Text))
            {
                btn.Text = "ON";
            }
            else if ("ON".Equals(btn.Text))
            {
                btn.Text = "OFF";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            exListView1.SelectedIndexChanged += exListView1_SelectedIndexChanged;

            List<string> lines = new List<string>();

            if (exListView1.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("你未选择任何数据！");
                return;
            }

            //MessageBox.Show(exListView1.SelectedIndices.Count + "....");

            try
            {
                for (int i = 0; i < this.exListView1.SelectedIndices.Count; i++)
                {
                    int index = exListView1.SelectedIndices[i];

                    EXListViewItem itemName = exListView1.Items[index] as EXListViewItem;

                    EXControlListViewSubItem itemCmbox = itemName.SubItems[1] as EXControlListViewSubItem;
                    EXControlListViewSubItem itemTxtBox = itemName.SubItems[2] as EXControlListViewSubItem;
                    EXControlListViewSubItem itemLaser = itemName.SubItems[3] as EXControlListViewSubItem;
                    EXControlListViewSubItem itemDelay = itemName.SubItems[4] as EXControlListViewSubItem;

                    ComboBox cbBox = itemCmbox.MyControl as ComboBox;
                    TextBox txtBox = itemTxtBox.MyControl as TextBox;
                    Button btnLaser = itemLaser.MyControl as Button;
                    NumericUpDown numDelay = itemDelay.MyControl as NumericUpDown;

                    lines.Add(String.Format("序号#{0}\r\n指令#{1}\r\n代码#{2}\r\n激光状态#{3}\r\n延迟时间#{4}",
                        itemName.Text, cbBox.Text, txtBox.Text, btnLaser.Text, numDelay.Text));

                }
            }
            catch (Exception ex)
            {
                m_main.AddLog(ex.Message, true, true);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存";
            dialog.Filter = "文本 |*.txt|所有文件 |*.*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Application.StartupPath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = dialog.FileName;

                    File.WriteAllLines(fileName, lines);

                    m_main.ListParams = m_listParams;
                    labSum.Text = labSum.Text + "，保存成功！";
                }
                catch (Exception ex)
                {
                    m_main.AddLog(ex.Message, true, true);
                }
            }

        }

        private void exListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labSum.Text = "选中" + exListView1.SelectedIndices.Count.ToString() + "条";
            try
            {
                for (int i = 0; i < exListView1.SelectedIndices.Count; i++)
                {
                    int index = exListView1.SelectedIndices[i];
                    EXListViewItem itemName = exListView1.Items[index] as EXListViewItem;

                    if (index + 1 == exListView1.Items.Count)
                    {
                        exListView1.BeginUpdate();

                        int lastIndex = Convert.ToInt32(itemName.Text) + 1;

                        m_exListViewItem = new EXListViewItem(lastIndex.ToString());

                        InitControls(m_exListViewItem);

                        exListView1.Items.Add(m_exListViewItem);

                        exListView1.EndUpdate();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCheckAll.Checked)
            {
                exListView1.SelectedIndexChanged -= exListView1_SelectedIndexChanged;
                foreach (EXListViewItem item in exListView1.Items)
                {
                    item.Selected = chkCheckAll.Checked;
                }
            }
            else
            {
                exListView1.SelectedIndexChanged += exListView1_SelectedIndexChanged;
            }
            labSum.Text = "选中" + exListView1.SelectedIndices.Count.ToString() + "条";
        }

    }
}
