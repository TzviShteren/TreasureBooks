using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public interface IShelfServis
    {
        Task<IEnumerable<ShelfModel>> GetAllShelfs();
        Task<bool> AddShelf(ShelfAddVM newShelf);
    }
}
