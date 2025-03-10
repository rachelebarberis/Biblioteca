using Biblioteca.Data;
using Biblioteca.ViewModels;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Services
{
    public class BookServices
    {
        private readonly LibraryDbContext _context;

        public BookServices(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<BooksListViewModel> GetAllBooksAsync() 
        {
            try
            {
                var booksList = new BooksListViewModel
                {
                    Books = await _context.Books.ToListAsync()
                };

                return booksList;
            }
            catch
            {
                return new BooksListViewModel { Books = new List<Book>() };
            }
        }
    }
}
