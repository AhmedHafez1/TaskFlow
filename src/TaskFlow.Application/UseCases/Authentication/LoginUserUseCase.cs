using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Application.UseCases.Authentication
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHashingService _passwordHashingService;

        public LoginUserUseCase(
            IUserRepository userRepository,
            IJwtService jwtService,
            IPasswordHashingService passwordHashingService
        )
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHashingService = passwordHashingService;
        }

        public async Task<AuthenticationResult> ExecuteAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null)
                return new AuthenticationResult(false, null, "User not found", null);

            if (
                _passwordHashingService.VerifyPassword(loginDto.Password, user.PasswordHash)
                == false
            )
                return new AuthenticationResult(false, null, "Invalid password", null);

            user.RecordLogin();
            await _userRepository.UpdateAsync(user);

            var token = _jwtService.GenerateToken(user);

            var userDto = new UserDto(
                user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.FullName,
                user.CreatedDate,
                user.LastLogin
            );

            return new AuthenticationResult(true, token, null, userDto);
        }
    }
}
