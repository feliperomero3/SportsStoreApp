using System.Collections.Generic;
using System.Linq;
using SportsStore.Entities;

namespace SportsStore.Models
{
    public class SupplierModel
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<SupplierProductModel> Products { get; set; }

        public static SupplierModel FromSupplier(Supplier supplier)
        {
            if (supplier == null) return null;

            return new SupplierModel
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                City = supplier.City,
                State = supplier.State,
                Products = supplier.Products.Select(SupplierProductModel.FromProduct).ToArray()
            };
        }
    }
}
