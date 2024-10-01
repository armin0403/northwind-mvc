using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Core;
using NorthwindMVC.Infrastructure.Services;
using NorthwindMVC.Web.Helpers.PasswordHelper;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Controllers
{
	public class UserController : Controller

    {
        private readonly IUserService _userSerivce;
        private readonly IValidator<UserViewModel> _validator;
        private readonly IMapper _mapper;

        public UserController(IUserService UserService, 
                              IValidator<UserViewModel> UserViewModelValidator,
                              IMapper Mapper) 
        {
            _userSerivce = UserService;
            _validator = UserViewModelValidator;
            _mapper = Mapper; 
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
            ModelState.Clear();
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }

            var passwordSalt = PasswordHelper.CreateSalt();
            var passwordHash = PasswordHelper.CreateHash(model.Password, passwordSalt);

            var entity = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Username = model.Username,
                Email = model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _userSerivce.Add(entity);

            return RedirectToAction("Index", "Home");
        }
    }
}