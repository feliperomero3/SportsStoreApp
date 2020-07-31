using System.Collections.Generic;

namespace ServerApp.Models
{
    public class SupplierModel
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<SupplierProductModel> Products { get; set; }
    }
}
