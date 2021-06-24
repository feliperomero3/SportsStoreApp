using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SupplierController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("{id}")]
        public SupplierModel GetSupplier(long id)
        {
            var supplier = _applicationDbContext.Suppliers
                .Include(s => s.Products)
                .FirstOrDefault(s => s.SupplierId == id);

            var supplierModel = SupplierModel.FromSupplier(supplier);

            return supplierModel;
        }

        [HttpGet]
        public IEnumerable<SupplierModel> GetSuppliers()
        {
            var suppliers = _applicationDbContext.Suppliers
                .Include(s => s.Products)
                .ThenInclude(p => p.Ratings)
                .ToArray();

            var supplierModels = suppliers.Select(SupplierModel.FromSupplier);

            return supplierModels;
        }

        [HttpPost]
        public IActionResult CreateSupplier(SupplierInputModel supplierModel)
        {
            var supplier = SupplierInputModel.ToSupplier(supplierModel);

            _applicationDbContext.Add(supplier);
            _applicationDbContext.SaveChanges();

            var supplierToReturn = SupplierModel.FromSupplier(supplier);

            return CreatedAtAction(nameof(GetSupplier), new { id = supplierToReturn.SupplierId }, supplierToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceSupplier(long id, SupplierInputModel supplierModel)
        {
            var supplierToReplace = _applicationDbContext.Suppliers.Find(id);

            var supplier = SupplierInputModel.ToSupplier(supplierModel);

            supplierToReplace.EditSupplier(supplier);

            _applicationDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(long id)
        {
            var suppplier = _applicationDbContext.Suppliers.Find(id);

            _applicationDbContext.Suppliers.Remove(suppplier);
            _applicationDbContext.SaveChanges();

            return NoContent();
        }
    }
}
