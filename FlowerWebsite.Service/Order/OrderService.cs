using AutoMapper;
using FlowerWebsite.Common;
using FlowerWebsite.Model.Entitys;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Service;

namespace FlowerWebsite.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        public OrderService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool CreateOrder(OrderReq req, long userId, ref string msg)
        {
            var flower = DbContext.db.Queryable<Flower>().First(p => p.Id == req.FlowerId);
            if (flower == null)
            {
                msg = "商品信息不存在！";
                return false;
            }
            Order order = new Order()
            {
                OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmffff"),
                OrderDate = DateTime.Now,
                UserId = userId,
                FlowerId = req.FlowerId,
                Price = flower.Price
            };
            return DbContext.db.Insertable(order).ExecuteCommand() > 0;
        }

        public List<OrderRes> GetOrder(long userId)
        {
            var order = DbContext.db.Queryable<Order>().Where(p => p.UserId == userId).Select(s => new OrderRes
            {
                Id = s.Id,
                OrderNumber = s.OrderNumber,
                Price= s.Price,
                OrderDate = s.OrderDate,
                FlowerTitle = SqlFunc.Subqueryable<Flower>().Where(f => f.Id == s.FlowerId).Select(f => f.Title)
            }).OrderBy(p => p.OrderDate, OrderByType.Desc).ToList();
            return order;
        }
    }
}
