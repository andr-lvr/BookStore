using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.DAL
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
