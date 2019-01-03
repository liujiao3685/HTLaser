using System;
using System.Configuration;
using System.Data.SqlClient;

namespace QRCode.DAL
{
    public class DbHelper
    {
        /// <summary>
        /// 连接数据库字符
        /// </summary>
        public static string MyConnectionStr = ConfigurationManager.ConnectionStrings["MyDatabase"].ToString();

        private SqlConnection m_sqlConnection = null;

        #region Instance...
        private static DbHelper m_dbHelper = null;

        public static DbHelper GetInstance()
        {
            if (m_dbHelper == null)
            {
                m_dbHelper = new DbHelper();
            }
            return m_dbHelper;
        }
        #endregion

        public DbHelper()
        {
            Init();
        }

        private void Init()
        {
            GetConection();
        }

        public SqlConnection GetConection()
        {
            try
            {
                m_sqlConnection = new SqlConnection(MyConnectionStr);
                m_sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
            return m_sqlConnection;
        }

    }
}
