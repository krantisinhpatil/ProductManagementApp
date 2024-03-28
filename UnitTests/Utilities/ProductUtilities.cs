using ProductManagement.Data.Model;

namespace ProductManagementApiServiceTests.Utilities
{
    public static class ProductUtilities
    {
        public static Product DummyProductData()
        {
            return new Product()
            {
                ProductName = "ProductName",
                Price = 10.3m,
                Description = "Description",
                Availability = true
            };
        }
    }
}
