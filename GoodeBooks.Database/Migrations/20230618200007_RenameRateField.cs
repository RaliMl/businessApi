using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameRateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Volumes");

            migrationBuilder.AddColumn<double>(
                name: "AverageRate",
                table: "Volumes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRate",
                table: "Volumes");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Volumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
