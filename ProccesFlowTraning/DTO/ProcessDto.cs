using Microsoft.AspNetCore.Components.RenderTree;
using ProccesFlowTraning.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProccesFlowTraning.Dtos.PostDTO
{
    public class ProcessDto

    {

        public string? ProcessName { get; set; }
        public StateActive? ProcessState { get; set; }
        public string? Instructions { get; set; }

        public (int, String) ValidteProcess()
        {
            if (String.IsNullOrEmpty(ProcessName))
                return (0, "يجب ان تكتب اسم العملية");
          
            if (String.IsNullOrEmpty(Instructions))
                return (0, "يجب ان تكتب تعليمة العملية");
    
            return (1, "تم اضافه العملية بنجاح ");
        }
    }
}
