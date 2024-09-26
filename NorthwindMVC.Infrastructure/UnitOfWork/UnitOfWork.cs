using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Infrastructure.Repositories;
using NorthwindMVC.Infrastucture;

namespace NorthwindMVC.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindDbContext _dbContext;
        public UnitOfWork(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
            User = new UserRepository(dbContext);
        }
        public IUserRepository User { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
