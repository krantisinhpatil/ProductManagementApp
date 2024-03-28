using Microsoft.Extensions.Logging;
using Moq;
using ProductManagement.ApiService.Interfaces;
using ProductManagement.ApiService.Service;
using ProductManagement.Data.Interfaces;
using ProductManagement.Data.Model;
using ProductManagementApiServiceTests.Utilities;

namespace ProductManagementApiServiceTests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<ILogger<ProductService>> _logger;
        private IProductService _service;
        private Product product;

        /// <summary>
        /// Initializes a new instance of see ref<paramref name="ProductServiceTests"/>
        /// </summary> 
        public ProductServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _logger = new Mock<ILogger<ProductService>>();

            _service = new ProductService(
                _productRepository.Object,
                _logger.Object);

            _productRepository.Setup(x => x.AddAsync(It.IsAny<Product>()));
            _productRepository.Setup(x => x.UpdateAsync(It.IsAny<Product>()));
             product = ProductUtilities.DummyProductData();
        }

        /// <summary>
        /// Test method to add product successfully.
        /// </summary>
        /// <returns>returns asynchronous Task.</returns>
        [TestMethod]
        public async Task AddProductAsync_SuccesAsync()
        {
            await _service.AddProductAsync(product);

            _productRepository.Verify(
                x => x.AddAsync(It.Is<Product>(
                x =>
                x.ProductName == product.ProductName &&
                x.Availability == true &&
                x.Price == product.Price &&
                x.Description == product.Description)), Times.Once);

            _productRepository.Verify(x => x.CompleteAsync(), Times.Once); 
        }

        /// <summary>
        /// Test method to update product successfully.
        /// </summary>
        /// <returns>returns asynchronous Task.</returns>
        [TestMethod]
        public async Task UpdateProductAsync_SuccesAsync()
        {
            await _service.UpdateProductAsync(product);

            _productRepository.Verify(
                x => x.UpdateAsync(It.Is<Product>(
                x =>
                x.ProductName == product.ProductName &&
                x.Availability == true &&
                x.Price == product.Price &&
                x.Description == product.Description)), Times.Once);

            _productRepository.Verify(x => x.CompleteAsync(), Times.Once);
        }

        /// <summary>
        /// Test method to retrieve product.
        /// </summary>
        /// <returns>returns asynchronous Task.</returns>
        [TestMethod]
        public async Task GetProductById_SuccesAsync()
        {
            _productRepository.Setup(x => x.FirstOrDefaultAsync(x => x.ProductId == 1));

            await _service.GetProductByIdAsync(1);
            _productRepository.Verify(x => x.FirstOrDefaultAsync(x => x.ProductId == 1), Times.Once);
        }
    }
}
