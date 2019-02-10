using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerDAL
{
    public class OperateUser : IOperateUser
    {
        /// <summary>
        /// 新增员工
        /// 返回结果：1->成功 2->失败 3->异常
        /// </summary>
        /// <param name="EmpNo"></param>
        /// <param name="EmpName"></param>
        /// <param name="EmpPwd"></param>
        /// <param name="Auth"></param>
        /// <returns></returns>
        public int CreateUser(string EmpNo, string EmpName, string EmpPwd, string Auth)
        {
            StringBuilder strSql = new StringBuilder();
            try
            {
                //判断员工是否存在
                int count = ExistUser(EmpNo);
                if (count == 2)
                {
                    strSql.Clear();
                    strSql.Append("INSERT INTO USERS(EmpNo,Name,Password,Auth) values(@empNo,@name,@pwd,@auth)");
                    SqlParameter[] parameters = new SqlParameter[4];
                    parameters[0] = new SqlParameter("@empNo", SqlDbType.NVarChar, 50);
                    parameters[0].Value = EmpNo;
                    parameters[1] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
                    parameters[1].Value = EmpName;
                    parameters[2] = new SqlParameter("@pwd", SqlDbType.NVarChar, 50);
                    parameters[2].Value = EmpPwd;
                    parameters[3] = new SqlParameter("@auth", SqlDbType.NVarChar, 50);
                    parameters[3].Value = Auth;

                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLServerConnectionString, strSql.ToString(), CommandType.Text, parameters);

                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception ex)
            {
                return 3;
            }
        }

        /// <summary>
        /// 删除用户结果
        /// 1成功 2失败 3异常
        /// </summary>
        /// <param name="EmpID"></param>
        /// <returns></returns>
        public int DeleteUser(string EmpID)
        {
            try
            {
                int count = ExistUser(EmpID);
                if (count == 1)
                {
                    string sql = "DELETE FROM USERS WHERE EmpNo=@EmpNo";
                    SqlParameter[] sqlParameters = new SqlParameter[1];
                    sqlParameters[0] = new SqlParameter("@EmpNo", SqlDbType.NVarChar, 50);
                    sqlParameters[0].Value = EmpID;

                    SqlHelper.ExecuteNonQuery(sql, sqlParameters);
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            catch (Exception)
            {
                return 3;
            }
        }

        /// <summary>
        /// 判断员工是否存在
        /// 1存在 2不存在 3异常
        /// </summary>
        /// <param name="EmpID"></param>
        /// <returns></returns>
        public int ExistUser(string EmpNo)
        {
            string sql = "SELECT COUNT(*) FROM USERS WHERE EmpNo = @EmpNo";
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@EmpNo", SqlDbType.NVarChar, 50);
                sqlParameters[0].Value = EmpNo;

                int count = SqlHelper.ExecuteNonQuery(sql, sqlParameters);
                if (count == 0)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 3;
            }
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetAllUsers()
        {
            List<UserInfo> users = new List<UserInfo>();
            try
            {
                string sql = "SELECT * FROM USERS";
                DataSet ds = SqlHelper.ExecuteDataset(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.EmpID = dr["EmpID"].ToString();
                    userInfo.EmpName = dr["EmpName"].ToString();
                    userInfo.EmpPassword = dr["EmpPassword"].ToString();
                    userInfo.Auth = dr["Auth"].ToString();

                    users.Add(userInfo);
                }
                return users;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public string GetSysDateTime()
        {
            String SysDatetime = "";
            try
            {
                string strSQL = "SELECT GETDATE()";
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.SQLServerConnectionString, CommandType.Text, strSQL);
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd HH:mm:ss";
                SysDatetime = Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString(), dtFormat).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                SysDatetime = "";
            }
            return SysDatetime;
        }

        /// <summary>
        /// 根据员工姓名获取员工编号
        /// </summary>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public string GetUserEmpID(string EmpName)
        {
            try
            {
                string sql = String.Format("SELECT EmpNo FROM USERS WHERE EmpName={0}", EmpName);
                DataSet ds = SqlHelper.ExecuteDataset(sql);
                string empNo = ds.Tables[0].Rows[0][0].ToString();
                ds.Clear();
                ds = null;
                return empNo;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool IsConnnection()
        {
            return SqlHelper.IsConnection(SqlHelper.SQLServerConnectionString);
        }

        /// <summary>
        /// 用户操作方法
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="EmpName"></param>
        /// <param name="EmpPwd"></param>
        /// <param name="Auth">指定用户操作权限</param>
        /// <returns></returns>
        public ServiceResult OperateLogin(string EmpID, string EmpName, string EmpPwd, string Auth)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                int count = ExistUser(EmpID);
                if (count == 1)
                {
                    string sql = "SELECT EmpID,EmpName,EmpPwd,Auth FROM USERS WHERE EmpID=@EmpID";
                    SqlParameter[] sqlParameters =
                    {
                        new SqlParameter{ParameterName="@EmpID",SqlDbType=SqlDbType.NVarChar,Size=50,SqlValue = EmpID}
                    };
                    DataSet ds = SqlHelper.ExecuteDataset(sql, sqlParameters);
                    UserInfo user = new UserInfo();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        user.EmpID = dr["EmpID"].ToString();
                        user.EmpName = dr["EmpName"].ToString();
                        user.EmpPassword = dr["EmpPassword"].ToString();
                        user.Auth = dr["Auth"].ToString();
                    }

                    if (user.EmpName != EmpName)
                    {
                        result.IsSuccess = false;
                        result.Msg = "用户名错误";
                    }
                    else if (user.EmpPassword != EmpPwd)
                    {
                        result.IsSuccess = false;
                        result.Msg = "密码错误";
                    }
                    else if (user.Auth != Auth)
                    {
                        result.IsSuccess = false;
                        result.Msg = "权限不足";
                    }
                    else
                    {
                        result.IsSuccess = true;
                        result.Msg = "操作成功";
                    }

                }
                else if (count == 2)
                {
                    result.IsSuccess = false;
                    result.Msg = String.Format("员工编号：{0}  - 不存在！", EmpID);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Msg = "异常！";
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = ex.Message;
            }
            return result;
        }
    }
}
