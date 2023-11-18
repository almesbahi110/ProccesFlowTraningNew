using ProccesFlowTraning.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProccesFlowTraning.Dtos.PostDTO
{
    public class ProcessStagesDto
    {

        public int? ProcessId { get; set; }
        public int? StageId { get; set; }

        public int? Order { get; set; }
        public int? Next { get; set; }
        public (int, String) ValidteProcessStages()
        {
            if (StageId == null || StageId == 0)
                return (0, "يجب ان تكتب رقم المرحله ");
            if (ProcessId == null || ProcessId == 0)
                return (0, "يجب ان تكتب رقم العملية ");
            if (Next == null || Next == 0)
                return (0, "يجب ان تكتب رقم التالي ");
            if (Order == null || Order == 0)
                return (0, "يجب ان تكتب الترتيب ");
            return (1, "تم اضافه طلب العملية بنجاح ");
        }
    }
}
