using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Infrastructure.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(NorthwindDbContext dbContext) : base(dbContext)
		{
		}
	}
}
