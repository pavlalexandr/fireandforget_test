using DbContextWithApiCallTest.Model.Entities;

namespace DbContextWithApiCallTest.Services
{
    public interface IOrdersService
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task ProcessTask();
        Task UpdateOrder(int id, string statis);
    }
}