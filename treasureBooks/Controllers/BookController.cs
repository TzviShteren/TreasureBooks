using Microsoft.AspNetCore.Mvc;
using treasureBooks.Servis;
using treasureBooks.ViewModel;

namespace treasureBooks.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServis _bookServis;


        public BookController(IBookServis servis)
        {
            _bookServis = servis;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _bookServis.GetAllBooks());
        }
        public IActionResult AddNewBook(long id)
        {
            return View(new BookAddlVM {SetBookfId = id});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBook(BookAddlVM vm) =>
                    await _bookServis.AddBook(vm) ? RedirectToAction("Index") : View(vm);
    }
}
