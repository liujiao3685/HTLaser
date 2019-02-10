using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 用户操作类
    /// </summary>
    public interface IOperateUser
    {
        Boolean IsConnnection();

        String GetSysDateTime();

        List<UserInfo> GetAllUsers();

        ServiceResult OperateLogin(string EmpID, string EmpName, string EmpPwd, string Auth);

        int CreateUser(string EmpNo, string EmpName, string EmpPwd, string Auth);

        string GetUserEmpID(string EmpName);

        int DeleteUser(string EmpID);

        int ExistUser(string EmpID);

    }
}
