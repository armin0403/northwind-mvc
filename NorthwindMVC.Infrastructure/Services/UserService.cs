using NorthwindMVC.Core;
using NorthwindMVC.Infrastructure.UnitOfWork;

namespace NorthwindMVC.Infrastructure.Services
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

        public Task<User> LogIn(string username, string password)
        {

            throw new NotImplementedException();
        }

        public Task<User> SignUpAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
