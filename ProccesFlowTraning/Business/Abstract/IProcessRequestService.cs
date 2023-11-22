using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IProcessRequestService
    {
        Task<IQueryable> GetAll();
        Task<ProcessRequest> GetById(int id);
        Task<(int,String)> Delete(int id);
        Task<(int,String)> PostData(ProcessRequestDto data);
        Task<(int,String)> PutData(ProcessRequest data,int id);
       
    }
}
