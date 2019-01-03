namespace HuaTianProject.Entity
{
    public class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 权限
        /// </summary>
        public string Auth { set; get; }

        public User() { }

        public User(string name, string password, string auth)
        {
            this.Name = name;
            this.Password = password;
            this.Auth = auth;
        }
    }
}
