using ProccesFlowTraning.DTO;
using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;

namespace ProccesFlowTraning.Business.Abstract
{
    public interface IEmployeeService
    {
        Task<(int, List<Employee>)> GetAll();
        Task<Employee> GetById(int id);
        Task<(int,String)> Delete(int id);
        Task<(int,String)> PostData(EmployeeDto data);
        Task<(int,String)> PutData(Employee data,int id);
       
    }
}
