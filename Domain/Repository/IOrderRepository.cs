using OrderApp.Domain.Entities;

namespace OrderApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task AddOrder(Entities.Order order);
        Task UpdateOrder(Entities.Order order);
    }
}
