namespace TaskFlow.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLogin { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, string passwordHash)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedDate = DateTimeOffset.UtcNow;
            IsActive = true;
            PasswordHash = passwordHash;
        }

        public void Update(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public void RecordLogin() => LastLogin = DateTimeOffset.UtcNow;

        public void Deactivate() => IsActive = false;

        public void Reactivate() => IsActive = true;
    }
}
