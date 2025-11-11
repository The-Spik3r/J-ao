using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jīao.Migrations
{
    /// <inheritdoc />
    public partial class fixtocase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fotoUrl",
                table: "Categories",
                newName: "FotoUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FotoUrl",
                table: "Categories",
                newName: "fotoUrl");
        }
    }
}
