namespace treasureBooks.ViewModel
{
    public class SetBookAddVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
        public long ShelfId { get; set; }

        public List<BookAddlVM> Books { get; set; } = [];
    }
}
