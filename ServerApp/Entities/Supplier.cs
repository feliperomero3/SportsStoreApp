using System.Collections.Generic;

namespace ServerApp.Entities
{
    public class Supplier
    {
        public long SupplierId { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public ICollection<Product> Products { get; private set; }

        private Supplier()
        {
        }

        public Supplier(string name, string city, string state) : this()
        {
            Name = name;
            City = city;
            State = state;
        }

        public Supplier(long supplierId) : this()
        {
            SupplierId = supplierId;
        }
    }
}
