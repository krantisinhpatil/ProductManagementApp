using ProductManagement.ApiService.Interfaces;
using ProductManagement.ApiService.Service;
using ProductManagement.Data.Interfaces;
using ProductManagement.Data.Repository;

namespace ProductManagement.ApiService.Extension
{
    public static class ServiceCollectionExtenstion
    {
        public static void AddService(IServiceCollection Services) 
        {
            Services.AddTransient<IProductRepository, ProductRepository>();
            Services.AddTransient<IProductService, ProductService>();
        }
    }
}
