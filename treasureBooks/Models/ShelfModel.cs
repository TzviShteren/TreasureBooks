using System.ComponentModel.DataAnnotations;

namespace treasureBooks.Models
{
    public class ShelfModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public required int Height { get; set; } // גובה
        [Required]
        public required int Width { get; set; } // רוחב

        public LibraryModel? Library { get; set; }

        public long LibraryId { get; set; }

        public List<SetBooksModel> SetBooksList { get; set; } = [];
    }
}