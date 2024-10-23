namespace NorthwindMVC.Web
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration (this IServiceCollection service)
        {
            UserConfig.UserMapperConfig();
        }
    }
}
