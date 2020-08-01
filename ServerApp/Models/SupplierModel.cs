using System;
using System.Collections.Generic;
using System.Linq;
using ServerApp.Entities;

namespace ServerApp.Models
{
    public class SupplierModel
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<SupplierProductModel> Products { get; set; }

        public static SupplierModel GetFromSupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            return new SupplierModel
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                City = supplier.City,
                State = supplier.State,
                Products = supplier.Products.Select(SupplierProductModel.GetFromProduct).ToArray()
            };
        }
    }
}
