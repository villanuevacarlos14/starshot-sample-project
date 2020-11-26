using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starshot.Web.Migrations
{
    public partial class ModifyAttendanceEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockOut",
                table: "EmployeeAttendances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockIn",
                table: "EmployeeAttendances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 26, 21, 15, 57, 498, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "HashedPassword" },
                values: new object[] { new DateTime(2020, 11, 26, 21, 15, 57, 485, DateTimeKind.Local).AddTicks(1440), "AQAAAAEAACcQAAAAEHavsII44T9nNAwFGXDyBB+pU8kuh4oyRtGdrkASK2T3Q/Gn56C+BCrZ3BbapP8ZUQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockOut",
                table: "EmployeeAttendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockIn",
                table: "EmployeeAttendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 26, 10, 18, 4, 39, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "HashedPassword" },
                values: new object[] { new DateTime(2020, 11, 26, 10, 18, 4, 17, DateTimeKind.Local).AddTicks(6420), "AQAAAAEAACcQAAAAEAm8qU8LFbwZ2PY9awRidWj1MkhD9alg8dukwqxjUdkiC0epvl6nBD/t2/BdpES+iw==" });
        }
    }
}
