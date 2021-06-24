using System;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class ProductCreatedModel
    {
        public long ProductId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public long SupplierId { get; set; }

        public static ProductCreatedModel FromProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new ProductCreatedModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                SupplierId = product.Supplier.SupplierId
            };
        }
    }
}
