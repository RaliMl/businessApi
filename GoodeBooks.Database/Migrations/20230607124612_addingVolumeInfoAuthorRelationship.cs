using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class addingVolumeInfoAuthorRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorVolumeInfo_VolumeInfos_VolumesId",
                table: "AuthorVolumeInfo");

            migrationBuilder.RenameColumn(
                name: "VolumesId",
                table: "AuthorVolumeInfo",
                newName: "VolumeInfosId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorVolumeInfo_VolumesId",
                table: "AuthorVolumeInfo",
                newName: "IX_AuthorVolumeInfo_VolumeInfosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorVolumeInfo_VolumeInfos_VolumeInfosId",
                table: "AuthorVolumeInfo",
                column: "VolumeInfosId",
                principalTable: "VolumeInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorVolumeInfo_VolumeInfos_VolumeInfosId",
                table: "AuthorVolumeInfo");

            migrationBuilder.RenameColumn(
                name: "VolumeInfosId",
                table: "AuthorVolumeInfo",
                newName: "VolumesId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorVolumeInfo_VolumeInfosId",
                table: "AuthorVolumeInfo",
                newName: "IX_AuthorVolumeInfo_VolumesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorVolumeInfo_VolumeInfos_VolumesId",
                table: "AuthorVolumeInfo",
                column: "VolumesId",
                principalTable: "VolumeInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
