using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FaqLanguageTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "FrequentlyQuestions");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "FrequentlyQuestions");

            migrationBuilder.CreateTable(
                name: "FrequentlyQuestionsLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    FaqId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequentlyQuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequentlyQuestionsLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrequentlyQuestionsLanguage_FrequentlyQuestions_FrequentlyQuestionsId",
                        column: x => x.FrequentlyQuestionsId,
                        principalTable: "FrequentlyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrequentlyQuestionsLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrequentlyQuestionsLanguage_FrequentlyQuestionsId",
                table: "FrequentlyQuestionsLanguage",
                column: "FrequentlyQuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_FrequentlyQuestionsLanguage_LanguageId",
                table: "FrequentlyQuestionsLanguage",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrequentlyQuestionsLanguage");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "FrequentlyQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "FrequentlyQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
