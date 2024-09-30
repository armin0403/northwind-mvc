using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastructure.Services
{
    public interface IUserService
    {
        Task<User> LogIn (string username, string password);
        Task<User> SignUpAsync (User user);

        bool Add (User user);

    }
}
