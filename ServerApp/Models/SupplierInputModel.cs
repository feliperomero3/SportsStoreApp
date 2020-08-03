using System.ComponentModel.DataAnnotations;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class SupplierInputModel
    {
        [Required]
        public string Name { get; private set; }

        [Required]
        public string City { get; private set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; private set; }

        public static Supplier ToSupplier(SupplierInputModel supplier)
        {
            return new Supplier(supplier.Name, supplier.City, supplier.State);
        }
    }
}
