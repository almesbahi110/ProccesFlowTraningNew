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
    public class ProcessRequestController : ControllerBase
    {
        private readonly SmartFlowDbContext _context;
        private readonly IProcessRequestService _processRequestService;


        public ProcessRequestController(SmartFlowDbContext cont, IProcessRequestService processRequestService)
        {
     
            _context = cont;
             _processRequestService= processRequestService;
        }
   
      
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAll()
        {
            try
            {
          
            var res = await _processRequestService.GetAll();
           
            return Ok(res);

            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _processRequestService.GetById(id);
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
            var (state, massage) =await _processRequestService.Delete(id);
            if (state == 0)
            {
                return Ok(massage);
            }
            return Ok(massage);
        }


        [HttpPost]
        public async Task<ActionResult> PostData(ProcessRequestDto data)
        {
          var (state,massage)=await _processRequestService.PostData(data);
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
        public async Task<ActionResult> PutData(ProcessRequest data,int id)
        {
            var (state, massage) = await _processRequestService.PutData(data,id);
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