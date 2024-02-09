using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Korisnici",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Korisnici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Universty",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkedAt",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_KorisnikId",
                table: "Skills",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_LocationId",
                table: "Korisnici",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Locations_LocationId",
                table: "Korisnici",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Korisnici_KorisnikId",
                table: "Skills",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Locations_LocationId",
                table: "Korisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Korisnici_KorisnikId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_KorisnikId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_LocationId",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Universty",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "WorkedAt",
                table: "Korisnici");
        }
    }
}
