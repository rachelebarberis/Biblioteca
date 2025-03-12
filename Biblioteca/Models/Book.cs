using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(50)]
        public required string Author { get; set; }

        [Required]
        [StringLength(50)]
        public required string Genre { get; set; }

        [Required]
        public required bool Availability { get; set; }

        [Required]
        public required string ImgCover { get; set; }

        public ICollection<Prestito>? Prestiti { get; set; }
    }
}
