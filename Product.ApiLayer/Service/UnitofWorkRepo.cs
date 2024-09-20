using Product.ApiLayer.Database;
using Product.ApiLayer.Interface;

namespace Product.ApiLayer.Service
{
    public class UnitofWorkRepo : IUnitOfWork
    {
        private readonly ProductContext _dbContext;

        public UnitofWorkRepo(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ProductContext dbContext
        {
            get { return _dbContext; }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
