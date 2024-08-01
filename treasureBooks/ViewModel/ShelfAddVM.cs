using System.ComponentModel.DataAnnotations;

namespace treasureBooks.ViewModel
{
    public class ShelfAddVM
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public long LibraryId { get; set; }
        public string NameLibrary { get; set; }
        public string ErrorMessage { get; set; }



    }
}
