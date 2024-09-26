using FluentValidation;
using NorthwindMVC.ViewModels;



namespace NorthwindMVC.Infrastructure.Helpers.Validator
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
                RuleFor(x => x.FirstName).Length(0, 10).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.DateOfBirth).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Email).EmailAddress().NotEmpty();
                RuleFor(x => x.Password).Length(8, 18).NotEmpty();
        }
    }
}
