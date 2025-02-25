using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Infrastructure.Repositories
{
	public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
	{
		public ShipperRepository(NorthwindDbContext dbContext) : base(dbContext)
		{
		}
	}
}
