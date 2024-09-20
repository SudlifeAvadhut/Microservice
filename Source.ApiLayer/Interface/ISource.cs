using Source.ApiLayer.BusinessModel;

namespace Source.ApiLayer.Interface
{
    public interface ISource
    {
        void Insert(ClsSourceBM ObjSource);
        void Update(ClsSourceBM ObjSource, int SourceId);
        void Delete(int SourceId);
        List<ClsSourceBM> GetAll();
    }
}
