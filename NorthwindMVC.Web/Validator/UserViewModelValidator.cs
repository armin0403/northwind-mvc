using FluentValidation;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Helpers
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator(IStringLocalizer<Resources.Resources> localizer)
        {
            RuleFor(x => x.FirstName).Length(1, 10).WithMessage(localizer["FirstNameValidationLength"])
                                     .NotEmpty().WithMessage(localizer["FirstNameValidationRequired"]);
            RuleFor(x => x.LastName).Length(1, 10).WithMessage(localizer["LastNameValidationLength"])
                                    .NotEmpty().WithMessage(localizer["LastNameValidationRequired"]);
            RuleFor(x => x.DateOfBirth).Must(BeAtLeast18YearsOld).WithMessage("Must be 18 or older!")
                                       .NotEmpty().WithMessage(localizer["DateOfBirthValidationRequired"]);
            RuleFor(x => x.Username).NotEmpty().WithMessage(localizer["UsernameValidationRequired"]);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage(localizer["EmailValidationRequired"]);
            RuleFor(x => x.Password).Length(8, 18).NotEmpty().WithMessage(localizer["PasswordValidationRequired"]);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage(localizer["ConfirmPasswordValidation"])
                                           .NotEmpty().WithMessage(localizer["ConfirmPasswordValidationRequired"]);
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
