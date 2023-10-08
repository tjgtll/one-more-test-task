using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vebtech_test.DAL.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name" },
                values: new object[] { new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"), 30, "admin1@example.com", "Admin1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name" },
                values: new object[] { new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"), 35, "superadmin1@example.com", "SuperAdmin1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name" },
                values: new object[] { new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"), 25, "user1@example.com", "User1" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5db705b2-6c4f-41b6-a461-56ba62b96082"), new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"), new Guid("d80c8954-b524-4f3e-960a-7711fde800d8") },
                    { new Guid("c4b467c8-a335-416b-8b5c-4912d9c694e5"), new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"), new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0") },
                    { new Guid("d6ef90dd-537b-4d6e-9587-118db3a09353"), new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"), new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d") },
                    { new Guid("dd844386-9d3f-47b8-984b-46c295219c4f"), new Guid("ba96c858-bc06-463d-864e-d411836fc931"), new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("5db705b2-6c4f-41b6-a461-56ba62b96082"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("c4b467c8-a335-416b-8b5c-4912d9c694e5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6ef90dd-537b-4d6e-9587-118db3a09353"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd844386-9d3f-47b8-984b-46c295219c4f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"));
        }
    }
}
