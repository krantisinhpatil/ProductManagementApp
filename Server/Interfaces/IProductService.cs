using ProductManagement.Data.Model;

namespace ProductManagement.ApiService.Interfaces
{
    /// <summary>
    /// Product service interface to perform Add, Update, and delete funtionality.
    /// </summary>
    /// <param name="product"></param>
    public interface IProductService
    {
        /// <summary>
        /// AddProductAsyns method will add Product to Db
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Returns asynchronous Task.</returns>
        public Task AddProductAsync(Product product);

        /// <summary>
        /// UpdateProductAsync method perform update funtionality
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Returns asynchronous Task.</returns>
        public Task UpdateProductAsync(Product product);

        /// <summary>
        /// DeleteProductAsync method perform Delete funtionality
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Returns asynchronous Task.</returns>
        public Task DeleteProductAsync(int productId);

        /// <summary>
        /// GetProductByIdAsync method gives Product using Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Returns single Product </returns>
        public Task<Product?> GetProductByIdAsync(int id);

        /// <summary>
        /// GetAllProducts gives list of products
        /// </summary>
        /// <returns>Returns list of Product</returns>
        public List<Product> GetAllProducts();
    }
}
