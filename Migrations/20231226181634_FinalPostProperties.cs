using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class FinalPostProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Locations_LocationId",
                table: "Korisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Locations_LocationId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Posts",
                newName: "PostLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_LocationId",
                table: "Posts",
                newName: "IX_Posts_PostLocationId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Korisnici",
                newName: "KorisnikLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Korisnici_LocationId",
                table: "Korisnici",
                newName: "IX_Korisnici_KorisnikLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Locations_KorisnikLocationId",
                table: "Korisnici",
                column: "KorisnikLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Locations_PostLocationId",
                table: "Posts",
                column: "PostLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Locations_KorisnikLocationId",
                table: "Korisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Locations_PostLocationId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostLocationId",
                table: "Posts",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostLocationId",
                table: "Posts",
                newName: "IX_Posts_LocationId");

            migrationBuilder.RenameColumn(
                name: "KorisnikLocationId",
                table: "Korisnici",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Korisnici_KorisnikLocationId",
                table: "Korisnici",
                newName: "IX_Korisnici_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Locations_LocationId",
                table: "Korisnici",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Locations_LocationId",
                table: "Posts",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
