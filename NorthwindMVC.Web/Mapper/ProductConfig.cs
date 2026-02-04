using Mapster;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
	public class ProductConfig
	{
		public static void ProductMapperConfig() 
		{
			TypeAdapterConfig<ProductViewModel, Product>.NewConfig();
		}
	}
}
