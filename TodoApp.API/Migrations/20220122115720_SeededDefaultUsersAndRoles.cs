using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.API.Migrations
{
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0268a4f7-6947-4a3a-b257-f44c6b6eef75", "ab2ca3f8-3b3b-4706-a915-7a07cfa18a11", "Admin", "ADMIN" },
                    { "6af8f92e-1e9c-4160-9517-562cf32524dd", "ec649cac-aaeb-4100-8565-1ff7b46c3337", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6b2e4166-1722-400a-9fe1-f651ef15e852", 0, "81ba5485-06c0-4b40-97cc-2bab2fc0c9c2", "admin@Todo.com", false, false, null, "ADMIN@TODO.COM", "ADMIN@TODO.COM", "AQAAAAEAACcQAAAAEMQKDtjxl03w7OFATz8HydIdshHycafmIA/DCGMKfc8LNypyVNBL9+f7qeuQ1KDZnA==", null, false, "5516b353-b2f8-4dae-951a-209aebae8dc2", false, "admin@Todo.com" },
                    { "dfa78716-7bdd-4929-b15d-8617337b9f52", 0, "58cafb0c-5f3a-4460-ac96-15671e522e10", "user@Todo.com", false, false, null, "USER@TODO.COM", "USER@TODO.COM", "AQAAAAEAACcQAAAAEFgZDYNXXpMqQ8HZJRFFj4cSMXSxio+uJw6PolFcbOuekN6vkobjCCrWd6vv+yc/Rg==", null, false, "e03cdaee-72f7-4239-9f3d-c103d4b93cb1", false, "user@Todo.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0268a4f7-6947-4a3a-b257-f44c6b6eef75", "6b2e4166-1722-400a-9fe1-f651ef15e852" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6af8f92e-1e9c-4160-9517-562cf32524dd", "dfa78716-7bdd-4929-b15d-8617337b9f52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0268a4f7-6947-4a3a-b257-f44c6b6eef75", "6b2e4166-1722-400a-9fe1-f651ef15e852" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6af8f92e-1e9c-4160-9517-562cf32524dd", "dfa78716-7bdd-4929-b15d-8617337b9f52" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0268a4f7-6947-4a3a-b257-f44c6b6eef75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af8f92e-1e9c-4160-9517-562cf32524dd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b2e4166-1722-400a-9fe1-f651ef15e852");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfa78716-7bdd-4929-b15d-8617337b9f52");
        }
    }
}
