namespace TaskFlow.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; protected set; }
        public DateTimeOffset UpdatedDate { get; protected set; }
    }
}
