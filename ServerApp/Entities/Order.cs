using System.Collections.Generic;

namespace ServerApp.Entities
{
    public class Order
    {
        public long OrderId { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Payment Payment { get; set; }
        public bool IsShipped { get; set; }
        public ICollection<CartLine> Products { get; set; }
    }
}
