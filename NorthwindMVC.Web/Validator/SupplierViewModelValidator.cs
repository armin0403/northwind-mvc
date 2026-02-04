using FluentValidation;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Validator
{
	public class SupplierViewModelValidator : AbstractValidator<SupplierViewModel>
	{
		public SupplierViewModelValidator(IStringLocalizer<Resources.Resources> localizer)
		{
			RuleFor(s => s.CompanyName).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.ContactName).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.ContactTitle).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.Phone).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.Fax).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.Address).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.City).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.Region).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.PostalCode).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.Country).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(s => s.HomePage).NotEmpty().WithMessage(localizer["FieldRequired"]);
		}
	}
}
