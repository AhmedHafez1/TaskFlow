using System.Security.Claims;

namespace TaskFlow.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId);
        ClaimsPrincipal? ValidateToken(string token);
        int GetUserId(string token);
    }
}
