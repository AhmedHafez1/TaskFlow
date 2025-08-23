using TaskFlow.Domain.Enums;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Application.DTOs.Task
{
    public record CreateTaskDto(
        string Title,
        string Description,
        DateTimeOffset DueDate,
        TaskPriority TaskPriority,
        int ProjectId,
        int? AssigneeId
    );
}
