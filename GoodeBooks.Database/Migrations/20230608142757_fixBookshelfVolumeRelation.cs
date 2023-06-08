using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixBookshelfVolumeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_Bookshelves_BookshelfId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_BookshelfId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "BookshelfId",
                table: "Volumes");

            migrationBuilder.CreateTable(
                name: "BookshelfVolume",
                columns: table => new
                {
                    BookshelvesId = table.Column<long>(type: "bigint", nullable: false),
                    VolumesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookshelfVolume", x => new { x.BookshelvesId, x.VolumesId });
                    table.ForeignKey(
                        name: "FK_BookshelfVolume_Bookshelves_BookshelvesId",
                        column: x => x.BookshelvesId,
                        principalTable: "Bookshelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookshelfVolume_Volumes_VolumesId",
                        column: x => x.VolumesId,
                        principalTable: "Volumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookshelfVolume_VolumesId",
                table: "BookshelfVolume",
                column: "VolumesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookshelfVolume");

            migrationBuilder.AddColumn<long>(
                name: "BookshelfId",
                table: "Volumes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_BookshelfId",
                table: "Volumes",
                column: "BookshelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_Bookshelves_BookshelfId",
                table: "Volumes",
                column: "BookshelfId",
                principalTable: "Bookshelves",
                principalColumn: "Id");
        }
    }
}
