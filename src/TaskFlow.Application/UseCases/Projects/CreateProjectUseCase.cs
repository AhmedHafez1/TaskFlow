using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.UseCases.Projects;

public class CreateProjectUseCase
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;

    public CreateProjectUseCase(
        IProjectRepository projectRepository,
        IUserRepository userRepository
    )
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
    }

    public async Task<ProjectDto> ExecuteAsync(CreateProjectDto dto, int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new InvalidOperationException("User not found.");

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
