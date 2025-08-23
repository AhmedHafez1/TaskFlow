using TaskFlow.Domain.Enums;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.DTOs.Task
{
    public record TaskDto(
        int Id,
        string Title,
        string Description,
        DateTimeOffset DueDate,
        TaskItemStatus Status,
        TaskPriority TaskPriority,
        int ProjectId,
        int? AssigneeId
    );
}
