using System.Diagnostics.CodeAnalysis;

namespace TaskFlow.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset LastLogin { get; set; }

        public User() { }

        [SetsRequiredMembers]
        public User(string firstName, string lastName, string email, string passwordHash)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsActive = true;
            PasswordHash = passwordHash;
        }

        public string FullName => $"{FirstName} {LastName}";

        public void Update(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public void RecordLogin() => LastLogin = DateTimeOffset.UtcNow;

        public void Deactivate() => IsActive = false;

        public void Reactivate() => IsActive = true;
    }
}
