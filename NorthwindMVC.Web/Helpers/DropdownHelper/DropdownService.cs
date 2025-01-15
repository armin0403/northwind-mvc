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
        var query = unitOfWork.EmployeeRepository.Find(e =>
            string.IsNullOrWhiteSpace(searchTerm) ||
            e.FirstName.ToLower().Contains(searchTerm) ||
            e.LastName.ToLower().Contains(searchTerm)); //querable

        

        return query.Select(e => new SelectListItem
        {
            Value = e.Id.ToString(),
            Text = e.FirstName + " " + e.LastName,
        });
    }

}
