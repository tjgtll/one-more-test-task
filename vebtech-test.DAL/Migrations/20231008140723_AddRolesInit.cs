using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vebtech_test.DAL.Migrations
{
    public partial class AddRolesInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0c28edfb-3e7f-408f-85a0-53041be07da7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("715a846b-9514-4459-83d0-faf27280955f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("891aab7d-820d-4ae3-a637-e81cc9b29b84"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8da50a15-064e-4f51-bc55-b27810d394df"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"), "Admin" },
                    { new Guid("ba96c858-bc06-463d-864e-d411836fc931"), "Support" },
                    { new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"), "SuperAdmin" },
                    { new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"), "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ba96c858-bc06-463d-864e-d411836fc931"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c28edfb-3e7f-408f-85a0-53041be07da7"), "User" },
                    { new Guid("715a846b-9514-4459-83d0-faf27280955f"), "Admin" },
                    { new Guid("891aab7d-820d-4ae3-a637-e81cc9b29b84"), "SuperAdmin" },
                    { new Guid("8da50a15-064e-4f51-bc55-b27810d394df"), "Support" }
                });
        }
    }
}
