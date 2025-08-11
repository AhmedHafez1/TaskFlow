using Microsoft.AspNetCore.Authentication;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.UseCases.Authentication
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IJwtService _jwtService;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IPasswordHashingService passwordHashingService,
            IJwtService jwtService
        )
        {
            _userRepository = userRepository;
            _passwordHashingService = passwordHashingService;
            _jwtService = jwtService;
        }

        public async Task<AuthenticationResult> ExecuteAsync(RegisterDto registerDto)
        {
            // Check if the user already exists
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return new AuthenticationResult(false, null, "User already exists", null);
            }

            // Hash the password
            var hashedPassword = _passwordHashingService.HashPassword(registerDto.Password);

            // Create the user
            var user = new User(
                registerDto.FirstName,
                registerDto.LastName,
                registerDto.Email,
                hashedPassword
            );

            user.RecordLogin();
            await _userRepository.CreateAsync(user);

            // Generate JWT token
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
