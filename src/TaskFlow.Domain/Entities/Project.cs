namespace TaskFlow.Domain.Entities
{
    public class Project : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public int OwnerId { get; set; }
        public required User Owner { get; set; }
        public List<ProjectMember> Members { get; set; } = new();
        public List<TaskItem> TaskItems { get; set; } = new();
    }
}
