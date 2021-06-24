using System;
using System.ComponentModel.DataAnnotations;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class SupplierInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        public static Supplier ToSupplier(SupplierInputModel supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            return new Supplier(supplier.Name, supplier.City, supplier.State);
        }
    }
}
