using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServerApp.Data;
using ServerApp.IntegrationTests.Helpers;
using ServerApp.IntegrationTests.Models;
using Xunit;
using Xunit.Abstractions;

namespace ServerApp.IntegrationTests.Controllers
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ProductControllerTests(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
            _httpClient = _factory.CreateDefaultClient(new Uri("https://localhost:5001/api/products/"));
        }

        [Fact]
        public async Task GetProduct_returns_expected_Product()
        {
            var expectedProduct = new ProductModel { ProductId = 1, Name = "Kayak" };

            try
            {
                var product = await _httpClient.GetFromJsonAsync<ProductModel>("1");

                Assert.NotNull(product);
                Assert.Equal(expectedProduct.Name, product.Name);
            }
            catch (HttpRequestException e)
            {
                _testOutputHelper.WriteLine(e.ToString());
                throw;

            }
            catch (JsonException f)
            {
                _testOutputHelper.WriteLine(f.ToString());
                throw;
            }
        }

        [Fact]
        public async Task GetProducts_returns_expected_Products_collection()
        {
            var httpClient = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();

                    var provider = scope.ServiceProvider;

                    try
                    {
                        var context = provider.GetRequiredService<ApplicationDbContext>();

                        DatabaseHelper.ResetTestDatabase(context);
                        DatabaseHelper.SeedTestDatabase(context);
                    }
                    catch (SqlException e)
                    {
                        var logger = provider.GetRequiredService<ILogger<ProductControllerTests>>();

                        logger.LogError(e, "An error occurred seting up the test database for the test.");

                        throw;
                    }
                });
            }).CreateDefaultClient(new Uri("https://localhost:5001/api/products"));

            var products = await httpClient.GetFromJsonAsync<ProductModel[]>("");

            Assert.NotNull(products);
            Assert.Equal(9, products.Length);
        }
    }
}
