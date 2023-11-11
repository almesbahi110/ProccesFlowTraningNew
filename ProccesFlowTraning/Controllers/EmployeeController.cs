using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Models;
using System;

namespace ProccesFlowTraning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly SmartFlowDbContext _context;
        public EmployeeController(SmartFlowDbContext cont)
        {
            _context = cont;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostData(Employee data)
        {
            var (status, message) = ValidateEmployee(data);

            if (status == true)
            {
                _context.Employees.Add(data);
                await _context.SaveChangesAsync();
                return Ok(message);
            }
            else
            {
                return Ok(message);
            }
        }

        private (bool, String) ValidateEmployee(Employee? employee)
        {
            if (employee is null)
                return (false, "لا يمكن ان يكون الموظف خالياً");

            if (string.IsNullOrEmpty(employee.EmployeeName))
                return (false, "يجب ان تكتب اسم الموظف");

            if (string.IsNullOrEmpty(employee.PhoneNumber))
                return (false, "يجب كتابه رقم الهاتف");
            
            return (true,"تم اضافه الموظف بنجاح");
        }
    }


   
}
