using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IPaginationService _paginationService;

        public EmployeeService(IUnitOfWork unitOfWork,
                               IPaginationService paginationService) 
        {
            this.UnitOfWork = unitOfWork;
            _paginationService = paginationService;
        }
        public async Task<Employee> GetById(int id)
        {
            return await UnitOfWork.EmployeeRepository.GetByIdAsync(id);
        }     

        public async Task<bool> Add(Employee employee)
        {  
            await UnitOfWork.EmployeeRepository.AddAsync(employee);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<PagedList<Employee>> GetPagedEmployee(int pageNumber, int pageSize, string searchTerm)
        {
            var employees = UnitOfWork.EmployeeRepository.GetAll();

            if(!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(e => e.FirstName.ToLower().Contains(searchTerm.ToLower()));
            }

            var pagedEmployees = _paginationService.CreatePagedList(employees, pageNumber, pageSize);

            return pagedEmployees;  
        }

        public async Task<bool> Delete(Employee employee)
        {
            await UnitOfWork.EmployeeRepository.DeleteAsync(employee);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Employee employee)
        {
            await UnitOfWork.EmployeeRepository.UpdateAsync(employee);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
