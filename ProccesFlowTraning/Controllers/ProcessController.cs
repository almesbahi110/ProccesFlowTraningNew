using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Business.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.Models;
using Microsoft.AspNetCore.OData.Query;

namespace ProccesFlowTraning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly SmartFlowDbContext _context;
        private readonly IProcessService _processService;


        public ProcessController(SmartFlowDbContext cont, IProcessService processService)
        {
     
            _context = cont;
            _processService = processService;
        }
   
      
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAll()
        {
            
            var result= await _processService.GetAll();
         
            return Ok(result);

          
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _processService.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var (state, massage) =await _processService.Delete(id);
            if (state == 0)
            {
                return Ok(massage);
            }
            return Ok(massage);
        }


        [HttpPost]
        public async Task<ActionResult> PostData(ProcessDto data)
        {
          var (state,massage)=await _processService.PostData(data);
            if (state == 0)
            {
                return Ok(massage); 
            }
            else
            {
                return BadRequest(massage   );
            }

         
        }


        [HttpPut]
        public async Task<ActionResult> PutData(Process data,int id)
        {
            var (state, massage) = await _processService.PutData(data,id);
            if (state == 0)
            {
                return BadRequest(massage);
            }
            else
            {
                return Ok(massage);
            }


        }


    }
}