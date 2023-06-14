using DbContextWithApiCallTest.Model.Entities;

namespace DbContextWithApiCallTest.Services
{
    public interface IOrdersDataService
    {
        Task<Order> GetOrderAsync(int id);
        Task SetOrderStatusAsync(int id, string status);
    }
}