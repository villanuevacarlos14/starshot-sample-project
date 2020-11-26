using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starshot.Data.Models;

namespace Starshot.Data.Mapping
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Active);
            builder.Property(x => x.DateCreated);
            builder.HasMany(x => x.EmployeAttendance)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId);
        }
    }
}
