using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Core;
using NorthwindMVC.Core.Models;

namespace NorthwindMVC.Infrastructure
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}