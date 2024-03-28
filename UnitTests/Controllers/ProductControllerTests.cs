using Moq;
using ProductManagement.ApiService.Controllers;
using ProductManagement.ApiService.Interfaces;
using ProductManagement.Data.Model;
using ProductManagementApiServiceTests.Utilities;

namespace ProductManagement.ApiServiceTests.Controllers
{
    /// <summary>
    /// Class for testing controller methods.
    /// </summary>
    [TestClass]
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private ProductController _controller;
        private Product product;

        public ProductControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();

            _controller = new ProductController(_productServiceMock.Object);

            _productServiceMock.Setup(x => x.AddProductAsync(It.IsAny<Product>()));
            _productServiceMock.Setup(x => x.UpdateProductAsync(It.IsAny<Product>()));

            product = ProductUtilities.DummyProductData();
        }

        [TestMethod]
        public async Task AddProduct_SuccessAsync()
        {           
             await _controller.AddProductAsync(product);
            _productServiceMock.Verify(x => x.AddProductAsync(product), Times.Once);
        }

        [TestMethod]
        public async Task UpdateProduct_SuccessAsync()
        {
            await _controller.UpdateProductAsync(product);
            _productServiceMock.Verify(x => x.UpdateProductAsync(product), Times.Once);
        }
    }
}
