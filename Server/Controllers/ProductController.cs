using Microsoft.AspNetCore.Mvc;
using ProductManagement.ApiService.Interfaces;
using ProductManagement.Data.Model;

namespace ProductManagement.ApiService.Controllers
{
    /// <summary>
    /// Product Controller 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of see ref<paramref name="ProductController"/>
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// The controller method to retrive all products.
        /// </summary>
        /// <returns>returns list of products</returns>
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        /// <summary>
        /// Get method to retrive single Product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns> return single product using Product Id</returns>
        [HttpGet("{id:int}")]
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        /// <summary>
        /// Post method to Add Product to database
        /// </summary>
        /// <param name="product"> Product object</param>
        /// <returns>Returns asynchronous Task.</returns>
        [HttpPost]
        public async Task AddProductAsync(Product product)
        {
            await _productService.AddProductAsync(product);
        }

        /// <summary>
        /// Upadte method to Update Product to database
        /// </summary>
        /// <param name="product">Product object</param>
        /// <returns>Returns asynchronous Task.</returns>
        [HttpPut]
        public async Task UpdateProductAsync(Product product)
        {
             await _productService.UpdateProductAsync(product);
        }

        /// <summary>
        /// Delete method to delete Product to database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>returns bool</returns>
        [HttpDelete("{id:int}")]
        public async Task<bool> DeleteProductAsync(int id)
        {
            await _productService.DeleteProductAsync(id);
            return true;
        }
    }
}
