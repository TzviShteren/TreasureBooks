using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public interface ILibraryServis
    {
        Task<List<LibraryModel>> GetLibrarysAsync();
		Task<bool> IsExistsByGevreAsync(string genre);
		Task<LibraryModel> CreateLibraryAsync(LibraryAddVM newGenre);
		Task<LibraryModel?> FindLibraryByIdAsync(int id);

        Task<LibraryModel?> DeleteByIdAsync(int id);

        //LibraryModel SearchLibrarys();
    }
}
