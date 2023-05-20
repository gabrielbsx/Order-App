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

        public void Handle(int orderId, int productId, int quantity)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }
            var product = _productService.GetProductById(productId);
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
            _orderRepository.UpdateOrder(order);
        }
    }
}
