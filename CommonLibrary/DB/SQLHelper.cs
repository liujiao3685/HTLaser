using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.IO;

namespace CommonLibrary.DB
{
    public static class SQLHelperFactory
    {
        private static Hashtable arrySQLHelper = new Hashtable();
        public static SQLHelper GetSQLHelper(string connectValue)
        {
            if (!arrySQLHelper.ContainsKey(connectValue))
            {
                //arrySQLHelper.Add(connectValue, new SQLHelper(connectValue));
                return null;
            }
            else
            {

                return ((SQLHelper)arrySQLHelper[connectValue]);
            }
        }

        public static SQLHelper AddSQLHelper(string connectValue, string connectionString)
        {
            if (!arrySQLHelper.ContainsKey(connectValue))
            {
                arrySQLHelper.Add(connectValue, new SQLHelper(connectionString));
            }

            return ((SQLHelper)arrySQLHelper[connectValue]);
        }
    }

    /// <summary>
    /// SQLHelper类封装对SQL Server数据库的添加、删除、修改和选择等操作

    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:Identifiers should be cased correctly", MessageId = "SQL")]
    public class SQLHelper
    {
        /// 连接数据源
        public static ConnectionState ConnState;
        private SqlConnection myConnection = null;
        private readonly string RETURNVALUE = "RETURNVALUE";
        private string connectionString;
        public static readonly string SQLServerConnectionString = ConfigurationManager.ConnectionStrings["SQLServerConn"].ToString();
        #region 封装所有字段

        public string ConnectString
        {
            get { return this.connectionString; }
        }
        #endregion

        private static SQLHelper sqlHelper = null;
        private static readonly object Locker = new object();
        public static SQLHelper GetInstance()
        {
            if (sqlHelper == null)
            {
                lock (Locker)
                {
                    sqlHelper = new SQLHelper();
                }
            }
            return sqlHelper;
        }

        public SQLHelper()
        {
            this.connectionString = SQLServerConnectionString;
            ConnState = ConnectionState.Closed;
        }

        public SQLHelper(string connectionString)
        {
            this.connectionString = connectionString;// EncryptStr.DecryptDes(connectionString, "1234ABCD");
            ConnState = ConnectionState.Closed;
        }

        public SQLHelper(string connectionString, string program)
        {
            this.connectionString = EncryptStr.DecryptDes(connectionString, "1234ABCD") + program;
            ConnState = ConnectionState.Closed;
        }

        public static Boolean IsConnection(string connectionString)
        {
            Boolean IsConnection = false;
            if (String.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("connectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                ConnState = connection.State;
                IsConnection = true;
            }
            catch (Exception)
            {
                ConnState = ConnectionState.Closed;
                IsConnection = false;
            }
            return IsConnection;
        }

        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        public void Open()
        {
            // 打开数据库连接
            if (myConnection == null)
            {
                myConnection = new SqlConnection(connectionString);
            }
            if (myConnection.State == ConnectionState.Closed)
            {
                try
                {
                    ///打开数据库连接
                    myConnection.Open();
                    ConnState = myConnection.State;
                }
                catch (Exception ex)
                {
                    ConnState = ConnectionState.Closed;
                    throw new Exception("Open SQL connection fail:" + ex.Message, ex);
                }
                finally
                {
                    ///关闭已经打开的数据库连接				
                }
            }
        }

        /// <summary>
        /// 关闭数据库连接

        /// </summary>
        public void Close()
        {
            ///判断连接是否已经创建
            if (myConnection != null)
            {
                ///判断连接的状态是否打开
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
                ConnState = myConnection.State;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 确认连接是否已经关闭
            if (myConnection != null)
            {
                myConnection.Dispose();
                myConnection = null;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName)
        {
            SqlCommand cmd = CreateProcCommand(procName, null);
            cmd.CommandTimeout = 60;
            try
            {
                ///执行存储过程
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("SP:" + procName + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();
            }

            ///返回存储过程的参数值

            return (int)cmd.Parameters[RETURNVALUE].Value;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回存储过程返回值</returns>
        public int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateProcCommand(procName, prams);
            cmd.CommandTimeout = 60;
            try
            {
                ///执行存储过程
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("SP:" + procName + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();
            }

            ///返回存储过程的参数值

            return (int)cmd.Parameters[RETURNVALUE].Value;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="dataReader">返回存储过程返回值</param>
        public void RunProc(string procName, out SqlDataReader dataReader)
        {
            ///创建Command
            SqlCommand cmd = CreateProcCommand(procName, null);
            cmd.CommandTimeout = 60;

            try
            {
                ///读取数据
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dataReader = null;
                throw new Exception("SP:" + procName + "--" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataSet">返回DataReader对象</param>
        public void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            ///创建Command
            SqlCommand cmd = CreateProcCommand(procName, prams);
            cmd.CommandTimeout = 60;

            try
            {
                ///读取数据
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dataReader = null;
                throw new Exception("SP:" + procName + "--" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="dataSet">返回DataSet对象</param>
        public void RunProc(string procName, ref DataSet dataSet)
        {
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            ///创建SqlDataAdapter
            SqlDataAdapter da = CreateProcDataAdapter(procName, null);

            try
            {
                ///读取数据
                da.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("SP:" + procName + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();	
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataSet">返回DataSet对象</param>
        public void RunProc(string procName, SqlParameter[] prams, ref DataSet dataSet)
        {
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            ///创建SqlDataAdapter
            SqlDataAdapter da = CreateProcDataAdapter(procName, prams);

            try
            {
                ///读取数据
                da.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("SP:" + procName + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();	
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>返回值</returns>
        public int RunSQL(string cmdText)
        {
            SqlCommand cmd = CreateSQLCommand(cmdText, null);
            cmd.CommandTimeout = 60;
            try
            {
                ///执行存储过程
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Command:" + cmdText + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();	
            }

            ///返回存储过程的参数值

            return (int)cmd.Parameters[RETURNVALUE].Value;
        }


        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回值</returns>
        public int RunSQL(string cmdText, SqlParameter[] prams)
        {
            int count = 0;
            SqlCommand cmd = CreateSQLCommand(cmdText, prams);
            cmd.CommandTimeout = 60;
            try
            {
                if (!IsConnection(SQLServerConnectionString))
                {
                    Open();
                }
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Command:" + cmdText + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();	
            }
            return count;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>		
        /// <param name="dataReader">返回DataReader对象</param>
        public void RunSQL(string cmdText, out SqlDataReader dataReader)
        {
            ///创建Command
            SqlCommand cmd = CreateSQLCommand(cmdText, null);
            cmd.CommandTimeout = 60;
            try
            {
                ///读取数据
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dataReader = null;
                throw new Exception("Command:" + cmdText + "--" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <param name="dataReader">返回DataReader对象</param>
        public void RunSQL(string cmdText, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            ///创建Command
            SqlCommand cmd = CreateSQLCommand(cmdText, prams);
            cmd.CommandTimeout = 60;
            try
            {
                ///读取数据
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dataReader = null;
                throw new Exception("Command:" + cmdText + "--" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="dataSet">返回DataSet对象</param>
        public void RunSQL(string cmdText, ref DataSet dataSet)
        {
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            ///创建SqlDataAdapter
            SqlDataAdapter da = CreateSQLDataAdapter(cmdText, null);

            try
            {
                ///读取数据
                da.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("Command:" + cmdText + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();	
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <param name="dataSet">返回DataSet对象</param>
        public void RunSQL(string cmdText, SqlParameter[] prams, ref DataSet dataSet)
        {
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            ///创建SqlDataAdapter
            SqlDataAdapter da = CreateSQLDataAdapter(cmdText, prams);

            try
            {
                ///读取数据
                da.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw new Exception("Command:" + cmdText + "--" + ex.Message, ex);
            }
            finally
            {
                ///关闭数据库的连接
                Close();	
            }
        }

        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程

        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        //private SqlCommand CreateProcCommand(string procName, SqlParameter[] prams) 
        public SqlCommand CreateProcCommand(string procName, SqlParameter[] prams)
        {
            ///打开数据库连接

            Open();

            ///设置Command
            SqlCommand cmd = new SqlCommand(procName, myConnection);
            cmd.CommandTimeout = 60;
            cmd.CommandType = CommandType.StoredProcedure;

            ///添加把存储过程的参数
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            ///添加返回参数ReturnValue
            cmd.Parameters.Add(
                new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            ///返回创建的SqlCommand对象
            return cmd;
        }

        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程

        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        //private SqlCommand CreateSQLCommand(string cmdText, SqlParameter[] prams) 
        public SqlCommand CreateSQLCommand(string cmdText, SqlParameter[] prams)
        {
            ///打开数据库连接

            Open();

            ///设置Command
            SqlCommand cmd = new SqlCommand(cmdText, myConnection);
            cmd.CommandTimeout = 60;
            ///添加把存储过程的参数
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            ///添加返回参数ReturnValue
            cmd.Parameters.Add(
                new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            ///返回创建的SqlCommand对象
            return cmd;
        }

        /// <summary>
        /// 创建一个SqlDataAdapter对象，用此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlDataAdapter对象</returns>
        public SqlDataAdapter CreateProcDataAdapter(string procName, SqlParameter[] prams)
        {
            ///打开数据库连接

            Open();

            ///设置SqlDataAdapter对象
            SqlDataAdapter da = new SqlDataAdapter(procName, myConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 60;

            ///添加把存储过程的参数
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    if (parameter.SqlDbType == SqlDbType.Udt)
                        da.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    else
                        da.SelectCommand.Parameters.Add(parameter);
                }
            }

            ///添加返回参数ReturnValue
            da.SelectCommand.Parameters.Add(
                new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            ///返回创建的SqlDataAdapter对象
            return da;
        }

        /// <summary>
        /// 创建一个SqlDataAdapter对象，用此来执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回SqlDataAdapter对象</returns>
        public SqlDataAdapter CreateSQLDataAdapter(string cmdText, SqlParameter[] prams)
        {
            ///打开数据库连接

            Open();

            ///设置SqlDataAdapter对象
            SqlDataAdapter da = new SqlDataAdapter(cmdText, myConnection);

            ///添加把存储过程的参数
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    da.SelectCommand.Parameters.Add(parameter);
                }
            }

            ///添加返回参数ReturnValue
            da.SelectCommand.Parameters.Add(
                new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            ///返回创建的SqlDataAdapter对象
            return da;
        }

        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="paramName">存储过程名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <param name="direction">参数方向</param>
        /// <param name="value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter CreateParam(string paramName, SqlDbType dbType, Int32 size, ParameterDirection direction, object value)
        {
            SqlParameter param;

            ///当参数大小为0时，不使用该参数大小值

            if (size > 0)
            {
                param = new SqlParameter(paramName, dbType, size);
            }
            else
            {
                ///当参数大小为0时，不使用该参数大小值

                param = new SqlParameter(paramName, dbType);
            }

            ///创建输出类型的参数

            param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
            {
                param.Value = value;
            }

            ///返回创建的参数

            return param;
        }

        /// <summary>
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的parameter 对象</returns>
        public SqlParameter CreateInParam(string paramName, SqlDbType dbType, int size, object value)
        {
            return CreateParam(paramName, dbType, size, ParameterDirection.Input, value);
        }

        /// <summary>
        /// 传入返回值参数

        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter CreateOutParam(string paramName, SqlDbType dbType, int size)
        {
            return CreateParam(paramName, dbType, size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 传入返回值参数

        /// </summary>
        /// <param name="paramName">存储过程名称</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public SqlParameter CreateReturnParam(string paramName, SqlDbType dbType, int size)
        {
            return CreateParam(paramName, dbType, size, ParameterDirection.ReturnValue, null);
        }
    }

    public class EncryptStr
    {
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };


        /// <summary>
        /// DES加密字符串

        /// </summary>
        /// <param name="encryptValue">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDes(string encryptValue, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptValue);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptValue;
            }
        }
        /// <summary>
        /// DES解密字符串

        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDes(string decryptValue, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptValue);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptValue;
            }
        }
    }
}
