using Mapster;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
	public class ShipperConfig
	{
		public static void ShipperMapperConfig() 
		{
			TypeAdapterConfig<ShipperViewModel, Shipper>.NewConfig();
		}
	}
}
