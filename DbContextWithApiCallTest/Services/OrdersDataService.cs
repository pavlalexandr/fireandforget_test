using DbContextWithApiCallTest.Model;
using DbContextWithApiCallTest.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbContextWithApiCallTest.Services
{
    public class OrdersDataService : IOrdersDataService
    {
        private readonly IDbContext _dbContext;

        public OrdersDataService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SetOrderStatusAsync(int id, string status)
        {
            var orderToUpdate = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderToUpdate != null)
            {
                orderToUpdate.Status = status;
                orderToUpdate.Updated = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
