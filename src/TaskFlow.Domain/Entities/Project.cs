using System.Diagnostics.CodeAnalysis;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class Project : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; private set; }
        public ProjectStatus Status { get; private set; } = ProjectStatus.Active;
        public DateTimeOffset CompletedAt { get; private set; }

        public int OwnerId { get; private set; }
        public User? Owner { get; private set; }
        public List<ProjectMember> ProjectMembers { get; private set; } = new();
        public List<TaskItem> TaskItems { get; private set; } = new();

        public Project() { }

        [SetsRequiredMembers]
        public Project(string name, string description, int ownerId)
        {
            Name = name;
            Description = description;
            OwnerId = ownerId;
        }

        public void Update(string name, string description, ProjectStatus status) =>
            (Name, Description, Status) = (name, description, status);

        public void Archive() => Status = ProjectStatus.Archived;

        public void Complete() => Status = ProjectStatus.Completed;

        public void AddMember(int memberId, ProjectRole role)
        {
            if (ProjectMembers.Any(m => m.MemberId == memberId))
                throw new ArgumentException("Member already exists in the project.");

            ProjectMembers.Add(new ProjectMember(Id, memberId, role));
        }

        public void RemoveMember(int memberId)
        {
            var member = ProjectMembers.FirstOrDefault(m => m.MemberId == memberId);
            if (member != null)
                ProjectMembers.Remove(member);
        }
    }
}
