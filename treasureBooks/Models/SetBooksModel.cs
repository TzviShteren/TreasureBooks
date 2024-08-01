using System.ComponentModel.DataAnnotations;

namespace treasureBooks.Models
{
    public class SetBooksModel
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public required string Title { get; set; }

        public ShelfModel? Shelf { get; set; }
        public long ShelfId { get; set; }

        public List<BookModel> Books { get; set; } = [];
    }
}