using NorthwindMVC.ViewModels;
using Mapster;
using NorthwindMVC.Core;

namespace NorthwindMVC.Mapper
{
    public static class UserMapper
    {
        public static void UserMapperConfig() 
        {
            TypeAdapterConfig<UserViewModel, User>.NewConfig();
        }
    }
}
