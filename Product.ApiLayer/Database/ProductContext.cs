using Microsoft.EntityFrameworkCore;
using Product.ApiLayer.Model;

namespace Product.ApiLayer.Database
{
    public class ProductContext : DbContext
    {
        public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClsProduct>().Property(x => x.ProductId).UseIdentityColumn(2000, 1);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClsProduct> Products { get; set; }
    }
}
