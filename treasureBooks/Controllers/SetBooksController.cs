using Microsoft.AspNetCore.Mvc;
using treasureBooks.Data;
using treasureBooks.Servis;
using treasureBooks.ViewModel;

namespace treasureBooks.Controllers
{
    public class SetBooksController : Controller
    {
        private readonly ISetBooksServis _setBooksServis;

        
        public SetBooksController(ISetBooksServis servis)
        {
            _setBooksServis = servis;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _setBooksServis.GetAllSetBooks());
        }
        public IActionResult AddNewSet(long Id, int Height, int Width)
        {
            ViewBag.Id = Id;
            ViewBag.Height = Height;
            ViewBag.Width = Width;
            return View(new SetBookAddVM { ShelfId = Id});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewShelf(SetBookAddVM vm) =>
                    await _setBooksServis.AddSetBook(vm) ? RedirectToAction("Index") : View(vm);
    }
}
