using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using treasureBooks.Data;
using treasureBooks.Servis;
using treasureBooks.ViewModel;

namespace treasureBooks.Controllers
{
    public class ShelfController(IShelfServis shelfServis) : Controller
    {
        
        private readonly IShelfServis _shelfServis = shelfServis;
        

        public async Task<IActionResult> Index(long libraryId)
        {
            try
            {
                var shelves = await _shelfServis.GetAllShelfsByLibraryIdAsync(libraryId);
                return View(shelves);
            }
            catch (Exception)
            {
                return View("Index", "Library");
            }
        }

        public IActionResult CreateShelf(long libraryId) =>
            View(new ShelfAddVM() { LibraryId = libraryId });
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShelf(ShelfAddVM vm)
        {
            try
            {
                await _shelfServis.GetAllShelfsByLibraryIdAsync(vm.LibraryId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View(new LibraryAddVM());
            }
        }
    }
}
