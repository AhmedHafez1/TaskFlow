using TaskFlow.Application.DTOs.Task;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.UseCases.Tasks
{
    public class CreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateTaskUseCase(
            ITaskRepository taskRepository,
            ICurrentUserService currentUserService
        )
        {
            _taskRepository = taskRepository;
            _currentUserService = currentUserService;
        }

        public async Task<TaskDto> ExecuteAsync(CreateTaskDto taskDto)
        {
            var authorId = _currentUserService.UserId;
            var task = new TaskItem(
                taskDto.Title,
                taskDto.Description,
                taskDto.DueDate,
                TaskItemStatus.ToDo,
                taskDto.TaskPriority,
                authorId,
                taskDto.ProjectId
            );

            await _taskRepository.CreateAsync(task);

            return new TaskDto(
                task.Id,
                task.Title,
                task.Description,
                task.DueDate,
                task.Status,
                task.TaskPriority,
                task.ProjectId,
                task.AssigneeId
            );
        }
    }
}
