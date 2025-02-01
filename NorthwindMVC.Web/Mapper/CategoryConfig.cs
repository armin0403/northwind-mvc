using Mapster;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
	public class CategoryConfig
	{
		public static void CategoryMapperConfig() 
		{
			TypeAdapterConfig<CategoryViewModel, Category>.NewConfig();
		}
	}
}
