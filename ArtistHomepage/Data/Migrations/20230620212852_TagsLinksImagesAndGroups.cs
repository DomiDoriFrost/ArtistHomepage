﻿// <auto-generated/>
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtistHomepage.Data.Migrations
{
    /// <inheritdoc />
    public partial class TagsLinksImagesAndGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "KofiLink",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Artworks");

            migrationBuilder.AddColumn<int>(
                name: "ArtworkIndex",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateDisplayMode",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReleaseDate",
                table: "Artworks",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArtworkGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtworkGroups_AspNetUsers_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CustomLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomLinks_AspNetUsers_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Copyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtworkId = table.Column<int>(type: "int", nullable: true),
                    ArtistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtworkArtworkGroup",
                columns: table => new
                {
                    ArtworksId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkArtworkGroup", x => new { x.ArtworksId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_ArtworkArtworkGroup_ArtworkGroups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "ArtworkGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtworkArtworkGroup_Artworks_ArtworksId",
                        column: x => x.ArtworksId,
                        principalTable: "Artworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArtworkGroupTags",
                columns: table => new
                {
                    ArtworkGroupsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkGroupTags", x => new { x.ArtworkGroupsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ArtworkGroupTags_ArtworkGroups_ArtworkGroupsId",
                        column: x => x.ArtworkGroupsId,
                        principalTable: "ArtworkGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtworkGroupTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArtworkTags",
                columns: table => new
                {
                    ArtworksId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkTags", x => new { x.ArtworksId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ArtworkTags_Artworks_ArtworksId",
                        column: x => x.ArtworksId,
                        principalTable: "Artworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtworkTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ImageTags",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTags", x => new { x.ImagesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ImageTags_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ImageTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkArtworkGroup_GroupsId",
                table: "ArtworkArtworkGroup",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkGroups_ArtistId",
                table: "ArtworkGroups",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkGroupTags_TagsId",
                table: "ArtworkGroupTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkTags_TagsId",
                table: "ArtworkTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomLinks_ArtistId",
                table: "CustomLinks",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtistId",
                table: "Images",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtworkId",
                table: "Images",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTags_TagsId",
                table: "ImageTags",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtworkArtworkGroup");

            migrationBuilder.DropTable(
                name: "ArtworkGroupTags");

            migrationBuilder.DropTable(
                name: "ArtworkTags");

            migrationBuilder.DropTable(
                name: "CustomLinks");

            migrationBuilder.DropTable(
                name: "ImageTags");

            migrationBuilder.DropTable(
                name: "ArtworkGroups");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropColumn(
                name: "ArtworkIndex",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "DateDisplayMode",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Artworks");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Artworks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KofiLink",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Artworks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Artworks",
                type: "int",
                nullable: true);
        }
    }
}
