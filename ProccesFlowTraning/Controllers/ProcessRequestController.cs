
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Models;


namespace ProccesFlowTraning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessRequestController : ControllerBase
    {

        private readonly SmartFlowDbContext _context;
        public ProcessRequestController(SmartFlowDbContext cont)
        {
            _context = cont;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<ProcessRequest>>> GetAllProcessRequest()
        {
            return await _context.ProcessRequests.ToListAsync();
        }
       
        [HttpPost]
        public async Task<ActionResult> PostData(ProcessRequest data)
        {
            _context.ProcessRequests.Add(data);
            await _context.SaveChangesAsync();
            return Ok("successfuly..add Stage.");
        }
    }
}
