using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistHomepage.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArtowrkDraftContentProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistId",
                table: "ArtworkDraftContents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ArtworkDraftContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ForSale",
                table: "ArtworkDraftContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "ArtworkDraftContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "ArtworkDraftContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ArtworkDraftContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkDraftContents_ArtistId",
                table: "ArtworkDraftContents",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkDraftContents_AspNetUsers_ArtistId",
                table: "ArtworkDraftContents",
                column: "ArtistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkDraftContents_AspNetUsers_ArtistId",
                table: "ArtworkDraftContents");

            migrationBuilder.DropIndex(
                name: "IX_ArtworkDraftContents_ArtistId",
                table: "ArtworkDraftContents");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ArtworkDraftContents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ArtworkDraftContents");

            migrationBuilder.DropColumn(
                name: "ForSale",
                table: "ArtworkDraftContents");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "ArtworkDraftContents");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "ArtworkDraftContents");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ArtworkDraftContents");
        }
    }
}
