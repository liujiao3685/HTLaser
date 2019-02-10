using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int ID { set; get; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpID { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string EmpName { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string EmpPassword { set; get; }

        /// <summary>
        /// 用户权限
        /// </summary>
        public string Auth { set; get; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginInTime { get; set; }

        /// <summary>
        /// 登出时间
        /// </summary>
        public string LoginOutTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

    }
}
