// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryLanguage> CountryLanguages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .ToTable("country") // Ensure mapping to correct table name in MySQL
            .HasKey(c => c.Code); // Define primary key for Country entity

        modelBuilder.Entity<City>()
            .ToTable("city"); // Ensure mapping to correct table name in MySQL

        modelBuilder.Entity<CountryLanguage>()
            .ToTable("countrylanguage");

        modelBuilder.Entity<Country>()
            .HasMany(c => c.Cities)
            .WithOne(c => c.Country)
            .HasForeignKey(c => c.CountryCode);

        modelBuilder.Entity<Country>()
            .HasMany(c => c.Languages)
            .WithOne(l => l.Country)
            .HasForeignKey(l => l.CountryCode);

        modelBuilder.Entity<City>()
            .HasKey(c => c.ID);

        modelBuilder.Entity<CountryLanguage>()
            .HasKey(cl => new { cl.CountryCode, cl.Language });
    }
}
