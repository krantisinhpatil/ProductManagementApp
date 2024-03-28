using ProductManagement.ApiService.Interfaces;
using ProductManagement.Data.Interfaces;
using ProductManagement.Data.Model;

namespace ProductManagement.ApiService.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private ILogger<ProductService> _logger;

        /// <summary>
        /// Initializes a new instance 
        /// </summary>
        /// <param name="IProductRepository">dfhgdj</param>
        /// <param name="ILogger<ProductService>">gfhk</param>
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.CompleteAsync();
            _logger.LogInformation($"[AddProductAsyns] - {product.ProductName} added successfully");
        }

        /// <inheritdoc/>
        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            await _productRepository.CompleteAsync();
            _logger.LogInformation($"[UpdateProductAsyns] - Product updated successfully for the {product.ProductId}");
        }

        /// <inheritdoc/>
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.
                FirstOrDefaultAsync(x => x.ProductId == id);
        }

        /// <inheritdoc/>
        public List<Product> GetAllProducts()
        {
            var productList = _productRepository.GetAll();
            return (List<Product>)productList;
        }

        /// <inheritdoc/>
        public async Task DeleteProductAsync(int productId)
        {
           await _productRepository.DeleteAsync(x=>x.ProductId== productId);
            await _productRepository.CompleteAsync();
            _logger.LogInformation($"[DeleteProductAsyns] - Product deleted successfully for the {productId}");
        }
    }
}
