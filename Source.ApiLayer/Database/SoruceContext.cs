using Microsoft.EntityFrameworkCore;
using Source.ApiLayer.Model;

namespace Source.ApiLayer.Database
{
    public class SoruceContext : DbContext
    {
        public SoruceContext() { }
        public SoruceContext(DbContextOptions<SoruceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClsProduct>().Property(x => x.ProductId).UseIdentityColumn(2000, 1);
            modelBuilder.Entity<ClsSource>().HasOne(x => x.Product).WithMany(x => x.Sources).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClsProduct> Products { get; set; }
        public DbSet<ClsSource> Soruces { get; set; }
    }
}
