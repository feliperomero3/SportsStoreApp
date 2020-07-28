using System.Collections.Generic;

namespace ServerApp.Models
{
    public class Supplier
    {
        public long SupplierId { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
    }
}