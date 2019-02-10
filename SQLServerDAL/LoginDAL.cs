using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerDAL
{
    public class LoginDAL : ILogin
    {
        public ServiceResult CheckUserAuth(string EmpNo, string UserAuth)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(string EmpNo, string EmpName, string EmpPassword, string Auth)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteUser(string EmpNo)
        {
            throw new NotImplementedException();
        }

        public ServiceResult ExistUser(string EmpNo)
        {
            throw new NotImplementedException();
        }
    }
}
