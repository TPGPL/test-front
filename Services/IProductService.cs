using OrderManagement.Models;

namespace OrderManagement.Services;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int id);
    Task<ServiceResponse<Product>> CreateProductAsync(Product product);
    Task<ServiceResponse<Product>> UpdateProductAsync(int id, Product product);
    Task DeleteProductAsync(int id);
}
