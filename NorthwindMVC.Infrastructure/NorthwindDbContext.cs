using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastructure
{
    public class NorthwindDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options, IConfiguration configuration) 
            : base(options)
		{
			_configuration = configuration;
		}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}