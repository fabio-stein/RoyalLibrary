using FluentValidation;
using MediatR;
using RoyalLibrary.Domain.Repository;

namespace RoyalLibrary.Features.Book;

public class BookSearchHandler(IBookRepository repository)
    : IRequestHandler<BookSearchHandler.Request, BookSearchHandler.Response>
{
    public record Request(string? Author, string? ISBN, int PageNumber, int PageSize) : IRequest<Response>;
    public record Response(List<Domain.Model.Book> Books);

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var pagedBooks = await repository.SearchBooksAsync(request.Author, request.ISBN, request.PageNumber, request.PageSize);

        return new Response(pagedBooks);
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