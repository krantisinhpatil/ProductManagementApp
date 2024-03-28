
using ProductManagement.Data.Model;

namespace ProductManagement.Data.Interfaces
{
    /// <summary>
    /// IProductRepository impemented Add, Update, Delete, Read fuctionality Products DbSet
    /// </summary>
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
