namespace MES.Entity
{
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpNo { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 用户权限
        /// </summary>
        public string Auth { set; get; }

        public User() { }

        public User(string name, string pass, string auth)
        {
            this.Name = name;
            this.Password = pass;
            this.Auth = auth;
        }

    }
}
