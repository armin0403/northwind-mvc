using FluentValidation;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Helpers
{
	public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
                RuleFor(x => x.FirstName).Length(0, 10).NotEmpty().WithMessage("First name required!");
                RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name required!");
                RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth required!");
                RuleFor(x => x.Username).NotEmpty().WithMessage("Username required!");
                RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email required!");
                RuleFor(x => x.Password).Length(8, 18).NotEmpty().WithMessage("Password required!");
                RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).NotEmpty().WithMessage("Please confirm your password");
        }
    }
}
