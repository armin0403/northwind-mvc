using NorthwindMVC.Core;
using NorthwindMVC.Infrastucture;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository

    {
        public UserRepository(NorthwindDbContext dbContext) : base(dbContext)
        {            
        }

    }
}
