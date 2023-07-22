using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class footerfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "FooterLanguageItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FooterLanguageItems_LanguageID",
                table: "FooterLanguageItems",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_FooterLanguageItems_Languages_LanguageID",
                table: "FooterLanguageItems",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "LanguageID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FooterLanguageItems_Languages_LanguageID",
                table: "FooterLanguageItems");

            migrationBuilder.DropIndex(
                name: "IX_FooterLanguageItems_LanguageID",
                table: "FooterLanguageItems");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "FooterLanguageItems");
        }
    }
}
