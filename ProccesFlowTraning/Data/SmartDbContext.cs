using Microsoft.EntityFrameworkCore;
using ProccesFlowTraning.Models;
namespace ProccesFlowTraning.Data
{
    public class SmartFlowDbContext : DbContext
    {
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProcessStages> ProcessStages { get; set; }
        public DbSet<ProcessRequest> ProcessRequests { get; set; }
        public SmartFlowDbContext(DbContextOptions<SmartFlowDbContext> options) : base(options) { }
    }
}