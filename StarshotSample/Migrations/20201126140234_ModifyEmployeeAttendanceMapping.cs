using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starshot.Web.Migrations
{
    public partial class ModifyEmployeeAttendanceMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 26, 22, 2, 33, 272, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "HashedPassword" },
                values: new object[] { new DateTime(2020, 11, 26, 22, 2, 33, 247, DateTimeKind.Local).AddTicks(8410), "AQAAAAEAACcQAAAAELx3fdTyLGtOYrrSVikKWghAZ69DTUJTJtPCabDCnKUTWnoogsUax20+xeEuSGkMPQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
