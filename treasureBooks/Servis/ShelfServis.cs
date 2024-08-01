using Microsoft.EntityFrameworkCore;
using treasureBooks.Data;
using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public class ShelfServis : IShelfServis
    {

        private readonly ApplicationDbContext _context;

        public ShelfServis(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddShelf(ShelfAddVM newShelf)
        {
            if (newShelf.Width < 1 || newShelf.Height < 1)
            {
                newShelf.ErrorMessage = $"must be greater than 1";
                return false;
            }

            ShelfModel Shelf = new() 
            { 
                Width = newShelf.Width,
                Height = newShelf.Height,
                LibraryId = newShelf.LibraryId,
            };
            await _context.Shelves.AddAsync(Shelf);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ShelfModel>> GetAllShelfs() =>
            await _context.Shelves
            .Select(x => x)
            .ToListAsync();
    }
}
