using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
	public interface IProductService
	{
		Task<PagedList<Product>> GetPagedProducts(int pageNumber, int pageSize, string searchTerm, int? categoryId);
		Task<Product> GetByIdAsync (int id);
		Task<bool> Add (Product product);
		Task<bool> Update (Product product);
		Task<bool> Delete (Product product);
	}
}
