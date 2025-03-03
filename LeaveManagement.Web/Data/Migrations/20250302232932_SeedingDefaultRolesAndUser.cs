using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51ebf45e-e394-4f00-84d5-9723848f60f3", null, "Supervisor", "SUPERVISOR" },
                    { "b1ea5f0b-9d02-4274-9ec4-653266d741a4", null, "Employee", "EMPLOYEE" },
                    { "f9565a3f-fe93-4fac-9ec9-772c0f1c7289", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "839179df-57df-40f3-b88c-489024651b60", 0, "ed7e6d59-bf1a-410e-96bc-5b76a38fc112", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHug+1EpTPBbeHUsLjSWuZM6uEj9D7AcbNkPWxBMvm4i9ppY+8cf9X9wRsnFgoATFg==", null, false, "9451abed-22d9-4abf-8c94-ba49bcbc7eba", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f9565a3f-fe93-4fac-9ec9-772c0f1c7289", "839179df-57df-40f3-b88c-489024651b60" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51ebf45e-e394-4f00-84d5-9723848f60f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1ea5f0b-9d02-4274-9ec4-653266d741a4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9565a3f-fe93-4fac-9ec9-772c0f1c7289", "839179df-57df-40f3-b88c-489024651b60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9565a3f-fe93-4fac-9ec9-772c0f1c7289");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "839179df-57df-40f3-b88c-489024651b60");
        }
    }
}
