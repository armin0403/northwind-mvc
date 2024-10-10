using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetByUsernameOrEmailAsync(string usernameOrEmail);
        User GetUserById(int id);
    }
}
