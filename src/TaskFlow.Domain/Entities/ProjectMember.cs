using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class ProjectMember
    {
        public required string MemberId { get; set; }
        public required string ProjectId { get; set; }
        public ProjectRole Role { get; private set; }
        public DateTime JoinedAt { get; private set; }
    }
}
