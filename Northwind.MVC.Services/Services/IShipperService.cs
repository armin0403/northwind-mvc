using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
	public interface IShipperService
	{
		Task<PagedList<Shipper>> GetPagedShippers(int pageNumber, int pageSize, string searchTerm);
		Task<Shipper> GetShipperById(int id);
		Task<bool> Add (Shipper shipper);
		Task<bool> Update (Shipper shipper);
		Task<bool> Delete (Shipper shipper);
	}
}
