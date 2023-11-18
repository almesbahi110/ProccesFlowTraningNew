using ProccesFlowTraning.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ProccesFlowTraning.Dtos.PostDTO
{
    public class ProcessRequestDto
    {
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public StateProcess? ProcessRequestState { get; set; }
        public string? Note { get; set; }
        public string? RequestDescraption { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProcessStagesId { get; set; }
        public (int, String) ValidteProcessRequest()
        {
           
            if (String.IsNullOrEmpty(Note))
                return (0, "يجب ان تكتب الملاحظه");
            if (String.IsNullOrEmpty(RequestDescraption))
                return (0, "يجب ان تكتب وصف طلب العملية");
            if(ProcessStagesId==null || ProcessStagesId==0)
                return (0, "يجب ان تكتب رقم مرحله العملية بشكل صحيح");
            if (EmployeeId == null || EmployeeId == 0)
                return (0, "يجب ان تكتب رقم الموظف صحيح");
            return (1, "تم اضافه طلب العملية بنجاح ");
        }
    }
}