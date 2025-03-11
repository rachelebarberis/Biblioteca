using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class AddBookViewModel
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
    }
}
