using Azure.Core;
using HW_20.Domain.Contract.Service;
using HW_20.Service.AppService;
using Microsoft.AspNetCore.Mvc;

namespace HW_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IAuthenticationAppService _AuthenticationAppService;

        public UserController(IAuthenticationAppService AuthenticationAppService)
        {
            _AuthenticationAppService = AuthenticationAppService;
        }



        [HttpPost("login")]
        public IActionResult Login(string userName, string password)
        {
            if (_AuthenticationAppService.Login(userName, password))
            {
                return Ok(new { Message = "ورود موفقیت‌آمیز" });
            }
            else
            {
                return Unauthorized(new { Message = "ورود به سیستم ناموفق بود" });
            }
        }
    }

}
