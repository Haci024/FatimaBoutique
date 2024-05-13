using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class BlogImagesTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsImages_Blogs_BLogsId",
                table: "BlogsImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguage_Categories_CategoriesId",
                table: "CategoryLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguage_Languages_LanguageId",
                table: "CategoryLanguage");

            migrationBuilder.DropTable(
                name: "FrequentlyQuestionsLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLanguage",
                table: "CategoryLanguage");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "AboutUsLanguages");

            migrationBuilder.RenameTable(
                name: "CategoryLanguage",
                newName: "CategoryLanguages");

            migrationBuilder.RenameColumn(
                name: "BLogsId",
                table: "BlogsImages",
                newName: "BLogId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogsImages_BLogsId",
                table: "BlogsImages",
                newName: "IX_BlogsImages_BLogId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLanguage_LanguageId",
                table: "CategoryLanguages",
                newName: "IX_CategoryLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLanguage_CategoriesId",
                table: "CategoryLanguages",
                newName: "IX_CategoryLanguages_CategoriesId");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "BlogsImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLanguages",
                table: "CategoryLanguages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogsLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    BlogsId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogsLanguages_Blogs_BlogsId",
                        column: x => x.BlogsId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogsLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogsLanguages_BlogsId",
                table: "BlogsLanguages",
                column: "BlogsId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsLanguages_LanguageId",
                table: "BlogsLanguages",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsImages_Blogs_BLogId",
                table: "BlogsImages",
                column: "BLogId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguages_Categories_CategoriesId",
                table: "CategoryLanguages",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguages_Languages_LanguageId",
                table: "CategoryLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsImages_Blogs_BLogId",
                table: "BlogsImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguages_Categories_CategoriesId",
                table: "CategoryLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLanguages_Languages_LanguageId",
                table: "CategoryLanguages");

            migrationBuilder.DropTable(
                name: "BlogsLanguages");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLanguages",
                table: "CategoryLanguages");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "FrequentlyQuestions");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "FrequentlyQuestions");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "BlogsImages");

            migrationBuilder.RenameTable(
                name: "CategoryLanguages",
                newName: "CategoryLanguage");

            migrationBuilder.RenameColumn(
                name: "BLogId",
                table: "BlogsImages",
                newName: "BLogsId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogsImages_BLogId",
                table: "BlogsImages",
                newName: "IX_BlogsImages_BLogsId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLanguages_LanguageId",
                table: "CategoryLanguage",
                newName: "IX_CategoryLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLanguages_CategoriesId",
                table: "CategoryLanguage",
                newName: "IX_CategoryLanguage_CategoriesId");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "AboutUsLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLanguage",
                table: "CategoryLanguage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FrequentlyQuestionsLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequentlyQuestionsId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaqId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsImages_Blogs_BLogsId",
                table: "BlogsImages",
                column: "BLogsId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguage_Categories_CategoriesId",
                table: "CategoryLanguage",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLanguage_Languages_LanguageId",
                table: "CategoryLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
