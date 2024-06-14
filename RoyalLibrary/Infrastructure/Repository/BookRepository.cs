using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Domain.Model;
using RoyalLibrary.Domain.Repository;

namespace RoyalLibrary.Infrastructure.Repository;

public class BookRepository(LibraryDbContext context) : IBookRepository
{
    public async Task<List<Book>> SearchBooksAsync(string? author, string? isbn, int pageNumber, int pageSize)
    {
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(author))
        {
            var authorKeywords = author.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var keyword in authorKeywords)
            {
                query = query.Where(book => book.FirstName.Contains(keyword) || book.LastName.Contains(keyword));
            }
        }

        if (!string.IsNullOrEmpty(isbn))
        {
            query = query.Where(book => book.ISBN == isbn);
        }

        var skipAmount = (pageNumber - 1) * pageSize;
        var pagedBooks = await query.Skip(skipAmount).Take(pageSize).ToListAsync();

        return pagedBooks;
    }
}
