using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.UseCases.Projects
{
    public class GetProjectsByOwnerUseCase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetProjectsByOwnerUseCase(
            IProjectRepository projectRepository,
            ICurrentUserService currentUserService
        )
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<List<ProjectDto>> ExcecuteAsync(int? id = null)
        {
            var ownerId = id ?? _currentUserService.UserId;

            return await _projectRepository
                .GetByOwnerIdAsync(ownerId)
                .Select(p => new ProjectDto(
                    p.Id,
                    p.Name,
                    p.Description!,
                    p.Status.ToString(),
                    p.CreatedDate,
                    p.UpdatedDate,
                    p.OwnerId,
                    p.TaskItems.Count,
                    p.TaskItems.Count(t => t.Status == TaskItemStatus.Done)
                ))
                .ToListAsync();
        }
    }
}
