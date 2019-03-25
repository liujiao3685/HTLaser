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

        /// <summary>
        /// 获取上一工位结果
        /// </summary>
        /// <returns></returns>
        public static IFailSafe CreateFailSafe()
        {
            string className = profilePath + ".FailSafeDAL";
            return (IFailSafe)Assembly.Load(profilePath).CreateInstance(className);
        }

        /// <summary>
        /// 安全气囊工具类
        /// </summary>
        /// <returns></returns>
        public static IAirBag CreateAirBag()
        {
            string className = profilePath + ".AirBagDAL";
            return (IAirBag)Assembly.Load(profilePath).CreateInstance(className);
        }

    }
}
