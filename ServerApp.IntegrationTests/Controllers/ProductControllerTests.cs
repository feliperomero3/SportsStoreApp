using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using ServerApp.IntegrationTests.Helpers;
using ServerApp.Models;
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
        public async Task GetProduct_returns_Product()
        {
            var expectedProduct = new ProductModel { ProductId = 1, Name = "Kayak" };

            var product = await _httpClient.GetFromJsonAsync<ProductModel>("1");

            Assert.NotNull(product);
            Assert.Equal(expectedProduct.ProductId, product.ProductId);
            Assert.Equal(expectedProduct.Name, product.Name);
        }

        [Fact]
        public async Task GetProducts_returns_Products_collection()
        {
            var httpClient = _factory.CreateClientWithDatabaseSetup(DatabaseHelper.ResetTestDatabase);

            var products = await httpClient.GetFromJsonAsync<ProductModel[]>("");

            Assert.NotNull(products);
            Assert.Equal(9, products.Length);
        }

        [Fact]
        public async Task GetProducts_filter_by_category_returns_filtered_Products_collection()
        {
            var httpClient = _factory.CreateClientWithDatabaseSetup(DatabaseHelper.ResetTestDatabase);

            var products = await httpClient.GetFromJsonAsync<ProductModel[]>("?category=Water");

            Assert.NotNull(products);
            Assert.Equal(2, products.Length);
        }

        [Fact]
        public async Task GetProducts_search_returns_filtered_Products_collection()
        {
            var httpClient = _factory.CreateClientWithDatabaseSetup(DatabaseHelper.ResetTestDatabase);

            var products = await httpClient.GetFromJsonAsync<ProductModel[]>("?search=boat");

            Assert.Single(products);
        }

        [Fact]
        public async Task CreateProduct_returns_CreatedResult()
        {
            var product = new ProductInputModel
            {
                Name = "Head Marlin Splash Snorkel",
                Description = "Silicone snorkel with semi-dry top",
                Category = "Watersports",
                Price = 14.24M,
                SupplierId = 1
            };

            var response = await _httpClient.PostAsJsonAsync("", product);

            response.EnsureSuccessStatusCode();

            var createdProduct = await response.Content.ReadFromJsonAsync<ProductModel>();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"https://localhost:5001/api/products/{createdProduct.ProductId}",
                response.Headers.Location.ToString());
        }

        [Fact]
        public async Task ReplaceProduct_returns_NoContentResult()
        {
            var product = await _httpClient.GetFromJsonAsync<ProductModel>("1");

            product.Name += " Modified";
            product.Description += " Modified";
            product.Category += " Modified";
            product.Price *= 2M;

            var productModified = new ProductInputModel
            {
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                SupplierId = product.Supplier.SupplierId
            };

            var response = await _httpClient.PutAsJsonAsync("1", productModified);

            response.EnsureSuccessStatusCode();

            var modifiedProduct = await _httpClient.GetFromJsonAsync<ProductModel>("1");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.Equal(product.Name, modifiedProduct.Name);
            Assert.Equal(product.Description, modifiedProduct.Description);
            Assert.Equal(product.Category, modifiedProduct.Category);
            Assert.Equal(product.Price, modifiedProduct.Price);
        }

        [Fact]
        public async Task UpdateProduct_returns_NoContentResult()
        {
            var patch = new JsonPatchDocument<ProductInputModel>();

            var patchDocument = patch.Replace(p => p.Name, "Modified Name");

            var request = new HttpRequestMessage(HttpMethod.Patch, _httpClient.BaseAddress + "1")
            {
                Content = new StringContent(JsonConvert.SerializeObject(patchDocument))
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");

            var response = await _httpClient.SendAsync(request);

            var modifiedProduct = await _httpClient.GetFromJsonAsync<ProductModel>("1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Modified Name", modifiedProduct.Name);
        }
    }
}
