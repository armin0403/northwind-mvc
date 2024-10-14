namespace NorthwindMVC.Web
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration (this IServiceCollection Service)
        {
            UserConfig.UserMapperConfig();
        }
    }
}
