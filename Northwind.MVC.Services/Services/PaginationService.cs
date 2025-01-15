using NorthwindMVC.Core.Pagination;

namespace NorthwindMVC.Services.Services
{
    public class PaginationService : IPaginationService
    {
        public Pager CalculatePages(int totalItems, int pageNumber, int pageSize)
        {
            return new Pager(totalItems, pageNumber, pageSize);
        }

        public PagedList<TEntity> CreatePagedList<TEntity>(IQueryable<TEntity> source, int pageNumber, int pageSize)
        {
            int totalCount = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var pager = CalculatePages(totalCount, pageNumber, pageSize);

            return new PagedList<TEntity>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = pager.TotalPages,
                TotalCount = totalCount,
                HasPreviousPage = pageNumber > 1,
                HasNextPage = pageNumber < pager.TotalPages,
                IsFirstPage = pageNumber == 1,
                IsLastPage = pageNumber > pager.TotalPages,
                Pager = pager,
                Items = items
            };
        }
    }
}
