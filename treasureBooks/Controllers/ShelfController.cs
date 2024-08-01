using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using treasureBooks.Data;
using treasureBooks.Servis;
using treasureBooks.ViewModel;

namespace treasureBooks.Controllers
{
    public class ShelfController : Controller
    {
        
        private readonly IShelfServis _shelfServis;
        private readonly ApplicationDbContext _context;


        public ShelfController(IShelfServis servis, ApplicationDbContext context)
        {
            _shelfServis = servis;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {         

            return View(await _shelfServis.GetAllShelfs());
        }

        public IActionResult AddNewShelf(long Id, string Name)
        {
            ViewBag.Name = Name;
            ViewBag.Id = Id;
            return View(new ShelfAddVM() { LibraryId = Id, NameLibrary = Name });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewShelf(ShelfAddVM vm) =>
                    await _shelfServis.AddShelf(vm) ? RedirectToAction("Index") : View(vm);

    }
}
