using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class addCascadeDeleteSearchinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_SearchInfos_SearchInfoId",
                table: "Volumes");

            migrationBuilder.AlterColumn<string>(
                name: "SearchInfoId",
                table: "Volumes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_SearchInfos_SearchInfoId",
                table: "Volumes",
                column: "SearchInfoId",
                principalTable: "SearchInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_SearchInfos_SearchInfoId",
                table: "Volumes");

            migrationBuilder.AlterColumn<string>(
                name: "SearchInfoId",
                table: "Volumes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_SearchInfos_SearchInfoId",
                table: "Volumes",
                column: "SearchInfoId",
                principalTable: "SearchInfos",
                principalColumn: "Id");
        }
    }
}
