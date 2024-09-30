using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindMVC.Core;


namespace NorthwindMVC.Infrastructure.Services
{
    public interface IUserService
    {
        Task<User> LogIn (string username, string password);
        Task<User> SignUpAsync (User user);
    }
}
