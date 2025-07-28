namespace TaskFlow.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public List<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
        public List<TaskItem> AuthoredTasks { get; set; } = new List<TaskItem>();
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
