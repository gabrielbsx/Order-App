using OrderApp.Domain.Entities;

namespace OrderApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
    }
}
