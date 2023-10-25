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
        public ApiResult GetFlowers(FlowerReq req)
        {   
            ApiResult apiResult = new ApiResult() { IsSuccess = true};
            apiResult.Result = _flowerService.GetFlowers(req);
            return apiResult;
        }

    }
}
