using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Tokens",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Posts",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Korisnici");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Tokens",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Posts",
                newName: "DateTime");
        }
    }
}
