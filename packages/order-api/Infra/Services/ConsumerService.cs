using OrderApp.Application.Interfaces;
using OrderApp.Domain.Entities;

namespace OrderApp.Infra.Services
{
    public class ConsumerService : IConsumerService
    {
        private static IEnumerable<Consumer> _consumers = new Consumer[]
        {
            new Consumer { Id = 1, Name = "John Doe", Email = "johndoe@mock.com"}
        };
        async public Task<Consumer> GetConsumerById(int id)
        {
            Consumer consumer = await Task.Run(() => _consumers.First(c => c.Id == id));
            return consumer;
        }
    }
}
