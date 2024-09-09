using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.DataAccess;
using WebAPIDemo.Model;
using WebAPIDemo.Model.Entity;

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
        [HttpPost("Search")]
        public IActionResult Search(string s)
        {
            return Ok(_context.Book.Where(item => item.Title.Contains(s) || item.Author.Contains(s)).ToList());
        }
        [HttpPut("Add")]
        public IActionResult Add(string title, string author)
        {
            Book book = new Book();
            book.Title = title;
            book.Author = author;
            _context.Book.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpPost("Update")]
        public IActionResult Update(int id, string title, string author)
        {
            Book book = new Book();
            book.Id = id;
            book.Title = title;
            book.Author = author;
            _context.Book.Update(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            Book book = new Book();
            book.Id = id;
            _context.Book.Remove(book);
            _context.SaveChanges();
            return Ok(book);
        }
    }
}
}
