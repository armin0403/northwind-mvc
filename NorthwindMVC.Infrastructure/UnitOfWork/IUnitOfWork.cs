using NorthwindMVC.Infrastructure.Repositories;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        void Save();
    }
}
