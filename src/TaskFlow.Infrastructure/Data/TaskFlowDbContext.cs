using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;
using TaskFlow.Domain.ValueObjects;

namespace TaskFlow.Infrastructure.Data
{
    public class TaskFlowDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
            });

            // Cofigure Task Entity
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity
                    .HasOne(e => e.Project)
                    .WithMany(e => e.TaskItems)
                    .HasForeignKey(e => e.ProjectId);
                entity.HasOne(t => t.Assignee).WithMany().HasForeignKey(e => e.AssigneeId);
                entity.HasOne(t => t.Author).WithMany().HasForeignKey(e => e.AuthorId);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(400);
                entity
                    .Property(e => e.TaskPriority)
                    .HasConversion(v => (int)v, v => (TaskPriority)v);
                entity.Property(e => e.Status).HasConversion(v => (int)v, v => (TaskItemStatus)v);
                entity
                    .Property(e => e.DueDate)
                    .HasConversion(
                        v => v.UtcDateTime,
                        v => new DateTimeOffset(DateTime.SpecifyKind(v, DateTimeKind.Utc))
                    );
            });

            // Configure Project Entity
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(400);
                entity.Property(e => e.Status).HasConversion(v => (int)v, v => (ProjectStatus)v);
            });

            // Configure ProjectMember Entity
            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.MemberId });
                entity
                    .HasOne(e => e.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(e => e.ProjectId);
                entity.HasOne(e => e.Member).WithMany().HasForeignKey(e => e.MemberId);
                entity.HasIndex(e => new { e.ProjectId });
                entity.HasIndex(e => new { e.MemberId });
                entity.Property(e => e.Role).HasConversion(v => (int)v, v => (ProjectRole)v);
            });

            // Configure TaskComment Entity
            modelBuilder.Entity<TaskComment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity
                    .HasOne(e => e.TaskItem)
                    .WithMany(t => t.TaskComments)
                    .HasForeignKey(e => e.TaskItemId);
                entity.HasOne(e => e.Author).WithMany().HasForeignKey(e => e.AuthorId);
                entity.Property(e => e.Comment).HasMaxLength(400);
            });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
