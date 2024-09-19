using Microsoft.AspNetCore.Mvc;

namespace NorthwindMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("LogIn");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View("SignUp");
        }
    }
}