using FlowerWebsite.Modal;
using FlowerWebsite.Service;
using FlowerWebsite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FlowerWebsite_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        public IFlowerService _flowerService;
        public FlowerController(IFlowerService flowerService) { 
            _flowerService = flowerService;
        }
        [HttpPost]
        public async Task<ApiResult> GetFlowers(FlowerReq req)
        {
            var apiResult = new ApiResult { IsSuccess = true };

            try
            {
                // 调用异步方法并等待结果
                var flowers = await _flowerService.GetFlowersAsync(req);
                apiResult.Result = flowers;  // 设置结果
            }
            catch (Exception ex)
            {
                // 处理异常情况
                apiResult.IsSuccess = false;
                apiResult.Msg = ex.Message;
            }

            return apiResult;
        }


    }
}
