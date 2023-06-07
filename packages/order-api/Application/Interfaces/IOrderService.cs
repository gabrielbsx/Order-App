using OrderApp.Domain.Entities;

namespace OrderApp.Application.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(Consumer consumer);
        void UpdateOrderStatus(int orderId, OrderStatus status);
    }
}
