using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.UseCases.Projects;

public class CreateProjectUseCase
{
    private readonly IProjectRepository _projectRepository;
    private readonly ICurrentUserService _currentUserService;

    public CreateProjectUseCase(
        IProjectRepository projectRepository,
        ICurrentUserService currentUserService
    )
    {
        _projectRepository = projectRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ProjectDto> ExecuteAsync(CreateProjectDto dto)
    {
        var userId = _currentUserService.UserId;
        var project = new Project(dto.Name, dto.Description, userId);

        project.AddMember(userId, ProjectRole.Owner);
        await _projectRepository.CreateAsync(project);

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
