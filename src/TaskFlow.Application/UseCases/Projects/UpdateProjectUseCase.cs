using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Application.UseCases.Projects
{
    public class UpdateProjectUseCase
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectUseCase(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDto> ExecuteAsync(UpdateProjectDto dto, int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
                throw new ArgumentException("Project not found.");
            project.Update(dto.Name, dto.Description, dto.Status);
            await _projectRepository.UpdateAsync(project);
            return new ProjectDto(
                project.Id,
                project.Name,
                project.Description!,
                project.Status,
                project.CreatedDate,
                project.UpdatedDate,
                project.OwnerId,
                0,
                0
            );
        }
    }
}
