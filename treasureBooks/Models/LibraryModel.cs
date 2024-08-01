using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace treasureBooks.Models
{
    [Index(nameof(Genre), IsUnique = true)]
    public class LibraryModel
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(50)]
        public required string Genre { get; set; }

        public List<ShelfModel> Shelfs { get; set; } = [];

    }
}
