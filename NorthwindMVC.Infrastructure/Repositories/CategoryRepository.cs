using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindDbContext dbContext): base(dbContext)
        {
        }
    }
}
