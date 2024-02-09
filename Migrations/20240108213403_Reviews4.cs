using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class Reviews4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewCompanyId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewCompanyId",
                table: "Reviews",
                column: "ReviewCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Korisnici_ReviewCompanyId",
                table: "Reviews",
                column: "ReviewCompanyId",
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

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ReviewCompanyId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewCompanyId",
                table: "Reviews");
        }
    }
}
