using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T_Camps.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTopicFromContactFormSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "ContactFormSubmissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "ContactFormSubmissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
