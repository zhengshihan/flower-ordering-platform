using FlowerWebsite.Modal;
using FlowerWebsite.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Service;

namespace FlowerWebsite_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Authorize]
        public ApiResult CreateOrder(OrderReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (req.FlowerId == 0)
            {
                apiResult.Msg = "参数不可以为空！";
            }
            else
            {
                string msg = string.Empty;
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                bool res = _orderService.CreateOrder(req, userId, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = res;
                }
            }
            return apiResult;
        }

        [HttpPost]
        [Authorize]
        public ApiResult GetOrder()
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            try
            {
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                apiResult.Result = _orderService.GetOrder(userId);
            }
            catch (Exception ex)
            {
                apiResult.IsSuccess = false;
                apiResult.Msg = ex.Message;
            }
            return apiResult;
        }
    }
}
