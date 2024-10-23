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

        public async Task<bool> Add(User user)
        {
            await UnitOfWork.UserRepository.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByUsernameOrEmail(string usernameOrEmail)
        {
            return await UnitOfWork.UserRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
        }

		public async Task<User> GetUserById(int id)
		{
			return await UnitOfWork.UserRepository.GetUserById(id);
		}
	}
}
