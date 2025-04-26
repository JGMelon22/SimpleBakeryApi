using ApiFelipe.Infrastructure.Data;
using ApiFelipe.Interfaces.Repositories;
using ApiFelipe.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFelipe.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        Product? product = await _dbContext.Products
                                .FirstOrDefaultAsync(x => x.Id == id)
                                ?? throw new Exception($"Product with id '{id} does not exist!'");

        _dbContext.Products.Remove(product!);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        List<Product> products = await _dbContext.Products
                                        .AsNoTracking()
                                        .ToListAsync();

        return products;
    }

    public async Task UpdateProductAsync(int id, Product updatedProduct)
    {
        Product? product = await _dbContext.Products
                                   .FirstOrDefaultAsync(x => x.Id == id);

        product!.Description = updatedProduct.Description;
        product!.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;

        await _dbContext.SaveChangesAsync();
    }
}