using System.ComponentModel.DataAnnotations;

namespace book_worm_api.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        //[Required]
        public string ImageURL { get; set; }
    }
}
