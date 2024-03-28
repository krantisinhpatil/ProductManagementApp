using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Data.Model
{
    public class Product
    {
        /// <summary>
        /// Gets or Sets the  Product Id 
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or Sets the Product Name as well it's Required
        /// </summary>
        public required string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets the Product Description
        /// </summary>
        public string? Description { get; set; } = null;

        /// <summary>
        /// Gets or Sets the Product Price
        /// </summary>

        public required decimal Price { get; set; }

        /// <summary>
        /// Gets or Sets the Product Availability
        /// </summary>

        public required bool Availability { get; set; }=false;   
    }
}
