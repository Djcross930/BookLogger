using System.Collections.Generic;
using System.Threading.Tasks;
using BookLogger.Models;

namespace BookLogger.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetShortBooks(int maxPages); // New method
    }
}

