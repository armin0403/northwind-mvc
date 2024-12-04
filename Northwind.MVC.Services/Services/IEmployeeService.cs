using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
    public interface IEmployeeService
    {
        Task<PagedList<Employee>> GetPagedEmployee (int pageNumber, int pageSize, string searchTerm);
        Task<Employee> GetById(int id);
        Task<bool> Add(Employee employee);
    }
}
