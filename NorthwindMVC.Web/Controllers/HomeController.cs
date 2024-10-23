using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Core;
using NorthwindMVC.Services;
using NorthwindMVC.Web.AuthConfig;

namespace NorthwindMVC.Web.Controllers
{
    [CustomAuthenticationFilter]
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
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}