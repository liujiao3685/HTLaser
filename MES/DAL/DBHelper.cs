using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MES.DAL
{
    public class DBHelper
    {
        //数据库连接字符
        private static string SqlServerConnectionStr = ConfigurationManager.ConnectionStrings["SQLServerConn"].ToString();

        private SqlConnection m_sqlCon;

        private static DBHelper m_dbHelper;

        public DBHelper()
        {

        }

        public DBHelper(string dbConnectString)
        {
            SqlServerConnectionStr = dbConnectString;
        }

        public static DBHelper Instance
        {
            get
            {
                if (m_dbHelper == null)
                {
                    m_dbHelper = new DBHelper();
                }
                return m_dbHelper;
            }
        }

        public bool IsConnection()
        {
            if (m_sqlCon == null || m_sqlCon.State == System.Data.ConnectionState.Closed)
            {
                return false;
            }
            return true;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (m_sqlCon == null)
                {
                    if (SqlServerConnectionStr != String.Empty)
                    {
                        m_sqlCon = new SqlConnection(SqlServerConnectionStr);
                        m_sqlCon.Open();
                    }
                    else
                    {
                        Program.LogNet.WriteError("异常", "获取数据库连接字符失败!");
                        return null;
                    }
                }
                return m_sqlCon;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败，请检查网络后重启软件！");
                Program.LogNet.WriteError("异常", "数据库连接异常：" + ex.Message);
                return null;
            }
        }

        public bool Open()
        {
            try
            {
                if (SqlServerConnectionStr != String.Empty)
                {
                    m_sqlCon = new SqlConnection(SqlServerConnectionStr);
                    m_sqlCon.Open();
                }
                else
                {
                    Program.LogNet.WriteError("异常", "获取数据库连接字符失败!");
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}