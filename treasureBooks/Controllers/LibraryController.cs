using Microsoft.AspNetCore.Mvc;
using treasureBooks.Data;
using treasureBooks.Servis;
using treasureBooks.ViewModel;
namespace treasureBooks.Controllers
{
    public class LibraryController : Controller
    {
        
        private readonly ILibraryServis _libraryServis;
        private readonly ApplicationDbContext _context;


        public LibraryController(ILibraryServis servis, ApplicationDbContext context)
        {
            _libraryServis = servis;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _libraryServis.GetAllLibrarys());
        }
        public async Task<IActionResult> AllInformation()
        {
            return View(await _libraryServis.GetAll());
        }

        [HttpGet]
        public IActionResult AddNewLibrary()
        {
            return View(new LibraryAddVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewLibrary(LibraryAddVM vm) =>
                    await _libraryServis.AddLibrary(vm) ? RedirectToAction("Index") : View(vm);


        //[HttpPost]
        //[ActivatorUtilitiesConstructor]
    }
}
