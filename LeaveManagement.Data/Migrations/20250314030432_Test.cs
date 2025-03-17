using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "839179df-57df-40f3-b88c-489024651b60",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d6d5a45-e95f-4fd7-aaa0-0e4cc5803c20", "AQAAAAIAAYagAAAAEHnD4TKhuQkfYkb5fEqYIvB44P2EW0LnbaGqOMMmxaOf6UkMOxNt/33lqwr62Ay6Pg==", "d8d2a012-435d-49c4-b5d4-531a7c449e23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "839179df-57df-40f3-b88c-489024651b60",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd4e8ddb-2c2f-45da-8f75-1b927460c27e", "AQAAAAIAAYagAAAAEEq5Idiq9tw7y5S7+RRxdxwIjYiXKYTngRly4QoVhIuDXbeISUCJXvMx0LfnMNl7cQ==", "63e1a967-bc87-463d-847a-d9b149402253" });
        }
    }
}
