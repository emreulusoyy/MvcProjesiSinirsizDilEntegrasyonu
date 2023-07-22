using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class home : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImagePath1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImagePath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImagePath3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImagePath4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeID);
                });

            migrationBuilder.CreateTable(
                name: "HomeLanguageItems",
                columns: table => new
                {
                    HomeLanguageItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerPretitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerMoreButton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryPretitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorySubtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryMoreButton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductViewAllButton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPretitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactJoinUsPlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactSubcribeButton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    HomeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeLanguageItems", x => x.HomeLanguageItemID);
                    table.ForeignKey(
                        name: "FK_HomeLanguageItems_Homes_HomeID",
                        column: x => x.HomeID,
                        principalTable: "Homes",
                        principalColumn: "HomeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeLanguageItems_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeLanguageItems_HomeID",
                table: "HomeLanguageItems",
                column: "HomeID");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLanguageItems_LanguageID",
                table: "HomeLanguageItems",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeLanguageItems");

            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
