using Microsoft.EntityFrameworkCore;
using treasureBooks.Data;
using treasureBooks.Models;
using treasureBooks.ViewModel;

namespace treasureBooks.Servis
{
    public class BookServis : IBookServis
    {
        private readonly ApplicationDbContext _context;

        public BookServis(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookModel>> GetAllBooks() =>
            await _context.Books
            .Select(x => x)
            .ToListAsync();

        public async Task<bool> AddBook(BookAddlVM newBook)
        {
            string? GetGenre = (
                from librarys in _context.Librarys
                join shelves in _context.Shelves on librarys.Id equals shelves.LibraryId
                join set in _context.SetBooks on shelves.Id equals set.ShelfId
                where librarys.Genre == newBook.Genre
                select librarys.Genre
                ).ToString();
            if (GetGenre != null)
            {
                newBook.ErrorMessage = $"Library Not found";
                return false;
            }
            if (newBook.Height < 1 || newBook.Width < 1)
            {
                newBook.ErrorMessage = $"must be greater than 1";
                return false;
            }

            BookModel model = new()
            {
                Name = newBook.Title,
                Height = newBook.Height,
                Width = newBook.Width,
                Genre = newBook.Genre,
                SetId = newBook.SetBookfId
            };
            await _context.Books.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
