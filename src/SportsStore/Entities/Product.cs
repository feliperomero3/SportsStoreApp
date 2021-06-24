using System.Collections.Generic;

namespace SportsStore.Entities
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
            Ratings = new List<Rating>();
        }

        public Product(string name, string description, string category, decimal price, Supplier supplier,
            ICollection<Rating> ratings = null) : this()
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Supplier = supplier;
            Ratings = ratings;
        }

        public void EditProduct(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Category = product.Category;
            Price = product.Price;
        }

        internal void ReplaceSupplier(Supplier supplier)
        {
            Supplier = supplier;
        }
    }
}
