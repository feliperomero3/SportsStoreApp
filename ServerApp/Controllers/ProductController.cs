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
        public IEnumerable<ProductModel> GetProducts()
        {
            var products = _applicationDbContext.Products
                .Include(p => p.Supplier).ThenInclude(p => p.Products)
                .Include(p => p.Ratings)
                .ToArray();

            var productModels = products.Select(ProductModel.GetFromProduct);

            return productModels;
        }
    }
}
