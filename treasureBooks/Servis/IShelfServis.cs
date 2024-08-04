using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public interface IShelfServis
    {
        Task<List<ShelfModel>> GetAllShelfsAsync();
        Task<List<ShelfModel>> GetAllShelfsByLibraryIdAsync(long libraryId);
        Task<ShelfModel> CreateShelfByLibraryIdAsync(ShelfAddVM shelfVM);
    }
}
