using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class BlogsTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Blogs");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Blogs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Blogs");

            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "Blogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
