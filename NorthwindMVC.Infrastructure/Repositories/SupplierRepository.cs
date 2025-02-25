using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Infrastructure.Repositories
{
	public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
	{
		public SupplierRepository(NorthwindDbContext dbContext) : base(dbContext)
		{
		}
	}
}
