using System;
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

        public async Task<IEnumerable<Book>> GetShortBooks(int maxPages)
        {
            return await _context.Books.Where(b => b.Pages <= maxPages).ToListAsync();
        }
    }
}

