using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;
using NorthwindMVC.Infrastructure;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IPaginationService _paginationService;
        private readonly NorthwindDbContext _dbContext;
        private readonly IPhotoService _photoService;

        public EmployeeService(IUnitOfWork unitOfWork,
                               IPaginationService paginationService,
                               NorthwindDbContext dbContext,
                               IPhotoService photoService) 
        {
            this.UnitOfWork = unitOfWork;
            _paginationService = paginationService;
            _dbContext = dbContext;
            _photoService = photoService;
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
            string? normalizedSearchTerm = searchTerm?.ToLower();

            var query = UnitOfWork.EmployeeRepository.Find(e =>
                string.IsNullOrEmpty(normalizedSearchTerm) ||
                e.FirstName.ToLower().Contains(normalizedSearchTerm) ||
                e.LastName.ToLower().Contains(normalizedSearchTerm));


            var pagedEmployees = _paginationService.CreatePagedList<Employee>(query, pageNumber, pageSize);

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

        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var hasSub = await UnitOfWork.EmployeeRepository.AnyAsync(e => e.ReportsToId == employee.Id);
                    if (hasSub)
                    {
                        return false;
                    }

                    await UnitOfWork.EmployeeRepository.DeleteAsync(employee);
                    await _photoService.DeletePhotoAsync(employee.PhotoPath);

                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }           

        }
    }
}
