using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class PostIndustry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostIndustryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostIndustryId",
                table: "Posts",
                column: "PostIndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Industries_PostIndustryId",
                table: "Posts",
                column: "PostIndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Industries_PostIndustryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostIndustryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostIndustryId",
                table: "Posts");
        }
    }
}
