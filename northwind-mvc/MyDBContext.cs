using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;
using northwind_mvc.Models;

namespace northwind_mvc
{
    public class MyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=Northwind;Username=postgres;Password=postgres");
    }
}
