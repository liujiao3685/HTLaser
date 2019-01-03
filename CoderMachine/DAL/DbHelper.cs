using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoderMachine.DAL
{
    public class DbHelper
    {
        //数据库连接字符
        private static string DataBaseConnectStr = AppSetting.GetConnectString();

        private SqlConnection m_sqlCon;

        private static DbHelper m_dbHelper;

        public DbHelper()
        {
            m_sqlCon = GetConnection();
            if (m_sqlCon != null && m_sqlCon.State != ConnectionState.Open)
            {
                m_sqlCon.Open();
            }
        }

        public static DbHelper Instance
        {
            get
            {
                if (m_dbHelper == null)
                {
                    m_dbHelper = new DbHelper();
                }
                return m_dbHelper;
            }
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (m_sqlCon == null)
                {
                    if (DataBaseConnectStr != String.Empty)
                    {
                        m_sqlCon = new SqlConnection(DataBaseConnectStr);
                        m_sqlCon.Open();
                    }
                    else
                    {
                        MessageBox.Show("获取数据库连接字符异常！");
                        return null;
                    }
                }
                return m_sqlCon;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询表数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>Tabel</returns>
        public DataTable SelectTable(string sql)
        {
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                SqlCommand cmd = new SqlCommand(sql, m_sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int ModifyTable(string sql, params SqlParameter[] ps)
        {
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                SqlCommand cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, null, CommandType.Text, sql, ps);

                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        //构建一个用于执行的命令对象
        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

    }
}
