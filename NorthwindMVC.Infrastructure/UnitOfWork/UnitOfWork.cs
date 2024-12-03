using System.Runtime.CompilerServices;
using NorthwindMVC.Infrastructure.Repositories;
using NorthwindMVC.Infrastucture;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindDbContext _dbContext;

        private IUserRepository _userRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;

			UserRepository = _userRepository ??= new UserRepository(_dbContext);
            EmployeeRepository = _employeeRepository ??= new EmployeeRepository(_dbContext);
        }

        public IUserRepository UserRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
          return await _dbContext.SaveChangesAsync();           
        }

        
    }
}
