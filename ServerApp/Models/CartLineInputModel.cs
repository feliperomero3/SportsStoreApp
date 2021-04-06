using System.ComponentModel.DataAnnotations;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class CartLineInputModel
    {
        [Required]
        [Range(typeof(long), "1", "9223372036854775807", ErrorMessage = "ProductId must be at least 1")]
        public long ProductId { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        public CartLine ToCartLine()
        {
            return new CartLine(ProductId, Quantity);
        }
    }
}
