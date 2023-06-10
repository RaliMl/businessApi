using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class seedAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74120986-3403-4b11-b264-0585331b7040");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ffe3af-ccd8-44b7-abac-c028ed72fba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3bdb9cd-994e-410a-87dc-9ed6972afe87");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74120986-3403-4b11-b264-0585331b7040", null, "User", "USER" },
                    { "a1ffe3af-ccd8-44b7-abac-c028ed72fba8", null, "Admin", "ADMIN" },
                    { "a3bdb9cd-994e-410a-87dc-9ed6972afe87", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
