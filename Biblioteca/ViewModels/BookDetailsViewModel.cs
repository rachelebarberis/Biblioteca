using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class BookDetailsViewModel
    {
      
        public Guid Id { get; set; }

   
        public string? Title { get; set; }

       
        public string? Author { get; set; }

      
        public  string? Genre { get; set; }


        public  bool Availability { get; set; }

       
        public  string? ImgCover { get; set; }
    }
}
