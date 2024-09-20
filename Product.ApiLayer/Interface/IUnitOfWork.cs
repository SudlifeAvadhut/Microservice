using Product.ApiLayer.Database;

namespace Product.ApiLayer.Interface
{
    public interface IUnitOfWork
    {
        ProductContext dbContext { get; }
    }
}
