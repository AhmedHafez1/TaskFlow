namespace TaskFlow.Application.DTOs
{
    public record UserDto(
        string Id,
        string Email,
        string FirstName,
        string LastName,
        string FullName,
        DateTime CreatedDate,
        DateTimeOffset LastLogin
    );
}
