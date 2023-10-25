

namespace FlowerWebsite.Service
{
    /// <summary>
    /// 注册dto
    /// </summary>
    public class RegisterReq
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary> 
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary> 
        public string Password { get; set; }
        public string ValidateKey { get; set; }

        public string ValidateCode { get; set; }

    }
}
