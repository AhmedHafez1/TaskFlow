namespace TaskFlow.Application.DTOs
{
    public record AuthenticationResult(
        bool Success,
        string? Token,
        string? ErrorMessage,
        UserDto? User
    );
}
