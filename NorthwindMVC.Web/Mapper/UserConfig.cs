using Mapster;
using NorthwindMVC.Core;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
	public static class UserConfig
    {
        public static void UserMapperConfig() 
        {
            TypeAdapterConfig<UserViewModel, User>.NewConfig();
        }        
    }
}
