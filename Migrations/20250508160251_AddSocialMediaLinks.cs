using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T_Camps.Migrations
{
    /// <inheritdoc />
    public partial class AddSocialMediaLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "YouTube",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "SocialMediaLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMediaLink_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLink_CompanyId",
                table: "SocialMediaLink",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediaLink");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "X",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YouTube",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
