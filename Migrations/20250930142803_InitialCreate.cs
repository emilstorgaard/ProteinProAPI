using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BodyUpAPI.Migrations
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubCategories", x => new { x.ProductId, x.SubCategoryId });
                    table.ForeignKey(
                        name: "FK_ProductSubCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSubCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryCategories", x => new { x.SubCategoryId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_SubCategoryCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Udforsk vores udvalg af kosttilskud til styrke og muskelvækst", "Muskelopbygning", "/muskelopbygning" },
                    { 2, "Udforsk vores udvalg af sunde og lækre mad- og snackprodukter", "Mad & Snacks", "/mad-snacks" },
                    { 3, "Udforsk vores udvalg af energigivende kosttilskud", "Energi", "/muskelopbygning" },
                    { 4, "Udforsk vores udvalg af tilbehør", "Tilbehør", "/accessories" },
                    { 5, "Udforsk vores produkter som ikke er kategoriseret under de primære kategorier", "Andet", "/other" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "Description", "Keywords", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Proteinpulver er et kosttilskud, der hjælper med muskelopbygning, restitution og at dække dit daglige proteinbehov. Perfekt til alle, der træner, vil optimere deres resultater eller har brug for ekstra protein i hverdagen.", "protein, whey, isolat, proteinpulver", "Proteinpulver", "/proteinpulver" },
                    { 2, "Kreatin er et populært kosttilskud blandt styrketrænere og atleter. Det hjælper med at øge styrke, eksplosivitet og muskelmasse ved at give musklerne mere energi under korte, intense træningspas. Kreatin findes naturligt i kød og fisk, men som pulver eller kapsler er det en praktisk måde at sikre optimal mængde på. Det er videnskabeligt dokumenteret, sikkert for de fleste voksne, og kan kombineres med proteinpulver for maksimal muskelvækst og restitution.", "kreatin, creatine, creapure", "Kreatin", "/kreatin" },
                    { 3, "Weight Gainer er et kosttilskud designet til at hjælpe med at tage på i vægt og opbygge muskelmasse. Det indeholder typisk en kombination af protein, kulhydrater og sunde fedtstoffer, som giver kroppen ekstra kalorier til at understøtte muskelvækst. Det er ideelt for personer, der har svært ved at spise nok gennem almindelig mad, f.eks. hurtigt stofskifte eller intensiv træning. Weight Gainer kan blandes i shakes, smoothies eller endda i madopskrifter, så det bliver nemt at få de nødvendige kalorier og proteiner.", "weight gainer, mass gainer, vægttilskud, gainer", "Weight gainer", "/weight-gainer" },
                    { 4, "Pre-Workout er et kosttilskud, der tages inden træning for at booste energi, fokus og udholdenhed. Det indeholder typisk koffein, aminosyrer og andre ingredienser, som hjælper dig med at yde dit bedste under intense træningspas. Pre-Workout er perfekt til dem, der vil have mere kraft, bedre koncentration og højere intensitet i deres træning. Det kan blandes med vand som en shake og tages ca. 20–30 minutter før træning.", "pre workout, preworkout", "Pre workout", "/pre-workout" },
                    { 5, "Proteinbarer er praktiske snacks, der hjælper dig med at få ekstra protein på farten. De er perfekte før eller efter træning, eller som et mellemmåltid, når du har brug for en hurtig energikilde. Proteinbarer indeholder typisk en blanding af protein, kulhydrater og lidt fedt, og findes i mange smagsvarianter, så det bliver både sundt og lækkert. De understøtter muskelopbygning, restitution og hjælper dig med at nå dit daglige proteinbehov.", "proteinbar, protein bar, barer, protein snack", "Proteinbarer", "/proteinbarer" },
                    { 6, "Elektrolytter er essentielle mineraler som natrium, kalium og magnesium, der hjælper kroppen med at opretholde væskebalance, nervefunktion og muskelsammentrækning. De er især vigtige under og efter træning, når du sveder og mister salte, og kan hjælpe med at forebygge kramper, træthed og dehydrering. Elektrolytter fås som pulver, tabletter eller drikke, og er en enkel måde at sikre optimal væskebalance på.", "elektrolyt, elektrolytter, electrolyte", "Elektrolytter", "/elektrolytter" },
                    { 7, "Energigel er et hurtigtoptageligt kosttilskud, der typisk anvendes under løb, cykling og andre udholdenhedssportsgrene. Gelen indeholder primært kulhydrater, som giver hurtig energi til musklerne og hjælper med at opretholde blodsukkeret under længerevarende træning eller konkurrence. Nogle gels indeholder også elektrolytter for at modvirke væsketab, eller koffein for at give ekstra fokus og energi.", "gel", "Gel", "/gel" },
                    { 8, "Shakers er uundværlige redskaber til at blande proteinpulver, kosttilskud og drikkevarer hurtigt og effektivt. De er designet med en tæt lukning og en indbygget si eller kugle, der hjælper med at nedbryde klumper og sikre en jævn konsistens. Shakers er ideelle til folk på farten, der ønsker en nem måde at forberede deres ernæringsdrikke på, hvad enten det er før eller efter træning. De fås i forskellige størrelser, materialer og designs, så du kan finde en, der passer til dine behov og stil.", "shaker, flaske, bottle, drikkedunk", "Shaker", "/shaker" },
                    { 9, "Udforsk vores produkter som ikke er kategoriseret under de primære kategorier", "", "Udenfor kategori", "/other" },
                    { 10, "Proteinbarer er praktiske snacks, der hjælper dig med at få ekstra protein på farten. De er perfekte før eller efter træning, eller som et mellemmåltid, når du har brug for en hurtig energikilde. Proteinbarer indeholder typisk en blanding af protein, kulhydrater og lidt fedt, og findes i mange smagsvarianter, så det bliver både sundt og lækkert. De understøtter muskelopbygning, restitution og hjælper dig med at nå dit daglige proteinbehov.", "snack, nødder, tørret frugt, bars, chips", "Snacks", "/snacks" }
                });

            migrationBuilder.InsertData(
                table: "SubCategoryCategories",
                columns: new[] { "CategoryId", "SubCategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 2, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubCategories_SubCategoryId",
                table: "ProductSubCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryCategories_CategoryId",
                table: "SubCategoryCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSubCategories");

            migrationBuilder.DropTable(
                name: "SubCategoryCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SubCategories");
        }
    }
}
