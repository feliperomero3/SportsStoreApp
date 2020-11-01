using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerApp.Data;

namespace ServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var environment = services.GetRequiredService<IWebHostEnvironment>();

                if (environment.IsDevelopment())
                {
                    try
                    {
                        var context = services.GetRequiredService<ApplicationDbContext>();

                        ApplicationDbContextInitializer.Initialize(context);
                        ApplicationDbContextSeedData.SeedDatabase(context);
                    }
                    catch (SqlException e)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();

                        logger.LogError(e, "An error occurred creating the database.");

                        throw;
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
