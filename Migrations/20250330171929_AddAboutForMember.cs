using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T_Camps.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutForMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Members");
        }
    }
}
