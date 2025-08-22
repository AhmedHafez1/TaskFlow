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

        public async Task<List<ProjectSummaryDto>> ExecuteAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects
                .Select(p => new ProjectSummaryDto(
                    p.Id,
                    p.Name,
                    p.Description!,
                    p.Status.ToString(),
                    p.CreatedDate,
                    p.UpdatedDate,
                    p.OwnerId
                ))
                .ToList();
        }
    }
}
