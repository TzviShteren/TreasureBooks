using System.ComponentModel.DataAnnotations;

namespace treasureBooks.ViewModel
{
    public class LibraryAddVM
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "not cool")]
        public string Genre { get; set; }

        public string ErrorMessage { get; set; }
    }
}
