using NorthwindMVC.Infrastructure.Repositories;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IShipperRepository ShipperRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
