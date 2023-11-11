using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Models;
namespace ProccesFlowTraning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {

        private readonly SmartFlowDbContext _context;
        public ProcessController(SmartFlowDbContext cont)
        {
            _context = cont;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<Process>>> GetAllProcess()
        {
            return await _context.Processes.ToListAsync();
        }
       
        [HttpPost]
        public async Task<ActionResult> PostData(Process data)
        {
            var (status, message) = ValidateProcess(data);

            if (status == true)
            {
                _context.Processes.Add(data);
                await _context.SaveChangesAsync();
                return Ok(message);
            }
            else
            {
                return Ok(message);
            }
          
          
        }
        private (bool, String) ValidateProcess(Process? process)
        {
            if (process is null)
                return (false, "لا يمكن ان يكون الموظف خالياً");

            if (string.IsNullOrEmpty(process.ProcessName))
                return (false, "يجب ان تكتب اسم العملية");

            if (string.IsNullOrEmpty(process.Instructions))
                return (false, "يجب كتابه تعليمة العملية");

            return (true, "تم اضافه العملية بنجاح");
        }
    }
}
