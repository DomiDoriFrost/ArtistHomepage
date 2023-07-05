using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistHomepage.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArtworkDraftContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkDrafts_ArtworkCreateViewModel_ArtworkCreateViewModelId",
                table: "ArtworkDrafts");

            migrationBuilder.DropTable(
                name: "ArtworkCreateViewModel");

            migrationBuilder.DropIndex(
                name: "IX_ArtworkDrafts_ArtworkCreateViewModelId",
                table: "ArtworkDrafts");

            migrationBuilder.DropColumn(
                name: "DateDisplayMode",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "ArtworkCreateViewModelId",
                table: "ArtworkDrafts");

            migrationBuilder.AddColumn<int>(
                name: "ArtworkDraftContentId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtworkDraftContentId",
                table: "ArtworkDrafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArtworkDraftContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: true),
                    NewImageTags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkDraftContent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtworkDraftContentId",
                table: "Images",
                column: "ArtworkDraftContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkDrafts_ArtworkDraftContentId",
                table: "ArtworkDrafts",
                column: "ArtworkDraftContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkDrafts_ArtworkDraftContent_ArtworkDraftContentId",
                table: "ArtworkDrafts",
                column: "ArtworkDraftContentId",
                principalTable: "ArtworkDraftContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ArtworkDraftContent_ArtworkDraftContentId",
                table: "Images",
                column: "ArtworkDraftContentId",
                principalTable: "ArtworkDraftContent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkDrafts_ArtworkDraftContent_ArtworkDraftContentId",
                table: "ArtworkDrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_ArtworkDraftContent_ArtworkDraftContentId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "ArtworkDraftContent");

            migrationBuilder.DropIndex(
                name: "IX_Images_ArtworkDraftContentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_ArtworkDrafts_ArtworkDraftContentId",
                table: "ArtworkDrafts");

            migrationBuilder.DropColumn(
                name: "ArtworkDraftContentId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ArtworkDraftContentId",
                table: "ArtworkDrafts");

            migrationBuilder.AddColumn<int>(
                name: "DateDisplayMode",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Artworks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ArtworkCreateViewModelId",
                table: "ArtworkDrafts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtworkCreateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    NewImageTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkCreateViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtworkCreateViewModel_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkDrafts_ArtworkCreateViewModelId",
                table: "ArtworkDrafts",
                column: "ArtworkCreateViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkCreateViewModel_ArtworkId",
                table: "ArtworkCreateViewModel",
                column: "ArtworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkDrafts_ArtworkCreateViewModel_ArtworkCreateViewModelId",
                table: "ArtworkDrafts",
                column: "ArtworkCreateViewModelId",
                principalTable: "ArtworkCreateViewModel",
                principalColumn: "Id");
        }
    }
}
