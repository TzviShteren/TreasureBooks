namespace treasureBooks.ViewModel
{
    public class BookAddlVM
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Genre { get; set; }
        public string ErrorMessage { get; set; }

        public long SetBookfId { get; set; }
    }
}
