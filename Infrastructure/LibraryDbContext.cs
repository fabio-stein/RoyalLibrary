using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.Infrastructure;

public class LibraryDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}