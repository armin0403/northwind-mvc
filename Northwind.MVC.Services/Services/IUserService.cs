using NorthwindMVC.Core;

namespace NorthwindMVC.Services
{
    public interface IUserService
    {
        User? GetByUsernameOrEmail(string usernameOrEmail);
        User GetUserById(int id);
        bool Add (User user);

    }
}
