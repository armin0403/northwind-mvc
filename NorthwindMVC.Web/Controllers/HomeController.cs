using Microsoft.AspNetCore.Mvc;

namespace NorthwindMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return View();
            }
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}