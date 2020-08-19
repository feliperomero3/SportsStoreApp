using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
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

            var supplierModel = SupplierModel.GetFromSupplier(supplier);

            return supplierModel;
        }

        [HttpGet]
        public IEnumerable<SupplierModel> GetSuppliers()
        {
            var suppliers = _applicationDbContext.Suppliers
                .Include(s => s.Products)
                .ThenInclude(p => p.Ratings)
                .ToArray();

            var supplierModels = suppliers.Select(SupplierModel.GetFromSupplier);

            return supplierModels;
        }

        [HttpPost]
        public IActionResult CreateSupplier(SupplierInputModel supplierModel)
        {
            var supplier = SupplierInputModel.ToSupplier(supplierModel);

            _applicationDbContext.Add(supplier);
            _applicationDbContext.SaveChanges();

            var supplierToReturn = SupplierModel.GetFromSupplier(supplier);

            return CreatedAtAction(nameof(GetSupplier), new { id = supplierToReturn.SupplierId }, supplierToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceSupplier(long id, SupplierInputModel supplierModel)
        {
            var supplierToReplace = _applicationDbContext.Suppliers.Find(id);

            var supplier = SupplierInputModel.ToSupplier(supplierModel);

            supplierToReplace.Replace(supplier);

            _applicationDbContext.SaveChanges();

            return NoContent();
        }
    }
}
