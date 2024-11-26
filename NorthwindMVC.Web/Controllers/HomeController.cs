using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Services;

namespace NorthwindMVC.Web.Controllers
{
    [AuthenticationFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger,
                              IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var currentLanguage = CultureInfo.CurrentCulture.Name;
            ViewData["SelectedLanguage"] = currentLanguage == "en-US" ? "English" : "Bosanski";
            ViewData["SelectedFlag"] = currentLanguage == "en-US" ? "us" : "ba";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}