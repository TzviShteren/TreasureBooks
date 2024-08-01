using Microsoft.EntityFrameworkCore;
using treasureBooks.Models;

namespace treasureBooks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Seed();
        }
        private void Seed()
        {
            if (!Librarys.Any())
            {
                List<LibraryModel> lib = [
                    new() {Genre = "Tension"},
                    new() {Genre = "Science Fiction"},
                    new() {Genre = "health"},
                    new() {Genre = "psychology"}
                ];
                Librarys.AddRange(lib);
                SaveChanges();
            }
        }

        public DbSet<LibraryModel> Librarys { get; set; }
        public DbSet<ShelfModel> Shelves { get; set; }
        public DbSet<SetBooksModel> SetBooks { get; set; }
        public DbSet<BookModel> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryModel>() // Library 1:N Shelf
                .HasMany(lib => lib.Shelfs)
                .WithOne(she => she.Library)
                .HasForeignKey(i => i.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShelfModel>() // Shelf 1:N SetBooks
                .HasMany(she => she.SetBooksList)
                .WithOne(sb => sb.Shelf)
                .HasForeignKey(i => i.ShelfId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetBooksModel>() // SetBooks 1:N Book
                .HasMany(sb => sb.Books)
                .WithOne(b => b.SetModel)
                .HasForeignKey(i => i.SetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
