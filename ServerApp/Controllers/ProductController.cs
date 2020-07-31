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

            var productModel = new ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Supplier = new SupplierModel
                {
                    SupplierId = product.Supplier.SupplierId,
                    Name = product.Supplier.Name,
                    City = product.Supplier.City,
                    State = product.Supplier.State,
                    Products = product.Supplier.Products.Select(p =>
                        new SupplierProductModel
                        {
                            ProductId = p.ProductId,
                            Name = p.Name,
                            Description = p.Description,
                            Category = p.Category,
                            Price = p.Price
                        }).ToArray()
                },
                Ratings = product.Ratings.Select(r =>
                    new RatingModel
                    {
                        RatingId = r.RatingId,
                        Stars = r.Stars
                    }).ToArray()
            };

            return productModel;
        }
    }
}
