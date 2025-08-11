namespace TaskFlow.Application.DTOs
{
    public record UserDto(
        int Id,
        string Email,
        string FirstName,
        string LastName,
        string FullName,
        DateTimeOffset CreatedDate,
        DateTimeOffset LastLogin
    );
}
