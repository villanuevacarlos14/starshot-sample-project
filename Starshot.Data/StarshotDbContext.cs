using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starshot.Data.Mapping;
using Starshot.Data.Models;

namespace Starshot.Data
{
    public class StarshotDbContext : DbContext
    {
        public StarshotDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new EmployeeAttendanceConfiguration());

            var defaultPassword = "123456";
            var hashedPassword = new PasswordHasher<object?>().HashPassword(null, defaultPassword);

            //seed database
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
                HashedPassword = hashedPassword
            });

            builder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name ="John Doe"
            });
        }
    }
}
