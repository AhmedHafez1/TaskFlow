using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskFlow.Infrastructure.Data
{
    public class TaskFlowDbContextFactory : IDesignTimeDbContextFactory<TaskFlowDbContext>
    {
        public TaskFlowDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskFlowDbContext>();

            optionsBuilder.UseNpgsql(
                "Server=localhost;Port=5432;Database=taskflow;User Id=postgres;Password=postgres;"
            );

            return new TaskFlowDbContext(optionsBuilder.Options);
        }
    }
}
