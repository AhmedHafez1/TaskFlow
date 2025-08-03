using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskItem>
    {
        Task<TaskItem?> GetByAssigneeId(int assigneeId);
        Task<TaskItem?> GetByProjectId(int projectId);
        Task<TaskItem?> GetByProjectIdAndAssigneeId(int projectId, int assigneeId);
    }
}
