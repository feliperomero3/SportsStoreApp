using System;
using System.Collections.Generic;
using System.Linq;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class OrderModel
    {
        public long OrderId { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public PaymentModel Payment { get; set; }
        public bool IsShipped { get; set; }
        public ICollection<CartLineModel> Products { get; set; }

        public static OrderModel FromOrder(Order order)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            var model = new OrderModel
            {
                OrderId = order.OrderId,
                Name = order.Name,
                Address = order.Address,
                Payment = PaymentModel.FromPayment(order.Payment),
                IsShipped = order.IsShipped,
                Products = order.Products.Select(CartLineModel.FromCartLine).ToArray()
            };

            return model;
        }
    }
}
