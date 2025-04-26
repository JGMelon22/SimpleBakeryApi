using ApiFelipe.Interfaces.Repositories;
using ApiFelipe.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFelipe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        IEnumerable<Product> products = await _productRepository.GetProductsAsync();
        return products.Count() > 0
                    ? Ok(products)
                    : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleProductAsync(int id)
    {
        Product? product = await _productRepository.GetProductAsync(id);
        return product != null
            ? Ok(product)
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewProductAsync(Product newProduct)
    {
        await _productRepository.AddProductAsync(newProduct);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProductAsync(int id, Product updatedProduct)
    {
        await _productRepository.UpdateProductAsync(id, updatedProduct);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProductAsync(int id)
    {
        await _productRepository.DeleteProductAsync(id);
        return NoContent();
    }
}
