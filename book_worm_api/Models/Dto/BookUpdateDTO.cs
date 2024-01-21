using System.ComponentModel.DataAnnotations;

namespace book_worm_api.Models.Dto
{
    public class BookUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
