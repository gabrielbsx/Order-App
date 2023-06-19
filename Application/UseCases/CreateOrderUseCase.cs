using OrderApp.Application.Interfaces;
using OrderApp.Domain.Entities;
using OrderApp.Domain.Interfaces;

namespace OrderApp.Application.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IConsumerService _consumerService;
        
        public CreateOrderUseCase(IOrderRepository orderRepository, IConsumerService consumerService)
        {
            _orderRepository = orderRepository;
            _consumerService = consumerService;
        }
        async public void Handle(int consumerId)
        {
            var consumer = await _consumerService.GetConsumerById(consumerId);
            if (consumer == null)
            {
                throw new Exception($"Consumer with ID {consumerId} not found.");
            }
            var order = new Order
            {
                Consumer = consumer,
                Status = OrderStatus.Pending
            };
            await _orderRepository.AddOrder(order);
        }
    }
}
