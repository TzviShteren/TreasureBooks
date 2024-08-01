using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using treasureBooks.Data;
using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public class LibraryServis : ILibraryServis
    {

        private readonly ApplicationDbContext _context;

        public LibraryServis(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> AddLibrary(LibraryAddVM vm)
        {
            if (_context.Librarys.Any(x => x.Genre == vm.Genre))
            {
                vm.ErrorMessage = $"A library {vm.Genre} already exists";
                return false;
            }

            LibraryModel Library = new() { Genre = vm.Genre };
            await _context.Librarys.AddAsync(Library);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LibraryModel>> GetAllLibrarys() =>
            await _context.Librarys
            .Select(x => x)
            .ToListAsync();

        public async Task<IEnumerable<LibraryModel>> GetAll() =>
            await _context.Librarys
             .Include(lib => lib.Shelfs)
             .ThenInclude(sh => sh.Select(x => x.SetBooksList))
             .ThenInclude(sb => sb.Select(x => x.Select(x => x.Books)))
             .ToListAsync();
    }
}
