namespace NorthwindMVC.Web.Mapper
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration (this IServiceCollection Service)
        {
            UserConfig.UserMapperConfig();
        }
    }
}
