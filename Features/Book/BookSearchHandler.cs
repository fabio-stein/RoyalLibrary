using MediatR;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Infrastructure;

namespace RoyalLibrary.Features.Book;

public class BookSearchHandler(LibraryDbContext context)
    : IRequestHandler<BookSearchHandler.BookSearchRequest, BookSearchHandler.BookSearchResponse>
{
    public record BookSearchRequest() : IRequest<BookSearchResponse>;
    public record BookSearchResponse(List<Domain.Model.Book> Books);

    public async Task<BookSearchResponse> Handle(BookSearchRequest request, CancellationToken cancellationToken)
    {
        var books = await context.Books.ToListAsync(cancellationToken);
        var response = new BookSearchResponse(books);
        return response;
    }
}