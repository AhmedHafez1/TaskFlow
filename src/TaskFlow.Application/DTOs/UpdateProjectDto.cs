using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.DTOs
{
    public record UpdateProjectDto(string Name, string Description, ProjectStatus Status);
}
