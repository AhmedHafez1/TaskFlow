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
        private readonly GetProjectsByOwnerUseCase _getProjectsByOwnerUseCase;

        public ProjectsController(
            CreateProjectUseCase createProjectUseCase,
            UpdateProjectUseCase updateProjectUseCase,
            GetAllProjectsUseCase getAllProjectsUseCase,
            GetProjectsByOwnerUseCase getProjectsByOwnerUseCase
        )
        {
            _createProjectUseCase = createProjectUseCase;
            _updateProjectUseCase = updateProjectUseCase;
            _getAllProjectsUseCase = getAllProjectsUseCase;
            _getProjectsByOwnerUseCase = getProjectsByOwnerUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _getAllProjectsUseCase.ExecuteAsync();
            return Ok(projects);
        }

        [HttpGet("mine")]
        public async Task<ActionResult<List<ProjectDto>>> GetMyOwenedProjects()
        {
            return Ok(await _getProjectsByOwnerUseCase.ExcecuteAsync());
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
