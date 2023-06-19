using OrderApp.Domain.Entities;

namespace OrderApp.Application.Interfaces
{
    public interface IConsumerService
    {
        Task<Consumer> GetConsumerById(int id);
    }
}
