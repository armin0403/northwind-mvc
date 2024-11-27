using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Core;
using NorthwindMVC.Services;
using NorthwindMVC.Web.Helpers.PasswordHelper;
using NorthwindMVC.Web.ViewModels;
using System.Text.Json;

namespace NorthwindMVC.Web.Controllers
{
    public class UserController : Controller

    {
        private readonly IUserService _userService;
        private readonly IValidator<UserViewModel> _validator;
        private readonly IMapper _mapper;

        public UserController(IUserService UserService,
                              IValidator<UserViewModel> validator,
                              IMapper Mapper)
        {
            _userService = UserService;
            _validator = validator;
            _mapper = Mapper;
        }


        public IActionResult Index()
        {
            return View("LogIn");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAsync(UserLogInViewModel model)
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Provide username/email or passowrd.");
                return View(model);
            }

            var user = await _userService.GetByUsernameOrEmail(model.UsernameOrEmail);
            if (user == null || model.Password == null)
            {
                ModelState.AddModelError(string.Empty, "Password or username/email incorrect!");
                return View(model);
            }

            var passwordHash = PasswordHelper.CreateHash(model.Password, user.PasswordSalt);
            if (user.PasswordHash != passwordHash)
            {
                ModelState.AddModelError(string.Empty, "Password or username/email incorrect!");
                return View(model);
            }
            string jsonString = JsonSerializer.Serialize(model);
            HttpContext.Session.SetString("UserData", jsonString);

            TempData["SuccessLogin"] = "You've been successfully logged in!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel model)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(model);

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

            _userService.Add(entity);

            return RedirectToAction("Index", "Home");
        }
    }
}