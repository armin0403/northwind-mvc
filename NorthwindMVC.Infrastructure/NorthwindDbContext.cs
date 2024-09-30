using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastucture
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=Northwind;Username=postgres;Password=postgres");
    }
}