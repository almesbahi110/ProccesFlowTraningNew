
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Models;


namespace ProccesFlowTraning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {

        private readonly SmartFlowDbContext _context;
        public StageController(SmartFlowDbContext cont)
        {
            _context = cont;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<Stage>>> GetAllStage()
        {
            return await _context.Stages.Include(a=>a.Employee).ToListAsync();
        }
       
        [HttpPost]
        public async Task<ActionResult> PostData(Stage data)
        {
            var (status, message) = ValidateStage(data);

            if (status == true)
            {
                _context.Stages.Add(data);
                await _context.SaveChangesAsync();
                return Ok(message);
            }
            else
            {
                return Ok(message);
            }
        }

        private (bool, String) ValidateStage(Stage? stage)
        {
            if (stage is null)
                return (false, "لا يمكن ان يكون الموظف خالياً");

            if (string.IsNullOrEmpty(stage.StageName))
                return (false, "يجب ان تكتب اسم المرحله");

            if (string.IsNullOrEmpty(stage.title))
                return (false, "يجب كتابه عنوان المرحله");
            if (string.IsNullOrEmpty(stage.EmployeeId))
                return (false, "يجب كتابه رقم الموظف المرتبط بهذه المرحله");
            if (string.IsNullOrEmpty(stage.description))
                return (false, "يجب كتابه وصف هذه المرحله");

            return (true, "تم اضافه المرحله بنجاح");
        }
    }
}
