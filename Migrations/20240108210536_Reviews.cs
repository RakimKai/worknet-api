using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Korisnici_AutorId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Korisnici_CompanyId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Reviews",
                newName: "ReviewEmployeeId");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Reviews",
                newName: "ReviewCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CompanyId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AutorId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Korisnici_ReviewCompanyId",
                table: "Reviews",
                column: "ReviewCompanyId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Korisnici_ReviewEmployeeId",
                table: "Reviews",
                column: "ReviewEmployeeId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Korisnici_ReviewCompanyId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Korisnici_ReviewEmployeeId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewEmployeeId",
                table: "Reviews",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "ReviewCompanyId",
                table: "Reviews",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewEmployeeId",
                table: "Reviews",
                newName: "IX_Reviews_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewCompanyId",
                table: "Reviews",
                newName: "IX_Reviews_AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Korisnici_AutorId",
                table: "Reviews",
                column: "AutorId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Korisnici_CompanyId",
                table: "Reviews",
                column: "CompanyId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
