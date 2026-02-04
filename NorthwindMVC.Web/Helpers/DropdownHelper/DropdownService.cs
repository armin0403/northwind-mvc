using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindMVC.Infrastructure.UnitOfWork;
using NorthwindMVC.Web.Helpers;

public class DropdownService : IDropdownService
{
    private readonly IUnitOfWork UnitOfWork;

    public DropdownService(IUnitOfWork unitOfWork)
    {
        this.UnitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetCategoriesDropdownList(string? searchTerm)
    {
        var query = UnitOfWork.CategoryRepository.Find(c =>
        string.IsNullOrWhiteSpace(searchTerm) ||
        c.CategoryName.ToLower().Contains(searchTerm));

        return query.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.CategoryName,
        });
    }

    public async Task<IEnumerable<SelectListItem>> GetEmployeesDropdownList(string? searchTerm)
    {
        var query = UnitOfWork.EmployeeRepository.Find(e =>
            string.IsNullOrWhiteSpace(searchTerm) ||
            e.FirstName.ToLower().Contains(searchTerm) ||
            e.LastName.ToLower().Contains(searchTerm)); //querable
              

        return query.Select(e => new SelectListItem
        {
            Value = e.Id.ToString(),
            Text = e.FirstName + " " + e.LastName,
        });
    }

    public async Task<IEnumerable<SelectListItem>> GetSuppliersDropdownList(string? searchTerm)
    {
        var query = UnitOfWork.SupplierRepository.Find(s =>
        string.IsNullOrWhiteSpace(searchTerm) ||
        s.CompanyName.ToLower().Contains(searchTerm));

        return query.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.CompanyName,
        });
    }
}
