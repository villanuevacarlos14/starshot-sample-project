using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starshot.Data.Models;

namespace Starshot.Data.Mapping
{
    public class EmployeeAttendanceConfiguration : IEntityTypeConfiguration<EmployeeAttendance>
    {
        public void Configure(EntityTypeBuilder<EmployeeAttendance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ClockIn);
            builder.Property(x => x.ClockOut);
            builder.Property(x => x.EmployeeId);
            builder.Property(x => x.DateCreated);
        }
    }
}
