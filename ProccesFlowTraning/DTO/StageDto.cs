using ProccesFlowTraning.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProccesFlowTraning.Dtos.PostDTO
{
    public class StageDto
    {
        public string? StageName { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int? EmployeeId { get; set; }

        public (bool, String) ValidateStage()
        {
           
            if (string.IsNullOrEmpty(StageName))
                return (false, "يجب ان تكتب اسم المرحله");

            if (string.IsNullOrEmpty(title))
                return (false, "يجب كتابه عنوان المرحله");
            if (EmployeeId == 0)
                return (false, "يجب كتابه رقم الموظف المرتبط بهذه المرحله");
            if (string.IsNullOrEmpty(description))
                return (false, "يجب كتابه وصف هذه المرحله");

            return (true, "تم اضافه المرحله بنجاح");
        }
    }
}
