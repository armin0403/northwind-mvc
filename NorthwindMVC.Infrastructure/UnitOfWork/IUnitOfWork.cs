using NorthwindMVC.Infrastructure.Repositories;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
