namespace TaskFlow.Application.DTOs
{
    public record ProjectSummaryDto(
        int Id,
        string Name,
        string Description,
        string Status,
        DateTimeOffset CreatedDate,
        DateTimeOffset? UpdatedDate,
        int OwnerId
    );
}
