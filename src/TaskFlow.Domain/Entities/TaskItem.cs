using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public DateTime DueDate { get; set; }
        public TaskItemStatus Status { get; set; }

        public int AssigneeId { get; set; }
        public required User Assignee { get; set; }
        public int AuthorId { get; set; }
        public required User Author { get; set; }
        public int ProjectId { get; set; }
        public required Project Project { get; set; }
    }
}
