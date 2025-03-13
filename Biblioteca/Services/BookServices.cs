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

        private async Task<bool> SaveAsync()
        {
            try
            {
                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            var fileName = addBookViewModel.ImgCover.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", fileName);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await addBookViewModel.ImgCover.CopyToAsync(stream);
            }

            var webPath = Path.Combine("Uploads", fileName).Replace("\\", "/");
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                Genre = addBookViewModel.Genre,
                Availability = addBookViewModel.Availability,
                ImgCover = webPath,
            };
            _context.Books.Add(book);
            return await SaveAsync();
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return null;
            }
            return book;
        }

        public async Task<bool> DeleteBookByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) { return false; }
            _context.Books.Remove(book);
            return await SaveAsync();
        }

        public async Task<bool> UpdateBookAsync(EditBookViewModel editBookViewModel)
        {
            var book = await _context.Books.FindAsync(editBookViewModel.Id);
            if (book == null) { return false; }
            var fileName = editBookViewModel.ImgCover.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", fileName);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await editBookViewModel.ImgCover.CopyToAsync(stream);
            }

            var webPath = Path.Combine("Uploads", fileName).Replace("\\", "/");


            book.Title = editBookViewModel.Title;
            book.Author = editBookViewModel.Author;
            book.Genre = editBookViewModel.Genre;
            book.Availability = editBookViewModel.Availability;
            book.ImgCover = webPath;

            return await SaveAsync();
        }
    }
}


