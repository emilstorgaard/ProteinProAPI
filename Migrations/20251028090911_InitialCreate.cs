using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProteinProAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Retailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Keywords", "Name" },
                values: new object[,]
                {
                    { 1, "proteinpulver.jpg", "whey, isolat, proteinpulver", "Proteinpulver" },
                    { 2, "kreatin.jpg", "kreatin, creatine, creapure", "Kreatin" },
                    { 3, "weightGainer.jpg", "weight gainer, mass gainer, vægttilskud, gainer, weight-gainer, mass-gainer", "Weight gainer" },
                    { 4, "preworkout.jpg", "pre workout, preworkout, pre-workout", "Pre workout" },
                    { 5, "proteinbar.jpg", "proteinbar, protein bar, barer, protein snack", "Proteinbarer" },
                    { 6, "elektrolytter.jpg", "elektrolyt, elektrolytter, electrolyte", "Elektrolytter" },
                    { 7, "gel.jpg", "gel, gels", "Gels" },
                    { 8, "snacks.jpg", "snack, nødder, tørret frugt, bars, chips, topping, sirup, toppings", "Snacks" },
                    { 9, "tilbehør.jpg", "shaker, bottle, tøj, sko, bælte, taske, hat, kasket", "Tilbehør" },
                    { 10, "other.jpg", "", "Andet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
