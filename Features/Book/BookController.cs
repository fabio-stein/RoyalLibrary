using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Infrastructure;

namespace RoyalLibrary.Features.Book;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public IActionResult Index([FromServices] LibraryDbContext context)
    {
        return Ok(context.Books.ToList());
    }
}