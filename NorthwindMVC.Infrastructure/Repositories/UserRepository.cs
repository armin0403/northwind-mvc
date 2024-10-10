using NorthwindMVC.Core;
using NorthwindMVC.Infrastucture;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository

    {
        public UserRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }

        public User GetByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }

		public User GetUserById(int id)
		{
			return _dbContext.Users.FirstOrDefault(u => u.Id == id);
		}
	}
}
