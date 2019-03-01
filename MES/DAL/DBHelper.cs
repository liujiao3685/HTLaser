using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MES.DAL
{
    public class DBHelper
    {
        //数据库连接字符
        private static string SqlServerConnectionStr = ConfigurationManager.ConnectionStrings["SQLServerConn"].ToString();

        private SqlConnection SqlConnection;

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
            if (SqlConnection == null || SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                return false;
            }
            return true;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (SqlConnection == null)
                {
                    if (SqlServerConnectionStr != String.Empty)
                    {
                        SqlConnection = new SqlConnection(SqlServerConnectionStr);
                        SqlConnection.Open();
                    }
                    else
                    {
                        Program.LogNet.WriteError("异常", "获取数据库连接字符失败!");
                        return null;
                    }
                }
                else if(SqlConnection.State != ConnectionState.Open)
                {
                    SqlConnection.Open();
                }
                return SqlConnection;
            }
            catch (Exception ex)
            {
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
                    SqlConnection = new SqlConnection(SqlServerConnectionStr);
                    SqlConnection.Open();
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