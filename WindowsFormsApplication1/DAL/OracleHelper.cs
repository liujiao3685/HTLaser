using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace WindowsFormsApplication1.Core
{
    public class OracleHelper
    {
        private static string connectString = ConfigurationManager.ConnectionStrings["OracelString"].ConnectionString;
        public static OracleConnection m_connection = null;

        static OracleHelper()
        {
            Open();
        }

        public static bool Open()
        {
            try
            {
                m_connection = new OracleConnection(connectString);
                m_connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet SelectTable(string sql)
        {
            try
            {
                if (m_connection.State == ConnectionState.Closed)
                    m_connection.Open();

                OracleCommand cmd = new OracleCommand(sql, m_connection);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 占位符查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static DataSet SelectTable(string sql, params OracleParameter[] cmdParms)
        {
            try
            {
                if (m_connection.State == ConnectionState.Closed)
                    m_connection.Open();

                OracleCommand cmd = new OracleCommand(sql, m_connection);

                if (cmdParms != null)
                    foreach (OracleParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 增删改操作数据库
        /// </summary>
        /// <param name="sql">数据库语句</param>
        /// <returns>影响的行数</returns>
        public static int ModifyTable(string sql)
        {
            int rs = 0;
            try
            {
                if (m_connection.State == ConnectionState.Closed)
                    m_connection.Open();

                OracleCommand cmd = new OracleCommand(sql, m_connection);
                rs = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rs = -1;
            }
            return rs;
        }

        public static int ModifyTable(string sql, params OracleParameter[] cmdParms)
        {
            int rs = 0;
            try
            {
                if (m_connection.State == ConnectionState.Closed)
                    m_connection.Open();

                OracleCommand cmd = new OracleCommand(sql, m_connection);
                if (cmdParms != null)
                    foreach (OracleParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);

                rs = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rs = -1;
            }
            return rs;
        }

        /// <summary>
        /// 事务执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool ModifyTableByTrans(string sql, params OracleParameter[] cmdParms)
        {
            if (m_connection.State == ConnectionState.Closed)
                m_connection.Open();

            //开启事务
            OracleTransaction transaction = m_connection.BeginTransaction();
            OracleCommand cmd = new OracleCommand();
            try
            {
                cmd.Transaction = transaction;
                cmd.Connection = m_connection;
                cmd.Parameters.AddRange(cmdParms);
                //if (cmdParms != null)
                //    foreach (OracleParameter parm in cmdParms)
                //        cmd.Parameters.Add(parm);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                transaction.Dispose();
                m_connection.Close();
            }
        }

        /// <summary>
        /// 事务执行批量SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool ModifyTableByTrans(List<string> sqls, params OracleParameter[] cmdParms)
        {
            if (m_connection.State == ConnectionState.Closed)
                m_connection.Open();

            //开启事务
            OracleTransaction transaction = m_connection.BeginTransaction();
            OracleCommand cmd = new OracleCommand();
            cmd.Transaction = transaction;
            cmd.Connection = m_connection;

            try
            {
                cmd.Parameters.AddRange(cmdParms);

                //if (cmdParms != null)
                //    foreach (OracleParameter parm in cmdParms)
                //        cmd.Parameters.Add(parm);

                foreach (var item in sqls)
                {
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                transaction.Dispose();
                m_connection.Close();
            }
        }

        /// <summary>
        /// 执行返回的第一行的第一列的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            if (m_connection.State == ConnectionState.Closed)
                m_connection.Open();

            object obj;

            try
            {
                OracleCommand cmd = new OracleCommand(sql, m_connection);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return null;
            }
            return obj;
        }

    }
}
