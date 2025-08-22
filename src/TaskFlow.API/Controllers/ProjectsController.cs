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
        private readonly GetAllProjectsUseCase _getAllProjectsUseCase;

        public ProjectsController(
            CreateProjectUseCase createProjectUseCase,
            UpdateProjectUseCase updateProjectUseCase,
            GetAllProjectsUseCase getAllProjectsUseCase
        )
        {
            _createProjectUseCase = createProjectUseCase;
            _updateProjectUseCase = updateProjectUseCase;
            _getAllProjectsUseCase = getAllProjectsUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _getAllProjectsUseCase.ExecuteAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto dto)
        {
            var project = await _createProjectUseCase.ExecuteAsync(dto);
            return Created("api/projects", project);
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
