using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class BaseClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "ImeKompanije",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Korisnici");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImeKompanije",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
