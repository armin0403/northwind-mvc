using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
	public interface ISupplierService
	{
		Task<PagedList<Supplier>> GetPagedSuppliers(int pageNumber, int pageSize, string searchTerm);
		Task<Supplier> GetByIdAsync(int id);
		Task<bool> Add (Supplier supplier);
		Task<bool> Delete (Supplier supplier);
		Task<bool> Update (Supplier supplier);
	}
}
