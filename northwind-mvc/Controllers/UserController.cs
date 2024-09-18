using Microsoft.AspNetCore.Mvc;

namespace northwind_mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("LogIn");
        }
    }
}
