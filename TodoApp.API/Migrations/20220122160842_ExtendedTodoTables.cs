using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.API.Migrations
{
    public partial class ExtendedTodoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0268a4f7-6947-4a3a-b257-f44c6b6eef75",
                column: "ConcurrencyStamp",
                value: "ebec1b14-aefe-4f07-a6fd-498146afef6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af8f92e-1e9c-4160-9517-562cf32524dd",
                column: "ConcurrencyStamp",
                value: "00e7bf29-ca19-439f-9636-1c988e741361");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b2e4166-1722-400a-9fe1-f651ef15e852",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba949ffc-626f-4855-9698-102b799b46ed", "AQAAAAEAACcQAAAAELciMuyhQQQrclsxGJCxvOdwGB+o73unqsKqfHcW9d6xNhtMDp0XSx/ijQDaPDa1Hg==", "4faab990-971a-44d8-a886-32b9d6d710bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfa78716-7bdd-4929-b15d-8617337b9f52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308711de-52aa-4b42-9ac7-5674c02b078c", "AQAAAAEAACcQAAAAEC8a0S4uDI3xHcCFy/E5XsDW5ZxM2iRipW6O/BNKNs7Hwk+k2ZmAW2Nc8gUYHpqiaw==", "f5aecacd-e5dd-4e22-8843-f7cc04e118aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todos");

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
        }
    }
}
