using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Infrastructure;

namespace RoyalLibrary.Features.Book;

public class BookSearchHandler(LibraryDbContext context)
    : IRequestHandler<BookSearchHandler.Request, BookSearchHandler.Response>
{
    public record Request(string? Author, string? ISBN, int PageNumber, int PageSize) : IRequest<Response>;
    public record Response(List<Domain.Model.Book> Books);

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(request.Author))
        {
            var authorKeywords = request.Author.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var keyword in authorKeywords)
            {
                query = query.Where(book => book.FirstName.Contains(keyword) || book.LastName.Contains(keyword));
            }
        }

        if (!string.IsNullOrEmpty(request.ISBN))
        {
            query = query.Where(book => book.ISBN == request.ISBN);
        }

        var skipAmount = (request.PageNumber - 1) * request.PageSize;
        var pagedBooks = await query.Skip(skipAmount).Take(request.PageSize).ToListAsync(cancellationToken);

        var response = new Response(pagedBooks);
        return response;
    }

    public class BookSearchValidator : AbstractValidator<Request>
    {
        public BookSearchValidator()
        {
            RuleFor(x => x.Author)
                .MaximumLength(50)
                .WithMessage("Author name must not exceed 50 characters.");

            RuleFor(x => x.ISBN)
                .MaximumLength(80)
                .WithMessage("ISBN must not exceed 80 characters.");
            
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("Page size must be between 1 and 100.");
        }
    }
}