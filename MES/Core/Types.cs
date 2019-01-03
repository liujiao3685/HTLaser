using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES.Core
{
    public class Types
    {

    }

    public enum UserRight
    {
        /// <summary>
        /// 操作员
        /// </summary>
        Operator = 0,

        /// <summary>
        /// 管理员
        /// </summary>
        Manager = 1,

        /// <summary>
        /// 超级管理员
        /// </summary>
        Admin = 2

    }

}
