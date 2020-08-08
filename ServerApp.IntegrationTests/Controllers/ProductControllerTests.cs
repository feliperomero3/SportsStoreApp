using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using ServerApp.IntegrationTests.Models;
using Xunit;
using Xunit.Abstractions;

namespace ServerApp.IntegrationTests.Controllers
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _httpClient;

        public ProductControllerTests(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _httpClient = factory.CreateDefaultClient(new Uri("https://localhost:5001/api/products/"));
        }

        [Fact]
        public async Task Get_Product_returns_expected_Product()
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
    }
}
