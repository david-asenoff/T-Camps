using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T_Camps.Migrations
{
    /// <inheritdoc />
    public partial class AddEventDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionFull",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionShort",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GalleryImageUrls",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationMapEmbedUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTube",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionFull",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DescriptionShort",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GalleryImageUrls",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocationMapEmbedUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "YouTube",
                table: "Events");
        }
    }
}
