using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace worknet_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "FullTime",
                table: "EmploymentTypes");

            migrationBuilder.DropColumn(
                name: "PartTime",
                table: "EmploymentTypes");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Skills",
                newName: "IndustryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills",
                newName: "IX_Skills_IndustryId");

            migrationBuilder.RenameColumn(
                name: "Remote",
                table: "EmploymentTypes",
                newName: "Title");

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmploymentTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Full-time" },
                    { 2, "Part-time" },
                    { 3, "Remote" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Business" },
                    { 2, "Real Estate" },
                    { 3, "Technology" },
                    { 4, "Healthcare" },
                    { 5, "Finance" },
                    { 6, "Education" },
                    { 7, "Hospitality" },
                    { 8, "Manufacturing" },
                    { 9, "Retail" },
                    { 10, "Transportation" },
                    { 11, "Marketing" },
                    { 12, "Construction" },
                    { 13, "Agriculture" },
                    { 14, "Media and Entertainment" },
                    { 15, "Energy" },
                    { 16, "Telecommunications" },
                    { 17, "Automotive" },
                    { 18, "Legal" },
                    { 19, "Environmental" },
                    { 20, "Architecture" },
                    { 21, "Pharmaceuticals" },
                    { 22, "Nonprofit" },
                    { 23, "Research and Development" },
                    { 24, "Information Technology" },
                    { 25, "Human Resources" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country" },
                values: new object[,]
                {
                    { 1, "", "" },
                    { 2, "Sarajevo", "Bosnia and Herzegovina" },
                    { 3, "Zagreb", "Croatia" },
                    { 4, "Pristina", "Kosovo" },
                    { 5, "Podgorica", "Montenegro" },
                    { 6, "Skopje", "North Macedonia" },
                    { 7, "Belgrade", "Serbia" },
                    { 8, "Ljubljana", "Slovenia" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "EmployeeId", "IndustryId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "Business Strategy" },
                    { 2, null, 1, "Management" },
                    { 3, null, 1, "Entrepreneurship" },
                    { 4, null, 2, "Property Management" },
                    { 5, null, 2, "Real Estate Development" },
                    { 6, null, 2, "Commercial Real Estate" },
                    { 7, null, 3, "Programming" },
                    { 8, null, 3, "Software Development" },
                    { 9, null, 3, "Data Science" },
                    { 10, null, 4, "Medical Coding" },
                    { 11, null, 4, "Nursing" },
                    { 12, null, 4, "Health Informatics" },
                    { 13, null, 5, "Financial Analysis" },
                    { 14, null, 5, "Investment Banking" },
                    { 15, null, 5, "Accounting" },
                    { 16, null, 6, "Teaching" },
                    { 17, null, 6, "Educational Technology" },
                    { 18, null, 6, "Curriculum Design" },
                    { 19, null, 7, "Customer Service" },
                    { 20, null, 7, "Hotel Management" },
                    { 21, null, 7, "Event Planning" },
                    { 22, null, 8, "Quality Control" },
                    { 23, null, 8, "Supply Chain Management" },
                    { 24, null, 8, "Lean Manufacturing" },
                    { 25, null, 9, "Visual Merchandising" },
                    { 26, null, 9, "Retail Sales" },
                    { 27, null, 9, "Inventory Management" },
                    { 28, null, 10, "Logistics" },
                    { 29, null, 10, "Fleet Management" },
                    { 30, null, 10, "Aviation" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Industries_IndustryId",
                table: "Skills",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Industries_IndustryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.RenameColumn(
                name: "IndustryId",
                table: "Skills",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_IndustryId",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "EmploymentTypes",
                newName: "Remote");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullTime",
                table: "EmploymentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartTime",
                table: "EmploymentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                table: "Skills",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
