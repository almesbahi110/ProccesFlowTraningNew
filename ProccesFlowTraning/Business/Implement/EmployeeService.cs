using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProccesFlowTraning.Data;
using ProccesFlowTraning.Models;
using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Business.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProccesFlowTraning.Dtos.PostDTO;
using ProccesFlowTraning.DTO;

namespace ProccesFlowTraning.Business.Implement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly SmartFlowDbContext _context;
        public EmployeeService(SmartFlowDbContext cont)
        {
            _context = cont;
        }


        public async Task<IQueryable> GetAll()
        {
                return (_context.Employees.AsQueryable());
        }

        public async Task<Employee> GetById(int id)
        {
            var data = await _context.Employees.FindAsync(id);
            if (data == null)
            {
               
            }
            return await _context.Employees.SingleOrDefaultAsync(a=>a.EmployeeId == id);
        }

        public async Task<(int ,String)> Delete(int id)
        {
            var data = await _context.Employees.FindAsync(id);
            if (data == null)
            {
                return (0,"عذراً لم يتم العثور على هذا الموظف");
            }
            _context.Employees.Remove(data);
            await _context.SaveChangesAsync();
            return (1, "تم حذف هذا الموظف بنجاح");
        }

        public async Task<(int, String)> PostData(EmployeeDto data)
        {
            try
            {
                var (status, message) = data.ValidteEmployee();
                if (status == 0)
                {
                    return (0, message);
                }
                else
                {
                    var employee = new Employee
                    {
                       Birthdate= data.Birthdate,
                       Department  =    data.Department,
                       EmployeeName= data.EmployeeName,
                       PhoneNumber = data.PhoneNumber,
                       Gender= data.Genderr,
                       EmployeeState = data.EmployeeState

                    };
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return (1, "تم اضافه هذا الموظف بنجاح");
                }
            }
            catch (Exception ex) {
                return (0,"عذرا لم يتم اضافه الموظف بنجاح");
            }
        }
        public async Task<(int, String)> PutData(Employee data,int id)
        {

          
            try
            {
                EmployeeDto employeeDto=new EmployeeDto();
                var (status, message) = employeeDto.ValidteEmployee();
                if (id != data.EmployeeId)
                {
                    return (status, "رقم الموظف غير صحيح");
                }
              
                _context.Entry(data).State = EntityState.Modified;//Entry يعدل على سجل موجود يعني يشوف ايش المختلف ويعدله
                await _context.SaveChangesAsync();
                return (1, message);
            }
            catch (Exception ex)
            {
                return (0, "عذرا لم يتم تعديل الموظف بنجاح");
            }
        }
    }
}
