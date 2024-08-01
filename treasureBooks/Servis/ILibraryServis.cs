using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public interface ILibraryServis
    {
        Task<IEnumerable<LibraryModel>> GetAllLibrarys();
        Task<IEnumerable<LibraryModel>> GetAll();
        Task<bool> AddLibrary(LibraryAddVM newGenre);

        //LibraryModel SearchLibrarys();
    }
}
