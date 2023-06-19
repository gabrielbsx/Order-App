using OrderApp.Application.Interfaces;
using OrderApp.Domain.Entities;

namespace OrderApp.Infra.Services
{
    public class ProductService : IProductService
    {
        private static IEnumerable<Product> _products = new Product[]
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0m },
            new Product { Id = 2, Name = "Product 2", Price = 20.0m },
        };
        async public Task<Product> GetProductById(int id)
        {
            Product product = await Task.Run(() => _products.First(c => c.Id == id));
            return product;
        }
    }
}
