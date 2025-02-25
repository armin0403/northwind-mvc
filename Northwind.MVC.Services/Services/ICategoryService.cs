using NorthwindMVC.Core.Models;
using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
    public interface ICategoryService
    {
        Task<PagedList<Category>> GetPagedCategories(int pageNumber, int pageSize, string searchTerm);
        Task<Category> GetById(int id);
        Task<bool> Add (Category category);
        Task<bool> Update (Category category);
        Task<bool> Delete (Category category);
    }
}
