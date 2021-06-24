using System.ComponentModel.DataAnnotations;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class CartLineInputModel
    {
        [Required]
        [Range(typeof(long), "1", "9223372036854775807", ErrorMessage = "ProductId must be at least 1")]
        public long ProductId { get; set; }

        [Required]
        [Range(typeof(int), "1", "999", ErrorMessage = "Quantity must be at least 1 and less then 999")]
        public int Quantity { get; set; }

        public CartLine ToCartLine()
        {
            return new CartLine(ProductId, Quantity);
        }
    }
}
