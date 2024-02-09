using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class PostProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_EmploymentTypes_EmploymentTypeId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Korisnici_KorisnikId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Skills_SkillId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Korisnici_KorisnikId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_EmploymentTypeId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_KorisnikId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "KorisnikId",
                table: "Skills",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_KorisnikId",
                table: "Skills",
                newName: "IX_Skills_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Posts",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_SkillId",
                table: "Posts",
                newName: "IX_Posts_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Korisnici_CompanyId",
                table: "Posts",
                column: "CompanyId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Korisnici_EmployeeId",
                table: "Skills",
                column: "EmployeeId",
                principalTable: "Korisnici",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Korisnici_CompanyId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Korisnici_EmployeeId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Skills",
                newName: "KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills",
                newName: "IX_Skills_KorisnikId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Posts",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CompanyId",
                table: "Posts",
                newName: "IX_Posts_SkillId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EmploymentTypeId",
                table: "Posts",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_KorisnikId",
                table: "Posts",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_EmploymentTypes_EmploymentTypeId",
                table: "Posts",
                column: "EmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Korisnici_KorisnikId",
                table: "Posts",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Skills_SkillId",
                table: "Posts",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Korisnici_KorisnikId",
                table: "Skills",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id");
        }
    }
}
