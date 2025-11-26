using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jīao.Migrations
{
    /// <inheritdoc />
    public partial class happyhour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "Menus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHappyHour",
                table: "Menus",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiscountPercentage", "IsHappyHour" },
                values: new object[] { 15, true });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiscountPercentage", "IsHappyHour" },
                values: new object[] { 0, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IsHappyHour",
                table: "Menus");
        }
    }
}
