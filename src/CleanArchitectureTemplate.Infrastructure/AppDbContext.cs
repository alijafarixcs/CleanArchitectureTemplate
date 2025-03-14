using CleanArchitectureTemplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Infrastructure;
public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } // Example entity
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) // Ensures this runs only if not configured by DI
        {
            optionsBuilder.UseSqlite("Data Source=./db/mydatabase.db");
        }
    }
}
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.OwnsOne(b => b.Price, price =>
        {
            price.Property(p => p.Value).HasColumnName("Price");
        });
    }
}
