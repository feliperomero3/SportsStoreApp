using System.Collections.Generic;

namespace ServerApp.Entities
{
    public class Order
    {
        public long OrderId { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public Payment Payment { get; private set; }
        public bool IsShipped { get; private set; }
        public ICollection<CartLine> Products { get; private set; }

        private Order()
        {
            Products = new List<CartLine>();
        }

        public Order(string name, string address, Payment payment, ICollection<CartLine> products) : this()
        {
            OrderId = 0;
            Name = name;
            Address = address;
            Payment = payment;
            Products = products;
            IsShipped = false;
        }

        public void MarkShipped()
        {
            IsShipped = true;
        }
    }
}
