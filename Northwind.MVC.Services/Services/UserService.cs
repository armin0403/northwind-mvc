using NorthwindMVC.Core;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork UnitOfWork;

        public UserService(IUnitOfWork unitOfWork) 
        {
            this.UnitOfWork = unitOfWork;
        }

        public bool Add(User user)
        {
            UnitOfWork.UserRepository.Add(user);
            UnitOfWork.Save();
            return true;
        }

        public User? GetByUsernameOrEmail(string usernameOrEmail)
        {
            return UnitOfWork.UserRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
        }
    }
}
