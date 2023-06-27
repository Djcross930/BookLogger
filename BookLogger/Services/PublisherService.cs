using System.Collections.Generic;
using System.Threading.Tasks;
using BookLogger.Models;
using BookLogger.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLogger.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisherId(int publisherId)
        {
            var publisher = await _context.Publishers.Include(p => p.Books).FirstOrDefaultAsync(p => p.PublisherId == publisherId);
            return publisher?.Books;
        }
    }

}

