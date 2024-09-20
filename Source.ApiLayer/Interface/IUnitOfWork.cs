using Source.ApiLayer.Database;

namespace Source.ApiLayer.Interface
{
    public interface IUnitOfWork
    {
        SoruceContext dbContext { get; }
    }
}
