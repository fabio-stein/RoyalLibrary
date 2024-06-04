using FluentAssertions;
using FluentValidation.TestHelper;
using MockQueryable.Moq;
using Moq;
using RoyalLibrary.Domain.Model;
using RoyalLibrary.Features.Book;
using RoyalLibrary.Infrastructure;

namespace RoyalLibrary.Tests;

public class BookSearchHandlerTests
    {
        [Fact]
        public void BookSearchValidator_ValidRequest_ShouldPassValidation()
        {
            // Arrange
            var validator = new BookSearchHandler.BookSearchValidator();
            var request = new BookSearchHandler.Request("John Doe", "1234567890");

            // Act
            var result = validator.TestValidate(request);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("John Doe doiwahduoawhduawidhaowudhaowdhaowidhwadoiawhdoiawhdwaoihdawhdowahdiowahdowa", "1234567890123456789012345678901234567890123456789012345678901234567890123456789051515125151251512512")]
        public void BookSearchValidator_InvalidRequest_ShouldHaveValidationErrors(string author, string isbn)
        {
            // Arrange
            var validator = new BookSearchHandler.BookSearchValidator();
            var request = new BookSearchHandler.Request(author, isbn);

            // Act
            var result = validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.Author);
            result.ShouldHaveValidationErrorFor(r => r.ISBN);
        }
    }