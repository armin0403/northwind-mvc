using FluentValidation;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Web.Resources;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Validator
{
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewModelValidator(IStringLocalizer<Resources.Resources>localizer) 
        {
            RuleFor(x => x.FirstName).Length(1, 10).WithMessage(localizer["FirstNameValidationLength"])
                                     .NotEmpty().WithMessage(localizer["FirstNameValidationRequired"]);
            RuleFor(x => x.LastName).Length(1, 10).WithMessage(localizer["LastNameValidationLength"])
                                    .NotEmpty().WithMessage(localizer["LastNameValidationRequired"]);
            RuleFor(x => x.Title).NotEmpty()
                                 .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.TitleOfCourtesy).NotEmpty()
                                           .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.Address).NotEmpty()
                                   .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.City).NotEmpty()
                                .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.Region).NotEmpty()
                                  .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.PostalCode).NotEmpty()
                                      .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.Country).NotEmpty()
                                   .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.HomePhone).NotEmpty()
                                     .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.Extension).NotEmpty()
                                     .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.PhotoUpload).NotEmpty()
                                 .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.HireDate).NotEmpty()
                                    .WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.DateOfBirth).NotEmpty()
                                       .WithMessage(localizer["DateOfBirthValidationRequired"]);
        }
        
    }
}
