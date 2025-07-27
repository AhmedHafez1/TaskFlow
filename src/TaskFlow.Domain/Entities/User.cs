namespace TaskFlow.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
