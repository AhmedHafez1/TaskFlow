using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.UseCases.Projects;

namespace TaskFlow.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly CreateProjectUseCase _createProjectUseCase;

        public ProjectsController(CreateProjectUseCase createProjectUseCase)
        {
            _createProjectUseCase = createProjectUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto dto)
        {
            var project = await _createProjectUseCase.ExecuteAsync(dto);
            return Ok(project);
        }
    }
}
