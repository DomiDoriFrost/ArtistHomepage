using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistHomepage.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArtworkDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtworkDrafts",
                columns: table => new
                {
                    ArtworkDraftId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtworkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkDrafts", x => x.ArtworkDraftId);
                    table.ForeignKey(
                        name: "FK_ArtworkDrafts_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkDrafts_ArtworkId",
                table: "ArtworkDrafts",
                column: "ArtworkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtworkDrafts");
        }
    }
}
