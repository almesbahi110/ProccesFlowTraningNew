using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IProcessService
    {
        Task<(int, List<Process>)> GetAll();
        Task<Process> GetById(int id);
        Task<(int,String)> Delete(int id);
        Task<(int,String)> PostData(ProcessDto data);
        Task<(int,String)> PutData(Process data,int id);
       
    }
}
