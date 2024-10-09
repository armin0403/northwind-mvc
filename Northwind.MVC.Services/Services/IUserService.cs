using NorthwindMVC.Core;

namespace NorthwindMVC.Services
{
    public interface IUserService
    {
        User? GetByUsernameOrEmail(string usernameOrEmail);
        bool Add (User user);

    }
}
