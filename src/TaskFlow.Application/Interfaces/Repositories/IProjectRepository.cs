using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Repositories;

public interface IProjectRepository : IGenericRepository<Project>
{
    IQueryable<Project> GetByOwnerIdAsync(int ownerId);
    Task<Project?> GetByNameAsync(string name);
}
