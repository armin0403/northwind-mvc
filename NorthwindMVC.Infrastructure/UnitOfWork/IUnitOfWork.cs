using NorthwindMVC.Infrastructure.Repositories;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
