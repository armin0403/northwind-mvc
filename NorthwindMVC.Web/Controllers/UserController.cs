using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Infrastructure.Services;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Controllers
{
	public class UserController : Controller

    {
        private readonly IUserService _userSerivce;
        private readonly IValidator<UserViewModel> _validator;

        public UserController(IUserService UserService, IValidator<UserViewModel> UserViewModelValidator) 
        {
            _userSerivce = UserService;
            _validator = UserViewModelValidator;
        }
       
        public IActionResult Index()
        {
            return View("LogIn");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(UserViewModel model)
        {
           return View(model);
        }

        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel model)
        {
                                  
          
            return View(model);
        }
    }
}