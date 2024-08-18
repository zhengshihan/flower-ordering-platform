using FlowerWebsite.Common;
using FlowerWebsite.Modal;
using FlowerWebsite.Model.Entitys;
using FlowerWebsite.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerWebsite_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        public ICustomJwtService _customJwtService;
        public LoginController(IUserService uerService, ICustomJwtService customJwtService)
        {
            _userService = uerService;
            _customJwtService = customJwtService;

        }

        [HttpGet]
        public IActionResult GetValidateCodeImages(string t) 
        {
            var validateCodeString = Tools.CreateValidateString();
            MemoryHelper.SetMemory(t, validateCodeString,5);
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);
            return File(buffer, @"image/jpeg");
        }


        [HttpPost]
        public ApiResult Check(UserReq req)
        {
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            ApiResult apiResult = new ApiResult()
            {
                IsSuccess = false
            };
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "username and password can not be null";
            }
            else if(currCode == null){
                apiResult.Msg = "Captcha doesn't exist, please refresh";
            }
            else if(currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "Captcha is false, please refresh or try again";
            }
            else
            {
                UserRes user = _userService.GetUsers(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "User doesn't exist, username or password is false";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJwtService.GetToken(user);
                }
            }
            return apiResult;

        }
        
        
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Register(RegisterReq req)
        {
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (string.IsNullOrEmpty(req.UserName))
            {
                apiResult.Msg = "Username cannot be null!";
            }
            else if (string.IsNullOrEmpty(req.Password))
            {
                apiResult.Msg = "Password cannot be null!";
            }
            else if (string.IsNullOrEmpty(req.NickName))
            {
                apiResult.Msg = "NickName cannot be null!";
            }
            else if (string.IsNullOrEmpty(req.ValidateKey))
            {
                apiResult.Msg = "ValidateKey cannot be null!";
            }
            else if (string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "ValidateCode cannot be null!";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "Captcha doesn't exist, please refresh";
            }
            else if (currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "Captcha is false, please refresh or try again";
            }
            else
            {
                string msg = string.Empty;
                var res = _userService.RegisterUser(req, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJwtService.GetToken(res);
                }
            }
            return apiResult;
        }
    }
}
