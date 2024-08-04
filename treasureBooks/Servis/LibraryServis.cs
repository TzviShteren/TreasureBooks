using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using treasureBooks.Data;
using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public class LibraryServis(ApplicationDbContext context) : ILibraryServis
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<LibraryModel>> GetLibrarysAsync() =>
            await _context.Librarys.ToListAsync();

        public async Task<bool> IsExistsByGevreAsync(string genre) =>
            await _context.Librarys.AnyAsync(x => x.Genre == genre);


		public async Task<LibraryModel> CreateLibraryAsync(LibraryAddVM libraryVM)
        {
            if (await IsExistsByGevreAsync(libraryVM.Genre))
            {
                throw new Exception($"A library {libraryVM.Genre} already exists");
            }

            LibraryModel Library = new() { Genre = libraryVM.Genre };
            await _context.Librarys.AddAsync(Library);
            await _context.SaveChangesAsync();
            return Library;
        }

        public async Task<LibraryModel?> FindLibraryByIdAsync(int id) =>
            await _context.Librarys.FirstOrDefaultAsync(x => x.Id == id);


        public async Task<LibraryModel?> DeleteByIdAsync(int id)
        {
            var toDelete = await FindLibraryByIdAsync(id) 
                ?? throw new Exception($"A library by {id} not exists");
            _context.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }
    }
}
