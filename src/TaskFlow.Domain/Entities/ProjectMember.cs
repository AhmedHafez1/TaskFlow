using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Domain.Entities
{
    public class ProjectMember : BaseEntity
    {
        public int MemberId { get; set; }
        public required User Member { get; set; }
        public int ProjectId { get; set; }
        public required Project Project { get; set; }
        public ProjectRole Role { get; set; }
        public DateTimeOffset JoinedAt { get; set; }
    }
}
