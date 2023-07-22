using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class about_Contact_languageitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Languages_LanguageID",
                table: "Abouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Languages_LanguageID",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LanguageID",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_LanguageID",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactUs",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AboutUs",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "VisionMission",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "BannerImage");

            migrationBuilder.RenameColumn(
                name: "HaveQuestion",
                table: "Contacts",
                newName: "AddresIframe");

            migrationBuilder.AddColumn<string>(
                name: "AboutImagePath",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BannerImagePath",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AboutLanguageItems",
                columns: table => new
                {
                    AboutLanguageItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageBannerSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionPretitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDescriptionCard1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDescriptionCard2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDescriptionCard3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionDescriptionCard4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticPretitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemValue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemValue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemValue3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemValue4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemName5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatisticItemValue5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    AboutID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutLanguageItems", x => x.AboutLanguageItemID);
                    table.ForeignKey(
                        name: "FK_AboutLanguageItems_Abouts_AboutID",
                        column: x => x.AboutID,
                        principalTable: "Abouts",
                        principalColumn: "AboutID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutLanguageItems_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactLanguageItems",
                columns: table => new
                {
                    ContactLanguageItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageBannerSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaveQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceholderFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceholderSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceholderMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceholderPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceholderMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendButton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLanguageItems", x => x.ContactLanguageItemID);
                    table.ForeignKey(
                        name: "FK_ContactLanguageItems_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactLanguageItems_Languages_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Languages",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutLanguageItems_AboutID",
                table: "AboutLanguageItems",
                column: "AboutID");

            migrationBuilder.CreateIndex(
                name: "IX_AboutLanguageItems_LanguageID",
                table: "AboutLanguageItems",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLanguageItems_ContactID",
                table: "ContactLanguageItems",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLanguageItems_LanguageID",
                table: "ContactLanguageItems",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutLanguageItems");

            migrationBuilder.DropTable(
                name: "ContactLanguageItems");

            migrationBuilder.DropColumn(
                name: "AboutImagePath",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "BannerImagePath",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "BannerImage",
                table: "Contacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "AddresIframe",
                table: "Contacts",
                newName: "HaveQuestion");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUs",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AboutUs",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisionMission",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageID",
                table: "Contacts",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_LanguageID",
                table: "Abouts",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Languages_LanguageID",
                table: "Abouts",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "LanguageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Languages_LanguageID",
                table: "Contacts",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "LanguageID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
