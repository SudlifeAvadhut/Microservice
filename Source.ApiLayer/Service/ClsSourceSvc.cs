using Source.ApiLayer.BusinessModel;
using Source.ApiLayer.Interface;
using Source.ApiLayer.Model;

namespace Source.ApiLayer.Service
{
    public class ClsSourceSvc : ISource
    {
        public IUnitOfWork _unitOfWork;
        public ClsSourceSvc(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        ~ClsSourceSvc()
        {
            Dispose(false);
        }
        public void Delete(int SourceId)
        {
            var dataexist = _unitOfWork.dbContext.Soruces.Where(x => x.SourceId == SourceId).FirstOrDefault();

            if (dataexist != null)
            {
                _unitOfWork.dbContext.Soruces.Remove(dataexist);
                _unitOfWork.dbContext.SaveChanges();
            }
        }

        public List<ClsSourceBM> GetAll()
        {

            var GetAllSource = _unitOfWork.dbContext.Soruces.Join(_unitOfWork.dbContext.Products,
                x => x.ProductId,
                y => y.ProductId,
                (x, y) => new { x, y })
                .Select(i => new ClsSourceBM
                {
                    SourceId = i.x.SourceId,
                    SoruceName = i.x.SoruceName,
                    IsActive = i.x.IsActive,
                    CreatedAt = i.x.CreatedAt,
                    CreatedBy = i.x.CreatedBy,
                    ProductName = i.y.ProductName
                }).ToList();

            return GetAllSource;
        }

        public void Insert(ClsSourceBM ObjSource)
        {

            var ProductId = _unitOfWork.dbContext.Products.Where(x => x.ProductName == ObjSource.ProductName).Select(x=>x.ProductId).FirstOrDefault();

            if(ProductId != null && ProductId > 0)
            {
                var SourceData = _unitOfWork.dbContext.Soruces.Where(x => x.ProductId == ProductId && x.SoruceName == ObjSource.SoruceName).FirstOrDefault();

                if(SourceData == null)
                {
                    ClsSource ObjSou = new ClsSource
                    {
                        SoruceName = ObjSource.SoruceName,
                        IsActive = ObjSource.IsActive,
                        CreatedAt = DateTime.Now,
                        CreatedBy = ObjSource.CreatedBy,
                        ProductId = ProductId
                    };
                    _unitOfWork.dbContext.Soruces.Add(ObjSou);
                    _unitOfWork.dbContext.SaveChanges();
                }
            }

        }

        public void Update(ClsSourceBM ObjSource, int SourceId)
        {
            var ProductId = _unitOfWork.dbContext.Products.Where(x => x.ProductName == ObjSource.ProductName).Select(x => x.ProductId).FirstOrDefault();

            if (ProductId != null && ProductId > 0)
            {
                var SourceData = _unitOfWork.dbContext.Soruces.Where(x => x.ProductId == ProductId && x.SoruceName == ObjSource.SoruceName).FirstOrDefault();

                if (SourceData == null)
                {
                    ClsSource ObjSou = new ClsSource
                    {
                        SoruceName = ObjSource.SoruceName,
                        IsActive = ObjSource.IsActive,
                        CreatedAt = DateTime.Now,
                        CreatedBy = ObjSource.CreatedBy,
                        ProductId = ProductId
                    };
                    _unitOfWork.dbContext.Soruces.Update(ObjSou);
                    _unitOfWork.dbContext.SaveChanges();
                }
            }

                
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                // Console.WriteLine("This is the first call to Dispose. Necessary clean-up will be done!");

                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    // Console.WriteLine("Explicit call: Dispose is called by the user.");
                }
                else
                {
                    // Console.WriteLine("Implicit call: Dispose is called through finalization.");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Console.WriteLine("Unmanaged resources are cleaned up here.");

                // TODO: set large fields to null.

                disposedValue = true;
            }
            else
            {
                // Console.WriteLine("Dispose is called more than one time. No need to clean up!");
            }
        }



        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}
