using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.UseCases.Authentication;

namespace TaskFlow.API.Controllers
{
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly LoginUserUseCase _loginUserUseCase;

        public AuthController(
            ILogger<AuthController> logger,
            IUserRepository userRepository,
            RegisterUserUseCase registerUserUseCase,
            LoginUserUseCase loginUserUseCase
        )
        {
            _logger = logger;
            _userRepository = userRepository;
            _registerUserUseCase = registerUserUseCase;
            _loginUserUseCase = loginUserUseCase;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResult>> Register(
            [FromBody] RegisterDto registerDto
        )
        {
            var authResult = await _registerUserUseCase.ExecuteAsync(registerDto);

            if (authResult.Success == false)
                return BadRequest(authResult);

            return Ok(authResult);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var authResult = _loginUserUseCase.ExecuteAsync(loginDto).Result;

            if (authResult.Success == false)
                return BadRequest(authResult);

            return Ok(authResult);
        }
    }
}
