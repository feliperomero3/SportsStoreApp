using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServerApp.Data;

namespace ServerApp.IntegrationTests
{
    public static class WebApplicationFactoryExtensions
    {
        public static HttpClient CreateClientWithDatabaseSetup(this CustomWebApplicationFactory<Startup> factory,
            Action<ApplicationDbContext> configureAction)
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();

                    var provider = scope.ServiceProvider;

                    try
                    {
                        var context = provider.GetRequiredService<ApplicationDbContext>();

                        configureAction(context);
                    }
                    catch (SqlException e)
                    {
                        var logger = provider.GetRequiredService<ILogger<CustomWebApplicationFactory<Startup>>>();

                        logger.LogError(e, "An error occurred setting up the test database for the test.");

                        throw;
                    }
                });
            }).CreateClient();
        }
    }
}
