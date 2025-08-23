using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.DTOs
{
    public record ProjectDto(
        int Id,
        string Name,
        string Description,
        string Status,
        DateTimeOffset CreatedDate,
        DateTimeOffset? UpdatedDate,
        int OwnerId,
        int TaskCount,
        int CompletedTaskCount
    );
}
