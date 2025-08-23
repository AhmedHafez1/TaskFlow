using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.Task;
using TaskFlow.Application.UseCases.Tasks;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly CreateTaskUseCase _createTaskUseCase;

        public TasksController(CreateTaskUseCase createTaskUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskDto taskDto)
        {
            return await _createTaskUseCase.ExecuteAsync(taskDto);
        }
    }
}
