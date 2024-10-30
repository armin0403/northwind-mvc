using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Core;
using NorthwindMVC.Infrastructure;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository

    {
        public UserRepository(NorthwindDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }

		public async Task<User> GetUserById(int id)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
		}
	}
}
