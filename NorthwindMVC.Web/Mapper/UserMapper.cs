using Mapster;
using NorthwindMVC.Core;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
	public static class UserMapper
    {
        public static void UserMapperConfig() 
        {
            TypeAdapterConfig<UserViewModel, User>.NewConfig();
        }
    }
}
