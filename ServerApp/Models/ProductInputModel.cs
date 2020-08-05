using System;
using System.ComponentModel.DataAnnotations;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class ProductInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Price must be at least 1")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(long), "1", "9223372036854775807", ErrorMessage = "SupplierId must be at least 1")]
        public long SupplierId { get; set; }

        public static Product ToProduct(ProductInputModel product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product(product.Name, product.Description, product.Category, product.Price, product.SupplierId);
        }
    }
}
