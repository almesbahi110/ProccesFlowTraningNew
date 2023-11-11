using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProccesFlowTraning.Models
{
    public class Stage
    {
        [Key]
        public int? StageId { get; set; }   
        public string? StageName { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }

        public String? EmployeeId { get; set; }

     [ForeignKey("EmployeeId")]
      public Employee? Employee { get; set; }


    }
}
