using ProductManagement.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Data.DataContext
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of see ref<paramref name="AppDbContext"/>
        /// </summary>
        /// <param name="DbContextOptions<AppDbContext>"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Products Table
        /// </summary>
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
        }
    }
}
