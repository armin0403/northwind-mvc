using NorthwindMVC.Web.Mapper;

namespace NorthwindMVC.Web
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection service)
        {
            UserConfig.UserMapperConfig();
            EmployeeConfig.EmployeeMapperConfig();
            CategoryConfig.CategoryMapperConfig();
            ProductConfig.ProductMapperConfig();
            ShipperConfig.ShipperMapperConfig();
            SupplierConfig.SupplierMapperConfig();
        }
    }
}