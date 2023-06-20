using OrderApp.Domain.Entities;
using OrderApp.Domain.Interfaces;

namespace OrderApp.Infra.Repositories.Memory
{
    public class OrderMemoryRepository : IOrderRepository
    {
        private static IEnumerable<Order> _orders = new Order[]{};
        public OrderMemoryRepository() { }
        public async Task<Order> GetOrderById(int id)
        {
            Order order = await Task.Run(() => _orders.First(o => o.Id == id));
            return order;
        }
        public async Task AddOrder(Order order)
        {
            await Task.Run(() => _orders.Append(order));
        }
        public async Task UpdateOrder(Order order)
        {
            Order orderToUpdate = await GetOrderById(order.Id);
            if (orderToUpdate == null)
            {
                throw new Exception("Order not found");
            }
            orderToUpdate = order;
        }
    }
}
