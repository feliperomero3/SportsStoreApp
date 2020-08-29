using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("{id}")]
        public ProductModel GetProduct(long id)
        {
            var product = _applicationDbContext.Products
                .Include(p => p.Supplier).ThenInclude(p => p.Products)
                .Include(p => p.Ratings)
                .FirstOrDefault(p => p.ProductId == id);

            var productModel = ProductModel.GetFromProduct(product);

            return productModel;
        }

        [HttpGet]
        public IEnumerable<ProductModel> GetProducts(string category, string search)
        {
            var query = _applicationDbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.ToLower().Contains(category.ToLower()));
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
                                         p.Description.ToLower().Contains(search.ToLower()));
            }

            var products = query
                .Include(p => p.Supplier).ThenInclude(p => p.Products)
                .Include(p => p.Ratings)
                .ToArray();

            var productModels = products.Select(ProductModel.GetFromProduct);

            return productModels;
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductInputModel productModel)
        {
            var supplier = _applicationDbContext.Suppliers.Find(productModel.SupplierId);
            var product = ProductInputModel.ToProduct(productModel, supplier);

            _applicationDbContext.Attach(product);
            _applicationDbContext.SaveChanges();

            var productToReturn = ProductCreatedModel.FromProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = productToReturn.ProductId }, productToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceProduct(long id, ProductInputModel productModel)
        {
            var productToReplace = _applicationDbContext.Products
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.ProductId == id);

            var product = ProductInputModel.ToProduct(productModel, productToReplace?.Supplier);

            productToReplace?.EditProduct(product);

            _applicationDbContext.SaveChanges();

            return NoContent();
        }
    }
}
