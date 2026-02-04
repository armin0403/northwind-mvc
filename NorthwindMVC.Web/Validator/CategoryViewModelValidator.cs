using FluentValidation;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Validator
{
	public class CategoryViewModelValidator : AbstractValidator<CategoryViewModel>
	{
		public CategoryViewModelValidator(IStringLocalizer<Resources.Resources> localizer) 
		{
			RuleFor(x => x.Photo).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage(localizer["FieldRequired"]);
			RuleFor(x => x.Description).NotEmpty().WithMessage(localizer["FieldRequired"]);
		}
	}
}
