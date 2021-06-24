using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class OrderInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public PaymentInputModel Payment { get; set; }

        public ICollection<CartLineInputModel> Products { get; set; }

        public Order ToOrder()
        {
            return new Order(Name, Address, Payment.ToPayment(), Products.Select(c => c.ToCartLine()).ToArray());
        }
    }
}
