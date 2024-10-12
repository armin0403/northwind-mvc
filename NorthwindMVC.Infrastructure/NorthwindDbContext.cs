using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastucture
{
    public class NorthwindDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NorthwindDbContext(IConfiguration configuration) 
        
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("NorthwindConnection"));
    }
}