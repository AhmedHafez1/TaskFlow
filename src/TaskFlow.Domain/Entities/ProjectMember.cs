using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public int MemberId { get; private set; }
        public User? Member { get; private set; }
        public int ProjectId { get; private set; }
        public Project? Project { get; private set; }
        public ProjectRole Role { get; private set; }

        public ProjectMember() { }

        public ProjectMember(int projectId, int memberId, ProjectRole role)
        {
            MemberId = memberId;
            ProjectId = projectId;
            Role = role;
        }

        public void Update(ProjectRole role) => Role = role;
    }
}
