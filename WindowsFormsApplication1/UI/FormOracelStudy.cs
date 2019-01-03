using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApplication1.Core;

namespace WindowsFormsApplication1.UI
{
    public partial class FormOracelStudy : Form
    {
        private string _Name = string.Empty;

        private string _Pwd = string.Empty;

        public FormOracelStudy()
        {
            InitializeComponent();
        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            bool rs = OracleHelper.Open();

            if (rs) MessageBox.Show("连接成功");
            else MessageBox.Show("连接失败");
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentCellIndex = dgvUser.CurrentRow.Index;
            if (currentCellIndex < dgvUser.Rows.Count - 1)
            {
                string name = dgvUser.Rows[currentCellIndex].Cells[0].Value.ToString();
                string password = dgvUser.Rows[currentCellIndex].Cells[1].Value.ToString();

                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("用户名或密码不能为空！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                _Name = name;
                _Pwd = password;

                txtName.Text = name;
                txtPwd.Text = password;
            }
        }

        private void UpdateTable()
        {
            string sql = "Select * from test";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (OracleHelper.Open())
            {
                ds = OracleHelper.SelectTable(sql);
                dt = ds.Tables[0];
                dgvUser.DataSource = dt.DefaultView;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();
            string pwd = txtPwd.Text.ToString();

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }

            string sql = "Update test set Name='" + name + "',PASSWORD='" + pwd + "' where Name='" + _Name + "' ";

            int rs = OracleHelper.ModifyTable(sql);

            if (rs > 0)
            {
                MessageBox.Show("修改成功");
                UpdateTable();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();
            string pwd = txtPwd.Text.ToString();

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return;
            }

            string sql = "insert into test(Name,Password) values('" + name + "','" + pwd + "')";
            int rs = OracleHelper.ModifyTable(sql);

            if (rs > 0)
            {
                MessageBox.Show("增加成功");
                UpdateTable();
            }
            else
            {
                MessageBox.Show("增加失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.ToString();

            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("未选择删除的用户！");
                return;
            }

            string sql = "Delete from test where Name=:name";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("name",OracleDbType.NVarchar2,50,name,ParameterDirection.Input),
            };

            int rs = OracleHelper.ModifyTable(sql, parameters);

            if (rs > 0)
            {
                MessageBox.Show("删除成功");
                UpdateTable();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> lists = new List<string>
            {
                "insert into test(Name,Password) values(:name1,:pwd1)",
                "insert into test(Name,Password) values(:name2,:pwd2)"
            };

            string sql =
                "begin " +
                "insert into test(Name,Password) values(:name1,:pwd1);" +
                "insert into test(Name,Password) values(:name2,:pwd2);" +
                "end;";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("name1","333"),
                new OracleParameter("pwd1",OracleDbType.NVarchar2,50,"333",ParameterDirection.Input),
                new OracleParameter("name2",OracleDbType.NVarchar2,50,"222",ParameterDirection.Input),
                new OracleParameter("pwd2",OracleDbType.NVarchar2,50,"222",ParameterDirection.Input),
            };

            //bool rs = OracleHelper.ModifyTableByTrans(lists, parameters);
            bool rs = OracleHelper.ModifyTableByTrans(sql, parameters);

            if (rs)
            {
                MessageBox.Show("增加成功");
                UpdateTable();
            }
            else
            {
                MessageBox.Show("增加失败");
            }
        }
    }
}
