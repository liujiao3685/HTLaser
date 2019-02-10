using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 业务逻辑层
/// 主要是针对具体的问题的操作，也可理解成对数据层的操作，对数据业务的逻辑处理。如果把数据层当成积木，那么逻辑层就是对这些积木的搭建
/// </summary>
namespace BLL
{
    /// <summary>
    /// 用户登录管理
    /// 
    /// </summary>
    public partial class OperateUser
    {
        /// <summary> 
        /// partial :局部类型,这个关键字的类、结构或接口可以写成几个部分
        /// 表示这个类这里的代码只是一部分代码.
        /// 可以再另外的.cs文件中再写这个类的另外一部分代码.
        /// 比如 
        /// public partial class Program
        ///  {
        ///      static void Main(string[] args) {}
        ///      partial class Program
        ///      {
        ///        public void Test(){}
        ///      }
        ///  }
        /// 编译后它相当于
        /// public class Program
        /// {
        ///     static void Main(string[] args){}
        ///     public void Test(){}
        /// }
        /// </summary>

        public IOperateUser idal = DALAccess.CreateOperateUser();

        #region 成员方法

        public bool IsConnection()
        {
            return idal.IsConnnection();
        }

        public List<UserInfo> GetAllUserInfos()
        {
            return idal.GetAllUsers();
        }

        public int CreateUser(string EmpNo, string EmpName, string EmpPwD, string Auth)
        {
            return idal.CreateUser(EmpNo, EmpName, EmpPwD, Auth);
        }

        public int DeleteUser(string EmpID)
        {
            return idal.DeleteUser(EmpID);
        }

        public int ExistUser(string EmpNo)
        {
            return idal.ExistUser(EmpNo);
        }

        public string GetSysDateTime()
        {
            return idal.GetSysDateTime();
        }

        public string GetUserEmpID(string EmpName)
        {
            return idal.GetUserEmpID(EmpName);
        }

        public ServiceResult OperateLogin(string EmpID, string EmpName, string EmpPwd, string Auth)
        {
            return idal.OperateLogin(EmpID, EmpName, EmpPwd, Auth);
        }

        #endregion

    }
}
