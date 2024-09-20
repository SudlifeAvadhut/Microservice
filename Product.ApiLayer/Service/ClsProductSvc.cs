using Product.ApiLayer.BusinessModel;
using Product.ApiLayer.Interface;
using Product.ApiLayer.Model;

namespace Product.ApiLayer.Service
{
    public class ClsProductSvc : IProduct
    {
        public IUnitOfWork _unitOfWork;
        public ClsProductSvc(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        ~ClsProductSvc()
        {
            Dispose(false);
        }
        public void Delete(int ProductId)
        {
            var dataexist = _unitOfWork.dbContext.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();

            if(dataexist != null)
            {
                _unitOfWork.dbContext.Products.Remove(dataexist);
                _unitOfWork.dbContext.SaveChanges();
            }
        }

        public List<ClsProductBM> GetAll()
        {
            return _unitOfWork.dbContext.Products.Select(x => new ClsProductBM
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy
            }).ToList();
        }

        public void Insert(ClsProductBM ObjProduct)
        {

            var dataexist = _unitOfWork.dbContext.Products.Where(x => x.ProductName == ObjProduct.ProductName).FirstOrDefault();

            if(dataexist == null)
            {
                ClsProduct objpro = new ClsProduct
                {
                    ProductName = ObjProduct.ProductName,
                    IsActive = ObjProduct.IsActive,
                    CreatedAt = DateTime.Now,
                    CreatedBy = ObjProduct.CreatedBy
                };

                _unitOfWork.dbContext.Products.Add(objpro);
                _unitOfWork.dbContext.SaveChanges();
            }

            //throw new NotImplementedException();
        }

        public void Update(ClsProductBM ObjProduct, int ProductId)
        {
            var dataexist = _unitOfWork.dbContext.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();

            if( dataexist != null)
            {
                ClsProduct objpro = new ClsProduct
                {
                    ProductName = ObjProduct.ProductName,
                    IsActive = ObjProduct.IsActive,
                    CreatedAt = DateTime.Now,
                    CreatedBy = ObjProduct.CreatedBy
                };
                _unitOfWork.dbContext.Products.Update(objpro);
                _unitOfWork.dbContext.SaveChanges();
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
