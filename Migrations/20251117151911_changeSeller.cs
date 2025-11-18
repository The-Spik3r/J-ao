using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jīao.Migrations
{
    /// <inheritdoc />
    public partial class changeSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarketStalls_SellerId",
                table: "MarketStalls");

            migrationBuilder.RenameColumn(
                name: "FirtName",
                table: "Sellers",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "MarketStalls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MarketStalls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Views",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarketStalls_SellerId",
                table: "MarketStalls",
                column: "SellerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarketStalls_SellerId",
                table: "MarketStalls");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "MarketStalls");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Sellers",
                newName: "FirtName");

            migrationBuilder.CreateIndex(
                name: "IX_MarketStalls_SellerId",
                table: "MarketStalls",
                column: "SellerId");
        }
    }
}
