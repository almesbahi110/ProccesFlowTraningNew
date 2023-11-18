using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IProcessStageService
    {
        Task<(int, List<ProcessStages>)> GetAll();
        Task<ProcessStages> GetById(int id);
        Task<(int,String)> Delete(int id);
        Task<(int,String)> PostData(ProcessStagesDto data);
        Task<(int,String)> PutData(ProcessStages data,int id);
       
    }
}
