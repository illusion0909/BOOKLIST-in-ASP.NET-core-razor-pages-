using System.ComponentModel.DataAnnotations;

namespace DotNet_Project10.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }

        public int Price { get; set; }
    }
}
