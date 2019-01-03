using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MES.DAL
{
    public class DBHelper
    {
        //数据库连接字符
        private static string DataBaseConnectStr = "Data Source=Dell7577;Initial Catalog=ProductsDb;User Id=HTLaser;Password=ht2018";

        private SqlConnection m_sqlCon;

        private static DBHelper m_dbHelper;

        public DBHelper()
        {

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
                        MessageBox.Show("获取数据库连接字符失败！");
                        return null;
                    }
                }
                return m_sqlCon;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败，请检查配置文件后重启软件！");
                return null;
            }
        }

    }
}