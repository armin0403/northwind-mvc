using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Services;

namespace NorthwindMVC.Web.Controllers
{
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
			var userId = HttpContext.Session.GetInt32("UserId");

			if (userId != null)
            {              
				var currentUser = _userService.GetUserById(userId.Value);
                return View(currentUser);
            }

            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}