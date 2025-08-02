using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public int MemberId { get; set; }
        public User? Member { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public ProjectRole Role { get; set; }

        public ProjectMember() { }

        public ProjectMember(int projectId, int memberId, ProjectRole role)
        {
            MemberId = memberId;
            ProjectId = projectId;
            Role = role;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public void Update(ProjectRole role) => Role = role;
    }
}
