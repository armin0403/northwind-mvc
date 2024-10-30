using NorthwindMVC.Core;

namespace NorthwindMVC.Services
{
    public interface IUserService
    {
        Task<User> GetByUsernameOrEmail(string usernameOrEmail);
        Task<User> GetUserById(int id);
        Task<bool> Add (User user);

    }
}
