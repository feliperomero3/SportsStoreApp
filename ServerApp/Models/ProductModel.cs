using System.Collections.Generic;

namespace ServerApp.Models
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
    }
}
