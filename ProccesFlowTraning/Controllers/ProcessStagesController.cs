
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Models;


namespace ProccesFlowTraning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessStagesController : ControllerBase
    {

        private readonly SmartFlowDbContext _context;
        public ProcessStagesController(SmartFlowDbContext cont)
        {
            _context = cont;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<ProcessStages>>> GetAllProcessStages()
        {
            return await _context.ProcessStages.ToListAsync();
        }
       
        [HttpPost]
        public async Task<ActionResult> PostData(ProcessStages data)
        {
            _context.ProcessStages.Add(data);
            await _context.SaveChangesAsync();
            return Ok("successfuly..add Stage.");
        }
        }
}
