using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class TokenLogicFinished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Tokens_TokenId",
                table: "Korisnici");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_TokenId",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "Korisnici");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TokenId",
                table: "Korisnici",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_TokenId",
                table: "Korisnici",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Tokens_TokenId",
                table: "Korisnici",
                column: "TokenId",
                principalTable: "Tokens",
                principalColumn: "Id");
        }
    }
}
