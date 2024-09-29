using NorthwindMVC.Infrastructure.Repositories;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
