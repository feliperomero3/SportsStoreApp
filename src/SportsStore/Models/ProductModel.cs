using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class ProductModel
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public SupplierModel Supplier { get; set; }
        public ICollection<RatingModel> Ratings { get; set; }

        public static ProductModel FromProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var productModel = new ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Supplier = SupplierModel.FromSupplier(product.Supplier),
                Ratings = product.Ratings.Select(RatingModel.FromRating).ToArray()
            };

            return productModel;
        }
    }
}
