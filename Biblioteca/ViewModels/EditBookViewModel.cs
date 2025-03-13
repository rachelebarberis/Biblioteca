namespace Biblioteca.ViewModels
{
    public class EditBookViewModel
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public  required string Author { get; set; }
        public required string Genre { get; set; }
        public required bool Availability { get; set; }
        public IFormFile? ImgCover { get; set; }

        public string? ImgPath { get; set; }
    }
}
