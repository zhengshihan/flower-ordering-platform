using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Model.Entitys
{
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
      
        public long Id { get; set; }
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
        /// <summary>
        /// 注册时间
        /// </summary>
     
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
      
        public int UserType { get; set; }

    }
}
