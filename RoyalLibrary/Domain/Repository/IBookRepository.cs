using RoyalLibrary.Domain.Model;

namespace RoyalLibrary.Domain.Repository;

public interface IBookRepository
{
    Task<List<Book>> SearchBooksAsync(string? author, string? isbn, int pageNumber, int pageSize);
}