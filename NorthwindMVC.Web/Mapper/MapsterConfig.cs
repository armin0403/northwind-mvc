using NorthwindMVC.Web.Mapper;

namespace NorthwindMVC.Web
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection service)
        {
            UserConfig.UserMapperConfig();
            EmployeeConfig.EmployeeMapperConfig();
        }
    }
}