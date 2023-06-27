using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLogger.Models;
using BookLogger.Data;
using BookLogger.Services;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IBookService _bookService;

    public BooksController(AppDbContext context, IBookService bookService)
    {
        _context = context;
        _bookService = bookService;
    }
    //GET /api/books/short?maxPages={maxPages}
    [HttpGet("short")]
    public async Task<ActionResult<IEnumerable<Book>>> GetShortBooks([FromQuery] int maxPages = 100)
    {
        var books = await _bookService.GetShortBooks(maxPages);
        return Ok(books);
    }

    // GET: api/Books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    // GET: api/Books/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // PUT: api/Books/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book book)
    {
        if (id != book.BookId)
        {
            return BadRequest();
        }

        _context.Entry(book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    // POST: api/Books
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        book.Author = null;
        book.Publisher = null;

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBook", new { id = book.BookId }, book);
    }


    // DELETE: api/Books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BookExists(int id)
    {
        return _context.Books.Any(e => e.BookId == id);
    }
}