using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class PostEmploymentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostEmploymentTypeId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostEmploymentTypeId",
                table: "Posts",
                column: "PostEmploymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_EmploymentTypes_PostEmploymentTypeId",
                table: "Posts",
                column: "PostEmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_EmploymentTypes_PostEmploymentTypeId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostEmploymentTypeId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostEmploymentTypeId",
                table: "Posts");
        }
    }
}
