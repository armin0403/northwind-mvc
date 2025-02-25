using FluentValidation;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Validator
{
	public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
	{
		public ProductViewModelValidator(IStringLocalizer<Resources.Resources> localizer)
		{
			RuleFor(e => e.ProductName).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.SupplierId).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.CategoryId).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.QuantityPerUnit).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.UnitPrice).NotEqual(0).WithMessage(localizer["FieldRequired"])
									 .NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.UnitsInStock).NotEqual(0).WithMessage(localizer["FieldRequired"])
									    .NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.UnitsOnOrder).NotEqual(0).WithMessage(localizer["FieldRequired"])
										.NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(e => e.ReOrderLevel).NotEqual(0).WithMessage(localizer["FieldRequired"])
										.NotEmpty().WithMessage(localizer["FieldRequired"]);
		}
	}
}
