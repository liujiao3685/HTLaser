using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ILogin
    {
        int CreateUser(string EmpNo,string EmpName,string EmpPassword,string Auth);

        ServiceResult CheckUserAuth(string EmpNo,string UserAuth);

        ServiceResult ExistUser(string EmpNo);

        ServiceResult DeleteUser(string EmpNo);
    }
}
