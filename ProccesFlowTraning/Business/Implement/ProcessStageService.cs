
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

namespace ProccesFlowTraning.Business.Implement
{
    public class ProcessStageService : IProcessStageService
    {
        private readonly SmartFlowDbContext _context;
        public ProcessStageService(SmartFlowDbContext cont)
        {
            _context = cont;


        }


        public async Task<IQueryable> GetAll()
        {
                return ( _context.ProcessStages.AsQueryable());
        }

        public async Task<ProcessStages> GetById(int id)
        {
            var data = await _context.ProcessStages.FindAsync(id);
            if (data == null)
            {
               
            }
            return await _context.ProcessStages.SingleOrDefaultAsync(a=>a.ProcessStagesId == id);
        }

        public async Task<(int ,String)> Delete(int id)
        {
            var data = await _context.ProcessStages.FindAsync(id);
            if (data == null)
            {
                return (0,"عذراً لم يتم العثور على هذه مرحه لالعملية");
            }
            _context.ProcessStages.Remove(data);
            await _context.SaveChangesAsync();
            return (1, "تم حذف مرحله العملية بنجاح");
        }

        public async Task<(int, String)> PostData(ProcessStagesDto data)
        {
            try
            {
                var (status, message) = data.ValidteProcessStages();
                if (status == 0)
                {
                    return (0, message);
                }
                else
                {
                    var processStage = new ProcessStages
                    {
                       Next=data.Next,
                       StageId=data.StageId,
                       Order=data.Order,
                       ProcessId=data.ProcessId,
                      

                    };
                    _context.ProcessStages.Add(processStage);
                    await _context.SaveChangesAsync();
                    return (1, "تم اضافه مرحله العملية بنجاح");
                }
            }
            catch (Exception ex) {
                return (0,"عذرا لم يتم اضافه مرحله العملية بنجاح");
            }
        }
        public async Task<(int, String)> PutData(ProcessStages data,int id)
        {

          
            try
            {
                ProcessStagesDto processStageDto=new ProcessStagesDto();
                var (status, message) = processStageDto.ValidteProcessStages();
                if (id != data.ProcessId)
                {
                    return (status, "رقم مرحله العملية غير صحيح");
                }
              
                _context.Entry(data).State = EntityState.Modified;//Entry يعدل على سجل موجود يعني يشوف ايش المختلف ويعدله
                await _context.SaveChangesAsync();
                return (1, message);
            }
            catch (Exception ex)
            {
                return (0, "عذرا لم يتم تعديل مرحله العملية بنجاح");
            }
        }
    }
}
