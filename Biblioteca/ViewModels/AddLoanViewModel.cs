using Biblioteca.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class AddLoanViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        public string? User { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailUser { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? LoanDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; } = DateTime.Now.AddDays(20);

        public Guid BookId { get; set; }

        [ForeignKey("BookId")]

        public Book? Book { get; set; }
    }
}
