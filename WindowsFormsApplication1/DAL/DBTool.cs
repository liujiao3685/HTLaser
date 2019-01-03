using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using HslCommunication.LogNet;

namespace MES.DAL
{
    public class DBTool
    {
        public static SqlConnection m_sqlCon;

        private static SqlTransaction m_sqlTran;

        private static DBHelper helper = DBHelper.Instance;

        private static Stopwatch sw = new Stopwatch();

        public DBTool()
        {
            m_sqlCon = helper.GetConnection();
            if (m_sqlCon != null && m_sqlCon.State != ConnectionState.Open)
            {
                m_sqlCon.Open();
            }
        }

        /// <summary>
        /// 获取表中总数据-存储过程
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="pass"></param>
        /// <param name="ng"></param>
        public void GetTableCountByProcedure(out string sum, out string pass, out string ng)
        {
            sw.Start();
            SqlCommand Cmd = null;
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();
                Cmd = new SqlCommand("exec GetTypeCount @sum output, @pass output, @ng output; ", m_sqlCon);

                Cmd.Parameters.Add(new SqlParameter("@sum", SqlDbType.Int));
                Cmd.Parameters["@sum"].Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.Int));
                Cmd.Parameters["@pass"].Direction = ParameterDirection.Output;
                Cmd.Parameters.Add(new SqlParameter("@ng", SqlDbType.Int));

                Cmd.Parameters["@ng"].Direction = ParameterDirection.Output;

                //Cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                //Cmd.Parameters["@id"].Value = id;   //参数
                //Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.ExecuteNonQuery();

                sum = Cmd.Parameters["@sum"].Value.ToString();//count
                pass = Cmd.Parameters["@pass"].Value.ToString();//pass
                ng = Cmd.Parameters["@ng"].Value.ToString();//ng 

            }
            catch (Exception ex)
            {
                sum = "0";//count
                pass = "0";//pass
                ng = "0";//ng 

            }

            sw.Stop();
            Console.WriteLine("GetTableCountByProcedure耗时：" + sw.Elapsed.ToString());

        }

        /// <summary>
        /// 获取表中总数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetTableCount(string sql)
        {
            int count = 0;
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                SqlCommand cmd = new SqlCommand(sql, m_sqlCon);

                count = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                count = -1;
            }

            return count;
        }

        /// <summary>
        /// 检测数据库中是否存在某数据
        /// 1:存在，2:不存在
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>0：不存在，1:存在，2:异常</returns>
        public int IsExist(string sql)
        {
            int type = 2;
            SqlDataReader reader = null;
            SqlCommand cmd = null;
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                cmd = new SqlCommand(sql, m_sqlCon);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    type = 1;
                }
            }
            catch (Exception ex)
            {
                type = -1;//异常
            }
            finally
            {
                reader?.Close();
                cmd?.Dispose();
            }
            return type;
        }

        /// <summary>
        /// 使用事务执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int TransactionTable(string sql)
        {
            int result = 0;
            long ticks = 0;
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                //开始事务
                m_sqlTran = m_sqlCon.BeginTransaction();

                SqlCommand cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, m_sqlTran, CommandType.Text, sql, null);
                //PrepareCommand(cmd, m_sqlCon, null, CommandType.Text, sql, null);

                result = cmd.ExecuteNonQuery();

                //提交事务
                m_sqlTran.Commit();

                return result;
            }
            catch (Exception ex)
            {
                result = -1;
                m_sqlTran.Rollback();
                return result;
            }
            finally
            {
                m_sqlTran.Dispose();
                m_sqlCon.Close();

                sw.Stop();
                ticks = sw.ElapsedMilliseconds;

                Debug.WriteLine("m_sqlCon---------------->入库耗时：" + ticks + "ms");
            }
        }

        /// <summary>
        /// 正常执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public int ModifyTable(string sql, params SqlParameter[] ps)
        {
            int result = 0;
            SqlCommand cmd = null;
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, null, CommandType.Text, sql, ps);

                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                result = -1;
                return result;
            }
            finally
            {
                cmd?.Dispose();
            }
        }

        /// <summary>
        /// 查询表数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>Tabel</returns>
        public static DataTable SelectTable(string sql)
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

        /// <summary>
        /// 使用事务操作数据库（增加、更新表）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cmdText"></param>
        /// <param name="ps"></param>
        /// <returns>所影响的行数</returns>
        public int TransactionTable(string cmdText, params SqlParameter[] ps)
        {
            int result = 0;
            try
            {
                //开始事务
                m_sqlTran = m_sqlCon.BeginTransaction();

                SqlCommand cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, m_sqlTran, CommandType.Text, cmdText, ps);

                result = cmd.ExecuteNonQuery();

                //提交事务
                m_sqlTran.Commit();

                return result;
            }
            catch (Exception ex)
            {
                result = -1;
                m_sqlTran.Rollback();
                return result;
            }
        }

        /// <summary>
        /// 用提供的参数和存在的数据库连接对象，执行SQL查询，并返回查询结果的第一行第一列的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cmdText"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public object ExcuteScalar(CommandType type, string cmdText, params SqlParameter[] ps)
        {
            try
            {
                SqlCommand cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, null, type, cmdText, ps);

                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return val;
            }
            catch (Exception ex)
            {
                return null;
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