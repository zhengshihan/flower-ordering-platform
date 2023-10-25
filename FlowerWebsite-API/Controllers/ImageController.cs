using FlowerWebsite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerWebsite_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public List<ImageModel> GetImages() { 
            List<ImageModel> list = new List<ImageModel>()
            {
                new ImageModel() {ImageUrl="/images/banners/21_birthday_banner_pc.jpg",CourseUrl="http://localhost:3000/"},
                new ImageModel() {ImageUrl="/images/banners/21_brand_banner_pc.jpg",CourseUrl="http://localhost:3000/"},
                new ImageModel() {ImageUrl="/images/banners/21_syz_banner_pc.jpg",CourseUrl="http://localhost:3000/"}
            };
            return list;

        }
    }
}
