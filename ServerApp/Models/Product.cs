using System.Collections.Generic;

namespace ServerApp.Models
{
    public class Product
    {
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Supplier Supplier { get; private set; }
        public IEnumerable<Rating> Ratings { get; private set; }
    }
}
