using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication1.Core;
using WindowsFormsApplication1.Entity;

namespace WindowsFormsApplication1.UI
{
    public partial class FormMySqlStudy : Form
    {
        private string conStr = "database=schema;User ID=root;Password=root;server=localhost;charset=utf8";//数据库连接语句

        private string conStr2 = "Server=localhost;Database=schema;Pooling=True;Port=3306;User Id=root;" +
            "Password=root;Persist Security Info=True;Allow Zero Datetime=True;Character Set = utf8;";

        private MySqlConnection mySqlConnection;

        private string _Name;

        private string _Pwd;

        public FormMySqlStudy()
        {
            InitializeComponent();
        }

        private void FormMySqlStudy_Load(object sender, EventArgs e)
        {

        }

        //连接数据库
        private void userButton1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (mySqlConnection.State == ConnectionState.Closed)
                {
                    mySqlConnection.Open();
                    MessageBox.Show("连接成功！");
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("连接失败：" + ex.Message);
            }
        }

        private void userButton2_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            string sql = "SELECT * FROM mydb;";
            mySqlConnection = new MySqlConnection(conStr);
            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                mySqlConnection.Open();
                da.Fill(ds);
                dgvUser.DataSource = null;
                dgvUser.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentCellFocus();
        }

        private void CurrentCellFocus()
        {
            int currentCellIndex = dgvUser.CurrentRow.Index;

            if (currentCellIndex < dgvUser.Rows.Count - 1)
            {
                string id = dgvUser.Rows[currentCellIndex].Cells[0].Value.ToString();
                string name = dgvUser.Rows[currentCellIndex].Cells[1].Value.ToString();
                string password = dgvUser.Rows[currentCellIndex].Cells[2].Value.ToString();

                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password))
                {
                    return;
                }

                _Name = name;
                _Pwd = password;

                txtName.Text = name;
                txtPwd.Text = password;
            }
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

            string sql = "Update mydb set Name='" + name + "',PASSWORD='" + pwd + "' where Name='" + _Name + "' ";

            int rs = MySQLHelper.ModifyTable(sql);

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

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空！");
                return;
            }

            string sql = "insert into mydb(Name,Password) values(@name,@pwd);";
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("name",value:name),
                new MySqlParameter("pwd",value:pwd)
            };

            int rs = MySQLHelper.ModifyTable(sql, parameters);

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

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> lists = new List<string>
            {
                "insert into mydb(name,password) values(@name,@pwd);",
                "insert into mydb(name,password) values(@name2,@pwd2);"
            };

            string sql =
                "insert into mydb(name,password) values(@name,@pwd);" +
                "insert into mydb(name,password) values(@name2,@pwd2); ";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("name","12"),
                new MySqlParameter("pwd","111"),
                new MySqlParameter("name2","32"),
                new MySqlParameter("pwd2","222"),
            };

            //int rs = MySQLHelper.ModifyTableByTrans(sql, parameters);
            int rs = MySQLHelper.ModifyTableByTrans(lists, parameters);

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
            if (String.IsNullOrEmpty(_Name)) return;

            string sql = @"delete from mydb where name=@name";
            MySqlParameter para = new MySqlParameter("name", _Name);

            int rs = MySQLHelper.ModifyTable(sql, para);

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
    }
}
