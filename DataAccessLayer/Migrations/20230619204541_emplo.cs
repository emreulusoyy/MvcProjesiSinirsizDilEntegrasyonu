using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class emplo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeLanguageItems",
                columns: table => new
                {
                    EmployeeLanguageItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguageItems", x => x.EmployeeLanguageItemID);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageItems_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageItems_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageItems_EmployeeID",
                table: "EmployeeLanguageItems",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageItems_LanguageID",
                table: "EmployeeLanguageItems",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLanguageItems");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
