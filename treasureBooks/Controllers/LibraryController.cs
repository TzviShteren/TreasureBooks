using Microsoft.AspNetCore.Mvc;
using treasureBooks.Data;
using treasureBooks.Servis;
using treasureBooks.ViewModel;
namespace treasureBooks.Controllers
{
    public class LibraryController(ILibraryServis libraryServis) : Controller
    {

        private readonly ILibraryServis _libraryServis = libraryServis;


        public async Task<IActionResult> Index() =>
			View(await _libraryServis.GetLibrarysAsync());


		public async Task<IActionResult> AllInformation()
        {
            return View(await _libraryServis.GetLibrarysAsync());
        }

        [HttpGet]
        public IActionResult AddNewLibrary() =>
            View(new LibraryAddVM());
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewLibrary(LibraryAddVM vm)
        {
            try
            {
                await _libraryServis.CreateLibraryAsync(vm);
                return RedirectToAction("Index");
			}
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View(new LibraryAddVM());
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var delete = await _libraryServis.DeleteByIdAsync(id);
                return View("Details", delete);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View("Index", await _libraryServis.GetLibrarysAsync());
            }
        }
    }
}
