using System.Diagnostics.CodeAnalysis;

namespace TaskFlow.Domain.Entities
{
    public class TaskComment : BaseEntity
    {
        public required string Comment { get; set; }
        public int TaskItemId { get; private set; }
        public TaskItem? TaskItem { get; private set; }
        public int AuthorId { get; private set; }
        public User? Author { get; private set; }

        public TaskComment() { }

        [SetsRequiredMembers]
        public TaskComment(string comment, int taskItemId, int authorId)
        {
            Comment = comment;
            TaskItemId = taskItemId;
            AuthorId = authorId;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public void Update(string comment) => Comment = comment;
    }
}
