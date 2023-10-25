using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Model.Entitys
{
    public class Order
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string OrderNumber { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public decimal Price { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 鲜花Id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public long FlowerId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public long UserId { get; set; }
    }
}
