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

namespace BloggingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessStagesController : ControllerBase
    {
        private readonly SmartFlowDbContext _context;
        private readonly IProcessStageService _procesStageService;


        public ProcessStagesController(SmartFlowDbContext cont, IProcessStageService processStageService)
        {

            _context = cont;
            _procesStageService = processStageService;
        }


        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var res = await _procesStageService.GetAll();
               
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
                var data = await _procesStageService.GetById(id);
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
            var (state, massage) = await _procesStageService.Delete(id);
            if (state == 0)
            {
                return Ok(massage);
            }
            return Ok(massage);
        }


        [HttpPost]
        public async Task<ActionResult> PostData(ProcessStagesDto data)
        {
            var (state, massage) = await _procesStageService.PostData(data);
            if (state == 0)
            {
                return Ok(massage);
            }
            else
            {
                return BadRequest(massage);
            }


        }


        [HttpPut]
        public async Task<ActionResult> PutData(ProcessStages data, int id)
        {
            var (state, massage) = await _procesStageService.PutData(data, id);
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