using Mapster;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Mapper
{
    public class EmployeeConfig
    {
        public static void EmployeeMapperConfig() 
        {
            TypeAdapterConfig<EmployeeViewModel, Employee>.NewConfig();
        }

    }
}
