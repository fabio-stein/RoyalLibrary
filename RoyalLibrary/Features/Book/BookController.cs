using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RoyalLibrary.Features.Book;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index([FromServices] IMediator mediator, [FromQuery] BookSearchHandler.Request request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }
}