using ProteinProAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProteinProAPI.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SubCategoryCategories> SubCategoryCategories { get; set; }
    public DbSet<ProductSubCategories> ProductSubCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // -------------------------
        // SubCategory <-> Category
        // -------------------------
        modelBuilder.Entity<SubCategoryCategories>()
            .HasKey(scc => new { scc.SubCategoryId, scc.CategoryId });

        modelBuilder.Entity<SubCategoryCategories>()
            .HasOne(scc => scc.SubCategory)
            .WithMany(sc => sc.SubCategoryCategories)
            .HasForeignKey(scc => scc.SubCategoryId);

        modelBuilder.Entity<SubCategoryCategories>()
            .HasOne(scc => scc.Category)
            .WithMany(c => c.SubCategoryCategories)
            .HasForeignKey(scc => scc.CategoryId);

        // -------------------------
        // Product <-> SubCategory
        // -------------------------
        modelBuilder.Entity<ProductSubCategories>()
            .HasKey(psc => new { psc.ProductId, psc.SubCategoryId });

        modelBuilder.Entity<ProductSubCategories>()
            .HasOne(psc => psc.Product)
            .WithMany(p => p.ProductSubCategories)
            .HasForeignKey(psc => psc.ProductId);

        modelBuilder.Entity<ProductSubCategories>()
            .HasOne(psc => psc.SubCategory)
            .WithMany(sc => sc.ProductSubCategories)
            .HasForeignKey(psc => psc.SubCategoryId);

        // --- SEED DATA ---

        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Muskelopbygning", Url = "/muskelopbygning", Description = "Udforsk vores udvalg af kosttilskud til styrke og muskelvækst" },
            new Category { Id = 2, Name = "Mad & Snacks", Url = "/mad-snacks", Description = "Udforsk vores udvalg af sunde og lækre mad- og snackprodukter" },
            new Category { Id = 3, Name = "Energi", Url = "/energi", Description = "Udforsk vores udvalg af energigivende kosttilskud" },
            new Category { Id = 4, Name = "Tilbehør", Url = "/accessories", Description = "Udforsk vores udvalg af tilbehør" },
            new Category { Id = 5, Name = "Andet", Url = "/other", Description = "Udforsk vores produkter som ikke er kategoriseret under de primære kategorier" }
        );

        // SubCategories
        modelBuilder.Entity<SubCategory>().HasData(
            new SubCategory { Id = 1, Name = "Proteinpulver", Url = "/proteinpulver", Keywords = "protein, whey, isolat, proteinpulver", Description = "Proteinpulver er et kosttilskud, der hjælper med muskelopbygning, restitution og at dække dit daglige proteinbehov. Perfekt til alle, der træner, vil optimere deres resultater eller har brug for ekstra protein i hverdagen." },
            new SubCategory { Id = 2, Name = "Kreatin", Url = "/kreatin", Keywords = "kreatin, creatine, creapure", Description = "Kreatin er et populært kosttilskud blandt styrketrænere og atleter. Det hjælper med at øge styrke, eksplosivitet og muskelmasse ved at give musklerne mere energi under korte, intense træningspas. Kreatin findes naturligt i kød og fisk, men som pulver eller kapsler er det en praktisk måde at sikre optimal mængde på. Det er videnskabeligt dokumenteret, sikkert for de fleste voksne, og kan kombineres med proteinpulver for maksimal muskelvækst og restitution." },
            new SubCategory { Id = 3, Name = "Weight gainer", Url = "/weight-gainer", Keywords = "weight gainer, mass gainer, vægttilskud, gainer", Description = "Weight Gainer er et kosttilskud designet til at hjælpe med at tage på i vægt og opbygge muskelmasse. Det indeholder typisk en kombination af protein, kulhydrater og sunde fedtstoffer, som giver kroppen ekstra kalorier til at understøtte muskelvækst. Det er ideelt for personer, der har svært ved at spise nok gennem almindelig mad, f.eks. hurtigt stofskifte eller intensiv træning. Weight Gainer kan blandes i shakes, smoothies eller endda i madopskrifter, så det bliver nemt at få de nødvendige kalorier og proteiner." },
            new SubCategory { Id = 4, Name = "Pre workout", Url = "/pre-workout", Keywords = "pre workout, preworkout", Description = "Pre-Workout er et kosttilskud, der tages inden træning for at booste energi, fokus og udholdenhed. Det indeholder typisk koffein, aminosyrer og andre ingredienser, som hjælper dig med at yde dit bedste under intense træningspas. Pre-Workout er perfekt til dem, der vil have mere kraft, bedre koncentration og højere intensitet i deres træning. Det kan blandes med vand som en shake og tages ca. 20–30 minutter før træning." },
            new SubCategory { Id = 5, Name = "Proteinbarer", Url = "/proteinbarer", Keywords = "proteinbar, protein bar, barer, protein snack", Description = "Proteinbarer er praktiske snacks, der hjælper dig med at få ekstra protein på farten. De er perfekte før eller efter træning, eller som et mellemmåltid, når du har brug for en hurtig energikilde. Proteinbarer indeholder typisk en blanding af protein, kulhydrater og lidt fedt, og findes i mange smagsvarianter, så det bliver både sundt og lækkert. De understøtter muskelopbygning, restitution og hjælper dig med at nå dit daglige proteinbehov." },
            new SubCategory { Id = 6, Name = "Elektrolytter", Url = "/elektrolytter", Keywords = "elektrolyt, elektrolytter, electrolyte", Description= "Elektrolytter er essentielle mineraler som natrium, kalium og magnesium, der hjælper kroppen med at opretholde væskebalance, nervefunktion og muskelsammentrækning. De er især vigtige under og efter træning, når du sveder og mister salte, og kan hjælpe med at forebygge kramper, træthed og dehydrering. Elektrolytter fås som pulver, tabletter eller drikke, og er en enkel måde at sikre optimal væskebalance på." },
            new SubCategory { Id = 7, Name = "Gel", Url = "/gel", Keywords = "gel", Description = "Energigel er et hurtigtoptageligt kosttilskud, der typisk anvendes under løb, cykling og andre udholdenhedssportsgrene. Gelen indeholder primært kulhydrater, som giver hurtig energi til musklerne og hjælper med at opretholde blodsukkeret under længerevarende træning eller konkurrence. Nogle gels indeholder også elektrolytter for at modvirke væsketab, eller koffein for at give ekstra fokus og energi." },
            new SubCategory { Id = 8, Name = "Shaker", Url = "/shaker", Keywords = "shaker, flaske, bottle, drikkedunk", Description = "Shakers er uundværlige redskaber til at blande proteinpulver, kosttilskud og drikkevarer hurtigt og effektivt. De er designet med en tæt lukning og en indbygget si eller kugle, der hjælper med at nedbryde klumper og sikre en jævn konsistens. Shakers er ideelle til folk på farten, der ønsker en nem måde at forberede deres ernæringsdrikke på, hvad enten det er før eller efter træning. De fås i forskellige størrelser, materialer og designs, så du kan finde en, der passer til dine behov og stil." },
            new SubCategory { Id = 9, Name = "Udenfor kategori", Url = "/other", Keywords = "", Description = "Udforsk vores produkter som ikke er kategoriseret under de primære kategorier" },
            new SubCategory { Id = 10, Name = "Snacks", Url = "/snacks", Keywords = "snack, nødder, tørret frugt, bars, chips", Description = "Proteinbarer er praktiske snacks, der hjælper dig med at få ekstra protein på farten. De er perfekte før eller efter træning, eller som et mellemmåltid, når du har brug for en hurtig energikilde. Proteinbarer indeholder typisk en blanding af protein, kulhydrater og lidt fedt, og findes i mange smagsvarianter, så det bliver både sundt og lækkert. De understøtter muskelopbygning, restitution og hjælper dig med at nå dit daglige proteinbehov." }
        );

        // SubCategoryCategories (join table)
        modelBuilder.Entity<SubCategoryCategories>().HasData(
            new { SubCategoryId = 1, CategoryId = 1 },
            new { SubCategoryId = 2, CategoryId = 1 },
            new { SubCategoryId = 3, CategoryId = 1 },
            new { SubCategoryId = 4, CategoryId = 1 },
            new { SubCategoryId = 4, CategoryId = 3 },
            new { SubCategoryId = 5, CategoryId = 1 },
            new { SubCategoryId = 5, CategoryId = 2 },
            new { SubCategoryId = 6, CategoryId = 3 },
            new { SubCategoryId = 7, CategoryId = 3 },
            new { SubCategoryId = 8, CategoryId = 4 },
            new { SubCategoryId = 9, CategoryId = 5 },
            new { SubCategoryId = 10, CategoryId = 2 }
        );
    }
}
