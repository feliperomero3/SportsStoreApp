using System;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class SupplierProductModel
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public static SupplierProductModel GetFromProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new SupplierProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price
            };
        }
    }
}
