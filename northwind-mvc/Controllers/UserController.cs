using Microsoft.AspNetCore.Mvc;
using northwind_mvc.Models;

namespace northwind_mvc.Controllers
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
