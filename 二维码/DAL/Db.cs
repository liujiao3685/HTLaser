using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCode.Entity;

namespace QRCode.DAL
{
    public class Db
    {
        private static SqlConnection m_sqlConnection;

        #region Instance
        private static Db m_db = null;

        private Db()
        {
            m_sqlConnection = DbTool.SqlConnection;
        }

        public static Db GetInstance()
        {
            if (m_db == null)
            {
                m_db = new Db();
            }
            return m_db;
        }
        #endregion

        /// <summary>
        /// 更新指定用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(User user)
        {
            try
            {
                string sql = "update users set name=@name,password=@password where id=@id;";
                SqlCommand cmd = new SqlCommand(sql, m_sqlConnection);
                cmd.CommandText = sql;
                cmd.Parameters.Add("@name", user.Name);
                cmd.Parameters.Add("@password", user.Password);
                cmd.Parameters.Add("@id", user.Id);

                int rs = cmd.ExecuteNonQuery();
                return rs;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Insert(User user)
        {
            try
            {
                string sql = "insert into users (name,password) values(@name,@password);";
                SqlCommand cmd = m_sqlConnection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("@name", user.Name);
                cmd.Parameters.Add("@password", user.Password);

                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>表集合</returns>
        public List<User> SelectUsers(string sql)
        {
            try
            {
                List<User> list = new List<User>();
                User user;

                SqlCommand cmd = new SqlCommand(sql, m_sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Password = reader["password"].ToString()
                    };
                    list.Add(user);
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>DataSet</returns>
        public DataSet Select(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, m_sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

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
        /// 删除
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>所影响的行数</returns>
        public int Delete(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, m_sqlConnection);

                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception)
            {
                return -1;
            }

        }

    }
}
