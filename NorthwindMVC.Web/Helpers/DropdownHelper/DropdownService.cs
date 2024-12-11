using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindMVC.Infrastructure.UnitOfWork;
using NorthwindMVC.Web.Helpers;

public class DropdownService : IDropdownService
{
    private readonly IUnitOfWork unitOfWork;

    public DropdownService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetEmployeesDropdownList(string? searchTerm)
    {
        var employees = await unitOfWork.EmployeeRepository.GetAllList();

        // If no search term, return the top five employees for initial load
        if (string.IsNullOrEmpty(searchTerm))
        {
            employees = employees.Take(5).ToList();
        }
        else
        {
            // Search through the full employee list
            employees = employees.Where(e =>
                e.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                e.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return employees.Select(e => new SelectListItem
        {
            Value = e.Id.ToString(),
            Text = e.FirstName + " " + e.LastName,
        });
    }

}
