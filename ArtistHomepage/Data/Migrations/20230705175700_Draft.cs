using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistHomepage.Data.Migrations
{
    /// <inheritdoc />
    public partial class Draft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ArtworkDraftContent_ArtworkDraftContentId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "ArtworkDrafts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtworkDraftContent",
                table: "ArtworkDraftContent");

            migrationBuilder.RenameTable(
                name: "ArtworkDraftContent",
                newName: "ArtworkDraftContents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtworkDraftContents",
                table: "ArtworkDraftContents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ArtworkDraftContents_ArtworkDraftContentId",
                table: "Images",
                column: "ArtworkDraftContentId",
                principalTable: "ArtworkDraftContents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ArtworkDraftContents_ArtworkDraftContentId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtworkDraftContents",
                table: "ArtworkDraftContents");

            migrationBuilder.RenameTable(
                name: "ArtworkDraftContents",
                newName: "ArtworkDraftContent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtworkDraftContent",
                table: "ArtworkDraftContent",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ArtworkDrafts",
                columns: table => new
                {
                    ArtworkDraftId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtworkDraftContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkDrafts", x => x.ArtworkDraftId);
                    table.ForeignKey(
                        name: "FK_ArtworkDrafts_ArtworkDraftContent_ArtworkDraftContentId",
                        column: x => x.ArtworkDraftContentId,
                        principalTable: "ArtworkDraftContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkDrafts_ArtworkDraftContentId",
                table: "ArtworkDrafts",
                column: "ArtworkDraftContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ArtworkDraftContent_ArtworkDraftContentId",
                table: "Images",
                column: "ArtworkDraftContentId",
                principalTable: "ArtworkDraftContent",
                principalColumn: "Id");
        }
    }
}
