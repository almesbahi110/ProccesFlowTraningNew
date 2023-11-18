using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProccesFlowTraning.Models
{
    public  class Employee : EmployeeDepartment
    {
        public string Department { get; set; }  
    }
    public abstract class EmployeeDepartment
    {
        [Key]
        public int EmployeeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public Gender? Gender { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public StateActive? EmployeeState { get; set; }
        protected EmployeeDepartment()
        {
            EmployeeState = StateActive.Enable;
        }
    }
}