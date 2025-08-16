using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public int UserId =>
            int.Parse(_httpContextAccessor.HttpContext!.User.FindFirst("userId")!.Value);

        public string Email => _httpContextAccessor.HttpContext!.User.FindFirst("email")!.Value;

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated;
    }
}
