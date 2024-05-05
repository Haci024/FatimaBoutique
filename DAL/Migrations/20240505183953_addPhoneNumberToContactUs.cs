using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addPhoneNumberToContactUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsLanguages_AboutUs_AboutUsId",
                table: "AboutUsLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsLanguages_Languages_LanguageId",
                table: "AboutUsLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutUsLanguages",
                table: "AboutUsLanguages");

            migrationBuilder.RenameTable(
                name: "AboutUsLanguages",
                newName: "AboutUsLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_AboutUsLanguages_LanguageId",
                table: "AboutUsLanguage",
                newName: "IX_AboutUsLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AboutUsLanguages_AboutUsId",
                table: "AboutUsLanguage",
                newName: "IX_AboutUsLanguage_AboutUsId");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutUsLanguage",
                table: "AboutUsLanguage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsLanguage_AboutUs_AboutUsId",
                table: "AboutUsLanguage",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsLanguage_Languages_LanguageId",
                table: "AboutUsLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsLanguage_AboutUs_AboutUsId",
                table: "AboutUsLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsLanguage_Languages_LanguageId",
                table: "AboutUsLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutUsLanguage",
                table: "AboutUsLanguage");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ContactUs");

            migrationBuilder.RenameTable(
                name: "AboutUsLanguage",
                newName: "AboutUsLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_AboutUsLanguage_LanguageId",
                table: "AboutUsLanguages",
                newName: "IX_AboutUsLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AboutUsLanguage_AboutUsId",
                table: "AboutUsLanguages",
                newName: "IX_AboutUsLanguages_AboutUsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutUsLanguages",
                table: "AboutUsLanguages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsLanguages_AboutUs_AboutUsId",
                table: "AboutUsLanguages",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsLanguages_Languages_LanguageId",
                table: "AboutUsLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
