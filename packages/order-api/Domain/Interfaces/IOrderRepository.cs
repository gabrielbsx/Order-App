using OrderApp.Domain.Entities;

namespace OrderApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Entities.Order order);
        void UpdateOrder(Entities.Order order);
        Entities.Order GetOrderById(int orderId);
        IEnumerable<Entities.Order> GetOrdersByConsumer(int consumerId);
    }
}
