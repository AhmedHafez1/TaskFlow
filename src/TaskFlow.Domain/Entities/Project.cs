using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class Project : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Active;
        public DateTimeOffset CompletedAt { get; set; }

        public int OwnerId { get; set; }
        public required User Owner { get; set; }
        public List<ProjectMember> Members { get; set; } = new();
        public List<TaskItem> TaskItems { get; set; } = new();

        public Project() { }

        public Project(string name, string description, int ownerId, User owner)
        {
            Name = name;
            Description = description;
            OwnerId = ownerId;
            Owner = owner;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public void Update(string name, string description) =>
            (Name, Description) = (name, description);

        public void Archive() => Status = ProjectStatus.Archived;

        public void Complete() => Status = ProjectStatus.Completed;

        public void AddMember(int memberId, int projectId, ProjectRole role)
        {
            if (Members.Any(m => m.MemberId == memberId))
                throw new ArgumentException("Member already exists in the project.");

            Members.Add(new ProjectMember(projectId, memberId, role));
        }

        public void RemoveMember(int memberId)
        {
            var member = Members.FirstOrDefault(m => m.MemberId == memberId);
            if (member != null)
                Members.Remove(member);
        }
    }
}
