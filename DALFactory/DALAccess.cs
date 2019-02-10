using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 数据工厂
/// </summary>
namespace DALFactory
{
    public sealed class DALAccess
    {
        private static readonly string profilePath = ConfigurationManager.AppSettings["DBProviderType"].ToString();
        private DALAccess() { }

        /// <summary>
        /// 创建用户操作管理类
        /// </summary>
        /// <returns>数据层</returns>
        public static IOperateUser CreateOperateUser()
        {
            string className = profilePath + ".OperateUserDAL";
            return (IOperateUser)Assembly.Load(profilePath).CreateInstance(className);
        }
        
        /// <summary>
        /// 创建焊接参数管理类
        /// </summary>
        /// <returns></returns>
        public static ISaveWeldingData CreateSaveWeldingData()
        {
            string className = profilePath + ".SaveWeldingDataDAL";
            return (ISaveWeldingData)Assembly.Load(profilePath).CreateInstance(className);
        }

    }
}
