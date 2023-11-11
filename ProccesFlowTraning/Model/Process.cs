using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProccesFlowTraning.Models
{
    public class Process
    {
        [Key]
        public int? ProcessId { get; set; }   
        public string? ProcessName { get; set; }
        [EnumDataType(typeof(StateActive))]
        public StateActive? ProcessState { get; set; }
        public Process()
        {
            this.ProcessState = StateActive.Enable;
        }
        public string? Instructions { get; set; }



    }
}
