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
using ProccesFlowTraning.DTO;

namespace BloggingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SmartFlowDbContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<StageController> _logger;


        public EmployeeController(SmartFlowDbContext cont, IEmployeeService employeeService, ILogger<StageController> logger)
        {
     
            _context = cont;
            _employeeService = employeeService;
            _logger = logger;
        }
   
      
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
            var (status, message) = await _employeeService.GetAll();
            if (status == 0)
            {
                return BadRequest(message);
            }
            return Ok(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _employeeService.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var (state, massage) =await _employeeService.Delete(id);
            if (state == 0)
            {
                return Ok(massage);
            }
            return Ok(massage);
        }


        [HttpPost]
        public async Task<ActionResult> PostData(EmployeeDto data)
        {
          var (state,massage)=await _employeeService.PostData(data);
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
        public async Task<ActionResult> PutData(Employee data,int id)
        {
            var (state, massage) = await _employeeService.PutData(data,id);
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