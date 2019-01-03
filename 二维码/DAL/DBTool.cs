using System.Data;
using System.Data.SqlClient;

namespace QRCode.DAL
{
    public class DbTool
    {
        public static DbHelper MDbHelper = new DbHelper();

        public static SqlConnection SqlConnection = MDbHelper.GetConection();

        /// <summary>  
        /// 用提供的参数和存在的数据库连接对象，执行SQL查询，并返回查询结果的第一行第一列的值  
        /// </summary>   
        /// <remarks>  
        /// 使用示例:    
        ///  Object obj = ExecuteScalar(connection, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));  
        /// </remarks> 
        public static object ExcuteScalar(SqlConnection con, CommandType type, string commandText, params SqlParameter[] ps)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, con, null, type, commandText, ps);

            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>  
        /// 用提供的参数和存在的数据库连接对象，执行SQL查询，并返回查询结果的DatSet结果集  
        /// </summary>  
        public static DataSet ExecuteDataSet(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, SqlConnection, null, commandType, commandText, commandParameters);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 使用事务执行SQL语句（非查询）
        /// </summary>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, commandType, commandText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 用提供的参数，执行SQL语句（非查询） 
        /// </summary>
        /// /// <remarks>  
        /// 使用示例:    
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));  
        /// </remarks> 
        public static int ExecuteNonQuery(string sql, CommandType type, string commandText, params SqlParameter[] ps)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, SqlConnection, null, type, commandText, ps);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static DataTable ExcuteTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, SqlConnection);
            da.Fill(dt);
            return dt;
        }

        public static DataTable ExcuteTable(string sql, CommandType type, params SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, SqlConnection);
            da.SelectCommand.CommandType = type;
            da.SelectCommand.Parameters.AddRange(ps);
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        public static DataSet ExcuteDataSet(string sql, CommandType type, params SqlParameter[] ps)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, SqlConnection);
            da.SelectCommand.CommandType = type;
            da.SelectCommand.Parameters.AddRange(ps);
            da.Fill(ds);
            return ds;
        }

        /// <summary>  
        /// 构建一个用于执行的命令对象  
        /// </summary>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
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
