using Microsoft.EntityFrameworkCore;
using System;
using treasureBooks.Data;
using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public class SetBooksServis : ISetBooksServis
    {
        private readonly ApplicationDbContext _context;

        public SetBooksServis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SetBooksModel>> GetAllSetBooks() =>
            await _context.SetBooks
            .Select(x => x)
            .ToListAsync();


        public async Task<bool> AddSetBook(SetBookAddVM newSet)
        {
            SetBooksModel VM = new()
            {
                Title = newSet.Name,
            };
            await _context.SetBooks.AddAsync(VM);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
