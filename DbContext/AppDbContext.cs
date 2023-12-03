using iii.Models;

namespace iii.DbContext;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            Name = "Samosa",
            Price = 15,
            Description = "Lorem ipsum",
            ImageURL = "",
            CategoryName = "Appetizer"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 2,
            Name = "Samosa",
            Price = 20,
            Description = "Lorem ipsum 2",
            ImageURL = "",
            CategoryName = "Burger"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 3,
            Name = "Less",
            Price = 22,
            Description = "Lorem ipsum 3",
            ImageURL = "",
            CategoryName = "Alchohol"
        });
    }
}