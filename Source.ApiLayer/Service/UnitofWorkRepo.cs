using Source.ApiLayer.Database;
using Source.ApiLayer.Interface;

namespace Source.ApiLayer.Service
{
    public class UnitofWorkRepo : IUnitOfWork
    {
        private readonly SoruceContext _dbContext;

        public UnitofWorkRepo(SoruceContext dbContext)
        {
            _dbContext = dbContext;
        }


        public SoruceContext dbContext
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
