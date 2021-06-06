using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServerApp.IntegrationTests.Helpers;
using ServerApp.Models;
using Xunit;

namespace ServerApp.IntegrationTests.Controllers
{
    public class SupplierControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        public SupplierControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("https://localhost:5001/api/suppliers/");
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GetSupplier_returns_Supplier()
        {
            var expectedSupplier = new SupplierModel { SupplierId = 1, Name = "Splash Dudes" };

            var supplier = await _httpClient.GetFromJsonAsync<SupplierModel>("1");

            Assert.NotNull(supplier);
            Assert.Equal(expectedSupplier.SupplierId, supplier.SupplierId);
            Assert.Equal(expectedSupplier.Name, supplier.Name);
        }

        [Fact]
        public async Task GetSuppliers_returns_Supplier_collection()
        {
            var httpClient = _factory.CreateClientWithDatabaseSetup(DatabaseHelper.ResetTestDatabase);

            var suppliers = await httpClient.GetFromJsonAsync<SupplierModel[]>("");

            Assert.NotNull(suppliers);
            Assert.Equal(3, suppliers.Length);
        }

        [Fact]
        public async Task CreateSupplier_returns_CreatedResult()
        {
            var supplier = new SupplierInputModel { Name = "Splash Dudes", City = "San Jose", State = "CA" };

            var response = await _httpClient.PostAsJsonAsync("", supplier);

            response.EnsureSuccessStatusCode();

            var createdSupplier = await response.Content.ReadFromJsonAsync<SupplierModel>();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"https://localhost:5001/api/suppliers/{createdSupplier.SupplierId}",
                response.Headers.Location.ToString());
        }

        [Fact]
        public async Task ReplaceSupplier_returns_NoContentResult()
        {
            var supplier = await _httpClient.GetFromJsonAsync<SupplierModel>("1");

            supplier.Name = "Overtone's";
            supplier.City = "Greenville";
            supplier.State = "NC";

            var supplierModified = new SupplierInputModel
            {
                Name = supplier.Name,
                City = supplier.City,
                State = supplier.State
            };

            var response = await _httpClient.PutAsJsonAsync("1", supplierModified);

            response.EnsureSuccessStatusCode();

            var modifiedSupplier = await _httpClient.GetFromJsonAsync<SupplierModel>("1");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.Equal(modifiedSupplier.Name, supplier.Name);
            Assert.Equal(modifiedSupplier.City, supplier.City);
            Assert.Equal(modifiedSupplier.State, supplier.State);
        }

        [Fact]
        public async Task DeleteSupplier_deletes_the_Supplier_and_returns_NoContentResult()
        {
            var supplier = new SupplierModel { SupplierId = 1 };

            var response = await _httpClient.DeleteAsync($"{supplier.SupplierId}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
