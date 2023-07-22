using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class footer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    FooterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinterestLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinterestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.FooterID);
                });

            migrationBuilder.CreateTable(
                name: "FooterLanguageItems",
                columns: table => new
                {
                    FooterLanguageItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterLanguageItems", x => x.FooterLanguageItemID);
                    table.ForeignKey(
                        name: "FK_FooterLanguageItems_Footers_FooterID",
                        column: x => x.FooterID,
                        principalTable: "Footers",
                        principalColumn: "FooterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FooterLanguageItems_FooterID",
                table: "FooterLanguageItems",
                column: "FooterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterLanguageItems");

            migrationBuilder.DropTable(
                name: "Footers");
        }
    }
}
