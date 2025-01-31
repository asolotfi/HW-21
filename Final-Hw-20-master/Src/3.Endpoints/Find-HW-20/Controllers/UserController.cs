using HW_20.Domain.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace HW_20.Controllers
{
    public class UserController : Controller
    {

        private readonly IAuthenticationAppService _AuthenticationAppService;

        public UserController(IAuthenticationAppService AuthenticationAppService)
        {
            _AuthenticationAppService = AuthenticationAppService;
        }

        [HttpGet]
        public IActionResult signin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string userName, string password)
        {
            if (_AuthenticationAppService.Login(userName, password))
            {
                return RedirectToAction("Show", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "ورود به سیستم ناموفق بود";
                return View("Index");
            }
        }
    }

}
