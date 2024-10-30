using FluentValidation;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Helpers
{
	public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
                RuleFor(x => x.FirstName).Length(1, 10).WithMessage("First name must be between 1 and 10 characters.")
                                         .NotEmpty().WithMessage("First name required!");
                RuleFor(x => x.LastName).Length(1, 10).WithMessage("Last name must be between 1 and 10 characters.")
                                        .NotEmpty().WithMessage("Last name required!");
                RuleFor(x => x.DateOfBirth).Must(BeAtLeast18YearsOld).WithMessage("Must be 18 or older!")
                                           .NotEmpty().WithMessage("Date of birth required!");
                RuleFor(x => x.Username).NotEmpty().WithMessage("Username required!");
                RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email required!");
                RuleFor(x => x.Password).Length(8, 18).NotEmpty().WithMessage("Password required!");
                RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Must be same as password!")
                                               .NotEmpty().WithMessage("Please confirm your password");
        }

        private bool BeAtLeast18YearsOld(DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth > today.AddYears(-age)) 
            {
                age--; 
            }
            return age > 18;
        }
    }
}
