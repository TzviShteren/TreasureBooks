using Microsoft.EntityFrameworkCore;
using treasureBooks.Data;
using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public class ShelfServis(ApplicationDbContext context, ILibraryServis libraryServis) : IShelfServis
    {

        private readonly ApplicationDbContext _context = context;
        private readonly ILibraryServis _libraryServis = libraryServis;


        public async Task<ShelfModel> CreateShelfByLibraryIdAsync(ShelfAddVM shelfVM)
        {
            var library = await GetAllShelfsByLibraryIdAsync(shelfVM.LibraryId)
            ?? throw new Exception($"A library by {shelfVM.LibraryId} not exists");

            var model = new ShelfModel() { Height = shelfVM.Height, Width = shelfVM .Width , LibraryId = shelfVM .LibraryId};
            
            await _context.Shelves.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<ShelfModel>> GetAllShelfsAsync() =>
            await _context.Shelves.ToListAsync();

        public async Task<List<ShelfModel>> GetAllShelfsByLibraryIdAsync(long libraryId)
        {
            var library = await _context.Librarys
                .Include(lib => lib.Shelfs)
                .FirstOrDefaultAsync(lib => lib.Id == libraryId)
                ?? throw new Exception($"A library by {libraryId} not exists");

            return library.Shelfs.ToList();
        }

    }
}
