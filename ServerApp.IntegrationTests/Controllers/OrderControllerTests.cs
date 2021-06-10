using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ServerApp.Models;
using Xunit;

namespace ServerApp.IntegrationTests.Controllers
{
    public class OrderControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        public OrderControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("https://localhost:5001/api/orders/");
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GetOrders_Returns_Orders_collection()
        {
            var orders = await _httpClient.GetFromJsonAsync<OrderModel[]>(string.Empty);

            Assert.NotNull(orders);
            Assert.True(orders.Any());
        }

        [Fact(Skip = "NotImplementedYet")]
        public async Task GetOrder_Returns_Order()
        {
            var expectedOrder = new OrderModel { OrderId = 1 };

            var order = await _httpClient.GetFromJsonAsync<OrderModel>("1");

            Assert.NotNull(order);
            Assert.Equal(expectedOrder.OrderId, order.OrderId);
        }

        [Fact]
        public async Task CreateOrder_Returns_Created_Result()
        {
            var order = new OrderInputModel
            {
                Name = "Order 1",
                Address = "Boulevard 124",
                Payment = new PaymentInputModel
                {
                    CardNumber = "5921",
                    CardExpiry = "01/24",
                    CardSecurityCode = "999",
                    Total = 1250m
                },
                Products = new[]
                {
                    new CartLineInputModel { ProductId = 1, Quantity = 1 },
                    new CartLineInputModel { ProductId = 2, Quantity = 1 }
                }
            };

            var response = await _httpClient.PostAsJsonAsync(string.Empty, order);

            await response.Content.ReadFromJsonAsync<dynamic>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task MarkShipped_Marks_the_Order_As_Shipped()
        {
            var response = await _httpClient.PostAsync("1", null);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
