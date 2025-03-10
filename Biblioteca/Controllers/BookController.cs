using Biblioteca.Services;
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
            var booksList = await _bookServices.GetAllProductsAsync();

            return View(booksList);
        }
    }
}
