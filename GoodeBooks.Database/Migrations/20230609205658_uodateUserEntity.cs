using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class uodateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3047bd22-ec8b-427c-9965-bee6026de5d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76756d98-6d00-4c3c-80c9-fbce0166b3a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8f9bc11-c5bf-4007-8175-5dfeb1ccd7e6");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3047bd22-ec8b-427c-9965-bee6026de5d2", null, "Employee", "EMPLOYEE" },
                    { "76756d98-6d00-4c3c-80c9-fbce0166b3a2", null, "User", "USER" },
                    { "c8f9bc11-c5bf-4007-8175-5dfeb1ccd7e6", null, "Admin", "ADMIN" }
                });
        }
    }
}
