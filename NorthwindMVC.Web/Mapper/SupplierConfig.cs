using Mapster;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
	public class SupplierConfig
	{
		public static void SupplierMapperConfig()
		{
			TypeAdapterConfig<SupplierViewModel, Supplier>.NewConfig();
		}
	}
}
