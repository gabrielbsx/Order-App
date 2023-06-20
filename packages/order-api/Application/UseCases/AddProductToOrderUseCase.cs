using OrderApp.Application.Interfaces;
using OrderApp.Domain.Entities;
using OrderApp.Domain.Interfaces;

namespace OrderApp.Application.UseCases
{
    public class AddProductToOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        
        public AddProductToOrderUseCase(IOrderRepository orderRepository, IProductService productService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
        }

        async public void Handle(int orderId, int productId, int quantity)
        {
            Order order = await _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} not found.");
            }
            var item = new OrderItem
            {
                Product = product,
                Quantity = quantity,
                UnitPrice = product.Price,
            };
            order.OrderItems.Add(item);
            order.CalculateTotalValue();
            await _orderRepository.UpdateOrder(order);
        }
    }
}
