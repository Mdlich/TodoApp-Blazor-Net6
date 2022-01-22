using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.API.Migrations
{
    public partial class ExtendedUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TodoUserId",
                table: "Todos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0268a4f7-6947-4a3a-b257-f44c6b6eef75",
                column: "ConcurrencyStamp",
                value: "0c593eed-5f57-4447-9180-28ff25298ea5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af8f92e-1e9c-4160-9517-562cf32524dd",
                column: "ConcurrencyStamp",
                value: "3020ffb7-5f76-47d4-9366-1b16036142f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b2e4166-1722-400a-9fe1-f651ef15e852",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e5cc304-725f-4e9d-b83b-9b8f3ba41f5c", "AQAAAAEAACcQAAAAEE6qkox4ei8IovmRybRGJA5TBOltPzEjKcKDUgr2xATuVM90EcAzeQeyaj6yLb9Qtw==", "8e1babd7-9c7b-4376-ab0f-e7fc374916f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfa78716-7bdd-4929-b15d-8617337b9f52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66203bb4-efde-44b8-881b-914d42bbec33", "AQAAAAEAACcQAAAAEHmGLVlLeG9arg0EBotBoacRMal1AcGDi75gY6sL7W4MsKrixqFmEjtTWM97V41Wjg==", "0e8726ea-5361-4944-9218-53f26c6828ab" });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_TodoUserId",
                table: "Todos",
                column: "TodoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_TodoUserId",
                table: "Todos",
                column: "TodoUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_TodoUserId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_TodoUserId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TodoUserId",
                table: "Todos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0268a4f7-6947-4a3a-b257-f44c6b6eef75",
                column: "ConcurrencyStamp",
                value: "ab2ca3f8-3b3b-4706-a915-7a07cfa18a11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af8f92e-1e9c-4160-9517-562cf32524dd",
                column: "ConcurrencyStamp",
                value: "ec649cac-aaeb-4100-8565-1ff7b46c3337");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b2e4166-1722-400a-9fe1-f651ef15e852",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81ba5485-06c0-4b40-97cc-2bab2fc0c9c2", "AQAAAAEAACcQAAAAEMQKDtjxl03w7OFATz8HydIdshHycafmIA/DCGMKfc8LNypyVNBL9+f7qeuQ1KDZnA==", "5516b353-b2f8-4dae-951a-209aebae8dc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfa78716-7bdd-4929-b15d-8617337b9f52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58cafb0c-5f3a-4460-ac96-15671e522e10", "AQAAAAEAACcQAAAAEFgZDYNXXpMqQ8HZJRFFj4cSMXSxio+uJw6PolFcbOuekN6vkobjCCrWd6vv+yc/Rg==", "e03cdaee-72f7-4239-9f3d-c103d4b93cb1" });
        }
    }
}
