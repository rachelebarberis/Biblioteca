using Biblioteca.Data;
using Biblioteca.ViewModels;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    public class BookServices
    {
        private readonly LibraryDbContext _context;

        public async Task<BooksListViewModel> GetAllProductsAsync()
        {
            try
            {
                var booksList = new BooksListViewModel();


                booksList.Books = await _context.Books.ToListAsync();

                return booksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>() };
            }
        }
    }
}
