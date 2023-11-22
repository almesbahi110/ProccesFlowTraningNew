using ProccesFlowTraning.DTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IGPPD<T>
    {
        T GetAll();
        T GetById();
        T Delete();
       T PostData(T data);
        T PutData();
    }
}
