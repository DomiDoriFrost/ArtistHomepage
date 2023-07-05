using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistHomepage.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArtworkDraftWithViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkDrafts_Artworks_ArtworkId",
                table: "ArtworkDrafts");

            migrationBuilder.RenameColumn(
                name: "ArtworkId",
                table: "ArtworkDrafts",
                newName: "ArtworkCreateViewModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtworkDrafts_ArtworkId",
                table: "ArtworkDrafts",
                newName: "IX_ArtworkDrafts_ArtworkCreateViewModelId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Artworks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ArtworkCreateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    NewImageTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkDrafts_ArtworkCreateViewModel_ArtworkCreateViewModelId",
                table: "ArtworkDrafts");

            migrationBuilder.DropTable(
                name: "ArtworkCreateViewModel");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Artworks");

            migrationBuilder.RenameColumn(
                name: "ArtworkCreateViewModelId",
                table: "ArtworkDrafts",
                newName: "ArtworkId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtworkDrafts_ArtworkCreateViewModelId",
                table: "ArtworkDrafts",
                newName: "IX_ArtworkDrafts_ArtworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkDrafts_Artworks_ArtworkId",
                table: "ArtworkDrafts",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id");
        }
    }
}
