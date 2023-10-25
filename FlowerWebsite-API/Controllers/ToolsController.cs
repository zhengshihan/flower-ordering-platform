using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlowerWebsite.Common;


namespace FlowerWebsite_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpGet]
        public void InitDatabase()
        {
            DbContext.InitDataBase();
        }
    }
}
