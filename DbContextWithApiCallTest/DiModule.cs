using DbContextWithApiCallTest.Model;
using DbContextWithApiCallTest.Services;
using Microsoft.EntityFrameworkCore;

namespace DbContextWithApiCallTest
{
    public static class DiModule
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"));
            })
            .AddScoped<IDbContext, OrdersDbContext>()
            .AddScoped<IOrdersDataService, OrdersDataService>()
            .AddScoped<IOrdersService, OrdersService>()
            .AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            });
        }
    }
}
