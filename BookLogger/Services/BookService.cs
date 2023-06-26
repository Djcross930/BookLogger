using System.Collections.Generic;
using System.Threading.Tasks;
using BookLogger.Models;
using BookLogger.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLogger.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.AuthorId == authorId);
            return author?.Books;
        }
    }
}
