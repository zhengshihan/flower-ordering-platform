using System;
using System.Collections.Generic;


namespace FlowerWebsite.Service
{
    public class UserReq
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public string ValidateKey { get; set; }

        public string ValidateCode { get; set; }

    }
}
