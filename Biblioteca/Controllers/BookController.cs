using Biblioteca.Services;
using Biblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    public class BookController : Controller

    {
        private readonly BookServices _bookServices;

        public BookController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public async Task<IActionResult> Index()
        {
            var booksList = await _bookServices.GetAllBooksAsync();

            return View(booksList);
        }

     
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Index");
            }
            var result = await _bookServices.AddBookAsync(addBookViewModel);
            if (!result)
            {
                TempData["Error"] = "Error while saving entity to database";
            }
            return RedirectToAction("Index");
        }

        [Route("book/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var book = await _bookServices.GetBookByIdAsync(id);
            if (book == null)
            {
                TempData["Error"] = "Error while finding entity on database";
                return RedirectToAction("Index");
            }

            var bookDetailsViewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Availability = book.Availability,
                ImgCover = book.ImgCover,
            };

            return View(bookDetailsViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookServices.DeleteBookByIdAsync(id);

            if (!result)
            {
                TempData["Error"] = "Error while deleting entity from database";
            }
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> Edit (Guid id)
        {
            var book = await _bookServices.GetBookByIdAsync(id);

            if (book == null) { return RedirectToAction("Index"); };

            var editBookViewModel = new EditBookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Availability = book.Availability,
                ImgPath = book.ImgCover,
 
            };
            return View(editBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel)
        {
            var result = await _bookServices.UpdateBookAsync(editBookViewModel);
            if (!result)
            {
                TempData["Error"] = "Error while updating entity on database";
            }
            return RedirectToAction("Index");

        }
    }

}
