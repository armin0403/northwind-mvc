namespace NorthwindMVC.Web.Mapper
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration (this IServiceCollection service)
        {
            UserConfig.UserMapperConfig();
        }
    }
}
