using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }
    }
}
