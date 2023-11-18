using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IStageService
    {
        Task<(int, List<Stage>)> GetAll();
        Task<Stage> GetById(int id);
        Task<(int,String)> Delete(int id);
        Task<(int,String)> PostData(StageDto data);
        Task<(int,String)> PutData(Stage data,int id);
       
    }
}
