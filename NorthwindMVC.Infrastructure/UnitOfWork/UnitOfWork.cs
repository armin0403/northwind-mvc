using NorthwindMVC.Infrastructure.Repositories;
using NorthwindMVC.Infrastucture;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindDbContext _dbContext;

        private IUserRepository _userRepository;

        public UnitOfWork(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;

			UserRepository = _userRepository ??= new UserRepository(_dbContext);
        }

        public IUserRepository UserRepository { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
