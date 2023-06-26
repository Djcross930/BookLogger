using System.Collections.Generic;
using System.Threading.Tasks;
using BookLogger.Models;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);
}