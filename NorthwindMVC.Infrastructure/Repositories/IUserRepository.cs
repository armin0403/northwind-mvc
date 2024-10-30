using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastructure.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsernameOrEmailAsync(string usernameOrEmail);
        Task<User> GetUserById(int id);
    }
}
