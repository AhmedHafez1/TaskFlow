namespace TaskFlow.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public void Update(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);
    }
}
