using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.DTOs
{
    public record ProjectMemberDto(int Id, string Name, string Email, ProjectRole Role);
}
