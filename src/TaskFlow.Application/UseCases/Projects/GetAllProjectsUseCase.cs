using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Projects
{
    public class GetAllProjectsUseCase
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsUseCase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDto>> ExecuteAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects
                .Select(p => new ProjectDto(
                    p.Id,
                    p.Name,
                    p.Description!,
                    p.Status,
                    p.CreatedDate,
                    p.UpdatedDate,
                    p.OwnerId,
                    0,
                    0
                ))
                .ToList();
        }
    }
}
