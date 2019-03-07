using MES.Entity;
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
        public SqlConnection m_sqlCon;

        private SqlTransaction m_sqlTran;

        private DBHelper helper = DBHelper.Instance;

        private Stopwatch sw = new Stopwatch();

        private readonly static object Locker = new object();
        private static DBTool m_dbTool;
        public static DBTool Instance
        {
            get
            {
                if (m_dbTool == null)
                {
                    lock (Locker)
                    {
                        m_dbTool = new DBTool();
                    }
                }
                return m_dbTool;
            }
        }

        public DBTool()
        {
            Open();
        }

        private void Open()
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
            try
            {
                if (m_sqlCon == null || m_sqlCon.State != ConnectionState.Open)
                {
                    m_sqlCon = helper.GetConnection();
                }

                SqlCommand cmd = new SqlCommand("EXEC GetTypeCount @sum output, @pass output, @ng output ", m_sqlCon);

                cmd.Parameters.Add(new SqlParameter("@sum", SqlDbType.Int));
                cmd.Parameters["@sum"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.Int));
                cmd.Parameters["@pass"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("@ng", SqlDbType.Int));
                cmd.Parameters["@ng"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                sum = cmd.Parameters["@sum"].Value.ToString();//count
                pass = cmd.Parameters["@pass"].Value.ToString();//pass
                ng = cmd.Parameters["@ng"].Value.ToString();//ng 

            }
            catch (Exception ex)
            {
                sum = "0";//count
                pass = "0";//pass
                ng = "0";//ng 
                Program.LogNet.WriteError("异常", "获取产量异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取表中总数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetTableCount(string sql)
        {
            int count = 0;
            SqlCommand cmd = null;
            try
            {
                if (m_sqlCon == null || m_sqlCon.State != ConnectionState.Open)
                {
                    m_sqlCon = helper.GetConnection();
                }

                cmd = new SqlCommand(sql, m_sqlCon);

                count = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                cmd = null;
                count = -1;
                Program.LogNet.WriteError("异常", "GetTableCount--->" + ex.Message);
            }
            finally
            {
                if (m_sqlCon.State == ConnectionState.Open) m_sqlCon.Close();
            }

            return count;
        }

        /// <summary>
        /// 更新 / 插入拥有焊接参数的产品
        /// </summary>
        /// <param name="products">需要更新的产品</param>
        /// <returns></returns>
        public bool InsertProduct(List<Product> products)
        {
            try
            {
                //从PLC读取的数据 更新数据库
                string update = "update Product set WeldPower=@power,XPos=@xPos,YPos=@yPos,ZPos=@zPos,RPos=@rPos,Pressure=@press,Flow=@flow,WeldSpeed=@speed,WeldTime=@time " +
                    " where PNo =@pno";

                //产品入库
                string sql = "insert into Product(PNo,WeldPower,XPos,YPos,ZPos,RPos,Pressure,Flow,WeldSpeed,WeldTime) " +
                            "values(@pno,@power,@xPos,@yPos,@zPos,@rPos,@press,@flow,@speed,@time)";

                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                m_sqlTran = m_sqlCon.BeginTransaction();

                Product product = null;
                for (int i = 0; i < products.Count; i++)
                {
                    product = products[i];
                    SqlParameter[] parameters = { new SqlParameter { ParameterName = "@pno",SqlDbType = SqlDbType.NVarChar,SqlValue=product.PNo },
                        new SqlParameter{ParameterName = "@power",SqlDbType = SqlDbType.Int,SqlValue=product.WeldPower},
                        new SqlParameter{ParameterName = "@xPos",SqlDbType = SqlDbType.Decimal,SqlValue=product.XPos},
                        new SqlParameter{ParameterName = "@yPos",SqlDbType = SqlDbType.Decimal,SqlValue=product.YPos},
                        new SqlParameter{ParameterName = "@zPos",SqlDbType = SqlDbType.Decimal,SqlValue=product.ZPos},
                        new SqlParameter{ParameterName = "@rPos",SqlDbType = SqlDbType.Decimal,SqlValue=product.RPos},
                        new SqlParameter{ParameterName = "@press",SqlDbType = SqlDbType.Float,SqlValue=product.Pressure},
                        new SqlParameter{ParameterName = "@flow",SqlDbType = SqlDbType.Float,SqlValue=product.Flow},
                        new SqlParameter{ParameterName = "@speed",SqlDbType = SqlDbType.Int,SqlValue=product.WeldSpeed},
                        new SqlParameter{ParameterName = "@time",SqlDbType = SqlDbType.DateTime,SqlValue=product.WeldTime},
                    };

                    SqlCommand cmd = m_sqlCon.CreateCommand();
                    PrepareCommand(cmd, m_sqlCon, m_sqlTran, CommandType.Text, update, parameters);

                    int result = cmd.ExecuteNonQuery();

                }
                m_sqlTran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", ex.StackTrace + "--->" + ex.Message);
                m_sqlTran.Rollback();
                return false;
            }
            finally
            {
                m_sqlCon.Close();
            }
        }

        /// <summary>
        /// 使用SqlBulkCopy快速插入大量数据（100W/8s）,传入的Table结构需要与数据库中相同
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public bool InsertBatch(DataTable dt, List<Product> products)
        {
            Stopwatch sw = new Stopwatch();

            int totalCount = products.Count;

            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(m_sqlCon);
                bulkCopy.DestinationTableName = "Product";
                bulkCopy.BatchSize = totalCount;

                sw.Start();

                Product product = null;
                for (int i = 0; i < products.Count; i++)
                {
                    product = products[i];
                    DataRow dr = dt.NewRow();

                    dr[0] = product.PNo;
                    dr[1] = product.Status;
                    dr[2] = product.Coaxiality;
                    dr[3] = product.Surface;
                    dr[4] = product.WeldPower;
                    dr[5] = product.XPos;
                    dr[6] = product.YPos;
                    dr[7] = product.ZPos;
                    dr[8] = product.RPos;
                    dr[9] = product.Pressure;
                    dr[10] = product.Flow;
                    dr[11] = product.WeldSpeed;
                    dr[12] = product.WeldTime;

                    dt.Rows.Add(dr);
                }

                if (dt != null && dt.Rows.Count != 0)
                {
                    bulkCopy.WriteToServer(dt);
                    sw.Stop();
                }
                Console.WriteLine(string.Format("插入{0}条记录共花费{1}毫秒，{2}分钟.", totalCount, sw.ElapsedMilliseconds, (sw.ElapsedMilliseconds / 1000) / 60));
                return true;
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", ex.StackTrace + "--->" + ex.Message);
                return false;
            }
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
                if (m_sqlCon == null || m_sqlCon.State != ConnectionState.Open)
                {
                    m_sqlCon = helper.GetConnection();
                }

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
                Program.LogNet.WriteError("异常", "IsExist-->" + ex.Message);
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
                if (m_sqlCon == null || m_sqlCon.State != ConnectionState.Open)
                {
                    m_sqlCon = helper.GetConnection();
                }

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
                Program.LogNet.WriteError("异常:TransactionTable-->", ex.Message);
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
            try
            {
                //if (m_sqlCon == null || m_sqlCon.State != ConnectionState.Open)
                //{
                //    m_sqlCon = helper.GetConnection();
                //}

                //SqlCommand cmd = m_sqlCon.CreateCommand();
                //PrepareCommand(cmd, m_sqlCon, null, CommandType.Text, sql, ps);
                //result = cmd.ExecuteNonQuery();

                result = SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, CommandType.Text, sql, ps);

                return result;
            }
            catch (Exception ex)
            {
                result = -1;
                Program.LogNet.WriteError("异常", String.Format("ModifyTable-->SQL:{0} -- 异常信息：{1}", sql, ex.Message));
                return result;
            }
        }

        /// <summary>
        /// 根据产品编号查询指定产品
        /// </summary>
        /// <param name="pno"></param>
        /// <returns></returns>
        public Product SelectProductByNo(string pno)
        {
            string sql = "select * from Product where PNo = '" + pno + "'";

            Product product = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, null, CommandType.Text, sql, null);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        PNo = reader["PNo"].ToString(),
                        QCResult = reader["QCResult"].ToString(),
                        Coaxiality = Convert.ToDouble(reader["Coaxiality"]),
                        Surface = reader["Surface"].ToString(),
                        WeldPower = Convert.ToDouble(reader["WeldPower"]),
                        XPos = Convert.ToDouble(reader["XPos"]),
                        YPos = Convert.ToDouble(reader["YPos"]),
                        ZPos = Convert.ToDouble(reader["ZPos"]),
                        RPos = Convert.ToDouble(reader["RPos"]),
                        Pressure = Convert.ToDouble(reader["Pressure"]),
                        Flow = Convert.ToDouble(reader["Flow"]),
                        WeldSpeed = Convert.ToInt32(reader["WeldSpeed"]),
                        WeldTime = Convert.ToInt32(reader["WeldTime"])
                    };
                }

                return product;
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", "SelectProductByNo--->" + ex.Message);
                return null;
            }
            finally
            {
                cmd?.Parameters.Clear();
                reader?.Close();
            }
        }

        /// <summary>
        /// 根据用户名查询指定用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User SelectUserByName(string name)
        {
            string sql = "select * from users where name = '" + name + "'";
            User user = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                cmd = m_sqlCon.CreateCommand();
                PrepareCommand(cmd, m_sqlCon, null, CommandType.Text, sql, null);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new User()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Password = reader["Password"].ToString(),
                        Auth = reader["Auth"].ToString(),
                    };
                }

                return user;
            }
            catch (Exception)
            {
                cmd = null;
                return null;
            }
            finally
            {
                cmd = null;
                reader.Close();
                if (m_sqlCon.State == ConnectionState.Open) m_sqlCon.Close();
            }
        }

        /// <summary>
        /// 查询表数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>Tabel</returns>
        public DataTable SelectTable(string sql)
        {
            try
            {
                if (m_sqlCon == null || m_sqlCon.State != ConnectionState.Open)
                {
                    m_sqlCon = helper.GetConnection();
                }

                SqlCommand cmd = new SqlCommand(sql, m_sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", String.Format("SelectTable-->SQL:{0} -- 异常信息:{1}", sql, ex.Message));
                return null;
            }
        }

        public object SelectObject(string sql)
        {
            try
            {
                if (m_sqlCon.State != ConnectionState.Open) m_sqlCon.Open();

                SqlCommand cmd = new SqlCommand(sql, m_sqlCon);
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                if (m_sqlCon.State == ConnectionState.Open) m_sqlCon.Close();
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
                Program.LogNet.WriteError("异常", "TransactionTable--->" + ex.Message);
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
                Program.LogNet.WriteError("异常", ex.StackTrace + "--->" + ex.Message);
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