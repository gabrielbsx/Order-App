using OrderApp.Domain.Entities;

namespace OrderApp.Application.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetProducts();
    }
}
