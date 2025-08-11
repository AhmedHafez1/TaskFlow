using System.Security.Claims;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal? ValidateToken(string token);
        int GetUserId(string token);
    }
}
