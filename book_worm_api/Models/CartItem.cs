using System.ComponentModel.DataAnnotations.Schema;

namespace book_worm_api.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; } = new();
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
