using MES.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace MES.DAL
{
    public class DbUserHelper
    {
        private string Database_ConntectString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;

        private SQLiteConnection m_sqlConnection;

        public SQLiteCommand m_sqlCommand;

        private static DbUserHelper dbtool = null;

        private string sql = "Select * from users";

        private DbUserHelper()
        {
            Init();
        }

        public static DbUserHelper GetInstance()
        {
            if (dbtool == null)
            {
                dbtool = new DbUserHelper();
            }
            return dbtool;
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        private void Init()
        {
            /// 连接到数据库
            GetSQLConnection();

            /// 创建用户表
            CreateTable("create table if not exists [users] (name varchars(20),password varchar(20),auth varchars(20));");

            //创建默认用户
            CreateAdmin();
        }

        private void CreateAdmin()
        {
            User user = SelectOneData("程序员");
            if (user == null || String.IsNullOrEmpty(user.Name))
            {
                List<User> list =
                    new List<User>() { new User("操作员", "123", "操作员"), new User("管理员", "ht2018", "管理员"), new User("程序员", "admin", "程序员") };
                CreateMultiData(list);
            }
        }

        public SQLiteConnection GetSQLConnection()
        {
            m_sqlConnection = new SQLiteConnection(Database_ConntectString);
            m_sqlConnection.Open();
            return m_sqlConnection;
        }

        public SQLiteCommand GetCommand()
        {
            m_sqlCommand = new SQLiteCommand(sql, m_sqlConnection);
            return m_sqlCommand;
        }

        /// <summary>
        /// 一次插入多条数据-事务操作
        /// </summary>
        /// <param name="list"></param>
        public void CreateMultiData(List<User> list)
        {
            DbTransaction trans = m_sqlConnection.BeginTransaction();//开启事务
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConnection);
            try
            {
                //创建默认用户
                cmd.CommandText = "insert into users (name,password,auth) values(@name,@password,@auth);";
                foreach (User item in list)
                {
                    cmd.Parameters.Add(new SQLiteParameter("@name", DbType.String));
                    cmd.Parameters.Add(new SQLiteParameter("@password", DbType.String));
                    cmd.Parameters.Add(new SQLiteParameter("@auth", DbType.String));
                    cmd.Parameters["@name"].Value = item.Name;
                    cmd.Parameters["@password"].Value = item.Password;
                    cmd.Parameters["@auth"].Value = item.Auth;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();//提交事务
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int CreateTable(string sql)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, m_sqlConnection);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 查询指定表中所有数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable SelectData(string tableName)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = String.Format("Select * from [{0}];", tableName);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, m_sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dt = ds.Tables[0];

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询并返回表集合
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public List<User> SelectDataList(string tbName)
        {
            DbTransaction tran = m_sqlConnection.BeginTransaction();
            try
            {
                List<User> list = new List<User>();
                User user;

                string sql = String.Format("Select * from [{0}];", tbName);

                SQLiteCommand cmd = new SQLiteCommand(sql, m_sqlConnection);

                SQLiteDataReader reader = cmd.ExecuteReader();
                tran.Commit();

                while (reader.Read())
                {
                    user = new User();
                    user.Name = reader["name"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Auth = reader["auth"].ToString();
                    list.Add(user);
                }
                return list;
            }
            catch (Exception)
            {
                tran.Rollback();
                return null;
            }
        }

        /// <summary>
        /// 根据用户名查询指定用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User SelectOneData(string name)
        {
            try
            {
                User user = new User();
                string sql = String.Format("select * from users where name = '{0}';", name);
                SQLiteCommand cmd = new SQLiteCommand(sql, m_sqlConnection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user.Name = reader["name"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Auth = reader["auth"].ToString();
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int InsertData(string name, string password, string auth)
        {
            try
            {
                User user = SelectOneData(name);
                if (user.Name != name)
                {
                    string sql = String.Format("insert into [users] (name,password,auth) " +
                                               "values ('{0}','{1}','{2}')", name, password, auth);

                    SQLiteCommand cmd = new SQLiteCommand(sql, m_sqlConnection);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 删除指定用户名信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int DeleteData(string name)
        {
            try
            {
                string sql = String.Format("delete from [users] where name = '{0}'", name);
                SQLiteCommand cmd = new SQLiteCommand(sql, m_sqlConnection);
                int res = cmd.ExecuteNonQuery();
                return res;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        /// <summary>
        /// 更新指定用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int UpdateData(string name, string password)
        {
            try
            {
                string sql = String.Format("update [users] set password ='{0}' where name='{1}'; ", password, name);
                SQLiteCommand cmd = new SQLiteCommand(sql, m_sqlConnection);

                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void Dispose()
        {
            this.m_sqlConnection.Dispose();
            this.m_sqlCommand.Dispose();
        }

    }
}
