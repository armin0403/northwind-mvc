using Microsoft.AspNetCore.Mvc.Rendering;

namespace NorthwindMVC.Web.Helpers
{
    public interface IDropdownService
    {
        Task<IEnumerable<SelectListItem>> GetEmployeesDropdownList(string? searchTerm);
        Task<IEnumerable<SelectListItem>> GetCategoriesDropdownList(string? searchTerm);
        Task<IEnumerable<SelectListItem>> GetSuppliersDropdownList(string? searchTerm);
    }
}
