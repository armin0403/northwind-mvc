using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Core;

namespace NorthwindMVC.Infrastucture
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=Northwind;Username=postgres;Password=postgres");
    }
}