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
        private ICategoryRepository _categoryRepository;
		private IShipperRepository _shipperRepository;
        private ISupplierRepository _supplierRepository;
        private IProductRepository _productRepository;

		public UnitOfWork(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;

			UserRepository = _userRepository ??= new UserRepository(_dbContext);
            EmployeeRepository = _employeeRepository ??= new EmployeeRepository(_dbContext);
            CategoryRepository = _categoryRepository ??= new CategoryRepository(_dbContext);
            ShipperRepository = _shipperRepository ??= new ShipperRepository(_dbContext);
            SupplierRepository = _supplierRepository ??= new SupplierRepository(_dbContext);
            ProductRepository = _productRepository ??= new ProductRepository(_dbContext);
        }

        public IUserRepository UserRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IShipperRepository ShipperRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }

		public async Task<int> SaveChangesAsync()
        {
          return await _dbContext.SaveChangesAsync();           
        }

        
    }
}
