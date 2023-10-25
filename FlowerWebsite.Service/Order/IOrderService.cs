using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Service;

namespace FlowerWebsite.Service
{
    public interface IOrderService
    {
        bool CreateOrder(OrderReq req, long userId, ref string msg);
        List<OrderRes> GetOrder(long userId);
    }
}
