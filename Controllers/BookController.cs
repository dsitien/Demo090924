using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.DataAccess;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BooksContext _context;

        public BookController(BooksContext context)
        {
            _context = context;
        }

        [HttpGet("Books")]
        public IActionResult GetBooks()
        {
            return Ok(_context.Book.ToList());
        }
    }
}
