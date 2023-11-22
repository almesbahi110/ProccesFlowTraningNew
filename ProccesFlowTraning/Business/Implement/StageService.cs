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
    public class StageService : IStageService, IStageByIdEmployeeService
    {
        private readonly SmartFlowDbContext _context;
        public StageService(SmartFlowDbContext cont)
        {
            _context = cont;
        }
        public async Task<(int,List<Stage>)> GetAllStageByIdEmployee(int id)
        {
           
            return (1,await _context.Stages.Where(w=>w.EmployeeId==id).ToListAsync());
        }
        [EnableQuery]
        [HttpGet]
        public async Task<IQueryable> GetAll()
        {
            //   return (1, await _context.Stages.Include(a=>a.Employee).ToListAsync());
            return (_context.Stages.AsQueryable());
        }

        public async Task<Stage> GetById(int id)
        {
            var data = await _context.Stages.FindAsync(id);
            if (data == null)
            {
               
            }
            return await _context.Stages.SingleOrDefaultAsync(a=>a.StageId==id);
        }

        public async Task<(int ,String)> Delete(int id)
        {
            var data = await _context.Stages.FindAsync(id);
            if (data == null)
            {
                return (0,"عذراً لم يتم العثور على هذه المرحله");
            }
            _context.Stages.Remove(data);
            await _context.SaveChangesAsync();
            return (1, "تم حذف هذه المرحله بنجاح");
        }

        public async Task<(int, String)> PostData(StageDto data)
        {
            try
            {


                var stage = new Stage
                {
                    StageName = data.StageName,
                    EmployeeId = data.EmployeeId,
                    description = data.description,
                    title = data.title
                };
                _context.Stages.Add(stage);
                await _context.SaveChangesAsync();
                return (1, "تم اضافه هذه المرحله بنجاح");
            }
            catch (Exception ex) {
                return (0,"عذرا لم يتم اضافه المرحله بنجاح");
            }
        }
        public async Task<(int, String)> PutData(Stage data,int id)
        {

          
            try
            {
                if (id != data.StageId)
                {
                    return (0, "رقم المرحله غير صحيح");
                }
                var stage = new Stage
                {
                    StageId = data.StageId,
                    StageName = data.StageName,
                    EmployeeId = data.EmployeeId,
                    title = data.title,
                    description = data.description
                };
                _context.Entry(stage).State = EntityState.Modified;//Entry يعدل على سجل موجود يعني يشوف ايش المختلف ويعدله
                await _context.SaveChangesAsync();
                return (1, "تم التعديل هذه المرحله بنجاح");
            }
            catch (Exception ex)
            {
                return (0, "عذرا لم يتم اضافه المرحله بنجاح");
            }
        }
    }
}
