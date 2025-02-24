using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T_Camps.Migrations
{
    /// <inheritdoc />
    public partial class AddClientViewModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Clients",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Clients",
                newName: "Note");
        }
    }
}
