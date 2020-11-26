﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Starshot.Data;

namespace Starshot.Web.Migrations
{
    [DbContext(typeof(StarshotDbContext))]
    partial class StarshotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Starshot.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            DateCreated = new DateTime(2020, 11, 26, 22, 2, 33, 272, DateTimeKind.Local).AddTicks(4320),
                            Name = "John Doe"
                        });
                });

            modelBuilder.Entity("Starshot.Data.Models.EmployeeAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("ClockIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ClockOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAttendances");
                });

            modelBuilder.Entity("Starshot.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2020, 11, 26, 22, 2, 33, 247, DateTimeKind.Local).AddTicks(8410),
                            HashedPassword = "AQAAAAEAACcQAAAAELx3fdTyLGtOYrrSVikKWghAZ69DTUJTJtPCabDCnKUTWnoogsUax20+xeEuSGkMPQ==",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Starshot.Data.Models.EmployeeAttendance", b =>
                {
                    b.HasOne("Starshot.Data.Models.Employee", "Employee")
                        .WithMany("EmployeAttendance")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Starshot.Data.Models.Employee", b =>
                {
                    b.Navigation("EmployeAttendance");
                });
#pragma warning restore 612, 618
        }
    }
}
