using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly TaskFlowDbContext _context;

        public ProjectRepository(TaskFlowDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Project?> GetByNameAsync(string name)
        {
            var project = await _context.Projects.Where(p => p.Name == name).FirstOrDefaultAsync();
            return project;
        }

        public IQueryable<Project> GetByOwnerIdAsync(int ownerId)
        {
            return _context
                .Projects.Where(p => p.OwnerId == ownerId)
                .Include(p => p.TaskItems)
                .AsNoTracking();
        }
    }
}
