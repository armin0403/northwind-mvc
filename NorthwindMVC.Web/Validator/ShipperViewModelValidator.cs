using FluentValidation;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Validator
{
    public class ShipperViewModelValidator : AbstractValidator<ShipperViewModel>
    {
        public ShipperViewModelValidator(IStringLocalizer<Resources.Resources> localizer) 
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage(localizer["FieldRequired"]);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(localizer["FieldRequired"]);
        }
    }
}
