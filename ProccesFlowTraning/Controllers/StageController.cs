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
    public class StageController : ControllerBase
    {
        private readonly SmartFlowDbContext _context;
        private readonly IStageService _stageService;

        public StageController(SmartFlowDbContext cont, IStageService stageService)
        {
     
            _context = cont;
            _stageService = stageService;
           
        }
   
      
        [HttpGet]
        [EnableQuery]
       // [Route("GetAll")]
        public async Task<IQueryable> GetAll()
        {
           
                var result = await _stageService.GetAll();
                return result;          
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _stageService.GetById(id);
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
            var (state, massage) =await _stageService.Delete(id);
            if (state == 0)
            {
                return Ok(massage);
            }
            return Ok(massage);
        }


        [HttpPost]
        public async Task<ActionResult> PostData(StageDto data)
        {
          var (state,massage)=await _stageService.PostData(data);
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
        public async Task<ActionResult> PutData(Stage data,int id)
        {
            var (state, massage) = await _stageService.PutData(data,id);
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