using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
    public interface IPaginationService
    {
        PagedList<TEntity> CreatePagedList<TEntity>(IQueryable<TEntity> source, int pageNumber, int pageSize);
        Pager CalculatePages(int totalItems, int pageNumber, int pageSize); 
    }
}
