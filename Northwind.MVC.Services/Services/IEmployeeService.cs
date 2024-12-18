using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
    public interface IEmployeeService
    {
        Task<PagedList<Employee>> GetPagedEmployee (int pageNumber, int pageSize, string searchTerm);
        Task<Employee> GetById(int id);
        Task<bool> DeleteEmployeeAsync(Employee employee);
        Task<bool> Add(Employee employee);
        Task<bool> Delete(Employee employee);
        Task<bool> Update(Employee employee);
    }
}
