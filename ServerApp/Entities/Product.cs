using System.Collections.Generic;

namespace ServerApp.Entities
{
    public class Product
    {
        public long ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public Supplier Supplier { get; private set; }
        public ICollection<Rating> Ratings { get; private set; }

        private Product()
        {
        }

        public Product(string name, string description, string category, decimal price, Supplier supplier,
            ICollection<Rating> ratings)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Supplier = supplier;
            Ratings = ratings;
        }

        public Product(string name, string description, string category, decimal price, Supplier supplier)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Supplier = supplier;
        }
    }
}
