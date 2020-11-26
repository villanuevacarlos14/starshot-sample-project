using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starshot.Web.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "DateCreated", "Name" },
                values: new object[] { 1, false, new DateTime(2020, 11, 26, 10, 18, 4, 39, DateTimeKind.Local).AddTicks(9000), "John Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "HashedPassword", "UserName" },
                values: new object[] { 1, new DateTime(2020, 11, 26, 10, 18, 4, 17, DateTimeKind.Local).AddTicks(6420), "AQAAAAEAACcQAAAAEAm8qU8LFbwZ2PY9awRidWj1MkhD9alg8dukwqxjUdkiC0epvl6nBD/t2/BdpES+iw==", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
