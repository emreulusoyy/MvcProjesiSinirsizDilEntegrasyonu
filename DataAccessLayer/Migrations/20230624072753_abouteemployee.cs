using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class abouteemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeSubtitle",
                table: "AboutLanguageItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeTitle",
                table: "AboutLanguageItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeSubtitle",
                table: "AboutLanguageItems");

            migrationBuilder.DropColumn(
                name: "EmployeeTitle",
                table: "AboutLanguageItems");
        }
    }
}
