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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeTerritory>()
                .HasKey(et => new { et.EmployeeId, et.TerritoryId });

            modelBuilder.Entity<EmployeeTerritory>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTerritories)
                .HasForeignKey(et => et.EmployeeId);

            modelBuilder.Entity<EmployeeTerritory>()
                .HasOne(et => et.Territory)
                .WithMany(t => t.EmployeeTerritories)
                .HasForeignKey(et => et.TerritoryId);

            modelBuilder.Entity<EmployeeTerritory>()
                .HasIndex(et => new { et.EmployeeId, et.TerritoryId })
                .IsUnique();
        }
    }
}