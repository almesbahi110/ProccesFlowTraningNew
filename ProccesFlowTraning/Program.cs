using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Business.Abstract;
using ProccesFlowTraning.Business.Implement;
using ProccesFlowTraning.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IStageService, StageService>();
builder.Services.AddTransient<IProcessService, ProcessService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IProcessRequestService, ProcessRequestService>();
builder.Services.AddTransient<IProcessStageService, ProcessStageService>();


builder.Services.AddDbContext<SmartFlowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
