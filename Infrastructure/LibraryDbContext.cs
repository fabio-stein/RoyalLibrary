using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.Infrastructure;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
}