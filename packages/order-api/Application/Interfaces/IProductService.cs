using OrderApp.Domain.Entities;

namespace OrderApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductById(int productId);
    }
}
