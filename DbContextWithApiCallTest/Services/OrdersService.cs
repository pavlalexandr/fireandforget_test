using DbContextWithApiCallTest.Dto;
using DbContextWithApiCallTest.Model.Entities;
using Flurl;
using Flurl.Http;

namespace DbContextWithApiCallTest.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersDataService _ordersDataService;
        private readonly IServiceScopeFactory _scopeFactory;

        public OrdersService(
            IOrdersDataService ordersDataService,
            IServiceScopeFactory scopeFactory)
        {
            _ordersDataService = ordersDataService;
            _scopeFactory = scopeFactory;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _ordersDataService.GetOrderAsync(id);
        }

        public async Task UpdateOrder(int id, string statis)
        {
            await _ordersDataService.SetOrderStatusAsync(id, statis);
        }

        public async Task ProcessTask()
        {
            await Task.Delay(200);

            _ = Task.Run(async () =>
            {
                const int defaultOrderId = 1;
                using var scope = _scopeFactory.CreateScope();
                var scopedOrdersDataService = scope.ServiceProvider.GetRequiredService<IOrdersDataService>();
                ILogger<OrdersService> _logger = scope.ServiceProvider.GetRequiredService<ILogger<OrdersService>>();
                try
                {
                    var ordersUri = "https://localhost:7036".AppendPathSegments("api", "orders");

                    _logger.LogInformation("Saving data to API");

                    await ordersUri.PostJsonAsync(new OrderRequest()
                    {
                        Id = defaultOrderId,
                        Status = "super"
                    });

                    _logger.LogInformation(message: "Getting data from DB");

                    var orderFromDb = await scopedOrdersDataService.GetOrderAsync(defaultOrderId);
                    _logger.LogInformation(message: $"order.id={defaultOrderId} status={orderFromDb.Status}");

                    _logger.LogInformation("Saving data to DB");

                    await scopedOrdersDataService.SetOrderStatusAsync(defaultOrderId, "super_2");

                    _logger.LogInformation(message: "Getting data from API");
                    var orderFromApi = await ordersUri.AppendPathSegment("1").GetJsonAsync<Order>();

                    _logger.LogInformation(message: $"order.id={defaultOrderId} status={orderFromApi.Status}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "error (");
                }
            });
        }
    }
}
