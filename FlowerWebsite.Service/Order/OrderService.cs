using AutoMapper;
using FlowerWebsite.Common;
using FlowerWebsite.Model.Entitys;
using FlowerWebsite.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhaoxiFlower.Service;

namespace FlowerWebsite.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly EFDbContext _context;

        public OrderService(IMapper mapper, EFDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public bool CreateOrder(OrderReq req, long userId, ref string msg)
        {
            // Retrieve the flower using EF Core
            var flower = _context.Flowers
                .FirstOrDefault(p => p.Id == req.FlowerId);

            if (flower == null)
            {
                msg = "商品信息不存在！";
                return false;
            }

            // Create a new Order and set properties
            var order = new Order
            {
                OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmffff"),
                OrderDate = DateTime.Now,
                UserId = userId,
                FlowerId = req.FlowerId,
                Price = flower.Price
            };

            // Add and save the new order to the database
            _context.Orders.Add(order);
            var result = _context.SaveChanges();

            return result > 0;
        }

        public List<OrderRes> GetOrder(long userId)
        {
            // Query orders and include flower title using EF Core
            var orders = _context.Orders
                .Where(p => p.UserId == userId)
                .Select(s => new OrderRes
                {
                    Id = s.Id,
                    OrderNumber = s.OrderNumber,
                    Price = s.Price,
                    OrderDate = s.OrderDate,
                    FlowerTitle = _context.Flowers
                        .Where(f => f.Id == s.FlowerId)
                        .Select(f => f.Title)
                        .FirstOrDefault()
                })
                .OrderByDescending(p => p.OrderDate)
                .ToList();

            return orders;
        }
    }
}
