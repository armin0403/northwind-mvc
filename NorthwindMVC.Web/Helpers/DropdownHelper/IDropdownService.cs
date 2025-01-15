using Microsoft.AspNetCore.Mvc.Rendering;

namespace NorthwindMVC.Web.Helpers
{
    public interface IDropdownService
    {
        Task<IEnumerable<SelectListItem>> GetEmployeesDropdownList(string? searchTerm);
    }
}
