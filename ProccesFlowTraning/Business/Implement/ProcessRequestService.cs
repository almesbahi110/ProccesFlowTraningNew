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
    public class ProcessRequestService : IProcessRequestService
    {
        private readonly SmartFlowDbContext _context;
              public ProcessRequestService(SmartFlowDbContext cont)
        {
            _context = cont;
        }


        public async Task<IQueryable> GetAll()
        {
                return ( _context.ProcessRequests.AsQueryable());
        }

        public async Task<ProcessRequest> GetById(int id)
        {
            var data = await _context.ProcessRequests.FindAsync(id);
            if (data == null)
            {
               
            }
            return await _context.ProcessRequests.SingleOrDefaultAsync(a=>a.ProcessRequestId == id);
        }

        public async Task<(int ,String)> Delete(int id)
        {
            var data = await _context.ProcessRequests.FindAsync(id);
            if (data == null)
            {
                return (0,"عذراً لم يتم العثور على هذه طلب العملية");
            }
            _context.ProcessRequests.Remove(data);
            await _context.SaveChangesAsync();
            return (1, "تم حذف هذا الطلب بنجاح");
        }

        public async Task<(int, String)> PostData(ProcessRequestDto data)
        {
            try
            {
                ProcessRequestDto processRequestDto = new ProcessRequestDto();
                var (status, message) = processRequestDto.ValidteProcessRequest();
               
                    var processRequest = new ProcessRequest
                    {
                       EmployeeId= data.EmployeeId,
                       RequestDescraption=data.RequestDescraption,
                       ProcessStagesId=data.ProcessStagesId,
                       DateBegin = data.DateBegin
                    , DateEnd = data.DateEnd
                  ,ProcessRequestState=data.ProcessRequestState,
                       Note = data.Note
                      


                    };
                    _context.ProcessRequests.Add(processRequest);
                    await _context.SaveChangesAsync();
                    return (1, "تم اضافه هذه طلب العملية بنجاح");
                
            }
            catch (Exception ex) {
                return (0,"عذرا لم يتم اضافه طلب العملية ");
            }
        }
        public async Task<(int, String)> PutData(ProcessRequest data,int id)
        {

          
            try
            {
                ProcessRequestDto processRequestDto =new ProcessRequestDto();
                var (status, message) = processRequestDto.ValidteProcessRequest();
                if (id != data.ProcessRequestId)
                {
                    return (status, "رقم طلب العملية غير صحيح");
                }
              
                _context.Entry(data).State = EntityState.Modified;//Entry يعدل على سجل موجود يعني يشوف ايش المختلف ويعدله
                await _context.SaveChangesAsync();
                return (1, message);
            }
            catch (Exception ex)
            {
                return (0, "عذرا لم يتم تعديل طلب العملية بنجاح");
            }
        }
    }
}
