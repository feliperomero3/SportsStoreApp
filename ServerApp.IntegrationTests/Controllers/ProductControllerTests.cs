using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServerApp.IntegrationTests.Helpers;
using ServerApp.IntegrationTests.Models;
using Xunit;

namespace ServerApp.IntegrationTests.Controllers
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ProductControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("https://localhost:5001/api/products/");
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GetProduct_returns_expected_Product()
        {
            var expectedProduct = new ProductModel { ProductId = 1, Name = "Kayak" };

            var product = await _httpClient.GetFromJsonAsync<ProductModel>("1");

            Assert.NotNull(product);
            Assert.Equal(expectedProduct.Name, product.Name);
        }

        [Fact]
        public async Task GetProducts_returns_expected_Products_collection()
        {
            var httpClient = _factory.CreateClientWithDatabaseSetup(DatabaseHelper.ResetTestDatabase);

            var products = await httpClient.GetFromJsonAsync<ProductModel[]>("");

            Assert.NotNull(products);
            Assert.Equal(9, products.Length);
        }
    }
}
