using ApiFelipe.Models;

namespace ApiFelipe.Interfaces.Repositories;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product?> GetProductAsync(int id);
    Task UpdateProductAsync(int id, Product updatedProduct);
    Task DeleteProductAsync(int id);            
}