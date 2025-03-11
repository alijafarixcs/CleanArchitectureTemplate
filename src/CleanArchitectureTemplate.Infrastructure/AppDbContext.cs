using CleanArchitectureTemplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace  CleanArchitectureTemplate.Infrastructure;
public class AppDbContext : DbContext
{
    public DbSet<MyEntity> Entities { get; set; } // Example entity

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./db/mydatabase.db");
    }
}
