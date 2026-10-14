using BookNest.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Web.Data;

public class BookNestContext(DbContextOptions<BookNestContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(150).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Author).HasMaxLength(120).IsRequired();
        modelBuilder.Entity<Book>().HasIndex(b => b.Status);
    }
}
