using Mapster;
using NorthwindMVC.Core;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web
{
    public static class UserConfig
    {
        public static void UserMapperConfig()
        {
            TypeAdapterConfig<UserViewModel, User>.NewConfig();
        }
    }
}