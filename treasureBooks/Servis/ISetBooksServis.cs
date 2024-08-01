using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public interface ISetBooksServis
    {
        Task<IEnumerable<SetBooksModel>> GetAllSetBooks();
        Task<bool> AddSetBook(SetBookAddVM newSet);
    }
}
