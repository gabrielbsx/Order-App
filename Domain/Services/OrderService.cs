using OrderApp.Domain.Entities;
using OrderApp.Domain.Interfaces;

namespace OrderApp.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order CreateOrder(Consumer consumer)
        {
            Order order = new Order
            {
                Consumer = consumer,
                Status = OrderStatus.Pending
            };
            _orderRepository.AddOrder(order);
            return order;
        }

        public void UpdateStatusOrder(Order order, OrderStatus status)
        {
            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;
            _orderRepository.UpdateOrder(order);
        }
    }
}
