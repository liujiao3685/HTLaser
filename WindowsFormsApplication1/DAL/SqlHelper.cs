using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.DAL
{
    public class SqlHelper
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
        [SuppressMessage("Microsoft.Naming", "CA1709:Identifiers should be cased correctly", MessageId = "SQL")]
        public class SQLHelper
        {
            /// 连接数据源

            public ConnectionState ConnState;
            private SqlConnection myConnection = null;
            private readonly string RETURNVALUE = "RETURNVALUE";
            private string connectionString;

            #region 封装所有字段

            public string ConnectString
            {
                get { return this.connectionString; }
            }
            #endregion

            public SQLHelper()
            {
                this.connectionString = "";
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
                    //Close();
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
                    //Close();
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
                    //Close();	
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
                    //Close();	
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
                    //Close();	
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
                SqlCommand cmd = CreateSQLCommand(cmdText, prams);
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
                    //Close();	
                }

                ///返回存储过程的参数值

                return (int)cmd.Parameters[RETURNVALUE].Value;
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
                    //Close();	
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
                    //Close();	
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



        public static string Sql_676 = @"INSERT [dbo].[T_Define_Product] ([F_Id], [Customer], [ProductCode], [FullName], [FigureNumber], [ClientNumber], [Model], [CustomerCode], [Model_Series], [LHRH], [Atlasjob], [SortCode], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [Print_code1], [Print_code2], [Print_code3], [Print_code4], [Print_code5], [Print_code6], [Print_code7], [Print_code8], [Year_Rule]) VALUES (N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'139d7b9c-1eb8-41b1-ba9f-352f45f0adcb', N'H3Z', N'H3Z', N'DAB', N'DAB', N'H3Z', N'Benz', N'S级-高级轿车', N'LH', N'TMBCB', 1, NULL, NULL, CAST(0x0000A930010EC920 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9CD01037EFF AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'71e17057-553b-43b0-bc17-441595207874', N'ST040', N'MiddleStation', N'1', N'03501', N'ST050', 4, 1, 0, NULL, NULL, NULL, CAST(0x0000A9C00160E180 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9C00160E180 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'71e17057-553b-43b0-bc17-441595207874', N'ST020', N'FirstStation', N'1', N'02001', N'ST030', 2, 1, 0, NULL, NULL, NULL, CAST(0x0000A9C001517C7C AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9C001517C7C AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'71e17057-553b-43b0-bc17-441595207874', N'ST030', N'MiddleStation', N'1', N'03001', N'ST040', 3, 1, 0, NULL, NULL, NULL, CAST(0x0000A9C00155C7B4 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9C00155C7B4 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'71e17057-553b-43b0-bc17-441595207874', N'ST010', N'FirstStation', N'1', N'01001', NULL, 1, 1, 1, N'T_ST040', N'string01', NULL, CAST(0x0000A8C1009E0F3A AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A91B01043B18 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'71e17057-553b-43b0-bc17-441595207874', N'ST050', N'EndStation', N'1', N'05001', NULL, 5, 1, 0, NULL, NULL, NULL, CAST(0x0000A8C1009E0F3A AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A91B01043B18 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')


INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'9bf7c51b-ac8f-4e5b-9f7c-5897a390a104', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST010', N'扫描靠背骨架条码 ', 1, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9890116820C AS DateTime), N'admin', CAST(0x0000A9890116820C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'84a52a52-5fa0-4dea-8bd5-cdfe1bf581a9', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST010', N'扫描靠背二维码', 2, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9890117E19C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'78cf41b6-e11f-4552-a4d8-71f0203ea989', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST010', N'扫描靠背面套条码', 3, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A989011827EC AS DateTime), N'admin', CAST(0x0000A989011827EC AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'd1e05e8e-8dcd-42e0-a205-e9b136a1a7d8', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST010', N'扫描座椅面套序列号', 1, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A98901186E3C AS DateTime), N'admin', CAST(0x0000A98901186E3C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'bdbf729e-83f7-497b-8955-911a90164359', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST010', N'扫描加热垫条码', 5, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9890118B48C AS DateTime), N'admin', CAST(0x0000A9890118B48C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'df51b9d8-af68-4ea4-b451-6ffd595058df', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST020', N'扫描座椅座盆条码', 1, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A992015826BC AS DateTime), N'admin', CAST(0x0000A992015826BC AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'a217091e-c2a5-4e7a-87e5-6815ce30ae02', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST020', N'生产总成号条码', 1, 1, N'SZP,SDC', 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A99201586D0C AS DateTime), N'admin', CAST(0x0000A99201586D0C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'6ff638ee-26e2-4264-b8aa-3978660dcfb0', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST020', N'扫描座盆骨架条码', 2, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A9920158F9AC AS DateTime), N'admin', CAST(0x0000A9920158F9AC AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'e88577fa-ac12-42b4-a742-5642fc486b88', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST030', N'扫描气囊面套条码', 1, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A99300A20D8C AS DateTime), N'admin', CAST(0x0000A99300A20D8C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'17189a97-2c71-47ff-933f-384104641518', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST030', N'扫描加热垫条码', 2, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A99300A2E07C AS DateTime), N'admin', CAST(0x0000A99300A2E07C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'9c57a0e8-242b-4929-87df-d0c63e733345', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'扫描靠背任务单', 1, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A9C00156EDD8 AS DateTime), N'admin', CAST(0x0000A9CD010C1C23 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'e8e3fe0c-f335-482f-966d-dab35983fc13', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'扫描安全带条码', 2, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9C001579440 AS DateTime), N'admin', CAST(0x0000A9CD010C2EEB AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'e1e63b91-c670-48e2-8725-16f0688cfea8', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'第一道拧螺母工序', 3, 0, NULL, 1, NULL, 1, N'螺母A', 0, 1, NULL, CAST(0x0000A9C001585DD0 AS DateTime), N'admin', CAST(0x0000A9C001585DD0 AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'7f7bb13c-57a0-4e0e-9aeb-7b9ee1c747f5', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'第二道拧螺母工序', 4, 0, NULL, 1, NULL, 1, N'螺母B', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'62f6934d-c4e9-4780-a08d-e4b9f8221dcb', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'第三道拧螺母工序', 5, 0, NULL, 1, NULL, 1, N'螺母C', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'be2f5b5c-b304-4a72-9bf3-9192b393da48', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'第四道拧螺母工序', 6, 0, NULL, 1, NULL, 1, N'螺母D', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'6ead2599-4af8-42be-a627-ec3e0b7c7cc6', N'38e69e0f-f658-47f4-8804-63f5e8f2d8cc', N'ST040', N'第五道拧螺母工序', 7, 0, NULL, 1, NULL, 1, N'螺母E', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)


INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'9bf7c51b-ac8f-4e5b-9f7c-5897a390a104', N'A001', 1, NULL, N'string01', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'9bf7c51b-ac8f-4e5b-9f7c-5897a390a104', N'A002', 2, NULL, NULL, NULL, N'85fdbe2d-8763-4d41-a671-d4e497e60de2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'84a52a52-5fa0-4dea-8bd5-cdfe1bf581a9', N'A001', 1, NULL, N'string02', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'78cf41b6-e11f-4552-a4d8-71f0203ea989', N'A001', 1, NULL, N'string02', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'78cf41b6-e11f-4552-a4d8-71f0203ea989', N'A002', 2, NULL, NULL, NULL, N'eb50d2b7-ff06-43d1-a3dc-ffa93d8a7032', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'bdbf729e-83f7-497b-8955-911a90164359', N'A001', 1, NULL, N'string04', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'bdbf729e-83f7-497b-8955-911a90164359', N'A002', 2, NULL, NULL, NULL, N'4d36cabd-957e-4111-be29-e2ded4daa71e', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'df51b9d8-af68-4ea4-b451-6ffd595058df', N'A001', 1, NULL, N'string01', N'T_ST020', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'df51b9d8-af68-4ea4-b451-6ffd595058df', N'A002', 2, NULL, NULL, NULL, N'3b8cdefa-8aaa-40b7-8896-4537c2e0f1e5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'6ff638ee-26e2-4264-b8aa-3978660dcfb0', N'A001', 1, NULL, N'string02', N'T_ST020', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'6ff638ee-26e2-4264-b8aa-3978660dcfb0', N'A002', 2, NULL, NULL, NULL, N'9999a968-636c-4383-ac7b-9bf68e8b1d81', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'e88577fa-ac12-42b4-a742-5642fc486b88', N'A001', 1, NULL, N'string01', N'T_ST030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'17189a97-2c71-47ff-933f-384104641518', N'A001', 1, NULL, N'string02', N'T_ST030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'17189a97-2c71-47ff-933f-384104641518', N'A002', 2, NULL, NULL, NULL, N'4d36cabd-957e-4111-be29-e2ded4daa71e', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'9c57a0e8-242b-4929-87df-d0c63e733345', N'A001', 1, NULL, N'string01', N'T_ST040', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'9c57a0e8-242b-4929-87df-d0c63e733345', N'A002', 2, NULL, NULL, NULL, N'89c968aa-e28b-454f-93be-a78e04aab1df', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'9c57a0e8-242b-4929-87df-d0c63e733345', N'A003', 3, NULL, N'barcode', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'e8e3fe0c-f335-482f-966d-dab35983fc13', N'A001', 1, NULL, N'string02', N'T_ST040', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'df51b9d8-af68-4ea4-b451-6ffd595058df', N'A004', 3, NULL, NULL, NULL, NULL, 4, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'9c57a0e8-242b-4929-87df-d0c63e733345', N'A004', 4, NULL, NULL, NULL, NULL, 4, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'd1e05e8e-8dcd-42e0-a205-e9b136a1a7d8', N'A002', 1, NULL, NULL, NULL, N'a4868e79-7ef4-4349-8ae4-4afd159757c3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'e88577fa-ac12-42b4-a742-5642fc486b88', N'A002', 1, NULL, NULL, NULL, N'1977986d-9ef6-4b26-ac5b-c4e5c35fb1a6', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)


SELECT * FROM T_Define_Product WHERE Model='H3Z'--1
SELECT * FROM T_Define_Process WHERE ProductID IN (SELECT F_Id FROM T_Define_Product WHERE Model='H3Z')--5
SELECT * FROM T_Product_Step_Main WHERE Porduct_ID IN (SELECT F_Id FROM T_Define_Product WHERE Model='H3Z')--17
SELECT * FROM T_Product_Step_List WHERE Step_Id IN
(SELECT F_Id FROM T_Product_Step_Main WHERE Porduct_ID IN (SELECT F_Id FROM T_Define_Product WHERE Model='H3Z'))--22


";
        public static string Sql_677 = @"INSERT [dbo].[T_Define_Product] ([F_Id], [Customer], [ProductCode], [FullName], [FigureNumber], [ClientNumber], [Model], [CustomerCode], [Model_Series], [LHRH], [Atlasjob], [SortCode], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [Print_code1], [Print_code2], [Print_code3], [Print_code4], [Print_code5], [Print_code6], [Print_code7], [Print_code8], [Year_Rule]) VALUES (N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'139d7b9c-1eb8-41b1-ba9f-352f45f0adcb', N'H0I', N'H0I', N'DAB', N'DAB', N'H0I', N'Benz', N'S级-高级轿车', N'LH', N'TMBCB', 1, NULL, NULL, CAST(0x0000A930010EC920 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9CD01037EFF AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)


INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'71e17057-553b-43b0-bc17-441595207874', N'ST040', N'MiddleStation', N'1', N'03501', N'ST050', 4, 1, 0, NULL, NULL, NULL, CAST(0x0000A9C00160E180 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9C00160E180 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'71e17057-553b-43b0-bc17-441595207874', N'ST020', N'FirstStation', N'1', N'02001', N'ST030', 2, 1, 0, NULL, NULL, NULL, CAST(0x0000A9C001517C7C AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9C001517C7C AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'71e17057-553b-43b0-bc17-441595207874', N'ST030', N'MiddleStation', N'1', N'03001', N'ST040', 3, 1, 0, NULL, NULL, NULL, CAST(0x0000A9C00155C7B4 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A9C00155C7B4 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'71e17057-553b-43b0-bc17-441595207874', N'ST010', N'FirstStation', N'1', N'01001', NULL, 1, 1, 1, N'T_ST040', N'string01', NULL, CAST(0x0000A8C1009E0F3A AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A91B01043B18 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')
INSERT [dbo].[T_Define_Process] ([F_Id], [ProductID], [LineID], [StationID], [StationType], [EventNo], [Status], [NextStationID], [SortCode], [EnabledMark], [IsSpecial], [NextStationTBName], [BarcodeFldName], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId]) VALUES (NEWID(), N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'71e17057-553b-43b0-bc17-441595207874', N'ST050', N'EndStation', N'1', N'05001', NULL, 5, 1, 0, NULL, NULL, NULL, CAST(0x0000A8C1009E0F3A AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', CAST(0x0000A91B01043B18 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba')


INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'2f23e11f-0706-4c30-ac8b-84e3e6e14328', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST010', N'扫描靠背骨架条码 ', 1, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9890116820C AS DateTime), N'admin', CAST(0x0000A9890116820C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'0405daf2-c5c4-4363-a582-04d39e15c698', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST010', N'扫描靠背二维码', 2, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9890117E19C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'3791086e-df7c-4f0e-9444-e85ddab0b1c1', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST010', N'扫描靠背面套条码', 3, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A989011827EC AS DateTime), N'admin', CAST(0x0000A989011827EC AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'84064f15-9f46-4df5-b66c-a0736ec2f9a4', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST010', N'扫描座椅面套序列号', 1, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A98901186E3C AS DateTime), N'admin', CAST(0x0000A98901186E3C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'8df68e0e-438b-456a-814f-d89f72b78172', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST010', N'扫描加热垫条码', 5, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9890118B48C AS DateTime), N'admin', CAST(0x0000A9890118B48C AS DateTime), N'admin', CAST(0x0000A9890117E19C AS DateTime), N'admin')
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'36a0eacb-6d23-40c8-ba00-4ae028c848ab', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST020', N'扫描座椅座盆条码', 1, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A992015826BC AS DateTime), N'admin', CAST(0x0000A992015826BC AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'23d34095-45eb-4b86-9465-03efec9b66fc', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST020', N'生产总成号条码', 1, 1, N'SZP,SDC', 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A99201586D0C AS DateTime), N'admin', CAST(0x0000A99201586D0C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'169cf44f-fea5-45ab-b58d-e62fc3324842', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST020', N'扫描座盆骨架条码', 2, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A9920158F9AC AS DateTime), N'admin', CAST(0x0000A9920158F9AC AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'410c2272-5566-4bec-96ba-36e7322f6d10', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST030', N'扫描气囊面套条码', 1, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A99300A20D8C AS DateTime), N'admin', CAST(0x0000A99300A20D8C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'a5c062d4-b36f-4761-9209-b87038eb9707', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST030', N'扫描加热垫条码', 2, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A99300A2E07C AS DateTime), N'admin', CAST(0x0000A99300A2E07C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'354d2b80-e478-41b9-9fa1-03b1099216dd', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'扫描靠背任务单', 1, 0, NULL, 1, NULL, 0, NULL, 0, 1, NULL, CAST(0x0000A9C00156EDD8 AS DateTime), N'admin', CAST(0x0000A9CD010C1C23 AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'7e35ab92-d8cc-4eab-b8f1-994ea4d21708', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'扫描安全带条码', 2, 0, NULL, 1, NULL, 0, NULL, 1, 0, NULL, CAST(0x0000A9C001579440 AS DateTime), N'admin', CAST(0x0000A9CD010C2EEB AS DateTime), N'9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'58e847f6-0af7-40b8-b92f-5ef97fc1377b', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'第一道拧螺母工序', 3, 0, NULL, 1, NULL, 1, N'螺母A', 0, 1, NULL, CAST(0x0000A9C001585DD0 AS DateTime), N'admin', CAST(0x0000A9C001585DD0 AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'24c509cc-473c-4324-8e7c-5eced65d2e52', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'第二道拧螺母工序', 4, 0, NULL, 1, NULL, 1, N'螺母B', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'5161c5f0-ab1e-4a49-a9aa-a6f4e93a1ffb', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'第三道拧螺母工序', 5, 0, NULL, 1, NULL, 1, N'螺母C', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'ba2a58da-9c72-4d87-90c2-8e399f240563', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'第四道拧螺母工序', 6, 0, NULL, 1, NULL, 1, N'螺母D', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)
INSERT [dbo].[T_Product_Step_Main] ([F_Id], [Porduct_ID], [StationID], [Step_Name], [SortCode], [Is_Auto_Generate], [Replace_Rule], [Is_NG], [NG_Num], [Is_Read_Torque], [Nut_Name], [F_DeleteMark], [EnabledMark], [Description], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (N'eed8faac-1450-4039-8730-c0e724635ea4', N'19433d8d-b40d-41bb-aa99-425f8a042bf6', N'ST040', N'第五道拧螺母工序', 7, 0, NULL, 1, NULL, 1, N'螺母E', 0, 1, NULL, CAST(0x0000A9C00158A54C AS DateTime), N'admin', CAST(0x0000A9C00158A54C AS DateTime), N'admin', NULL, NULL)



INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'2f23e11f-0706-4c30-ac8b-84e3e6e14328', N'A001', 1, NULL, N'string01', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'2f23e11f-0706-4c30-ac8b-84e3e6e14328', N'A002', 2, NULL, NULL, NULL, N'85fdbe2d-8763-4d41-a671-d4e497e60de2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'0405daf2-c5c4-4363-a582-04d39e15c698', N'A001', 1, NULL, N'string02', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'3791086e-df7c-4f0e-9444-e85ddab0b1c1', N'A001', 1, NULL, N'string02', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'3791086e-df7c-4f0e-9444-e85ddab0b1c1', N'A002', 2, NULL, NULL, NULL, N'eb50d2b7-ff06-43d1-a3dc-ffa93d8a7032', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'8df68e0e-438b-456a-814f-d89f72b78172', N'A001', 1, NULL, N'string04', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'8df68e0e-438b-456a-814f-d89f72b78172', N'A002', 2, NULL, NULL, NULL, N'4d36cabd-957e-4111-be29-e2ded4daa71e', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'36a0eacb-6d23-40c8-ba00-4ae028c848ab', N'A001', 1, NULL, N'string01', N'T_ST020', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'36a0eacb-6d23-40c8-ba00-4ae028c848ab', N'A002', 2, NULL, NULL, NULL, N'3b8cdefa-8aaa-40b7-8896-4537c2e0f1e5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'169cf44f-fea5-45ab-b58d-e62fc3324842', N'A001', 1, NULL, N'string02', N'T_ST020', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'169cf44f-fea5-45ab-b58d-e62fc3324842', N'A002', 2, NULL, NULL, NULL, N'9999a968-636c-4383-ac7b-9bf68e8b1d81', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'410c2272-5566-4bec-96ba-36e7322f6d10', N'A001', 1, NULL, N'string01', N'T_ST030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'a5c062d4-b36f-4761-9209-b87038eb9707', N'A001', 1, NULL, N'string02', N'T_ST030', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'a5c062d4-b36f-4761-9209-b87038eb9707', N'A002', 2, NULL, NULL, NULL, N'4d36cabd-957e-4111-be29-e2ded4daa71e', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'354d2b80-e478-41b9-9fa1-03b1099216dd', N'A001', 1, NULL, N'string01', N'T_ST040', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'354d2b80-e478-41b9-9fa1-03b1099216dd', N'A002', 2, NULL, NULL, NULL, N'89c968aa-e28b-454f-93be-a78e04aab1df', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'354d2b80-e478-41b9-9fa1-03b1099216dd', N'A003', 3, NULL, N'barcode', N'T_ST010', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'7e35ab92-d8cc-4eab-b8f1-994ea4d21708', N'A001', 1, NULL, N'string02', N'T_ST040', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'36a0eacb-6d23-40c8-ba00-4ae028c848ab', N'A004', 3, NULL, NULL, NULL, NULL, 4, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'354d2b80-e478-41b9-9fa1-03b1099216dd', N'A004', 4, NULL, NULL, NULL, NULL, 4, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'84064f15-9f46-4df5-b66c-a0736ec2f9a4', N'A002', 1, NULL, NULL, NULL, N'a4868e79-7ef4-4349-8ae4-4afd159757c3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[T_Product_Step_List] ([F_Id], [Step_Id], [OperationCode], [SortCode], [Task_Barcode_FieldName], [Parts_BarCode_FieldName], [Station_Table_Name], [BarCode_Type_Id], [Product_Type_Start_Index], [Product_Type_Length], [F_DeleteMark], [EnabledMark], [F_CreatorTime], [F_CreatorUserId], [F_LastModifyTime], [F_LastModifyUserId], [F_DeleteTime], [F_DeleteUserId]) VALUES (NEWID(), N'410c2272-5566-4bec-96ba-36e7322f6d10', N'A002', 1, NULL, NULL, NULL, N'6efb5192-d1dd-4bb7-8fe7-5526e890ae8d', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)


SELECT * FROM T_Define_Product WHERE Model='H0I'--1
SELECT * FROM T_Define_Process WHERE ProductID IN (SELECT F_Id FROM T_Define_Product WHERE Model='H0I')--5
SELECT * FROM T_Product_Step_Main WHERE Porduct_ID IN (SELECT F_Id FROM T_Define_Product WHERE Model='H0I')--17
SELECT * FROM T_Product_Step_List WHERE Step_Id IN
(SELECT F_Id FROM T_Product_Step_Main WHERE Porduct_ID IN (SELECT F_Id FROM T_Define_Product WHERE Model='H0I'))--22


";

    }
}
