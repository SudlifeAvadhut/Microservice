using Product.ApiLayer.BusinessModel;

namespace Product.ApiLayer.Interface
{
    public interface IProduct
    {
        void Insert(ClsProductBM ObjProduct);
        void Update(ClsProductBM ObjProduct,int ProductId);
        void Delete(int ProductId);
        List<ClsProductBM> GetAll();

    }
}
