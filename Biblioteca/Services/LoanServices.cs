using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.ViewModels;

namespace Biblioteca.Services
{
    public class LoanServices
    {
        private readonly LibraryDbContext _context;

        public LoanServices(LibraryDbContext context)
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

        public async Task<bool> AddLoanAsync(AddLoanViewModel addLoanViewModel)
        {
            var prestito = new Prestito()
            {
                Id = Guid.NewGuid(),  
                BookId = addLoanViewModel.BookId,
                User = addLoanViewModel.User,
                EmailUser = addLoanViewModel.EmailUser,
                LoanDate = DateTime.Today, 
                ReturnDate = DateTime.Today.AddDays(20)  
            };

            _context.Prestiti.Add(prestito);
            return await SaveAsync();
        }
    }
}
