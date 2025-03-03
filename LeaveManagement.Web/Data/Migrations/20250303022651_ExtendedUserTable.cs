using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "839179df-57df-40f3-b88c-489024651b60",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dab48232-a4b8-4e89-8518-e1fef8ffa302", new DateOnly(1950, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEHgC2KCfUZJptMP9K6R0RMDpA5PlBb4FX4VaZFEayzVJZO1dzK+ixC7osNLihn435g==", "6bf2dac4-d064-4d13-8ed4-5e8757a9c3d4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "839179df-57df-40f3-b88c-489024651b60",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed7e6d59-bf1a-410e-96bc-5b76a38fc112", "AQAAAAIAAYagAAAAEHug+1EpTPBbeHUsLjSWuZM6uEj9D7AcbNkPWxBMvm4i9ppY+8cf9X9wRsnFgoATFg==", "9451abed-22d9-4abf-8c94-ba49bcbc7eba" });
        }
    }
}
