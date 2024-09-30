using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
