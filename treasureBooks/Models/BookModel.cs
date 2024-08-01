using System.ComponentModel.DataAnnotations;

namespace treasureBooks.Models
{
    public class BookModel
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public required string Name { get; set; }

        [Required]
        public required int Height { get; set; } // גובה
        [Required]
        public required int Width { get; set; } // רוחב
        
        [Required, StringLength(50)]
        public required string Genre { get; set; }

        public SetBooksModel? SetModel { get; set; }

        public long SetId { get; set; }


    }
}