using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Net.Http.Headers;
using Xunit;

namespace ServerApp.IntegrationTests.Controllers
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public HomeControllerTests(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient(new Uri("https://localhost:5001"));
        }

        [Fact]
        public async Task Home_returns_success_and_expected_content_type()
        {
            var expected = new MediaTypeHeaderValue("text/html");

            var response = await _httpClient.GetAsync("");

            response.EnsureSuccessStatusCode();

            Assert.Equal(expected.MediaType, response.Content.Headers.ContentType.MediaType);
        }
    }
}
