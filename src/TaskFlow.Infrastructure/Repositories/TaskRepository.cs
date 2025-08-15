using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<TaskItem>, ITaskRepository
    {
        private readonly TaskFlowDbContext _context;

        public TaskRepository(TaskFlowDbContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<TaskItem?> GetByAssigneeId(int assigneeId)
        {
            return _context.TaskItems.FirstOrDefaultAsync(ti => ti.AssigneeId == assigneeId);
        }

        public Task<TaskItem?> GetByProjectId(int projectId)
        {
            return _context.TaskItems.FirstOrDefaultAsync(ti => ti.ProjectId == projectId);
        }

        public Task<TaskItem?> GetByProjectIdAndAssigneeId(int projectId, int assigneeId)
        {
            return _context.TaskItems.FirstOrDefaultAsync(ti =>
                ti.ProjectId == projectId && ti.AssigneeId == assigneeId
            );
        }
    }
}
