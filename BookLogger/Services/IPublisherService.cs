using System.Collections.Generic;
using System.Threading.Tasks;
using BookLogger.Models;
using BookLogger.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLogger.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<Book>> GetBooksByPublisherId(int publisherId);
    }
}

