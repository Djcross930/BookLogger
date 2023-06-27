using System.Collections.Generic;
using System.Threading.Tasks;
using BookLogger.Models;

public interface IAuthorService
{
    Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);
}