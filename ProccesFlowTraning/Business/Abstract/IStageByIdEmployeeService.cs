using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IStageByIdEmployeeService
    {
        Task<(int, List<Stage>)> GetAllStageByIdEmployee(int id);       
    }
}
