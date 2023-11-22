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
using Microsoft.AspNetCore.OData.Query;

namespace ProccesFlowTraning.Business.Implement
{
    public class ProcessService : IProcessService
    {
        private readonly IConfiguration _configuration;
        private readonly SmartFlowDbContext _context;
        //  private readonly EmailConfiguration _emailConfig;
        //public AuthService(EmailConfiguration emailConfig) => _emailConfig = emailConfig;
        public ProcessService(SmartFlowDbContext cont, IConfiguration configuration)
        {
            _context = cont;

            _configuration = configuration;

        }

        [EnableQuery]
        [HttpGet]
        public async  Task<IQueryable> GetAll()
        {
                return ( _context.Processes.AsQueryable());
        }

        public async Task<Process> GetById(int id)
        {
            var data = await _context.Stages.FindAsync(id);
            if (data == null)
            {
               
            }
            return await _context.Processes.SingleOrDefaultAsync(a=>a.ProcessId == id);
        }

        public async Task<(int ,String)> Delete(int id)
        {
            var data = await _context.Processes.FindAsync(id);
            if (data == null)
            {
                return (0,"عذراً لم يتم العثور على هذه العملية");
            }
            _context.Processes.Remove(data);
            await _context.SaveChangesAsync();
            return (1, "تم حذف هذه العملية بنجاح");
        }

        public async Task<(int, String)> PostData(ProcessDto data)
        {
            try
            {
                var (status, message) = data.ValidteProcess();
                if (status == 0)
                {
                    return (0, message);
                }
                else
                {
                    var process = new Process
                    {
                        Instructions = data.Instructions,
                        ProcessName = data.ProcessName,
                        ProcessState = data.ProcessState,

                    };
                    _context.Processes.Add(process);
                    await _context.SaveChangesAsync();
                    return (1, "تم اضافه هذه العملية بنجاح");
                }
            }
            catch (Exception ex) {
                return (0,"عذرا لم يتم اضافه العملية بنجاح");
            }
        }
        public async Task<(int, String)> PutData(Process data,int id)
        {

          
            try
            {
                ProcessDto processDto=new ProcessDto();
                var (status, message) = processDto.ValidteProcess();
                if (id != data.ProcessId)
                {
                    return (status, "رقم العملية غير صحيح");
                }
              
                _context.Entry(data).State = EntityState.Modified;//Entry يعدل على سجل موجود يعني يشوف ايش المختلف ويعدله
                await _context.SaveChangesAsync();
                return (1, message);
            }
            catch (Exception ex)
            {
                return (0, "عذرا لم يتم تعديل العملية بنجاح");
            }
        }
    }
}
