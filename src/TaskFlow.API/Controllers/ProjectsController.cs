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
        private readonly UpdateProjectUseCase _updateProjectUseCase;

        public ProjectsController(
            CreateProjectUseCase createProjectUseCase,
            UpdateProjectUseCase updateProjectUseCase
        )
        {
            _createProjectUseCase = createProjectUseCase;
            _updateProjectUseCase = updateProjectUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto dto)
        {
            var project = await _createProjectUseCase.ExecuteAsync(dto);
            return Ok(project);
        }

        [HttpPut("{projectId:int}")]
        public async Task<ActionResult<ProjectDto>> UpdateProject(
            UpdateProjectDto dto,
            int projectId
        )
        {
            var project = await _updateProjectUseCase.ExecuteAsync(dto, projectId);
            return Ok(project);
        }
    }
}
