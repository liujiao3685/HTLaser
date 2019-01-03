using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;

namespace WindowsFormsApplication1.Core
{
    public static class MySQLHelper
    {
        public static readonly string connStr = ConfigurationManager.AppSettings["MySQLConnString2"];//appSettings

        public static string connStr2 = ConfigurationManager.ConnectionStrings["MySQLConnString"].ConnectionString;//connectionStrings

        public static MySqlConnection mySqlConnection;

        static MySQLHelper()
        {
            Open();
        }

        public static bool Open()
        {
            try
            {
                if (mySqlConnection == null || mySqlConnection.State == ConnectionState.Closed)
                {
                    mySqlConnection = new MySqlConnection(connStr);
                    mySqlConnection.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static string ConStr = ConfigurationManager.ConnectionStrings["MySQLConnString"].ToString();

        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 获取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 返回结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static MySqlDataReader GetReader(string sql)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                DBConnection.Close();
                throw ex;
            }
        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                DBConnection.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DBConnection.Close();
            }
        }

        #region 启用事务执行多条SQL语句
        /// <summary>
        /// 启用事务执行多条SQL语句
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public static bool UpdateByTran(List<string> sqlList)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DBConnection;
            try
            {
                DBConnection.Open();
                cmd.Transaction = DBConnection.BeginTransaction();//开启事务
                foreach (string itemsql in sqlList)
                {
                    cmd.CommandText = itemsql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//提交事务
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    cmd.Transaction.Rollback();//回滚事务
                throw new Exception("调用事务方法时出现错误：" + ex.Message);
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;//清空事务
                DBConnection.Close();

            }
        }
        #endregion

        #region 错误信息写入日志
        /// <summary>
        /// 将错误信息写入日志文件
        /// </summary>
        /// <param name="msg"></param>
        private static void WriteLog(string msg)
        {
            FileStream fs = new FileStream("Log.text", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("[{0}]  错误信息：{1}", DateTime.Now.ToString(), msg);
            sw.Close();
            fs.Close();
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql, MySqlParameter[] param)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog("执行Update(string sql)方法发生错误，错误日志：" + ex.Message);
                throw;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 返回单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql, SqlParameter[] param)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                cmd.Parameters.AddRange(param);//添加参数
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteLog("执行GetSingleResult(string sql)方法发生错误，错误日志：" + ex.Message);
                throw;
            }
            finally
            {
                DBConnection.Close();
            }
        }
        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static MySqlDataReader GetReader(string sql, SqlParameter[] param)
        {
            MySqlConnection DBConnection = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection);
            try
            {
                DBConnection.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteLog("执行GetReader(string sql)方法发生错误，错误日志：" + ex.Message);
                DBConnection.Close();
                throw ex;
            }

        }
        #endregion


        public static int ModifyTable(string sql)
        {
            int rs = 0;
            try
            {
                if (mySqlConnection.State == ConnectionState.Closed)
                    Open();

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                rs = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rs = -1;
            }
            return rs;
        }

        public static int ModifyTable(string sql, params MySqlParameter[] parameters)
        {
            int rs = 0;
            try
            {
                if (mySqlConnection.State == ConnectionState.Closed)
                    Open();

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
                cmd.Parameters.AddRange(parameters);

                rs = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rs = -1;
            }
            return rs;
        }

        public static int ModifyTableByTrans(string sqls, params MySqlParameter[] parameters)
        {
            int rs = 0;

            if (mySqlConnection.State == ConnectionState.Closed)
                Open();
            MySqlTransaction trans = mySqlConnection.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand(sqls, mySqlConnection, trans);
            try
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                rs = cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                rs = -1;
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;//清空事务
                mySqlConnection.Close();

            }
            return rs;
        }

        public static int ModifyTableByTrans(List<string> sqls, params MySqlParameter[] parameters)
        {
            int rs = 0;

            if (mySqlConnection.State == ConnectionState.Closed)
                Open();
            MySqlTransaction trans = mySqlConnection.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand(connStr, mySqlConnection);
            try
            {
                cmd.Parameters.AddRange(parameters);
                for (int i = 0; i < sqls.Count; i++)
                {
                    cmd.CommandText = sqls[i];
                    rs += cmd.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                rs = -1;
            }
            finally
            {
                if (cmd.Transaction != null)
                    cmd.Transaction = null;//清空事务
                mySqlConnection.Close();

            }
            return rs;
        }


        //ConfigurationManager.ConnectionStrings["MySQLConnString"].ConnectionString;

        //hashtable to store the parameter information, the hash table can store any type of argument 
        //Here the hashtable is static types of static variables, since it is static, that is a definition of global use.
        //All parameters are using this hash table, how to ensure that others in the change does not affect their time to read it
        //Before ,the method can use the lock method to lock the table, does not allow others to modify.when it has readed then  unlocked table.
        //Now .NET provides a HashTable's Synchronized methods to achieve the same function, no need to manually lock, completed directly by the system framework 
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Execute a SqlCommand command that does not return value, by appointed and specified connectionstring 
        /// The parameter list using parameters that in array forms
        /// </summary>
        /// <remarks>
        /// Usage example: 
        /// int result = ExecuteNonQuery(connString, CommandType.StoredProcedure,
        /// "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid database connectionstring</param>
        /// <param name="cmdType">MySqlCommand command type (stored procedures, T-SQL statement, and so on.) </param>
        /// <param name="cmdText">stored procedure name or T-SQL statement</param>
        /// <param name="commandParameters">MySqlCommand to provide an array of parameters used in the list</param>
        /// <returns>Returns a value that means number of rows affected/returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Execute a SqlCommand command that does not return value, by appointed and specified connectionstring 
        /// The parameter list using parameters that in array forms
        /// </summary>
        /// <remarks>
        /// Usage example: 
        /// int result = ExecuteNonQuery(connString, CommandType.StoredProcedure,
        /// "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">MySqlCommand command type (stored procedures, T-SQL statement, and so on.) </param>
        /// <param name="connectionString">a valid database connectionstring</param>
        /// <param name="cmdText">stored procedure name or T-SQL statement</param>
        /// <param name="commandParameters">MySqlCommand to provide an array of parameters used in the list</param>
        /// <returns>Returns true or false </returns>
        public static bool ExecuteNonQuery(CommandType cmdType, string connectionString, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
        }
        /// <summary>
        /// Execute a SqlCommand command that does not return value, by appointed and specified connectionstring 
        /// Array of form parameters using the parameter list 
        /// </summary>
        /// <param name="conn">connection</param>
        /// <param name="cmdType">MySqlCommand command type (stored procedures, T-SQL statement, and so on.)</param>
        /// <param name="cmdText">stored procedure name or T-SQL statement</param>
        /// <param name="commandParameters">MySqlCommand to provide an array of parameters used in the list</param>
        /// <returns>Returns a value that means number of rows affected</returns>
        public static int ExecuteNonQuery(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand command that does not return value, by appointed and specified connectionstring 
        /// Array of form parameters using the parameter list 
        /// </summary>
        /// <param name="conn">sql Connection that has transaction</param>
        /// <param name="cmdType">SqlCommand command type (stored procedures, T-SQL statement, and so on.)</param>
        /// <param name="cmdText">stored procedure name or T-SQL statement</param>
        /// <param name="commandParameters">MySqlCommand to provide an array of parameters used in the list</param>
        /// <returns>Returns a value that means number of rows affected </returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Call method of sqldatareader to read data
        /// </summary>
        /// <param name="connectionString">connectionstring</param>
        /// <param name="cmdType">command type, such as using stored procedures: CommandType.StoredProcedure</param>
        /// <param name="cmdText">stored procedure name or T-SQL statement</param>
        /// <param name="commandParameters">parameters</param>
        /// <returns>SqlDataReader type of data collection</returns>
        public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// use the ExectueScalar to read a single result
        /// </summary>
        /// <param name="connectionString">connectionstring</param>
        /// <param name="cmdType">command type, such as using stored procedures: CommandType.StoredProcedure</param>
        /// <param name="cmdText">stored procedure name or T-SQL statement</param>
        /// <param name="commandParameters">parameters</param>
        /// <returns>a value in object type</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static DataSet GetDataSet(string connectionString, string cmdText, params MySqlParameter[] commandParameters)
        {
            DataSet retSet = new DataSet();
            using (MySqlDataAdapter msda = new MySqlDataAdapter(cmdText, connectionString))
            {
                msda.Fill(retSet);
            }
            return retSet;
        }

        /// <summary>
        /// cache the parameters in the HashTable
        /// </summary>
        /// <param name="cacheKey">hashtable key name</param>
        /// <param name="commandParameters">the parameters that need to cached</param>
        public static void CacheParameters(string cacheKey, params MySqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// get parameters in hashtable by cacheKey
        /// </summary>
        /// <param name="cacheKey">hashtable key name</param>
        /// <returns>the parameters</returns>
        public static MySqlParameter[] GetCachedParameters(string cacheKey)
        {
            MySqlParameter[] cachedParms = (MySqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            MySqlParameter[] clonedParms = new MySqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (MySqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        ///Prepare parameters for the implementation of the command
        /// </summary>
        /// <param name="cmd">mySqlCommand command</param>
        /// <param name="conn">database connection that is existing</param>
        /// <param name="trans">database transaction processing </param>
        /// <param name="cmdType">SqlCommand command type (stored procedures, T-SQL statement, and so on.) </param>
        /// <param name="cmdText">Command text, T-SQL statements such as Select * from Products</param>
        /// <param name="cmdParms">return the command that has parameters</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
        }
        #region parameters
        /// <summary>
        /// Set parameters
        /// </summary>
        /// <param name="ParamName">parameter name</param>
        /// <param name="DbType">data type</param>
        /// <param name="Size">type size</param>
        /// <param name="Direction">input or output</param>
        /// <param name="Value">set the value</param>
        /// <returns>Return parameters that has been assigned</returns>
        public static MySqlParameter CreateParam(string ParamName, MySqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            MySqlParameter param;


            if (Size > 0)
            {
                param = new MySqlParameter(ParamName, DbType, Size);
            }
            else
            {

                param = new MySqlParameter(ParamName, DbType);
            }


            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }


            return param;
        }

        /// <summary>
        /// set Input parameters
        /// </summary>
        /// <param name="ParamName">parameter names, such as:@ id </param>
        /// <param name="DbType">parameter types, such as: MySqlDbType.Int</param>
        /// <param name="Size">size parameters, such as: the length of character type for the 100</param>
        /// <param name="Value">parameter value to be assigned</param>
        /// <returns>Parameters</returns>
        public static MySqlParameter CreateInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// Output parameters 
        /// </summary>
        /// <param name="ParamName">parameter names, such as:@ id</param>
        /// <param name="DbType">parameter types, such as: MySqlDbType.Int</param>
        /// <param name="Size">size parameters, such as: the length of character type for the 100</param>
        /// <param name="Value">parameter value to be assigned</param>
        /// <returns>Parameters</returns>
        public static MySqlParameter CreateOutParam(string ParamName, MySqlDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// Set return parameter value 
        /// </summary>
        /// <param name="ParamName">parameter names, such as:@ id</param>
        /// <param name="DbType">parameter types, such as: MySqlDbType.Int</param>
        /// <param name="Size">size parameters, such as: the length of character type for the 100</param>
        /// <param name="Value">parameter value to be assigned<</param>
        /// <returns>Parameters</returns>
        public static MySqlParameter CreateReturnParam(string ParamName, MySqlDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }

        /// <summary>
        /// Generate paging storedProcedure parameters
        /// </summary>
        /// <param name="CurrentIndex">CurrentPageIndex</param>
        /// <param name="PageSize">pageSize</param>
        /// <param name="WhereSql">query Condition</param>
        /// <param name="TableName">tableName</param>
        /// <param name="Columns">columns to query</param>
        /// <param name="Sort">sort</param>
        /// <returns>MySqlParameter collection</returns>
        public static MySqlParameter[] GetPageParm(int CurrentIndex, int PageSize, string WhereSql, string TableName, string Columns, Hashtable Sort)
        {
            MySqlParameter[] parm = {
                                   MySQLHelper.CreateInParam("@CurrentIndex",  MySqlDbType.Int32,      4,      CurrentIndex    ),
                                   MySQLHelper.CreateInParam("@PageSize",      MySqlDbType.Int32,      4,      PageSize        ),
                                   MySQLHelper.CreateInParam("@WhereSql",      MySqlDbType.VarChar,  2500,    WhereSql        ),
                                   MySQLHelper.CreateInParam("@TableName",     MySqlDbType.VarChar,  20,     TableName       ),
                                   MySQLHelper.CreateInParam("@Column",        MySqlDbType.VarChar,  2500,    Columns         ),
                                   MySQLHelper.CreateInParam("@Sort",          MySqlDbType.VarChar,  50,     GetSort(Sort)   ),
                                   MySQLHelper.CreateOutParam("@RecordCount",  MySqlDbType.Int32,      4                       )
                                   };
            return parm;
        }
        /// <summary>
        /// Statistics data that in table
        /// </summary>
        /// <param name="TableName">table name</param>
        /// <param name="Columns">Statistics column</param>
        /// <param name="WhereSql">conditions</param>
        /// <returns>Set of parameters</returns>
        public static MySqlParameter[] GetCountParm(string TableName, string Columns, string WhereSql)
        {
            MySqlParameter[] parm = {
                                   MySQLHelper.CreateInParam("@TableName",     MySqlDbType.VarChar,  20,     TableName       ),
                                   MySQLHelper.CreateInParam("@CountColumn",  MySqlDbType.VarChar,  20,     Columns         ),
                                   MySQLHelper.CreateInParam("@WhereSql",      MySqlDbType.VarChar,  250,    WhereSql        ),
                                   MySQLHelper.CreateOutParam("@RecordCount",  MySqlDbType.Int32,      4                       )
                                   };
            return parm;
        }
        /// <summary>
        /// Get the sql that is Sorted 
        /// </summary>
        /// <param name="sort"> sort column and values</param>
        /// <returns>SQL sort string</returns>
        private static string GetSort(Hashtable sort)
        {
            string str = "";
            int i = 0;
            if (sort != null && sort.Count > 0)
            {
                foreach (DictionaryEntry de in sort)
                {
                    i++;
                    str += de.Key + " " + de.Value;
                    if (i != sort.Count)
                    {
                        str += ",";
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// execute a trascation include one or more sql sentence(author:donne yin)
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdTexts"></param>
        /// <param name="commandParameters"></param>
        /// <returns>execute trascation result(success: true | fail: false)</returns>
        public static bool ExecuteTransaction(string connectionString, CommandType cmdType, string[] cmdTexts, params MySqlParameter[][] commandParameters)
        {
            MySqlConnection myConnection = new MySqlConnection(connectionString);       //get the connection object
            myConnection.Open();                                                        //open the connection
            MySqlTransaction myTrans = myConnection.BeginTransaction();                 //begin a trascation
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myConnection;
            cmd.Transaction = myTrans;

            try
            {
                for (int i = 0; i < cmdTexts.Length; i++)
                {
                    PrepareCommand(cmd, myConnection, null, cmdType, cmdTexts[i], commandParameters[i]);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                myTrans.Commit();
            }
            catch
            {
                myTrans.Rollback();
                return false;
            }
            finally
            {
                myConnection.Close();
            }
            return true;
        }
        #endregion
    }
}

