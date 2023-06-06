using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodeBooks.Database.Migrations
{
    /// <inheritdoc />
    public partial class removeVolumeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInfos_Volumes_Id",
                table: "SaleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchInfos_Volumes_Id",
                table: "SearchInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VolumeInfos_Volumes_Id",
                table: "VolumeInfos");

            migrationBuilder.AddColumn<string>(
                name: "SaleInfoId",
                table: "Volumes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SearchInfoId",
                table: "Volumes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VolumeInfoId",
                table: "Volumes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_SaleInfoId",
                table: "Volumes",
                column: "SaleInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_SearchInfoId",
                table: "Volumes",
                column: "SearchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_VolumeInfoId",
                table: "Volumes",
                column: "VolumeInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_SaleInfos_SaleInfoId",
                table: "Volumes",
                column: "SaleInfoId",
                principalTable: "SaleInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_SearchInfos_SearchInfoId",
                table: "Volumes",
                column: "SearchInfoId",
                principalTable: "SearchInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_VolumeInfos_VolumeInfoId",
                table: "Volumes",
                column: "VolumeInfoId",
                principalTable: "VolumeInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_SaleInfos_SaleInfoId",
                table: "Volumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_SearchInfos_SearchInfoId",
                table: "Volumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_VolumeInfos_VolumeInfoId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_SaleInfoId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_SearchInfoId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_VolumeInfoId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "SaleInfoId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "SearchInfoId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "VolumeInfoId",
                table: "Volumes");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInfos_Volumes_Id",
                table: "SaleInfos",
                column: "Id",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchInfos_Volumes_Id",
                table: "SearchInfos",
                column: "Id",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolumeInfos_Volumes_Id",
                table: "VolumeInfos",
                column: "Id",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
