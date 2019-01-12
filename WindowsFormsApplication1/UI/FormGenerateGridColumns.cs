using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.UI
{
    public partial class FormGenerateGridColumns : Form
    {
        public FormGenerateGridColumns()
        {
            InitializeComponent();
        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            GenerateColumns("colId","Id","序号");

            GenerateColumns("colName", "Name", "姓名");

            GenerateColumns("colPwd", "Pwd", "密码");

        }

        /// <summary>
        /// 自定义生成GRID列
        /// </summary>
        /// <param name="name">属性列名</param>
        /// <param name="dbName">数据库字段名称</param>
        /// <param name="headerText">界面文本</param>
        private void GenerateColumns(string name, string dbName, string headerText)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = dbName;
            col.HeaderText = headerText;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            col.Width = 100;

            dataGridView1.Columns.Add(col);
        }
    }
}
