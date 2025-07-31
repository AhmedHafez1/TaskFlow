namespace TaskFlow.Domain.Entities
{
    public class TaskComment : BaseEntity
    {
        public required string Comment { get; set; }
        public int TaskItemId { get; set; }
        public required TaskItem TaskItem { get; set; }
        public int AuthorId { get; set; }
        public required User Author { get; set; }
    }
}
