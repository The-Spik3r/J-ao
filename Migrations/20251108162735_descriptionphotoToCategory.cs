using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jīao.Migrations
{
    /// <inheritdoc />
    public partial class descriptionphotoToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fotoUrl",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "fotoUrl" },
                values: new object[] { "Authentic Japanese ramen bowls with rich broths", "https://pics.example/category-ramen.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "fotoUrl",
                table: "Categories");
        }
    }
}
