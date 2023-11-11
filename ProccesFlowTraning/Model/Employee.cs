using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProccesFlowTraning.Models
{
    public class Employee
    {
        [Key]
        public String? EmployeeId { get; set; }
        public DateTime? Birthdate { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender? StateGender { get; set; }
       // [Required]
        public string? EmployeeName { get; set; }
       
        public String? PhoneNumber { get; set; }

        [EnumDataType(typeof(StateActive))]
        public StateActive? EmployeeState { get; set; }
        public Employee()
        {
            this.EmployeeState = StateActive.Enable;
        }
    }
}
