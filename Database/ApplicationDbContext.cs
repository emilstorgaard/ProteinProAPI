using ProteinProAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProteinProAPI.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);

        // --- SEED DATA ---

        // Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Proteinpulver", Image = "proteinpulver.jpg", Keywords = "whey, isolat, proteinpulver" },
            new Category { Id = 2, Name = "Kreatin", Image = "kreatin.jpg", Keywords = "kreatin, creatine, creapure" },
            new Category { Id = 3, Name = "Weight gainer", Image = "weightGainer.jpg", Keywords = "weight gainer, mass gainer, vægttilskud, gainer, weight-gainer, mass-gainer" },
            new Category { Id = 4, Name = "Pre workout", Image = "preworkout.jpg", Keywords = "pre workout, preworkout, pre-workout" },
            new Category { Id = 5, Name = "Proteinbarer", Image = "proteinbar.jpg", Keywords = "proteinbar, protein bar, barer, protein snack" },
            new Category { Id = 6, Name = "Elektrolytter", Image = "elektrolytter.jpg", Keywords = "elektrolyt, elektrolytter, electrolyte" },
            new Category { Id = 7, Name = "Gels", Image = "gel.jpg", Keywords = "gel, gels" },
            new Category { Id = 8, Name = "Snacks", Image = "snacks.jpg", Keywords = "snack, nødder, tørret frugt, bars, chips, topping, sirup, toppings" },
            new Category { Id = 9, Name = "Tilbehør", Image = "tilbehør.jpg", Keywords = "shaker, bottle, tøj, sko, bælte, taske, hat, kasket" },
            new Category { Id = 10, Name = "Andet", Image = "other.jpg", Keywords = "" }
        );
    }
}
