using System;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed categories
            modelBuilder.Entity<Country>().HasData(SeedDataFactory.Countries);
            modelBuilder.Entity<JobCategory>().HasData(SeedDataFactory.JobCategories);
            modelBuilder.Entity<Employee>().HasData(SeedDataFactory.Employees);
            modelBuilder.Entity<Benefit>().HasData(SeedDataFactory.Benefits);


        }
    }
}
