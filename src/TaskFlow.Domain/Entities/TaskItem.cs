using System.Diagnostics.CodeAnalysis;
using TaskFlow.Domain.Enums;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }

        public DateTimeOffset DueDate { get; private set; }
        public TaskItemStatus Status { get; private set; }
        public TaskPriority TaskPriority { get; private set; }

        public int? AssigneeId { get; private set; }
        public User? Assignee { get; private set; }
        public int AuthorId { get; private set; }
        public User? Author { get; private set; }
        public int ProjectId { get; private set; }
        public Project? Project { get; private set; }
        public List<TaskComment> TaskComments { get; private set; } = new();

        public TaskItem() { }

        [SetsRequiredMembers]
        public TaskItem(
            string title,
            string description,
            DateTimeOffset dueDate,
            TaskItemStatus status,
            TaskPriority taskPriority,
            int authorId,
            int projectId
        )
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            TaskPriority = taskPriority;
            AuthorId = authorId;
            ProjectId = projectId;
        }

        public void Update(
            string name,
            string description,
            DateTimeOffset dueDate,
            TaskItemStatus status,
            TaskPriority taskPriority
        ) =>
            (Title, Description, DueDate, Status, TaskPriority) = (
                name,
                description,
                dueDate,
                status,
                taskPriority
            );

        public void AssignTo(int assigneeId) => AssigneeId = assigneeId;

        public void StartProgress() => Status = TaskItemStatus.InProgress;

        public void Postpone() => Status = TaskItemStatus.Postponed;

        public void Complete() => Status = TaskItemStatus.Done;

        public void UnAssign() => AssigneeId = null;

        public void AddComment(string comment) =>
            TaskComments.Add(new TaskComment(comment, Id, AuthorId));

        public void RemoveComment(int commentId) =>
            TaskComments.Remove(TaskComments.First(c => c.Id == commentId));

        public bool IsOverdue() => DateTimeOffset.UtcNow > DueDate && Status != TaskItemStatus.Done;
    }
}
