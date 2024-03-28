
using ProductManagement.Data.Interfaces;
using ProductManagement.Data.Model;
using ProductManagement.Data.DataContext;


namespace ProductManagement.Data.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext Context) : base(Context)
        {
        }

    }
}
