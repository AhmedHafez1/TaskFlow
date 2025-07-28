namespace TaskFlow.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public int OwnerId { get; set; }
        public required User Owner { get; set; }

        public List<User> Members { get; set; } = new List<User>();
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    }
}
