using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public interface IBookServis
    {
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<bool> AddBook(BookAddlVM newGenre);

    }
}
