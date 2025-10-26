using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jīao.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirtName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketStalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketStalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketStalls_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MarketStallId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_MarketStalls_MarketStallId",
                        column: x => x.MarketStallId,
                        principalTable: "MarketStalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartMenu",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartMenu", x => new { x.CartsId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_CartMenu_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartMenu_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "FirtName", "LastName", "Password", "State" },
                values: new object[] { 1, "Mei", "Zhang", "hash_demo", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Password", "State" },
                values: new object[,]
                {
                    { 1, "Av Siempre Viva 742", "karenbailapiola@gmail.com", "Karen", "Lasot", "Pa$$w0rd", 0 },
                    { 2, "Calle Falsa 123", "elluismidetotoras@gmail.com", "Luis", "Gonzales", "lamismadesiempre", 0 }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "MarketStalls",
                columns: new[] { "Id", "Description", "Location", "Name", "SellerId" },
                values: new object[] { 1, "Ramen & dumplings", "Centro", "Jīao Noodle Bar", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MarketStallId", "Name" },
                values: new object[] { 1, 1, "Ramen" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Caldo intenso, chashu, negi", "https://pics.example/ramen1.jpg", "Tonkotsu Ramen", 6500m, 50 },
                    { 2, 1, "Dumplings de cerdo", "https://pics.example/gyoza.jpg", "Gyoza (6)", 4200m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartMenu_MenusId",
                table: "CartMenu",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MarketStallId",
                table: "Categories",
                column: "MarketStallId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketStalls_SellerId",
                table: "MarketStalls",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartMenu");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MarketStalls");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
