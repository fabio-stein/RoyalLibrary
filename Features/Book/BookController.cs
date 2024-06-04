using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RoyalLibrary.Features.Book;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index([FromServices] IMediator mediator)
    {
        var response = await mediator.Send(new BookSearchHandler.BookSearchRequest());
        return Ok(response);
    }
}